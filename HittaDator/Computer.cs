using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HittaDator
{

    public class Computer
    {
        [Bindable(false)]
        private Regex oldRoleRx = new Regex(@"[A-Z][a-z]{2}_Wrk_PR");
        [Bindable(false)]
        private Regex newRoleRx = new Regex(@"Sll_Wrk_[A-Z][a-z]{2}_PR");
        public Computer() { }
        public Computer(string computerName, bool multiThread = false)
        {
            if (multiThread)
            {
                if (GetComputerFromSysmanNoError(computerName))
                {
                    this.fkonto = FindFunkKonto(computerName);
                    searchSuccess = true;
                }
                else
                {
                    this.computerName = computerName;
                    searchSuccess = false;
                }
            }
            else
            {
                if (GetComputerFromSysman(computerName))
                {
                    this.fkonto = FindFunkKonto(computerName);
                    searchSuccess = true;
                }
                else
                {
                    this.computerName = computerName;
                    searchSuccess = false;
                }
            }
            
        }
        public bool searchSuccess { get; set; }
        public string computerName { get; set; }
        public string os { get; set; }
        public string model { get; set; }
        public string role { get; set; }
        public string serial { get; set; }
        public string macAdress { get; set; }
        public string macAdressColon { get; set; }
        public string latestHeartbeat { get; set; }
        public string fkonto { get; set; }
        public string deployementmall { get; set; }
        public string lastUser { get; set; }
        
        private string NetResponseToString(string uriString)
        {
            Uri uri = new Uri(uriString);
            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse webResponse = webRequest.GetResponse();
            Stream receiveStream = webResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(receiveStream, encode);
            Char[] read = new Char[256];

            int count = readStream.Read(read, 0, 256);
            string output = "";
            while (count > 0)
            {
                String Str = new String(read, 0, count);
                output += Str;
                count = readStream.Read(read, 0, 256);
            }
            readStream.Close();
            webResponse.Close();
            return output;
        }

        private SearchResultCollection FindADObjects(string adClass, string filter, string attributes = "distinguishedName")
        {
            DirectoryContext dc = new DirectoryContext(DirectoryContextType.Domain, "gaia");
            Domain dn = Domain.GetDomain(dc);
            DirectorySearcher ds = new DirectorySearcher(dn.GetDirectoryEntry(), $"(&(objectCategory={adClass}){filter})");
            ds.SearchScope = SearchScope.Subtree;
            ds.PageSize = 1024;
            ds.PropertiesToLoad.AddRange(attributes.Split(','));
            SearchResultCollection result = ds.FindAll();
            ds.Dispose();

            return result;
        }

        private string FindFunkKonto(string computerName)
        {
            try
            {
                SearchResultCollection resultCollection = FindADObjects("user", $"(userworkstations=*{computerName}*)(cn=F*)", "cn,userworkstations");
                if (resultCollection.Count > 0)
                {
                    return resultCollection[0].Properties["cn"][0].ToString();
                }
                else
                {
                    return "Nej";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString() + Environment.NewLine + "Kontakta pavel.kuzminov@regionstockholm.se vid frågor", "FEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool GetComputerFromSysmanNoError(string computerName)
        {
            try
            {
                IdLookup idLookup = JsonSerializer.Deserialize<IdLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Client?name=" + computerName + "&take=1&skip=0&type=0"));
                if (idLookup.result.Count > 0)
                {
                    PcLookup pcLookup = JsonSerializer.Deserialize<PcLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/client?id=" + idLookup.result[0].id + "&name=" + idLookup.result[0].name + "&assetTag=" + idLookup.result[0].name));
                    InfoLookup infoLookup = JsonSerializer.Deserialize<InfoLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Reporting/Client?clientId=" + idLookup.result[0].id));

                    this.computerName = pcLookup.name;
                    if (this.computerName == null || this.computerName.Trim() == "")
                    {
                        this.computerName = "Info saknas i SysMan";
                    }
                    this.serial = pcLookup.serialNumber;
                    if (this.serial == null || this.serial.Trim() == "")
                    {
                        this.serial = infoLookup.serial;
                    }
                    if (this.serial == null || this.serial.Trim() == "")
                    {
                        this.serial = "Info saknas i SysMan";
                    }
                    this.macAdressColon = pcLookup.macAddress;
                    if (this.macAdressColon == null || this.macAdressColon.Trim() == "")
                    {
                        this.macAdressColon = "Info saknas i SysMan";
                    }
                    this.macAdress = pcLookup.macAddress.Replace(":", "");
                    if (this.macAdress == null || this.macAdress.Trim() == "")
                    {
                        this.macAdress = "Info saknas i SysMan";
                    }
                    this.model = idLookup.result[0].hardwareModel.name;
                    if (this.model == null || this.model.Trim() == "")
                    {
                        this.model = "Info saknas i SysMan";
                    }
                    this.latestHeartbeat = infoLookup.latestHeartbeat;
                    if (this.latestHeartbeat == null || this.latestHeartbeat.Trim() == "")
                    {
                        this.latestHeartbeat = "Info saknas i SysMan";
                    }
                    this.os = infoLookup.operatingSystem;
                    if (this.os == null || this.os.Trim() == "")
                    {
                        this.os = "Info saknas i SysMan";
                    }
                    if (null != pcLookup.deployment.deploymentTemplate)
                    {
                        this.deployementmall = pcLookup.deployment.deploymentTemplate.name;
                    }
                    else
                    {
                        this.deployementmall = "Okänd";
                    }
                    if (infoLookup.collections.Where(r => oldRoleRx.IsMatch(r)).ToList().Count() > 0)
                    {
                        this.role = infoLookup.collections.Where(r => oldRoleRx.IsMatch(r)).ToList().First().Substring(11);
                    }
                    else if (infoLookup.installedApplications.Where(r => newRoleRx.IsMatch(r.name)).ToList().Count() > 0)
                    {
                        this.role = infoLookup.installedApplications.Where(r => newRoleRx.IsMatch(r.name)).ToList().First().name.Substring(15);
                    }
                    else
                    {
                        this.role = "Okänd";
                    }
                    if (this.role == "Okänd" || this.role == "Kiosk_PC")
                    {
                        if (infoLookup.collections.Where(f => f.StartsWith("Gai_App_CitrixReceiverVardTerminal")).ToList().Count() > 0 || infoLookup.installedApplications.Where(r => r.name == "Kar_Rol_Vardterminal-Kiosk").ToList().Count() > 0)
                        {
                            this.role = "Vårdterminal";
                        }
                    }
                    this.lastUser = GetUserFromSysMan(infoLookup.lastUser);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Dator " + this.computerName + " failade med felmeddelande:" + Environment.NewLine + e.ToString() + Environment.NewLine + "Kontakta pavel.kuzminov@regionstockholm.se vid frågor", "FEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool GetComputerFromSysman(string computerName)
        {
            try
            {
                IdLookup idLookup = JsonSerializer.Deserialize<IdLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Client?name=" + computerName + "&take=1&skip=0&type=0"));
                if (idLookup.result.Count > 0)
                {
                    PcLookup pcLookup = JsonSerializer.Deserialize<PcLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/client?id=" + idLookup.result[0].id + "&name=" + idLookup.result[0].name + "&assetTag=" + idLookup.result[0].name));
                    InfoLookup infoLookup = JsonSerializer.Deserialize<InfoLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Reporting/Client?clientId=" + idLookup.result[0].id));

                    this.computerName = pcLookup.name;
                    if (this.computerName == null || this.computerName.Trim() == "")
                    {
                        this.computerName = "Info saknas i SysMan";
                    }
                    this.serial = pcLookup.serialNumber;
                    if (this.serial== null || this.serial.Trim() == "")
                    {
                        this.serial = infoLookup.serial;
                    }
                    if (this.serial == null || this.serial.Trim() == "")
                    {
                        this.serial = "Info saknas i SysMan";
                    }
                    this.macAdressColon = pcLookup.macAddress;
                    if (this.macAdressColon == null || this.macAdressColon.Trim() == "")
                    {
                        this.macAdressColon = "Info saknas i SysMan";
                    }
                    this.macAdress = pcLookup.macAddress.Replace(":", "");
                    if (this.macAdress == null || this.macAdress.Trim() == "")
                    {
                        this.macAdress = "Info saknas i SysMan";
                    }
                    this.model = idLookup.result[0].hardwareModel.name;
                    if (this.model == null || this.model.Trim() == "")
                    {
                        this.model = "Info saknas i SysMan";
                    }
                    this.os = infoLookup.operatingSystem;
                    if (this.os == null || this.os.Trim() == "")
                    {
                        this.os = "Info saknas i SysMan";
                    }
                    if (null != pcLookup.deployment.deploymentTemplate)
                    {
                        this.deployementmall = pcLookup.deployment.deploymentTemplate.name;
                    }
                    else
                    {
                        this.deployementmall = "Okänd";
                    }
                    if (infoLookup.collections.Where(r => oldRoleRx.IsMatch(r)).ToList().Count() > 0)
                    {
                        this.role = infoLookup.collections.Where(r => oldRoleRx.IsMatch(r)).ToList().First().Substring(11);
                    }
                    else if (infoLookup.installedApplications.Where(r => newRoleRx.IsMatch(r.name)).ToList().Count() > 0)
                    {
                        this.role = infoLookup.installedApplications.Where(r => newRoleRx.IsMatch(r.name)).ToList().First().name.Substring(15);
                    }
                    else
                    {
                        this.role = "Okänd";
                    }
                    if (this.role == "Okänd" || this.role == "Kiosk_PC")
                    {
                        if (infoLookup.collections.Where(f => f.StartsWith("Gai_App_CitrixReceiverVardTerminal")).ToList().Count() > 0 || infoLookup.installedApplications.Where(r => r.name == "Kar_Rol_Vardterminal-Kiosk").ToList().Count() > 0)
                        {
                            this.role = "Vårdterminal";
                        }
                    }
                    return true;
                }
                else
                {
                    throw new Exception("Datorn: " + computerName + " kunde inte hittas i Sysman.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Dator " + this.computerName + " failade med felmeddelande:" + Environment.NewLine + e.ToString() + Environment.NewLine + "Kontakta pavel.kuzminov@regionstockholm.se vid frågor", "FEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private string GetUserFromSysMan(string hsaid)
        {
            try
            {
                UserLookup userLookup = JsonSerializer.Deserialize<UserLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/User?name=" + hsaid + "&take=1&skip=0&type=0&targetActive=1"));
                if (userLookup.result.Count > 0)
                {
                    return userLookup.result[0].displayName;
                }
                else
                {
                    return $"Användare {hsaid} hittades inte i SysMan";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Dator "+this.computerName+" failade med felmeddelande:"+ Environment.NewLine + e.ToString() + Environment.NewLine + "Kontakta pavel.kuzminov@regionstockholm.se vid frågor", "FEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return $"Användare {hsaid} hittades inte i SysMan";
            }
        }
    }
    public class UserLookup
    {
        public List<Result> result { get; set; }
        public int totalCount { get; set; }
        public Links links { get; set; }
    }
}

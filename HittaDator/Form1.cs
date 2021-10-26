using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HittaDator
{
    public partial class HittaDator : Form
    {
        static Regex pcRx = new Regex(@"\A[A-z]{5}\d{8}");
        static Regex macColonRx = new Regex(@"^[a-fA-F0-9]{2}(:[a-fA-F0-9]{2}){5}$");
        static Regex macRx = new Regex(@"^[a-fA-F0-9]{12}$");
        static Regex macDashRx = new Regex(@"^[a-fA-F0-9]{2}(-[a-fA-F0-9]{2}){5}$");
        public bool fileSelected = false;
        public ConcurrentQueue<Computer> outQueue = new ConcurrentQueue<Computer>();
        public Color green = Color.FromArgb(255, 87, 154, 64);
        public Color red = Color.FromArgb(255, 172, 36, 32);
        public Color blue = Color.FromArgb(255, 43, 112, 170);
        public Color yellow = Color.FromArgb(255, 178, 108, 9);

        public List<Computer> computers = new List<Computer>();

        public HittaDator(string[] arg)
        {
            InitializeComponent();
            InitializeTheme();
            if (arg.Count() > 0 && arg[0] == "ValmenyBoot")
            {
                using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
                {
                    if (rk.OpenSubKey("NekoPavel", true) != null)
                    {
                        openFileDialog.InitialDirectory = rk.OpenSubKey("NekoPavel", true).GetValue("SavePath").ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Programmet startades inte via valmenyn!" + Environment.NewLine + @"Använd valmenyn som finns under \\dfs\gem$\Lit\IT-Service\Fabriken Solna\Pavels Program", "Fel!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
                {
                    if (rk.OpenSubKey("NekoPavel", true) != null)
                    {
                        openFileDialog.InitialDirectory = rk.OpenSubKey("NekoPavel", true).GetValue("SavePath").ToString();
                    }
                    else
                    {
                        if (!WindowsIdentity.GetCurrent().Name.StartsWith("GAIA\\gaisys"))
                        {
                            MessageBox.Show("Programmet kördes inte som gaisys!" + Environment.NewLine + "Startar om", "Fel!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.WorkingDirectory = Environment.CurrentDirectory;
                            proc.FileName = "runas.exe";
                            proc.Arguments = $"/user:gaia\\gaisys{WindowsIdentity.GetCurrent().Name.Substring(5)} \"{Assembly.GetEntryAssembly().Location}\"";
                            Process.Start(proc);
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }
        private void InitializeTheme()
        {
            if (ThemeExists())
            {
                SetColours(OpenTheme(GetSelectedTheme()));
            }
        }

        private string GetSelectedTheme()
        {
            using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
            {
                return rk.OpenSubKey("NekoPavel", true).GetValue("ThemeName").ToString();
            }
        }

        private Color[] OpenTheme(string themeName)
        {
            using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
            {
                Color[] colours = {
                Color.FromArgb((int)rk.OpenSubKey($"NekoPavel\\{themeName}").GetValue("BackColour")),
                Color.FromArgb((int)rk.OpenSubKey($"NekoPavel\\{themeName}").GetValue("ForeColour")),
                Color.FromArgb((int)rk.OpenSubKey($"NekoPavel\\{themeName}").GetValue("TextColour"))
                };
                return colours;
            }
        }

        private bool ThemeExists()
        {
            using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
            {
                return (rk.OpenSubKey("NekoPavel", true) != null && rk.OpenSubKey("NekoPavel", true).GetValue("ThemeName") != null && rk.OpenSubKey("NekoPavel", true).OpenSubKey(rk.OpenSubKey("NekoPavel", true).GetValue("ThemeName").ToString()) != null);
            }
        }

        private void SetColours(Color[] colours)
        {
            foreach (var control in Controls)
            {
                ((Control)control).BackColor = colours[1];
                ((Control)control).ForeColor = colours[2];
            }
            foreach (var control in tableLayoutPanelMulti.Controls)
            {
                ((Control)control).BackColor = colours[1];
                ((Control)control).ForeColor = colours[2];
            }
            foreach (var control in tableLayoutPanelSingle.Controls.OfType<TextBox>())
            {
                ((Control)control).BackColor = colours[1];
                ((Control)control).ForeColor = colours[2];
            }
            foreach (var control in tableLayoutPanelSingle.Controls.OfType<Label>())
            {
                ((Control)control).BackColor = colours[0];
                ((Control)control).ForeColor = colours[2];
            }
            BackColor = colours[0];
            ForeColor = colours[2];
            mainLabel.BackColor = BackColor;
            tableLayoutPanelMulti.BackColor = BackColor;
            tableLayoutPanelSingle.BackColor = BackColor;
            openFileButton.BackColor = BackColor;
        }

        private void DisplayComputerInfo(Computer computer)
        {
            serialTbx.Text = computer.serial;
            roleTbx.Text = computer.role;
            modelTbx.Text = computer.model;
            pcnameTbx.Text = computer.computerName;
            macColonTbx.Text = computer.macAdressColon;
            macTbx.Text = computer.macAdress;
            fkontoTbx.Text = computer.fkonto;
            deployementTbx.Text = computer.deployementmall;
            osTbx.Text = computer.os;
        }

        private void hittaDatorBtn_Click(object sender, EventArgs e)
        {
            computers = new List<Computer>();
            if (fileSelected)
            {
                try
                {
                    hittaDatorBtn.Enabled = false;
                    openFileButton.Enabled = false;
                    datorNamnIn.Enabled = false;
                    UseWaitCursor = true;
                    progressBar.Value = 0;
                    progressBar.ProgressBarColor = blue;
                    DataSet result;
                    using (FileStream stream = File.Open(datorNamnIn.Text, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            result = reader.AsDataSet();
                        }
                    }
                    progressBar.Maximum = result.Tables[0].Rows.Count;
                    Task findPcTask = new Task(() => FindComputerTask(result.Tables[0]));
                    findPcTask.Start();
                    Task queueTask = new Task(() =>
                    {
                    try
                    {
                        while (!findPcTask.IsCompleted || outQueue.Count > 0)
                        {
                            if (outQueue.Count > 0)
                            {
                                Computer tempComputer = new Computer();
                                if (outQueue.TryDequeue(out tempComputer))
                                {
                                    if (tempComputer.searchSuccess)
                                    {
                                        computers.Add(tempComputer);
                                    }
                                    else
                                    {
                                        tempComputer.lastUser = "Dator hittades inte i SysMan";
                                        tempComputer.latestHeartbeat = "Info saknas i SysMan";
                                        computers.Add(tempComputer);
                                        WriteToTextbox($"Kunde inte hitta {tempComputer.computerName} i SysMan");
                                    }
                                    this.Invoke(new Action(() =>
                                    {
                                        progressBar.Value += 1;
                                    }));
                                }
                            }
                        }
                        this.Invoke(new Action(() =>
                        {
                            WriteToTextbox($"Kollat upp {computers.Count} datorer.");
                            Thread.Sleep(10);
                            DataTable pcTable = ToTable(computers);
                            while (saveFileDialog.ShowDialog() != DialogResult.OK)
                            {

                            }
                            pcTable.TableName = "Datorexport";
                            GenerateExcel(pcTable, saveFileDialog.FileName);
                                //Spara filen här
                                WriteToTextbox("Excelfil sparad!");

                            if (progressBar.ProgressBarColor == blue)
                            {
                                progressBar.ProgressBarColor = green;
                            }
                            hittaDatorBtn.Enabled = true;
                            openFileButton.Enabled = true;
                            datorNamnIn.Enabled = true;
                            UseWaitCursor = false;
                        }));

                    }
                    catch (Exception ex)
                    {
                            WriteToTextbox(ex.ToString());
                            progressBar.ProgressBarColor = red;
                        }

                    });
                    queueTask.Start();
                }
                catch (IOException)
                {
                    MessageBox.Show("Filen du försöker köra är öppen i ett annat program. Vänligen stäng filen i alla andra program!", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    hittaDatorBtn.Enabled = true;
                    openFileButton.Enabled = true;
                    datorNamnIn.Enabled = true;
                    UseWaitCursor = false;
                    progressBar.ProgressBarColor = red;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Välj en fil eller skriv ett datornamn!", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    hittaDatorBtn.Enabled = true;
                    openFileButton.Enabled = true;
                    datorNamnIn.Enabled = true;
                    UseWaitCursor = false;
                    progressBar.ProgressBarColor = red;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Fel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    hittaDatorBtn.Enabled = true;
                    openFileButton.Enabled = true;
                    datorNamnIn.Enabled = true;
                    UseWaitCursor = false;
                    progressBar.ProgressBarColor = red;
                }
            }
            else
            {
                if (pcRx.IsMatch(datorNamnIn.Text))
                {
                    Computer computer = new Computer(pcRx.Match(datorNamnIn.Text).ToString());
                    if (computer.searchSuccess)
                    {
                        DisplayComputerInfo(computer);
                        datorNamnIn.Clear();
                    }
                }
                else if (macColonRx.IsMatch(datorNamnIn.Text))
                {
                    Computer computer = new Computer(macColonRx.Match(datorNamnIn.Text).ToString());
                    if (computer.searchSuccess)
                    {
                        DisplayComputerInfo(computer);
                        datorNamnIn.Clear();
                    }
                }
                else if (macRx.IsMatch(datorNamnIn.Text))
                {
                    string tempMac = macRx.Match(datorNamnIn.Text).ToString();
                    tempMac = tempMac.Insert(2, ":");
                    tempMac = tempMac.Insert(5, ":");
                    tempMac = tempMac.Insert(8, ":");
                    tempMac = tempMac.Insert(11, ":");
                    tempMac = tempMac.Insert(14, ":");
                    Computer computer = new Computer(tempMac);
                    if (computer.searchSuccess)
                    {
                        DisplayComputerInfo(computer);
                        datorNamnIn.Clear();
                    }
                }
                else if (macDashRx.IsMatch(datorNamnIn.Text))
                {
                    Computer computer = new Computer(macDashRx.Match(datorNamnIn.Text).ToString().Replace('-', ':'));
                    if (computer.searchSuccess)
                    {
                        DisplayComputerInfo(computer);
                        datorNamnIn.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Datornamnet är i fel format!", "Felaktig Inmatning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void FormatAsTable(Excel.Range SourceRange, string TableName, string TableStyleName)
        {
            SourceRange.Worksheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange,
            SourceRange, Type.Missing, Excel.XlYesNoGuess.xlYes, Type.Missing).Name = TableName;
            SourceRange.Select();
            SourceRange.Worksheet.ListObjects[TableName].TableStyle = TableStyleName;
        }

        public void GenerateExcel(DataTable table, string path)
        {
            // create a excel app along side with workbook and worksheet and give a name to it  
            Excel.Application excelApp = new Excel.Application
            {
                Visible = false,
                DisplayAlerts = false
            };
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
            Excel._Worksheet xlWorksheet = excelWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            //Add a new worksheet to workbook with the Datatable name  
            Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
            excelWorkSheet.Name = table.TableName;

            // add all the columns  
            for (int i = 1; i < table.Columns.Count + 1; i++)
            {
                excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
            }

            // add all the rows  
            for (int j = 0; j < table.Rows.Count; j++)
            {
                for (int k = 0; k < table.Columns.Count; k++)
                {
                    excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                }
            }
            Excel.Range range = excelWorkSheet.Range["A1", $"K{table.Rows.Count + 1}"]; //ERSÄTT BOKSTAVEN MED WHATEVER SOM BEHÖVS!!!
            FormatAsTable(range, "datorer", "TableStyleMedium16");
            range.EntireColumn.AutoFit();

            excelWorkBook.SaveAs(path);
            excelWorkBook.Close();
            excelApp.Quit();
        }

        public DataTable ToTable(List<Computer> computers)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Datornamn", "".GetType());
            table.Columns.Add("Operativsystem", "".GetType());
            table.Columns.Add("Modell", "".GetType());
            table.Columns.Add("Roll", "".GetType());
            table.Columns.Add("Serienummer", "".GetType());
            table.Columns.Add("MAC-adress", "".GetType());
            table.Columns.Add("MAC med kolon", "".GetType());
            table.Columns.Add("Funktionskonto", "".GetType());
            table.Columns.Add("Deployementmall", "".GetType());
            table.Columns.Add("Senaste Heartbeat", "".GetType());
            table.Columns.Add("Senaste användare", "".GetType());
            foreach (Computer computer in computers)
            {
                DataRow row = table.NewRow();
                row["Datornamn"] = computer.computerName;
                row["Operativsystem"] = computer.os;
                row["Modell"] = computer.model;
                row["Roll"] = computer.role;
                row["Serienummer"] = computer.serial;
                row["MAC-adress"] = computer.macAdress;
                row["MAC med kolon"] = computer.macAdressColon;
                row["Funktionskonto"] = computer.fkonto;
                row["Deployementmall"] = computer.deployementmall;
                row["Senaste användare"] = computer.lastUser;
                if (computer.latestHeartbeat != "Info saknas i SysMan")
                {
                    row["Senaste Heartbeat"] = computer.latestHeartbeat.Replace('T',' ');
                }
                else
                {
                    row["Senaste Heartbeat"] = computer.latestHeartbeat;
                }
                
                table.Rows.Add(row);
            }
            return table;
        }

        public void FindComputerTask(DataTable dataTable)
        {
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 25
            };
            _ = Parallel.For(0, dataTable.Rows.Count, options, i =>
            {
                Computer computer = new Computer(dataTable.Rows[i][0].ToString(),true);
                outQueue.Enqueue(computer);
            });
        }

        public void WriteToTextbox(string input)
        {
            if (input != "")
            {
                this.Invoke(new Action(() =>
                {
                    outputTextbox.AppendText(input + Environment.NewLine);
                }));
            }
        }

        private void MouseLeaveBox(object sender, EventArgs e)
        {
            followText.Visible = false;
            followText.Text = "Klicka för att kopiera";
        }

        private void MouseMoveOver(object sender, MouseEventArgs e)
        {
            followText.Visible = true;
            followText.Location = PointToClient(Cursor.Position + new Size(15, 0));
        }

        private void ClickTextbox(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                Clipboard.SetText(((TextBox)sender).Text.ToString());
                followText.Text = "Kopierat";
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                datorNamnIn.Text = openFileDialog.FileName;
                fileSelected = true;
                saveFileDialog.InitialDirectory = openFileDialog.FileName.Substring(0, openFileDialog.FileName.Length - openFileDialog.SafeFileName.Length);
            }
            tableLayoutPanelSingle.Visible = false;
            tableLayoutPanelMulti.Visible = true;
            hittaDatorBtn.Text = "Kör";
            mainLabel.Text = "Filnamn:";
            datorNamnIn.Location = new Point(112, 15);
            datorNamnIn.Size = new Size(364, 31);
            datorNamnIn.Font = new Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void datorNamnIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (fileSelected)
            {
                fileSelected = false;
                datorNamnIn.Clear();
            }
            tableLayoutPanelSingle.Visible = true;
            tableLayoutPanelMulti.Visible = false;
            mainLabel.Text = "Datornamn/Mac:adress";
            hittaDatorBtn.Text = "Sök";
            datorNamnIn.Location = new Point(253, 9);
            datorNamnIn.Size = new Size(223, 31);
            datorNamnIn.Font = new Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }
    }
}

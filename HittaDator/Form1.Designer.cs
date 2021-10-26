
using System;

namespace HittaDator
{
    partial class HittaDator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HittaDator));
            this.mainLabel = new System.Windows.Forms.Label();
            this.datorNamnIn = new System.Windows.Forms.TextBox();
            this.hittaDatorBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanelSingle = new System.Windows.Forms.TableLayoutPanel();
            this.deployementTbx = new System.Windows.Forms.TextBox();
            this.fkontoTbx = new System.Windows.Forms.TextBox();
            this.serialTbx = new System.Windows.Forms.TextBox();
            this.macColonTbx = new System.Windows.Forms.TextBox();
            this.macTbx = new System.Windows.Forms.TextBox();
            this.pcnameTbx = new System.Windows.Forms.TextBox();
            this.roleTbx = new System.Windows.Forms.TextBox();
            this.modelTbx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.osTbx = new System.Windows.Forms.TextBox();
            this.followText = new System.Windows.Forms.Label();
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanelMulti = new System.Windows.Forms.TableLayoutPanel();
            this.outputTextbox = new System.Windows.Forms.TextBox();
            this.progressBar = new SmoothProgressBar.SmoothProgressBar();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanelSingle.SuspendLayout();
            this.tableLayoutPanelMulti.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.mainLabel.Location = new System.Drawing.Point(12, 11);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(235, 25);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "Datornamn/Mac:adress";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datorNamnIn
            // 
            this.datorNamnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.datorNamnIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.datorNamnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datorNamnIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.datorNamnIn.Location = new System.Drawing.Point(253, 9);
            this.datorNamnIn.Name = "datorNamnIn";
            this.datorNamnIn.Size = new System.Drawing.Size(223, 31);
            this.datorNamnIn.TabIndex = 1;
            this.datorNamnIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.datorNamnIn_KeyPress);
            // 
            // hittaDatorBtn
            // 
            this.hittaDatorBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.hittaDatorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hittaDatorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hittaDatorBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.hittaDatorBtn.Location = new System.Drawing.Point(482, 9);
            this.hittaDatorBtn.Name = "hittaDatorBtn";
            this.hittaDatorBtn.Size = new System.Drawing.Size(87, 31);
            this.hittaDatorBtn.TabIndex = 2;
            this.hittaDatorBtn.Text = "Sök";
            this.hittaDatorBtn.UseVisualStyleBackColor = false;
            this.hittaDatorBtn.Click += new System.EventHandler(this.hittaDatorBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Operativsystem:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelSingle
            // 
            this.tableLayoutPanelSingle.ColumnCount = 2;
            this.tableLayoutPanelSingle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.48276F));
            this.tableLayoutPanelSingle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.51724F));
            this.tableLayoutPanelSingle.Controls.Add(this.deployementTbx, 1, 8);
            this.tableLayoutPanelSingle.Controls.Add(this.fkontoTbx, 1, 7);
            this.tableLayoutPanelSingle.Controls.Add(this.serialTbx, 1, 6);
            this.tableLayoutPanelSingle.Controls.Add(this.macColonTbx, 1, 5);
            this.tableLayoutPanelSingle.Controls.Add(this.macTbx, 1, 4);
            this.tableLayoutPanelSingle.Controls.Add(this.pcnameTbx, 1, 3);
            this.tableLayoutPanelSingle.Controls.Add(this.roleTbx, 1, 2);
            this.tableLayoutPanelSingle.Controls.Add(this.modelTbx, 1, 1);
            this.tableLayoutPanelSingle.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanelSingle.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanelSingle.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanelSingle.Controls.Add(this.label8, 0, 6);
            this.tableLayoutPanelSingle.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanelSingle.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanelSingle.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanelSingle.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanelSingle.Controls.Add(this.label10, 0, 8);
            this.tableLayoutPanelSingle.Controls.Add(this.osTbx, 1, 0);
            this.tableLayoutPanelSingle.Location = new System.Drawing.Point(17, 62);
            this.tableLayoutPanelSingle.Name = "tableLayoutPanelSingle";
            this.tableLayoutPanelSingle.RowCount = 9;
            this.tableLayoutPanelSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelSingle.Size = new System.Drawing.Size(597, 310);
            this.tableLayoutPanelSingle.TabIndex = 4;
            // 
            // deployementTbx
            // 
            this.deployementTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.deployementTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deployementTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deployementTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.deployementTbx.Location = new System.Drawing.Point(208, 275);
            this.deployementTbx.Name = "deployementTbx";
            this.deployementTbx.ReadOnly = true;
            this.deployementTbx.Size = new System.Drawing.Size(386, 31);
            this.deployementTbx.TabIndex = 20;
            this.deployementTbx.Click += new System.EventHandler(this.ClickTextbox);
            this.deployementTbx.MouseLeave += new System.EventHandler(this.MouseLeaveBox);
            this.deployementTbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveOver);
            // 
            // fkontoTbx
            // 
            this.fkontoTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.fkontoTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fkontoTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fkontoTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.fkontoTbx.Location = new System.Drawing.Point(208, 241);
            this.fkontoTbx.Name = "fkontoTbx";
            this.fkontoTbx.ReadOnly = true;
            this.fkontoTbx.Size = new System.Drawing.Size(386, 31);
            this.fkontoTbx.TabIndex = 19;
            this.fkontoTbx.Click += new System.EventHandler(this.ClickTextbox);
            this.fkontoTbx.MouseLeave += new System.EventHandler(this.MouseLeaveBox);
            this.fkontoTbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveOver);
            // 
            // serialTbx
            // 
            this.serialTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.serialTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.serialTbx.Location = new System.Drawing.Point(208, 207);
            this.serialTbx.Name = "serialTbx";
            this.serialTbx.ReadOnly = true;
            this.serialTbx.Size = new System.Drawing.Size(386, 31);
            this.serialTbx.TabIndex = 18;
            this.serialTbx.Click += new System.EventHandler(this.ClickTextbox);
            this.serialTbx.MouseLeave += new System.EventHandler(this.MouseLeaveBox);
            this.serialTbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveOver);
            // 
            // macColonTbx
            // 
            this.macColonTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.macColonTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.macColonTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macColonTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.macColonTbx.Location = new System.Drawing.Point(208, 173);
            this.macColonTbx.Name = "macColonTbx";
            this.macColonTbx.ReadOnly = true;
            this.macColonTbx.Size = new System.Drawing.Size(386, 31);
            this.macColonTbx.TabIndex = 17;
            this.macColonTbx.Click += new System.EventHandler(this.ClickTextbox);
            this.macColonTbx.MouseLeave += new System.EventHandler(this.MouseLeaveBox);
            this.macColonTbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveOver);
            // 
            // macTbx
            // 
            this.macTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.macTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.macTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.macTbx.Location = new System.Drawing.Point(208, 139);
            this.macTbx.Name = "macTbx";
            this.macTbx.ReadOnly = true;
            this.macTbx.Size = new System.Drawing.Size(386, 31);
            this.macTbx.TabIndex = 16;
            this.macTbx.Click += new System.EventHandler(this.ClickTextbox);
            this.macTbx.MouseLeave += new System.EventHandler(this.MouseLeaveBox);
            this.macTbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveOver);
            // 
            // pcnameTbx
            // 
            this.pcnameTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pcnameTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcnameTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcnameTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pcnameTbx.Location = new System.Drawing.Point(208, 105);
            this.pcnameTbx.Name = "pcnameTbx";
            this.pcnameTbx.ReadOnly = true;
            this.pcnameTbx.Size = new System.Drawing.Size(386, 31);
            this.pcnameTbx.TabIndex = 15;
            this.pcnameTbx.Click += new System.EventHandler(this.ClickTextbox);
            this.pcnameTbx.MouseLeave += new System.EventHandler(this.MouseLeaveBox);
            this.pcnameTbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveOver);
            // 
            // roleTbx
            // 
            this.roleTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.roleTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roleTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.roleTbx.Location = new System.Drawing.Point(208, 71);
            this.roleTbx.Name = "roleTbx";
            this.roleTbx.ReadOnly = true;
            this.roleTbx.Size = new System.Drawing.Size(386, 31);
            this.roleTbx.TabIndex = 14;
            this.roleTbx.Click += new System.EventHandler(this.ClickTextbox);
            this.roleTbx.MouseLeave += new System.EventHandler(this.MouseLeaveBox);
            this.roleTbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveOver);
            // 
            // modelTbx
            // 
            this.modelTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.modelTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modelTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.modelTbx.Location = new System.Drawing.Point(208, 37);
            this.modelTbx.Name = "modelTbx";
            this.modelTbx.ReadOnly = true;
            this.modelTbx.Size = new System.Drawing.Size(386, 31);
            this.modelTbx.TabIndex = 13;
            this.modelTbx.Click += new System.EventHandler(this.ClickTextbox);
            this.modelTbx.MouseLeave += new System.EventHandler(this.MouseLeaveBox);
            this.modelTbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveOver);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "MAC-adress:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "MAC med kolon:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "Serienummer:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "Funktionskonto:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Modell:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Datornamn:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Roll:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 25);
            this.label10.TabIndex = 11;
            this.label10.Text = "Deployementmall:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // osTbx
            // 
            this.osTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.osTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.osTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.osTbx.Location = new System.Drawing.Point(208, 3);
            this.osTbx.Name = "osTbx";
            this.osTbx.ReadOnly = true;
            this.osTbx.Size = new System.Drawing.Size(386, 31);
            this.osTbx.TabIndex = 12;
            this.osTbx.Click += new System.EventHandler(this.ClickTextbox);
            this.osTbx.MouseLeave += new System.EventHandler(this.MouseLeaveBox);
            this.osTbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveOver);
            // 
            // followText
            // 
            this.followText.AutoSize = true;
            this.followText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.followText.Location = new System.Drawing.Point(25, 44);
            this.followText.Name = "followText";
            this.followText.Size = new System.Drawing.Size(106, 15);
            this.followText.TabIndex = 5;
            this.followText.Text = "Klicka för att kopiera";
            this.followText.Visible = false;
            // 
            // openFileButton
            // 
            this.openFileButton.BackgroundImage = global::HittaDator.Properties.Resources.icon;
            this.openFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.openFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openFileButton.FlatAppearance.BorderSize = 0;
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileButton.Location = new System.Drawing.Point(576, 9);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(31, 31);
            this.openFileButton.TabIndex = 6;
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel Sheet|*.xlsx";
            // 
            // tableLayoutPanelMulti
            // 
            this.tableLayoutPanelMulti.ColumnCount = 1;
            this.tableLayoutPanelMulti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMulti.Controls.Add(this.outputTextbox, 0, 1);
            this.tableLayoutPanelMulti.Controls.Add(this.progressBar, 0, 0);
            this.tableLayoutPanelMulti.Location = new System.Drawing.Point(17, 46);
            this.tableLayoutPanelMulti.Name = "tableLayoutPanelMulti";
            this.tableLayoutPanelMulti.RowCount = 2;
            this.tableLayoutPanelMulti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMulti.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMulti.Size = new System.Drawing.Size(597, 329);
            this.tableLayoutPanelMulti.TabIndex = 7;
            this.tableLayoutPanelMulti.Visible = false;
            // 
            // outputTextbox
            // 
            this.outputTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.outputTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.outputTextbox.Location = new System.Drawing.Point(3, 28);
            this.outputTextbox.Multiline = true;
            this.outputTextbox.Name = "outputTextbox";
            this.outputTextbox.ReadOnly = true;
            this.outputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextbox.Size = new System.Drawing.Size(591, 301);
            this.outputTextbox.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressBar.Location = new System.Drawing.Point(3, 3);
            this.progressBar.Maximum = 100;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressBarColor = System.Drawing.Color.Blue;
            this.progressBar.Size = new System.Drawing.Size(591, 19);
            this.progressBar.TabIndex = 2;
            this.progressBar.Value = 0;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xlsx";
            this.saveFileDialog.Filter = "Excel Sheet|*.xlsx";
            // 
            // HittaDator
            // 
            this.AcceptButton = this.hittaDatorBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(617, 384);
            this.Controls.Add(this.tableLayoutPanelMulti);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.followText);
            this.Controls.Add(this.tableLayoutPanelSingle);
            this.Controls.Add(this.hittaDatorBtn);
            this.Controls.Add(this.datorNamnIn);
            this.Controls.Add(this.mainLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HittaDator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HittaDator V4.0";
            this.tableLayoutPanelSingle.ResumeLayout(false);
            this.tableLayoutPanelSingle.PerformLayout();
            this.tableLayoutPanelMulti.ResumeLayout(false);
            this.tableLayoutPanelMulti.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.TextBox datorNamnIn;
        private System.Windows.Forms.Button hittaDatorBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSingle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox osTbx;
        private System.Windows.Forms.TextBox deployementTbx;
        private System.Windows.Forms.TextBox fkontoTbx;
        private System.Windows.Forms.TextBox serialTbx;
        private System.Windows.Forms.TextBox macColonTbx;
        private System.Windows.Forms.TextBox macTbx;
        private System.Windows.Forms.TextBox pcnameTbx;
        private System.Windows.Forms.TextBox roleTbx;
        private System.Windows.Forms.TextBox modelTbx;
        private System.Windows.Forms.Label followText;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMulti;
        //private NewProgressBar progressBar;
        private System.Windows.Forms.TextBox outputTextbox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private SmoothProgressBar.SmoothProgressBar progressBar;
    }
}


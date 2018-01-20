namespace FamilyConsole
{
    partial class FrmEdit
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtdieDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDieNow = new System.Windows.Forms.ComboBox();
            this.cbxsex = new System.Windows.Forms.ComboBox();
            this.txtnumage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOver = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtnumlifestory = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtnumaddress = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtnumjob = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNumNmae = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thiscloseNow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.添加帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.txttimeBirth = new FamilyConsole.UserDefine.DateTimeControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 101;
            this.label3.Text = "日期：2017/5/12";
            // 
            // txtdieDay
            // 
            this.txtdieDay.Location = new System.Drawing.Point(399, 111);
            this.txtdieDay.Name = "txtdieDay";
            this.txtdieDay.Size = new System.Drawing.Size(172, 21);
            this.txtdieDay.TabIndex = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 99;
            this.label4.Text = "死亡日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 98;
            this.label2.Text = "是否健在";
            // 
            // cbxDieNow
            // 
            this.cbxDieNow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDieNow.FormattingEnabled = true;
            this.cbxDieNow.Items.AddRange(new object[] {
            "健在",
            "仙逝"});
            this.cbxDieNow.Location = new System.Drawing.Point(76, 154);
            this.cbxDieNow.Name = "cbxDieNow";
            this.cbxDieNow.Size = new System.Drawing.Size(173, 20);
            this.cbxDieNow.TabIndex = 97;
            // 
            // cbxsex
            // 
            this.cbxsex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxsex.FormattingEnabled = true;
            this.cbxsex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbxsex.Location = new System.Drawing.Point(399, 37);
            this.cbxsex.Name = "cbxsex";
            this.cbxsex.Size = new System.Drawing.Size(172, 20);
            this.cbxsex.TabIndex = 95;
            // 
            // txtnumage
            // 
            this.txtnumage.Location = new System.Drawing.Point(399, 74);
            this.txtnumage.Name = "txtnumage";
            this.txtnumage.Size = new System.Drawing.Size(172, 21);
            this.txtnumage.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "年龄";
            // 
            // btnOver
            // 
            this.btnOver.Location = new System.Drawing.Point(361, 498);
            this.btnOver.Name = "btnOver";
            this.btnOver.Size = new System.Drawing.Size(210, 47);
            this.btnOver.TabIndex = 92;
            this.btnOver.Text = "取消";
            this.btnOver.UseVisualStyleBackColor = true;
            this.btnOver.Click += new System.EventHandler(this.btnOver_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(76, 498);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(210, 47);
            this.btnAdd.TabIndex = 90;
            this.btnAdd.Text = "确定";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtnumlifestory
            // 
            this.txtnumlifestory.Location = new System.Drawing.Point(76, 292);
            this.txtnumlifestory.Multiline = true;
            this.txtnumlifestory.Name = "txtnumlifestory";
            this.txtnumlifestory.Size = new System.Drawing.Size(495, 168);
            this.txtnumlifestory.TabIndex = 89;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 295);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 88;
            this.label19.Text = "生平事迹";
            // 
            // txtnumaddress
            // 
            this.txtnumaddress.Location = new System.Drawing.Point(76, 185);
            this.txtnumaddress.Multiline = true;
            this.txtnumaddress.Name = "txtnumaddress";
            this.txtnumaddress.Size = new System.Drawing.Size(495, 75);
            this.txtnumaddress.TabIndex = 87;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 188);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 86;
            this.label18.Text = "常住地址";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 114);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 85;
            this.label16.Text = "出生日期";
            // 
            // txtnumjob
            // 
            this.txtnumjob.Location = new System.Drawing.Point(77, 80);
            this.txtnumjob.Name = "txtnumjob";
            this.txtnumjob.Size = new System.Drawing.Size(172, 21);
            this.txtnumjob.TabIndex = 84;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(30, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 83;
            this.label15.Text = "职业";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(336, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 82;
            this.label13.Text = "性别";
            // 
            // txtNumNmae
            // 
            this.txtNumNmae.Location = new System.Drawing.Point(77, 37);
            this.txtNumNmae.Name = "txtNumNmae";
            this.txtNumNmae.Size = new System.Drawing.Size(172, 21);
            this.txtNumNmae.TabIndex = 81;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 80;
            this.label12.Text = "姓名";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thiscloseNow,
            this.tsmExit,
            this.添加帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 25);
            this.menuStrip1.TabIndex = 91;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thiscloseNow
            // 
            this.thiscloseNow.Name = "thiscloseNow";
            this.thiscloseNow.Size = new System.Drawing.Size(68, 21);
            this.thiscloseNow.Text = "返回菜单";
            this.thiscloseNow.Click += new System.EventHandler(this.thiscloseNow_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(68, 21);
            this.tsmExit.Text = "退出程序";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // 添加帮助ToolStripMenuItem
            // 
            this.添加帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addHelp});
            this.添加帮助ToolStripMenuItem.Name = "添加帮助ToolStripMenuItem";
            this.添加帮助ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.添加帮助ToolStripMenuItem.Text = "添加帮助";
            // 
            // addHelp
            // 
            this.addHelp.Name = "addHelp";
            this.addHelp.Size = new System.Drawing.Size(152, 22);
            this.addHelp.Text = "修改注意";
            this.addHelp.Click += new System.EventHandler(this.addHelp_Click);
            // 
            // txttimeBirth
            // 
            this.txttimeBirth.Location = new System.Drawing.Point(77, 114);
            this.txttimeBirth.Name = "txttimeBirth";
            this.txttimeBirth.Size = new System.Drawing.Size(231, 22);
            this.txttimeBirth.TabIndex = 96;
            // 
            // FrmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(625, 567);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdieDay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxDieNow);
            this.Controls.Add(this.txttimeBirth);
            this.Controls.Add(this.cbxsex);
            this.Controls.Add(this.txtnumage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOver);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtnumlifestory);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtnumaddress);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtnumjob);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtNumNmae);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmEdit";
            this.Text = "FrmEdit";
            this.Load += new System.EventHandler(this.FrmEdit_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdieDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDieNow;
        private UserDefine.DateTimeControl txttimeBirth;
        private System.Windows.Forms.ComboBox cbxsex;
        private System.Windows.Forms.TextBox txtnumage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOver;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtnumlifestory;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtnumaddress;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtnumjob;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNumNmae;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thiscloseNow;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem 添加帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addHelp;
    }
}
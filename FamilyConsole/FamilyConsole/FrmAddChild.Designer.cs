namespace FamilyConsole
{
    partial class FrmAddChild
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.返回菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日期规则ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpOne = new FamilyConsole.UserDefine.DateTimeControl();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNumNmae = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtnumjob = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtnumaddress = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtnumlifestory = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtfather = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtmother = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSexName = new System.Windows.Forms.ComboBox();
            this.txtDieDay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxIsDie = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.返回菜单ToolStripMenuItem,
            this.添加帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(578, 25);
            this.menuStrip1.TabIndex = 63;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 返回菜单ToolStripMenuItem
            // 
            this.返回菜单ToolStripMenuItem.Name = "返回菜单ToolStripMenuItem";
            this.返回菜单ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.返回菜单ToolStripMenuItem.Text = "返回菜单";
            this.返回菜单ToolStripMenuItem.Click += new System.EventHandler(this.返回菜单ToolStripMenuItem_Click);
            // 
            // 添加帮助ToolStripMenuItem
            // 
            this.添加帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.日期规则ToolStripMenuItem});
            this.添加帮助ToolStripMenuItem.Name = "添加帮助ToolStripMenuItem";
            this.添加帮助ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.添加帮助ToolStripMenuItem.Text = "添加帮助";
            // 
            // 日期规则ToolStripMenuItem
            // 
            this.日期规则ToolStripMenuItem.Name = "日期规则ToolStripMenuItem";
            this.日期规则ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.日期规则ToolStripMenuItem.Text = "日期规则";
            this.日期规则ToolStripMenuItem.Click += new System.EventHandler(this.日期规则ToolStripMenuItem_Click);
            // 
            // dtpOne
            // 
            this.dtpOne.Location = new System.Drawing.Point(91, 156);
            this.dtpOne.Name = "dtpOne";
            this.dtpOne.Size = new System.Drawing.Size(225, 22);
            this.dtpOne.TabIndex = 64;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "姓名：";
            // 
            // txtNumNmae
            // 
            this.txtNumNmae.Location = new System.Drawing.Point(91, 79);
            this.txtNumNmae.Name = "txtNumNmae";
            this.txtNumNmae.Size = new System.Drawing.Size(166, 21);
            this.txtNumNmae.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(319, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 29;
            this.label13.Text = "性别";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(44, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "职业";
            // 
            // txtnumjob
            // 
            this.txtnumjob.Location = new System.Drawing.Point(91, 116);
            this.txtnumjob.Name = "txtnumjob";
            this.txtnumjob.Size = new System.Drawing.Size(166, 21);
            this.txtnumjob.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 156);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 35;
            this.label16.Text = "出生日期";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 200);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 39;
            this.label18.Text = "常住地址";
            // 
            // txtnumaddress
            // 
            this.txtnumaddress.Location = new System.Drawing.Point(91, 197);
            this.txtnumaddress.Multiline = true;
            this.txtnumaddress.Name = "txtnumaddress";
            this.txtnumaddress.Size = new System.Drawing.Size(467, 51);
            this.txtnumaddress.TabIndex = 40;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 262);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 41;
            this.label19.Text = "生平事迹";
            // 
            // txtnumlifestory
            // 
            this.txtnumlifestory.Location = new System.Drawing.Point(91, 262);
            this.txtnumlifestory.Multiline = true;
            this.txtnumlifestory.Name = "txtnumlifestory";
            this.txtnumlifestory.Size = new System.Drawing.Size(467, 108);
            this.txtnumlifestory.TabIndex = 42;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(321, 44);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 43;
            this.label20.Text = "父亲";
            // 
            // txtfather
            // 
            this.txtfather.Location = new System.Drawing.Point(384, 41);
            this.txtfather.Name = "txtfather";
            this.txtfather.Size = new System.Drawing.Size(172, 21);
            this.txtfather.TabIndex = 44;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(44, 41);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 45;
            this.label21.Text = "母亲";
            // 
            // txtmother
            // 
            this.txtmother.Location = new System.Drawing.Point(91, 41);
            this.txtmother.Name = "txtmother";
            this.txtmother.Size = new System.Drawing.Size(166, 21);
            this.txtmother.TabIndex = 46;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(91, 414);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(225, 39);
            this.btnAdd.TabIndex = 51;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOver
            // 
            this.btnOver.Location = new System.Drawing.Point(346, 414);
            this.btnOver.Name = "btnOver";
            this.btnOver.Size = new System.Drawing.Size(210, 39);
            this.btnOver.TabIndex = 52;
            this.btnOver.Text = "取消";
            this.btnOver.UseVisualStyleBackColor = true;
            this.btnOver.Click += new System.EventHandler(this.btnOver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "死亡日期";
            // 
            // cbxSexName
            // 
            this.cbxSexName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSexName.FormattingEnabled = true;
            this.cbxSexName.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbxSexName.Location = new System.Drawing.Point(384, 79);
            this.cbxSexName.Name = "cbxSexName";
            this.cbxSexName.Size = new System.Drawing.Size(172, 20);
            this.cbxSexName.TabIndex = 57;
            // 
            // txtDieDay
            // 
            this.txtDieDay.Location = new System.Drawing.Point(386, 153);
            this.txtDieDay.Name = "txtDieDay";
            this.txtDieDay.Size = new System.Drawing.Size(172, 21);
            this.txtDieDay.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 12);
            this.label3.TabIndex = 60;
            this.label3.Text = "日期：2017-5-12 或 2017/5/12";
            // 
            // cbxIsDie
            // 
            this.cbxIsDie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIsDie.FormattingEnabled = true;
            this.cbxIsDie.Items.AddRange(new object[] {
            "健在",
            "仙逝"});
            this.cbxIsDie.Location = new System.Drawing.Point(386, 116);
            this.cbxIsDie.Name = "cbxIsDie";
            this.cbxIsDie.Size = new System.Drawing.Size(170, 20);
            this.cbxIsDie.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "是否健在";
            // 
            // FrmAddChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(578, 503);
            this.Controls.Add(this.dtpOne);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxIsDie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDieDay);
            this.Controls.Add(this.cbxSexName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOver);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtmother);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtfather);
            this.Controls.Add(this.label20);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmAddChild";
            this.Text = "FrmPersonInfo";
            this.Load += new System.EventHandler(this.FrmPersonInfo_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 返回菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日期规则ToolStripMenuItem;
        private UserDefine.DateTimeControl dtpOne;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNumNmae;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtnumjob;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtnumaddress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtnumlifestory;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtfather;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtmother;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnOver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxSexName;
        private System.Windows.Forms.TextBox txtDieDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxIsDie;
        private System.Windows.Forms.Label label4;
    }
}
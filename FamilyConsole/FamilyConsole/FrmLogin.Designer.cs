namespace FamilyConsole
{
    partial class FrmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle_One_Id = new System.Windows.Forms.Label();
            this.lblTitle_two_pwd = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtUserpassword = new System.Windows.Forms.TextBox();
            this.btnUserLogin = new System.Windows.Forms.Button();
            this.rbtgonverment = new System.Windows.Forms.RadioButton();
            this.rbtUser = new System.Windows.Forms.RadioButton();
            this.CmsLogin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAllCmsLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.showCmsLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.hiddenCmsLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.helpAllCmsLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllCmsLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle_One_Id
            // 
            this.lblTitle_One_Id.AutoSize = true;
            this.lblTitle_One_Id.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle_One_Id.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle_One_Id.Location = new System.Drawing.Point(122, 197);
            this.lblTitle_One_Id.Name = "lblTitle_One_Id";
            this.lblTitle_One_Id.Size = new System.Drawing.Size(40, 16);
            this.lblTitle_One_Id.TabIndex = 0;
            this.lblTitle_One_Id.Text = "账号";
            // 
            // lblTitle_two_pwd
            // 
            this.lblTitle_two_pwd.AutoSize = true;
            this.lblTitle_two_pwd.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle_two_pwd.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle_two_pwd.Location = new System.Drawing.Point(122, 238);
            this.lblTitle_two_pwd.Name = "lblTitle_two_pwd";
            this.lblTitle_two_pwd.Size = new System.Drawing.Size(40, 16);
            this.lblTitle_two_pwd.TabIndex = 1;
            this.lblTitle_two_pwd.Text = "密码";
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserID.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserID.Location = new System.Drawing.Point(188, 197);
            this.txtUserID.Multiline = true;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(210, 25);
            this.txtUserID.TabIndex = 2;
            // 
            // txtUserpassword
            // 
            this.txtUserpassword.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserpassword.Location = new System.Drawing.Point(188, 233);
            this.txtUserpassword.Multiline = true;
            this.txtUserpassword.Name = "txtUserpassword";
            this.txtUserpassword.PasswordChar = '*';
            this.txtUserpassword.Size = new System.Drawing.Size(210, 25);
            this.txtUserpassword.TabIndex = 3;
            // 
            // btnUserLogin
            // 
            this.btnUserLogin.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnUserLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserLogin.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUserLogin.Location = new System.Drawing.Point(188, 318);
            this.btnUserLogin.Name = "btnUserLogin";
            this.btnUserLogin.Size = new System.Drawing.Size(210, 34);
            this.btnUserLogin.TabIndex = 4;
            this.btnUserLogin.Text = "登录";
            this.btnUserLogin.UseVisualStyleBackColor = false;
            this.btnUserLogin.Click += new System.EventHandler(this.btnUserLogin_Click);
            // 
            // rbtgonverment
            // 
            this.rbtgonverment.AutoSize = true;
            this.rbtgonverment.BackColor = System.Drawing.Color.Transparent;
            this.rbtgonverment.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtgonverment.Location = new System.Drawing.Point(188, 286);
            this.rbtgonverment.Name = "rbtgonverment";
            this.rbtgonverment.Size = new System.Drawing.Size(59, 16);
            this.rbtgonverment.TabIndex = 5;
            this.rbtgonverment.TabStop = true;
            this.rbtgonverment.Text = "管理员";
            this.rbtgonverment.UseVisualStyleBackColor = false;
            // 
            // rbtUser
            // 
            this.rbtUser.AutoSize = true;
            this.rbtUser.BackColor = System.Drawing.Color.Transparent;
            this.rbtUser.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtUser.ForeColor = System.Drawing.Color.Black;
            this.rbtUser.Location = new System.Drawing.Point(290, 286);
            this.rbtUser.Name = "rbtUser";
            this.rbtUser.Size = new System.Drawing.Size(71, 16);
            this.rbtUser.TabIndex = 6;
            this.rbtUser.TabStop = true;
            this.rbtUser.Text = "普通用户";
            this.rbtUser.UseVisualStyleBackColor = false;
            // 
            // CmsLogin
            // 
            this.CmsLogin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAllCmsLogin,
            this.helpAllCmsLogin,
            this.closeAllCmsLogin});
            this.CmsLogin.Name = "CmsLogin";
            this.CmsLogin.Size = new System.Drawing.Size(125, 70);
            // 
            // setAllCmsLogin
            // 
            this.setAllCmsLogin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCmsLogin,
            this.hiddenCmsLogin});
            this.setAllCmsLogin.Name = "setAllCmsLogin";
            this.setAllCmsLogin.Size = new System.Drawing.Size(124, 22);
            this.setAllCmsLogin.Text = "设置";
            // 
            // showCmsLogin
            // 
            this.showCmsLogin.Name = "showCmsLogin";
            this.showCmsLogin.Size = new System.Drawing.Size(124, 22);
            this.showCmsLogin.Text = "显示密码";
            this.showCmsLogin.Click += new System.EventHandler(this.showCmsLogin_Click);
            // 
            // hiddenCmsLogin
            // 
            this.hiddenCmsLogin.Name = "hiddenCmsLogin";
            this.hiddenCmsLogin.Size = new System.Drawing.Size(124, 22);
            this.hiddenCmsLogin.Text = "遮盖密码";
            this.hiddenCmsLogin.Click += new System.EventHandler(this.hiddenCmsLogin_Click);
            // 
            // helpAllCmsLogin
            // 
            this.helpAllCmsLogin.Name = "helpAllCmsLogin";
            this.helpAllCmsLogin.Size = new System.Drawing.Size(124, 22);
            this.helpAllCmsLogin.Text = "帮助文档";
            this.helpAllCmsLogin.Click += new System.EventHandler(this.helpAllCmsLogin_Click);
            // 
            // closeAllCmsLogin
            // 
            this.closeAllCmsLogin.Name = "closeAllCmsLogin";
            this.closeAllCmsLogin.Size = new System.Drawing.Size(124, 22);
            this.closeAllCmsLogin.Text = "退出";
            this.closeAllCmsLogin.Click += new System.EventHandler(this.closeAllCmsLogin_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::FamilyConsole.Properties.Resources.timgLoginTwo;
            this.ClientSize = new System.Drawing.Size(871, 609);
            this.ContextMenuStrip = this.CmsLogin;
            this.Controls.Add(this.rbtUser);
            this.Controls.Add(this.rbtgonverment);
            this.Controls.Add(this.btnUserLogin);
            this.Controls.Add(this.txtUserpassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lblTitle_two_pwd);
            this.Controls.Add(this.lblTitle_One_Id);
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "家谱管理登录界面";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.CmsLogin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle_One_Id;
        private System.Windows.Forms.Label lblTitle_two_pwd;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtUserpassword;
        private System.Windows.Forms.Button btnUserLogin;
        private System.Windows.Forms.RadioButton rbtgonverment;
        private System.Windows.Forms.RadioButton rbtUser;
        private System.Windows.Forms.ContextMenuStrip CmsLogin;
        private System.Windows.Forms.ToolStripMenuItem helpAllCmsLogin;
        private System.Windows.Forms.ToolStripMenuItem closeAllCmsLogin;
        private System.Windows.Forms.ToolStripMenuItem setAllCmsLogin;
        private System.Windows.Forms.ToolStripMenuItem showCmsLogin;
        private System.Windows.Forms.ToolStripMenuItem hiddenCmsLogin;

    }
}


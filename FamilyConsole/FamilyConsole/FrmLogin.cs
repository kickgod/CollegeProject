using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyConsole
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void closeAllCmsLogin_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("你确定关闭程序吗？", "关闭", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }          
        }
        private void helpAllCmsLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("管理员请输入的账号！账号为你的出生年月！密码默认：也为你的身份证号码！\n 例如：账号：19780915 密码：5116515998023231231","登录说明！");
        }

        private void showCmsLogin_Click(object sender, EventArgs e)
        {
            this.txtUserpassword.PasswordChar = '\0';
        }

        private void hiddenCmsLogin_Click(object sender, EventArgs e)
        {
            this.txtUserpassword.PasswordChar = '*';
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("请填写账号");
                return;
            }
            if (txtUserpassword.Text == "")
            {
                MessageBox.Show("请填写密码");
                return;              
            }
            if (rbtgonverment.Checked == false && rbtUser.Checked == false)
            {
                MessageBox.Show("请选择登录类型", "提示");
                return;
            }
            if (rbtgonverment.Checked)
            {
                UserConnection con=new UserConnection();
                int result = con.CheckIsGoverment(txtUserID.Text, txtUserpassword.Text);
                if (result == 0)
                {
                    MessageBox.Show("暂未拥有此权限--非管理员", "提示");
                    return;
                }
                else if (result == -1)
                {
                    MessageBox.Show("账号密码错误", "提示");
                    return;
                }
                else if (result == 1)
                {
                    this.Close();
                    new System.Threading.Thread(() =>
                    {
                        FrmOperator one = new FrmOperator();
                        one.IsCan = 30;
                        Application.Run(one);
                    }).Start();
                }                
            }
            if (rbtUser.Checked)
            {
                UserConnection con = new UserConnection();
                int result = con.CheckIsUser(txtUserID.Text, txtUserpassword.Text);
                if (result == 0)
                {
                    MessageBox.Show("暂未拥有此权限--非普通用户", "提示");
                    return;
                }
                else if (result == -1)
                {
                    MessageBox.Show("账号密码错误", "提示");
                    return;
                }
                else if (result == 1)
                {
                    this.Close();
                    new System.Threading.Thread(() =>
                    {
                        FrmOperator one =new FrmOperator();
                        one.IsCan = 20;
                        Application.Run(one);
                    }).Start();
                }                 
            }


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserID.Focus();
        }
    }
}

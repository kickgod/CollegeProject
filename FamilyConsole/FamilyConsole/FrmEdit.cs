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
    public partial class FrmEdit : Form
    {
        public int GetID;
        public int PeiOuSex;
        public int ShowORAdd;
        public FrmEdit()
        {
            InitializeComponent();
        }
        private void changeNull()
        {
            txtNumNmae.Text = "";
            txtnumjob.Text = "";
            txtnumaddress.Text = "";
            txtnumlifestory.Text = "";
        }

        private void EnableFalse()
        {
            cbxsex.Enabled = false;
            cbxDieNow.Enabled = false;
            txtnumage.Enabled = false;
        }
        private void EnableTrue()
        {
            txtNumNmae.Enabled = true;
            txtnumjob.Enabled = true;
            txtnumaddress.Enabled = true;
            txtnumlifestory.Enabled = true;
        }
        private void thiscloseNow_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("你要返回菜单吗？", "关闭", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("你确定关闭程序吗？", "关闭", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }   
        }

        private void FrmEdit_Load(object sender, EventArgs e)
        {
                this.Text = "配偶信息";
                dbtblNumberInfo info = new dbtblNumberInfo();
                DataTable td = info.GetPeiOuInfo(this.GetID);
                if (PeiOuSex == 0)
                {
                    cbxsex.Text = "男";
                }
                else
                {
                    cbxsex.Text = "女";
                }
                txtnumjob.Text = td.Rows[0]["工作"].ToString();
                txtNumNmae.Text = td.Rows[0]["姓名"].ToString();
                txttimeBirth.Text = td.Rows[0]["出生日期"].ToString();
                txtdieDay.Text = td.Rows[0]["NiDIeDay"].ToString();
                txtnumaddress.Text = td.Rows[0]["NiAddress"].ToString();
                txtnumlifestory.Text = td.Rows[0]["NiLifeStory"].ToString();
                txtnumage.Text = td.Rows[0]["年龄"].ToString();
                cbxDieNow.Text = td.Rows[0]["状态"].ToString();
                EnableFalse();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNumNmae.Text == "")
            {
                MessageBox.Show("请输入名称", "提示");
                return;
            }
            if (txtnumjob.Text == "")
            {
                MessageBox.Show("请输入职业", "提示");
                return;
            }
            if (txtnumaddress.Text == "")
            {
                MessageBox.Show("请输入常住地址", "提示");
                return;
            }
            if (txtnumlifestory.Text == "")
            {
                MessageBox.Show("请输入生平事迹", "提示");
                return;
            }
            if (txttimeBirth.Text == "")
            {
                MessageBox.Show("请输入出生日期", "提示");
                return;
            }

            if (!ValueJudge.IsDateTime(txttimeBirth.Text))
            {
                MessageBox.Show("请输入正确格式的出生日期", "提示");
                return;
            }
            DateTime one = new DateTime();
            if (txtdieDay.Text != "")
            {
                if (!ValueJudge.IsDateTime(txtdieDay.Text))
                {
                    MessageBox.Show("请输入正确格式的死亡日期", "提示");
                    return;
                }
                one = Convert.ToDateTime(txttimeBirth.Text);
                DateTime tcTwo = Convert.ToDateTime(txtdieDay.Text);
                if (tcTwo <= one)
                {
                    MessageBox.Show("日期错误！死亡日期与出生日期不符合常理", "警告");
                    return;
                }
            }
            string sql =
                String.Format("update Family.dbo.tblNumberInfo set  [JobID]='{0}' ,NiName ='{1}' ,[NiBirthDay] ='{2}',NiDIeDay='{3}' ,NiAddress='{4}',[NiLifeStory]='{5}' where NiSpouseId ={6}",
                    txtnumjob.Text, txtNumNmae.Text, txttimeBirth.Text, txtdieDay.Text, txtnumaddress.Text, txtnumlifestory.Text, GetID
                );
            if (txtdieDay.Text != "")
            {
                sql =
                    String.Format("update Family.dbo.tblNumberInfo set  [JobID]='{0}' ,NiName ='{1}' ,[NiBirthDay] ='{2}',NiDIeDay='{3}' ,NiAddress='{4}',[NiLifeStory]='{5}' , Nistate =40  where NiSpouseId ={6}",
                        txtnumjob.Text, txtNumNmae.Text, txttimeBirth.Text, txtdieDay.Text, txtnumaddress.Text, txtnumlifestory.Text, GetID
                    );
            }
            dbConnection db = new dbvwNumberInfo();
            db.CarryOutSqlSentence(sql);
            MessageBox.Show("修改成功", "成功");
            EnableFalse();
        }

        private void btnOver_Click(object sender, EventArgs e)
        {
            changeNull();
        }

        private void addHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("注意修改日期问题\n 1.出生不要大于死亡日期", "成功");
        }
    }
}

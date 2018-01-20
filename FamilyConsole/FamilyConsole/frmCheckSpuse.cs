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
    public partial class frmCheckSpuse : Form
    {
        public int GetID;
        public int PeiOuSex;
        public int ShowORAdd;
        //1 是添加 2是展示
        public frmCheckSpuse()
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
            txtNumNmae.Enabled = false;
            txtnumjob.Enabled = false;
            txtnumaddress.Enabled = false;
            txtnumlifestory.Enabled = false;
            txtnumage.Enabled = false;
        }
        private void EnableTrue()
        {
            txtNumNmae.Enabled = true;
            txtnumjob.Enabled = true;
            txtnumaddress.Enabled = true;
            txtnumlifestory.Enabled = true;
        }
        private void frmCheckSpuse_Load(object sender, EventArgs e)
        {
            if (ShowORAdd == 2)
            {
                this.Text = "配偶信息";
                dbtblNumberInfo info =new dbtblNumberInfo();
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
                dtpOne.Text = td.Rows[0]["出生日期"].ToString();
                txtDieDay.Text = td.Rows[0]["NiDIeDay"].ToString();
                txtnumaddress.Text = td.Rows[0]["NiAddress"].ToString();
                txtnumlifestory.Text = td.Rows[0]["NiLifeStory"].ToString();
                txtnumage.Text = td.Rows[0]["年龄"].ToString();
                cbxDieNow.Text = td.Rows[0]["状态"].ToString();
                btnAdd.Visible = false;
                btnOver.Visible = false;
                EnableFalse();
            }else if (ShowORAdd == 1)
            {
                this.Text = "添加配偶";
                txtnumage.Enabled = false;
                cbxsex.SelectedIndex = PeiOuSex;
                cbxsex.Enabled = false;
            }
        }

        private void btnOver_Click(object sender, EventArgs e)
        {
            changeNull();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
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
                if (dtpOne.IsNull())
                {
                    MessageBox.Show("请输入出生日期", "提示");
                    return;                 
                }
                DateTime dtlast=new DateTime();
                DateTime dt = Convert.ToDateTime(dtpOne.Text);
                Rule Rle=new Rule();
                bool iscan=Rle.CheckHavePeiOu(dt, GetID);
                if (!iscan)
                {
                    MessageBox.Show("配偶出生日期不符合配偶规则！（可查看具体规则）", "不符");
                    return;              
                }
                string dieday="NULL";
                bool IsHaveDieDay=false;
                if (txtDieDay.Text!="")
                {
                    bool isdate=ValueJudge.IsDateTime(txtDieDay.Text);
                    if (!isdate)
                    {
                        MessageBox.Show("日期格式错诶!", "不符");
                        return;                         
                    }
                    dtlast = Convert.ToDateTime(txtDieDay.Text);
                    if (dtlast < dt)
                    {
                        MessageBox.Show("请输入正确时间", "提示");
                        return;
                    }
                    IsHaveDieDay = true;
                    dieday = dtlast.ToString();
                }
                else
                {
                    
                }
                if (txtnumaddress.Text == "")
                {
                    MessageBox.Show("请输入地址", "提示");
                    return;
                }
                if (txtnumlifestory.Text == "")
                {
                    MessageBox.Show("请输入生平事迹", "提示");
                    return;
                }
                string state = "";
                if (cbxDieNow.SelectedIndex==1)
                {
                    state = "40";
                }
                else
                {
                    state = "30";
                }
                if (IsHaveDieDay && cbxDieNow.SelectedIndex == 0)
                {
                    MessageBox.Show("此人既有死亡日期！又被标定为健在！逻辑不符合","错误");
                    return;
                }
                string sql = String.Format("insert into [Family].[dbo].[tblNumberInfo] " +
                                           "( [JobID],[NiName],[NiSex],[NiSpouseId] ,[NiBirthDay],[NiDIeDay],[NiFatherId],[NiMotherId],[NiPicture],[NiAddress],[NiLifeStory],[Nistate]) " +
                                           "values('{0}','{1}',{2},{3},cast('{4}' as datetime2),{5},{6},{7},NULL,'{8}','{9}',{10})", txtnumjob.Text, txtNumNmae.Text, PeiOuSex, GetID, dtpOne.Text, dieday, -1, -1, txtnumaddress.Text.Replace("\'", "\'\'"), txtnumlifestory.Text.Replace("\'", "\'\'"), state);
                dbvwNumberInfo vw = new dbvwNumberInfo();
                vw.CarryOutSqlSentence(sql);
                dbConnection db =new dbConnection();
                string ID =db.CarryOutSqlGetFirstColmun(String.Format(
                    "select NiId from [Family].[dbo].[tblNumberInfo] where  JobID ='{0}' and  NiName='{1}' and NiSpouseId={2} and NiFatherId =-1 and NiBirthDay ='{3}'",
                    txtnumjob.Text, txtNumNmae.Text, GetID, dtpOne.Text));
                db.CarryOutSqlSentence("update [Family].[dbo].[tblNumberInfo] set NiSpouseId =" + ID + " where  NiId= "+GetID);
                MessageBox.Show("添加成功", "提示");
                changeNull();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message+exception.StackTrace);
            }
        }

        private void 配偶规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("配偶的出生日期必须在本人的健在时间段内", "提示");
        }
    }
}

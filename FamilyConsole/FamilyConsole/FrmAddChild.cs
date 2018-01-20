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
    public partial class FrmAddChild : Form
    {
        public FrmAddChild()
        {
            InitializeComponent();
        }
        public int id;
        public int fatherId;
        public int FatherId { get; set; }
        public int motherId;
        public int MotherId { get; set; }
        private void FrmPersonInfo_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "添加孩子";
                FontFamily myFontFamily = new FontFamily("幼圆"); //采用哪种字体
                this.Font = new System.Drawing.Font(myFontFamily, 9, FontStyle.Regular);
                dbvwNumberInfo num = new dbvwNumberInfo();
                DataTable person = num.GetPersonInfo(id);
                int sexparent = num.GetPersonSex(id);

                if (sexparent == 0) //如果是男的
                {
                    fatherId = Convert.ToInt32(person.Rows[0]["NiId"]);
                    motherId = Convert.ToInt32(person.Rows[0]["NiSpouseId"]);
                    txtmother.Text = person.Rows[0]["配偶"].ToString();
                    txtfather.Text = person.Rows[0]["姓名"].ToString();               
                }
                else
                {
                    motherId = Convert.ToInt32(person.Rows[0]["NiId"]);
                    fatherId = Convert.ToInt32(person.Rows[0]["NiSpouseId"]);
                    txtfather.Text = person.Rows[0]["姓名"].ToString();
                    txtmother.Text = person.Rows[0]["配偶"].ToString();
                }
                cbxIsDie.SelectedIndex = 0;
                cbxSexName.SelectedIndex = 0;
                txtmother.Enabled = false;
                txtfather.Enabled = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
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
                DateTime dt = Convert.ToDateTime(dtpOne.Text);
                Rule esrRule =new Rule();
                bool canhave=esrRule.CheckCanHaveSon(dt, id);
                if (!canhave)
                {
                    MessageBox.Show("孩子出生日期不符合孩子规则！（可查看具体规则）", "不符");
                    return;
                }
                DateTime dtlast;
                if (txtDieDay.Text != "")
                {
                    dtlast= Convert.ToDateTime(txtDieDay.Text);
                    if (dtlast < dt)
                    {
                        MessageBox.Show("请输入正确时间格式", "提示");
                        return;
                    }                  
                }
                else
                {
                    txtDieDay.Text = "NULL";
                }

                if (cbxIsDie.SelectedIndex == 1 && txtDieDay.Text != "")
                {
                    MessageBox.Show("此人健在无法添加死亡日期", "提示");
                    return;                  
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
                if (cbxIsDie.SelectedIndex == 1)
                {
                    state = "40";
                }
                else
                {
                    state = "30";
                }
                string codesex = cbxSexName.SelectedIndex.ToString();
                string strTime = dt.ToString();
                string sql = "";
                if (txtDieDay.Text != "")
                {
                    sql = String.Format("insert into [Family].[dbo].[tblNumberInfo] " +
                                        "( [JobID],[NiName],[NiSex],[NiSpouseId] ,[NiBirthDay],[NiDIeDay],[NiFatherId],[NiMotherId],[NiPicture],[NiAddress],[NiLifeStory],[Nistate]) " +
                                        "values('{0}','{1}',{2},NULL,cast('{3}' as datetime2),{4},{5},{6},NULL,'{7}','{8}',{9})", txtnumjob.Text, txtNumNmae.Text, codesex, strTime, txtDieDay.Text, fatherId, motherId, txtnumaddress.Text, txtnumlifestory.Text, state);                 
                }
                else
                {
                    sql = String.Format("insert into [Family].[dbo].[tblNumberInfo] " +
                                        "( [JobID],[NiName],[NiSex],[NiSpouseId] ,[NiBirthDay],[NiDIeDay],[NiFatherId],[NiMotherId],[NiPicture],[NiAddress],[NiLifeStory],[Nistate]) " +
                                        "values('{0}','{1}',{2},NULL,cast('{3}' as datetime2),cast('{4}' as datetime2),{5},{6},NULL,'{7}','{8}',{9})", txtnumjob.Text, txtNumNmae.Text, codesex, strTime, txtDieDay.Text, fatherId, motherId, txtnumaddress.Text, txtnumlifestory.Text, state);                   
                }
                dbvwNumberInfo vw = new dbvwNumberInfo();
                vw.CarryOutSqlSentence(sql);
                MessageBox.Show("添加成功","提示");
                ChengNull();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

        private void ChengNull()
        {
            txtmother.Text = "";
            txtfather.Text = "";
            txtNumNmae.Text = "";
            txtnumjob.Text = "";
            txtDieDay.Text = "";
            txtnumaddress.Text = "";
            txtnumlifestory.Text = "";
        }
        private void btnOver_Click(object sender, EventArgs e)
        {
            ChengNull();
        }

        private void 日期规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" 拥有儿子的合理性+\n 1.年龄小于十岁不可以拥有儿子\n 2.未有婚配不可以拥有儿子 \n3.儿子出生日期 必需在父亲壮年 10岁到死亡的时间", "提示");
        }

        private void 返回菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("你要返回菜单吗？", "关闭", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}

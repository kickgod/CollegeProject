using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FamilyConsole
{
    public partial class FrmOperator : Form
    {
        public FrmOperator()
        {
            InitializeComponent();
        }
        public int IsCan;
        private void ToolTSMFmaily_Click(object sender, EventArgs e)
        {

        }

        private void FrmOperator_Load(object sender, EventArgs e)
        {
            GetLoad();
            lblDieDescription.Visible = false;
            btnsave.Visible = false;
            button2.Visible = false;
            GetStory();
        }

        private void tpTwo_Click(object sender, EventArgs e)
        {

        }
        private void InitMenuTreeView()
        {
            dbvwNumberInfo vw= new dbvwNumberInfo();
            DataTable db=vw.GetAllDataFrom_vwNumberInfo();
            trvMenu.Nodes.Clear();
            /*加载先祖*/
            DataTable xianzu = vw.GetFirstPerson();

            if (xianzu.Rows.Count==1)
            {
                /*顶级节点*/
                TreeNode tnTop = new TreeNode();
                tnTop.Text = xianzu.Rows[0]["姓名"].ToString();
                tnTop.Tag = xianzu.Rows[0]["NiId"];
                trvMenu.Nodes.Add(tnTop);
                BindChildNode(tnTop);
            }
            trvMenu.ExpandAll(); 
        }
        private void BindChildNode(TreeNode tnTop)
        {
            dbvwNumberInfo vw= new dbvwNumberInfo();
            dbtblNumberInfo num=new dbtblNumberInfo();
            int i = Convert.ToInt32(tnTop.Tag.ToString());
            int t_sex=num.GetPersonSex(i);
            if (t_sex == 1)//女族人
            {
                DataTable db=num.MotherGetChilDataTable(i);
                for (int j = 0; j < db.Rows.Count; j++)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = db.Rows[j]["NiId"];
                    if (num.GetPersonSex(Convert.ToInt32(db.Rows[j]["NiId"])) == 1)
                    {
                        node.Text = "女:" + db.Rows[j]["NiName"].ToString();
                    }
                    else
                    {
                        node.Text = "男:" + db.Rows[j]["NiName"].ToString();
                    }
                    tnTop.Nodes.Add(node);
                    if (num.GetChildCount(i) != 0)
                    {
                        BindChildNode(node);
                    }
                }
            }
            else if (t_sex == 0)//女族人
            {
                DataTable db = num.FatherGetChilDataTable(i);
                for (int j = 0; j < db.Rows.Count; j++)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = db.Rows[j]["NiId"];
                    if (num.GetPersonSex(Convert.ToInt32(db.Rows[j]["NiId"])) == 1)
                    {
                        node.Text = "女:" + db.Rows[j]["NiName"].ToString();
                    }
                    else
                    {
                        node.Text = "男:" + db.Rows[j]["NiName"].ToString();
                    }
                    tnTop.Nodes.Add(node);
                    if (num.GetChildCount(i) != 0)
                    {
                        BindChildNode(node);
                    }
                }
            }
        }
        private void tpTwobtnSerach_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT [族编号] ,[工作] ,[姓名] ,[性别] ,[出生日期] ,[年龄] ,[配偶],[父亲],[母亲],[状态],[NiAddress] as '地址'  FROM [Family].[dbo].[vwNumberInfo] where [族编号] >0";
                if (txtName.Text != "")
                {
                    sql += " and  [姓名] like '%" + txtName.Text.Trim() + "%'";
                }
                if (txtJobName.Text != "")
                {
                    sql += " and [工作] like '%" + txtJobName.Text.Trim() + "%'";
                }
                if (cbxSex.SelectedIndex != 2)
                {
                    if (cbxSex.SelectedIndex == 0)
                    {
                        sql += " and [性别]='男'";
                    }
                    else if (cbxSex.SelectedIndex == 1)
                    {
                        sql += " and [性别]='女'";
                    }

                }
                if (cbxHunyin.SelectedIndex != 2)
                {
                    if (cbxHunyin.SelectedIndex == 0)
                    {
                        sql += " and [配偶]!='未婚配'";
                    }
                    else if (cbxHunyin.SelectedIndex == 1)
                    {
                        sql += " and [配偶] ='未婚配'";
                    }
                }
                if (txtAgeDown.Text != "")
                {
                    bool isInt = ValueJudge.IsInt(txtAgeDown.Text);
                    if (!isInt)
                    {
                        MessageBox.Show("请输入整数", "输入错误");
                        return;
                    }
                    sql += " and [年龄] >=" + txtAgeDown.Text;
                }
                if (txtAgeUp.Text != "")
                {
                    bool isInt = ValueJudge.IsInt(txtAgeUp.Text);
                    if (!isInt)
                    {
                        MessageBox.Show("请输入整数", "输入错误");
                        return;
                    }
                    sql += " and [年龄] <=" + txtAgeUp.Text;
                }
                if (cbxDie.SelectedIndex != 2)
                {
                    if (cbxDie.SelectedIndex == 0)
                    {
                        sql += " and [Nistate]= 40";
                    }
                    else if (cbxDie.SelectedIndex == 1)
                    {
                        sql += " and [Nistate] =30";
                    }
                }
                DateTime one = Convert.ToDateTime(DtpOne.Text);
                DateTime tow = Convert.ToDateTime(DtpTow.Text);
                sql += " and [NiBirthDay] > cast('" + one.ToString() + "' as datetime2) ";
                sql += " and [NiBirthDay] < cast('" + tow.ToString() + "' as datetime2) ";
                DataTable td = new DataTable();
                dbConnection con = new UserConnection();
                dgviewShow.DataSource = con.CarryOutSqlGeDataTable(sql);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,"错误");
                throw;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongDateString()+"  "+DateTime.Now.ToLongTimeString();
        }
        private void trvMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode node = trvMenu.SelectedNode;
                if (node.Tag != null)
                {
                    changeNull();
                    trvSon.Nodes.Clear();
                    int i = Convert.ToInt32(node.Tag);
                    dbvwNumberInfo num = new dbvwNumberInfo();
                    DataTable person = num.GetPersonInfo(Convert.ToInt32(i));
                    lblbianhao.Text = i.ToString();
                    txtNumNmae.Text = person.Rows[0]["姓名"].ToString();
                    txtnumSex.Text = person.Rows[0]["性别"].ToString();
                    txtnumAge.Text = person.Rows[0]["年龄"].ToString();
                    txtnumjob.Text = person.Rows[0]["工作"].ToString();
                    txtnumaddress.Text = person.Rows[0]["NiAddress"].ToString();
                    txttimeBirth.Text = person.Rows[0]["NiBirthDay"].ToString();
                    txtfather.Text = person.Rows[0]["父亲"].ToString();
                    txtmother.Text = person.Rows[0]["母亲"].ToString();
                    txtnumpeiou.Text = person.Rows[0]["配偶"].ToString();
                    txtdieDay.Text = person.Rows[0]["NiDIeDay"].ToString();
                    txtnumlifestory.Text=person.Rows[0]["NiLifeStory"].ToString();
                    TreeNode tnTop = new TreeNode();
                    tnTop.Text = person.Rows[0]["姓名"].ToString();
                    tnTop.Tag = person.Rows[0]["NiId"];
                    trvSon.Nodes.Add(tnTop);
                    BindChildNode(tnTop);
                    trvSon.ExpandAll();
                }
            }
            catch (Exception exception)
            {
               // MessageBox.Show(exception.Message);
            }
        }

        private void changeNull()
        {
            txtNumNmae.Text = "";
            txtnumSex.Text = "";
            txtnumAge.Text = "";
            txtnumjob.Text = "";
            txtnumaddress.Text = "";
            txttimeBirth.Text = "";
            txtfather.Text = "";
            txtmother.Text = "";
            txtdieDay.Text = "";
            txtnumlifestory.Text = "";
        }

        private void EnableFalse()
        {
            txtNumNmae.Enabled = false;
            txtnumSex.Enabled = false;
            txtnumAge.Enabled = false;
            txtnumjob.Enabled = false;
            txtnumaddress.Enabled = false;
            txttimeBirth.Enabled = false;
            txtfather.Enabled = false;
            txtmother.Enabled = false;
            txtdieDay.Enabled = false;
            txtnumpeiou.Enabled = false;
            txtnumlifestory.Enabled = false;
        }
        private void EnableTrue()
        {
            txtNumNmae.Enabled = true;
            txtnumjob.Enabled = true;
            txtnumaddress.Enabled = true;
            txttimeBirth.Enabled = true;
            txtdieDay.Enabled = true;
            txtnumlifestory.Enabled = true;
        }
        /*添加孩子*/
        private void AddChildCSM_Click(object sender, EventArgs e)
        {
            if (IsCan == 20)
            {
                MessageBox.Show("你暂时未有此项权限", "提示");
                return;
            }
            if (btnsave.Visible == true)
            {
                MessageBox.Show("无法添加！信息正在修改！", "提示");
                return;
            }
            Thread thread3 = new Thread(threadProOnes);//创建新线程  
            thread3.Start();
        }
        public void threadProOnes()
        {
            MethodInvoker MethInvo = new MethodInvoker(ShowForm3);
            BeginInvoke(MethInvo);
        }
        public void ShowForm3()
        {
            if (txtNumNmae.Text == "")
            {
                MessageBox.Show("请选择一个先辈！");
                return;
            }
            if (txtnumpeiou.Text == "未婚配" || txtnumpeiou.Text == "")
            {
                MessageBox.Show("此人未有婚配如何添加儿子", "提示");
                return;
            }
            FrmAddChild frm = new FrmAddChild();
            frm.id = Convert.ToInt32(lblbianhao.Text);
            frm.Show();
        }  


        /*查看配偶*/
        private void btnCheckPeiou_Click(object sender, EventArgs e)
        {
            Thread thread2 = new Thread(threadPro);//创建新线程  
            thread2.Start();

        }
        public void threadPro()
        {
            MethodInvoker MethInvo = new MethodInvoker(ShowForm2);
            BeginInvoke(MethInvo);
        }
        public void ShowForm2()
        {
            if (txtnumpeiou.Text == "未婚配"|| txtnumpeiou.Text=="")
            {
                MessageBox.Show("此人未有婚配", "提示");
                return;
            }
            int i = Convert.ToInt32(lblbianhao.Text);
            frmCheckSpuse frmcheck = new frmCheckSpuse();
            frmcheck.GetID = Convert.ToInt32(lblbianhao.Text);
            dbtblNumberInfo num = new dbtblNumberInfo();
            if (num.GetPersonSex(i) == 1)
            {
                frmcheck.PeiOuSex = 0;
            }
            else
            {
                frmcheck.PeiOuSex = 1;
            }
            frmcheck.ShowORAdd = 2;
            frmcheck.Show();
        }


        public void GetLoad()
        {
            #region 加载
            cbxSex.SelectedIndex = cbxSex.Items.IndexOf("选择全部");
            cbxHunyin.SelectedIndex = cbxHunyin.Items.IndexOf("选择全部");
            cbxDie.SelectedIndex = cbxDie.Items.IndexOf("选择全部");
            string sql = "SELECT [族编号] ,[工作] ,[姓名] ,[性别] ,[出生日期] ,[年龄] ,[配偶],[父亲],[母亲],[状态],[NiAddress] as '地址'  FROM [Family].[dbo].[vwNumberInfo] where [族编号] >0";
            DataTable td = new DataTable();
            dbConnection con = new UserConnection();
            dgviewShow.DataSource = con.CarryOutSqlGeDataTable(sql);
            /*节点绑定*/
            InitMenuTreeView();
            EnableFalse();
            #endregion
        }
        private void refreshData_Click(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void btnAddPeiou_Click(object sender, EventArgs e)
        {
            if (IsCan == 20)
            {
                MessageBox.Show("你暂时未有此项权限", "提示");
                return;
            }
            if (btnsave.Visible == true)
            {
                MessageBox.Show("无法添加！信息正在修改！", "提示");
                return;
            }
            if (lblbianhao.Text == "abc")
            {
                MessageBox.Show("请选择一个族人", "提示");
                return;                    
            }
            if (txtnumpeiou.Text == "未婚配" || txtnumpeiou.Text == "")
            {
                Thread thread2 = new Thread(threadPro_add);//创建新线程  
                thread2.Start();
            }
            else
            {
                MessageBox.Show("此人已经有婚配__小妾不计入族谱", "提示");
                return;              
            }
        }
        /*添加配偶*/
        public void threadPro_add()
        {
            MethodInvoker MethInvo = new MethodInvoker(ShowForm2_Add);
            BeginInvoke(MethInvo);
        }
        public void ShowForm2_Add()
        {
            int i = Convert.ToInt32(lblbianhao.Text);
            frmCheckSpuse frmcheck = new frmCheckSpuse();
            frmcheck.GetID = Convert.ToInt32(lblbianhao.Text);
            dbtblNumberInfo num = new dbtblNumberInfo();
            if (num.GetPersonSex(i) == 1)
            {
                frmcheck.PeiOuSex = 0;
            }
            else
            {
                frmcheck.PeiOuSex = 1;
            }
            frmcheck.ShowORAdd = 1;
            frmcheck.Show();
        }
        private void Delete(int i)
        {
            dbtblNumberInfo num =new dbtblNumberInfo();
            int t_sex = num.GetPersonSex(i);
            num.CarryOutSqlSentence("delete from [Family].[dbo].[tblNumberInfo] where NiId=" + i);
            num.CarryOutSqlSentence("delete from [Family].[dbo].[tblNumberInfo] where NiSpouseId = " + i);
            if (t_sex == 1) //女族人
            {
                DataTable db = num.MotherGetChilDataTable(i);
                for (int j = 0; j < db.Rows.Count; j++)
                {
                    if (num.GetChildCount(j, t_sex) != 0)
                    {
                        Delete(Convert.ToInt32(db.Rows[j]["NiId"]));
                    }
                    num.CarryOutSqlSentence("delete from [Family].[dbo].[tblNumberInfo] where NiId=" + db.Rows[j]["NiId"].ToString());
                    num.CarryOutSqlSentence("delete from [Family].[dbo].[tblNumberInfo] where NiSpouseId = " + db.Rows[j]["NiId"].ToString());
                }
            }
            else
            {
                DataTable db = num.FatherGetChilDataTable(i);
                for (int j = 0; j < db.Rows.Count; j++)
                {
                    if (num.GetChildCount(j, t_sex) != 0)
                    {
                        Delete(Convert.ToInt32(db.Rows[j]["NiId"]));
                    }
                    num.CarryOutSqlSentence("delete from [Family].[dbo].[tblNumberInfo] where NiId=" + db.Rows[j]["NiId"].ToString());
                    num.CarryOutSqlSentence("delete from [Family].[dbo].[tblNumberInfo] where NiSpouseId = " + db.Rows[j]["NiId"].ToString());
                }              
            }
        }

        private void deleteTSM_Click(object sender, EventArgs e)
        {
            if (IsCan == 20)
            {
                MessageBox.Show("你暂时未有此项权限", "提示");
                return;
            }
            if (btnsave.Visible == true)
            {
                MessageBox.Show("无法删除！信息正在修改！", "提示");
                return;
            }
            //得到族系_族系
            if (lblbianhao.Text == "abc")
            {
                MessageBox.Show("请选择一个族人", "提示");
                return;
            }
            if (System.Windows.Forms.MessageBox.Show("你确定要删除族人吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int i = Convert.ToInt32(lblbianhao.Text);
                dbtblNumberInfo num = new dbtblNumberInfo();
                Delete(i);
                InitMenuTreeView();
                deleteAll();
                MessageBox.Show("已经删除完毕", "成功");
            }
        }

        private void deleteAll()
        {
            lblbianhao.Text = "abc";
            txtNumNmae.Text = "";
            txtnumSex.Text = "";
            txtnumAge.Text = "";
            txtnumjob.Text = "";
            txttimeBirth.Text = "";
            txtdieDay.Text = "";
            txtnumpeiou.Text = "";
            txtfather.Text = "";
            txtnumpeiou.Text = "";
            txtfather.Text = "";
            txtfather.Text = "";
            txtmother.Text = "";
            trvSon.Nodes.Clear();
            txtnumaddress.Text = "";
            txtnumlifestory.Text = "";
        }

        private void EditTSM_Click(object sender, EventArgs e)
        {
            if (IsCan == 20)
            {
                MessageBox.Show("你暂时未有此项权限", "提示");
                return;                
            }
            if (lblbianhao.Text == "abc")
            {
                MessageBox.Show("请选择一个族人", "提示");
                return;     
            }
            EnableTrue();
            lblDieDescription.Visible = true;
            btnsave.Visible = true;
            button2.Visible = true;
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            int bianhao = Convert.ToInt32(lblbianhao.Text);
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
                String.Format("update Family.dbo.tblNumberInfo set  [JobID]='{0}' ,NiName ='{1}' ,[NiBirthDay] ='{2}',NiDIeDay='{3}' ,NiAddress='{4}',[NiLifeStory]='{5}' where NiId ={6}",
                txtnumjob.Text, txtNumNmae.Text, txttimeBirth.Text, txtdieDay.Text,txtnumaddress.Text,txtnumlifestory.Text,bianhao.ToString()
                );
            if (txtdieDay.Text != "")
            {
                sql =
                    String.Format("update Family.dbo.tblNumberInfo set  [JobID]='{0}' ,NiName ='{1}' ,[NiBirthDay] ='{2}',NiDIeDay='{3}' ,NiAddress='{4}',[NiLifeStory]='{5}' , Nistate =40  where NiId ={6}",
                        txtnumjob.Text, txtNumNmae.Text, txttimeBirth.Text, txtdieDay.Text, txtnumaddress.Text, txtnumlifestory.Text, bianhao.ToString()
                    );               
            }
            dbConnection db=new dbvwNumberInfo();
            db.CarryOutSqlSentence(sql);
            MessageBox.Show("修改成功", "成功");
            EnableFalse();
            btnsave.Visible = false;
            button2.Visible = false;
            lblDieDescription.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnableFalse();
            btnsave.Visible = false;
            button2.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (IsCan == 20)
            {
                MessageBox.Show("你暂时未有此项权限", "提示");
                return;
            }
            if (lblbianhao.Text == "abc")
            {
                MessageBox.Show("请选择一个族人", "提示");
                return;
            }
            if (btnsave.Visible == true)
            {
                MessageBox.Show("无法删除！信息正在修改！", "提示");
                return;
            }
            if (txtnumpeiou.Text == "未婚配" || txtnumpeiou.Text == "")
            {
                MessageBox.Show("此人未有婚配", "提示");
                return;
            }
            Thread thread2 = new Thread(threadEditPeiOu);//创建新线程  
            thread2.Start();
        }
        public void threadEditPeiOu()
        {
            MethodInvoker MethInvo = new MethodInvoker(ShowEditPeiOu);
            BeginInvoke(MethInvo);
        }
        public void ShowEditPeiOu()
        {
            int i = Convert.ToInt32(lblbianhao.Text);
            FrmEdit frmcheck = new FrmEdit();
            frmcheck.GetID = Convert.ToInt32(lblbianhao.Text);
            dbtblNumberInfo num = new dbtblNumberInfo();
            if (num.GetPersonSex(i) == 1)
            {
                frmcheck.PeiOuSex = 0;
            }
            else
            {
                frmcheck.PeiOuSex = 1;
            }
            frmcheck.ShowORAdd = 2;
            frmcheck.Show();
        }
        private void DeleteAllDateTSM_Click(object sender, EventArgs e)
        {
            if (IsCan == 20)
            {
                MessageBox.Show("你暂时未有此项权限", "提示");
                return;
            }
            if (System.Windows.Forms.MessageBox.Show("你确定要删除所有数据吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (System.Windows.Forms.MessageBox.Show("请你再次慎重考虑是否重建家谱！", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dbConnection db=new dbConnection();
                    db.CarryOutSqlSentence("  truncate table [Family].[dbo].[tblNumberInfo]");
                    MessageBox.Show("已经清空！", "提示");
                }
            }
        }

        private void GetDate()
        {
            dbvwNumberInfo num = new dbvwNumberInfo();
            DataTable td = num.GetAllDataFrom_vwNumberInfo();
            int zero_10 = 0;
            int shi_20 = 0;
            int ErShi_30 = 0;
            int SanShi_40 = 0;
            int shiwu_50 = 0;
            int wushi_60 = 0;
            int liushi_70 = 0;
            int qishi_80 = 0;
            int bashi_90 = 0;
            int jiushi_Up = 0;
            for (int i = 0; i < td.Rows.Count; i++)
            {
                int NianLing = Convert.ToInt32(td.Rows[i]["年龄"]);
                switch (NianLing/10)
                {
                    case 0:
                    {
                        zero_10++;
                    }break;
                    case 1:
                    {
                        shi_20++;
                    }break;
                    case 2:
                    {
                        ErShi_30++;
                    }break;
                    case 3:
                    {
                        SanShi_40++;
                    }break;
                    case 4:
                    {
                        shiwu_50++;
                    }break;
                    case 5:
                    {
                        wushi_60++;
                    }break;
                    case 6:
                    {
                        liushi_70++;
                    }break;
                    case 7:
                    {
                        qishi_80++;
                    }break;
                    case 8:
                    {
                        bashi_90++;
                    }break;
                    default:
                        jiushi_Up++;
                        break;
                }
            }
            //清除默认的series
            CharNainFenBu.Series.Clear();
            //new 一个叫做【Strength】的系列
            Series Strength = new Series("人员数量");
            //设置chart的类型，这里为柱状图
            Strength.ChartType = SeriesChartType.Column;
            //给系列上的点进行赋值，分别对应横坐标和纵坐标的值
            Strength.Points.AddXY("0~10", zero_10);
            Strength.Points.AddXY("10~20", shi_20);
            Strength.Points.AddXY("20~30", ErShi_30);
            Strength.Points.AddXY("30~40", SanShi_40);
            Strength.Points.AddXY("40~50", shiwu_50);
            Strength.Points.AddXY("50~60", wushi_60);
            Strength.Points.AddXY("60~70", liushi_70);
            Strength.Points.AddXY("70~80", qishi_80);
            Strength.Points.AddXY("80~90", bashi_90);
            Strength.Points.AddXY("90~", jiushi_Up);
            //把series添加到chart上
            CharNainFenBu.Series.Add(Strength);       
        }
        private void ShowData()
        {
            dbConnection con = new dbConnection();
            string AllPeople = con.CarryOutSqlGetFirstColmun("select count(*) from  [Family].[dbo].[tblNumberInfo]");
            double countAllPeople = Convert.ToDouble(AllPeople);
            RsAllPeopleCount.Height = 200;
            RsAllPeopleCount.Width = 25;
            lblAll.Text = "总人数:" + countAllPeople;
            dbvwNumberInfo num =new dbvwNumberInfo();
            DataTable td = num.GetAllDataFrom_vwNumberInfo();
            int sexCountGirl = 0;
            int sexCountBoy = 0;
            int weichengnian = 0;
            int lblLifeCount = 0;//当前健在人口
            int lblTillNowDieCount = 0;/*目前为止先祖人口*/
            int lblNowDanCount = 0; /*当前单身人数*/
            int lblJiaZuJiCount = 0;/*未记载*/
            int BoyNowStillLfe = 0;
            int GirlNowLifeStill = 0;
            int JianZiaWeicheng = 0;
            for (int i = 0; i < td.Rows.Count; i++)
            {
                if (td.Rows[i]["NiSex"].ToString() =="True")
                {
                    sexCountGirl++;
                }
                else
                {
                    sexCountBoy++;
                }
                if (Convert.ToInt32(td.Rows[i]["年龄"]) < 18)
                {
                    weichengnian++;
                }

                /*统计健在人口*/
                if (td.Rows[i]["Nistate"].ToString() == "30")
                {
                    lblLifeCount++;
                }
                /*统计死亡人口*/
                if (td.Rows[i]["Nistate"].ToString() == "40")
                {
                    lblTillNowDieCount++;
                }
                if (td.Rows[i]["配偶"].ToString() == "未记载" && td.Rows[i]["Nistate"].ToString() == "30")
                {
                    lblNowDanCount++;
                }
                if (td.Rows[i]["NiLifeStory"].ToString() == "" || td.Rows[i]["NiLifeStory"].ToString().Length<50)
                {
                    lblJiaZuJiCount++;
                }
                if (td.Rows[i]["Nistate"].ToString() == "30" && td.Rows[i]["性别"].ToString()=="男")
                {
                    BoyNowStillLfe++;
                }
                if (td.Rows[i]["Nistate"].ToString() == "30" && td.Rows[i]["性别"].ToString() == "女")
                {
                    GirlNowLifeStill++;
                }
                if (Convert.ToInt32(td.Rows[i]["年龄"]) < 18 && td.Rows[i]["Nistate"].ToString() == "30")
                {
                    JianZiaWeicheng++;
                }
            }
            lblLifeCountNow.Text = lblLifeCount.ToString();            /*显示健在总人口*/
            lblTillNowDieCountNow.Text = lblTillNowDieCount.ToString();//显示死亡人口
            lblNowDanCountNow.Text = lblNowDanCount.ToString();            /*单身人数*/
            lblJiZaiWithOut.Text = lblJiaZuJiCount.ToString();            /*记载*/
            lblLifeGrilNow.Text =GirlNowLifeStill.ToString();
            lblLifeBoyNow.Text = BoyNowStillLfe.ToString();
            lblWhouChengNian.Text = JianZiaWeicheng.ToString();
            lblWEichengnian.Text = "未成年:" + weichengnian;
            lblGirl.Text = "女生:" + sexCountGirl;
            lblBoy.Text = "男生:" + sexCountBoy;
            RSGrilCount.Height = Convert.ToInt32((sexCountGirl / countAllPeople) * 200);
            RSBoyCount.Height = Convert.ToInt32((sexCountBoy / countAllPeople) * 200);
            CRWeichengNain.Height = Convert.ToInt32((weichengnian / countAllPeople) * 200);
            GetDate();
        }

        private void btnTongji_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        private void GetStory()
        {
            dbConnection db = new dbConnection();
            DataTable Tt=db.CarryOutSqlGeDataTable(
                "select top 1 NiLifeStory ,NiName from  [Family].[dbo].[tblNumberInfo] where LEN(NiLifeStory)>30 order by newid()");
            txtStroyFamily.Text = "    " + Tt.Rows[0]["NiName"].ToString() + "：" + Tt.Rows[0]["NiLifeStory"].ToString();
        }
        private void lblCheckMore_Click(object sender, EventArgs e)
        {
            GetStory();
        }

        private void lblCheckMore_MouseHover(object sender, EventArgs e)
        {
            lblCheckMore.ForeColor=Color.Crimson;
        }

        private void lblCheckMore_MouseLeave(object sender, EventArgs e)
        {
            lblCheckMore.ForeColor = Color.Black;
        }

        private void getListData(string sql)
        {
            dbConnection db =new dbConnection();
            dgvList.DataSource = db.CarryOutSqlGeDataTable(sql);
        }
        private void btnGetDieList_Click(object sender, EventArgs e)
        {
            getListData("  select row_number() over (order by NiId) as '序号',姓名  as '姓名',性别 from [Family].[dbo].[vwNumberInfo] where Nistate=40");
        }
        private void btnHunPeiList_Click(object sender, EventArgs e)
        {
            getListData("  select row_number() over (order by NiId) as '序号',姓名  as '姓名',性别 from [Family].[dbo].[vwNumberInfo] where Nistate=30 and NiSpouseId =NULL");
        }

        private void btnGetJianZaiList_Click(object sender, EventArgs e)
        {
            getListData("select row_number() over (order by NiId) as '序号',姓名  as '姓名',性别 from [Family].[dbo].[vwNumberInfo] where Nistate=30");
        }

        private void btnWithOutShengPing_Click(object sender, EventArgs e)
        {
            getListData("  select row_number() over (order by NiId) as '序号',姓名  as '姓名',性别 from [Family].[dbo].[vwNumberInfo] where NiLifeStory=NULL or len(NiLifeStory)<50");
        }

        private void btnLiftGirlList_Click(object sender, EventArgs e)
        {
            getListData("  select row_number() over (order by NiId) as '序号',姓名  as '姓名',性别 from [Family].[dbo].[vwNumberInfo] where Nistate=30 and NiSex=1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getListData("  select row_number() over (order by NiId) as '序号',姓名  as '姓名',性别 from [Family].[dbo].[vwNumberInfo] where Nistate=30 and NiSex=0");
        }

        private void btnWeiChengNianList_Click(object sender, EventArgs e)
        {
            getListData("  select row_number() over (order by NiId) as '序号',姓名  as '姓名',性别 from [Family].[dbo].[vwNumberInfo] where Nistate=30 and 年龄<18");
        }

        private void TSMChangeColor_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
        }

        private void TSMgObACColor_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Gainsboro;
        }

        private void OutProcedureLogin_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("你确定退出登录吗？", "关闭", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                new System.Threading.Thread(() =>
                {
                    Application.Run(new FrmLogin());
                }).Start();
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbvwNumberInfo num = new dbvwNumberInfo();
            DataTable td = num.GetAllDataFrom_vwNumberInfo("Nistate = 30");
            int zero_10 = 0;
            int shi_20 = 0;
            int ErShi_30 = 0;
            int SanShi_40 = 0;
            int shiwu_50 = 0;
            int wushi_60 = 0;
            int liushi_70 = 0;
            int qishi_80 = 0;
            int bashi_90 = 0;
            int jiushi_Up = 0;
            for (int i = 0; i < td.Rows.Count; i++)
            {
                int NianLing = Convert.ToInt32(td.Rows[i]["年龄"]);
                switch (NianLing / 10)
                {
                    case 0:
                    {
                        zero_10++;
                    } break;
                    case 1:
                    {
                        shi_20++;
                    } break;
                    case 2:
                    {
                        ErShi_30++;
                    } break;
                    case 3:
                    {
                        SanShi_40++;
                    } break;
                    case 4:
                    {
                        shiwu_50++;
                    } break;
                    case 5:
                    {
                        wushi_60++;
                    } break;
                    case 6:
                    {
                        liushi_70++;
                    } break;
                    case 7:
                    {
                        qishi_80++;
                    } break;
                    case 8:
                    {
                        bashi_90++;
                    } break;
                    default:
                        jiushi_Up++;
                        break;
                }
            }
            //清除默认的series
            CharNainFenBu.Series.Clear();
            //new 一个叫做【Strength】的系列
            Series Strength = new Series("人员数量");
            //设置chart的类型，这里为柱状图
            Strength.ChartType = SeriesChartType.Column;
            //给系列上的点进行赋值，分别对应横坐标和纵坐标的值
            Strength.Points.AddXY("0~10", zero_10);
            Strength.Points.AddXY("10~20", shi_20);
            Strength.Points.AddXY("20~30", ErShi_30);
            Strength.Points.AddXY("30~40", SanShi_40);
            Strength.Points.AddXY("40~50", shiwu_50);
            Strength.Points.AddXY("50~60", wushi_60);
            Strength.Points.AddXY("60~70", liushi_70);
            Strength.Points.AddXY("70~80", qishi_80);
            Strength.Points.AddXY("80~90", bashi_90);
            Strength.Points.AddXY("90~", jiushi_Up);
            //把series添加到chart上
            CharNainFenBu.Series.Add(Strength);  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbvwNumberInfo num = new dbvwNumberInfo();
            DataTable td = num.GetAllDataFrom_vwNumberInfo();
            int zero_10 = 0;
            int shi_20 = 0;
            int ErShi_30 = 0;
            int SanShi_40 = 0;
            int shiwu_50 = 0;
            int wushi_60 = 0;
            int liushi_70 = 0;
            int qishi_80 = 0;
            int bashi_90 = 0;
            int jiushi_Up = 0;
            for (int i = 0; i < td.Rows.Count; i++)
            {
                int NianLing = Convert.ToInt32(td.Rows[i]["年龄"]);
                switch (NianLing / 10)
                {
                    case 0:
                    {
                        zero_10++;
                    } break;
                    case 1:
                    {
                        shi_20++;
                    } break;
                    case 2:
                    {
                        ErShi_30++;
                    } break;
                    case 3:
                    {
                        SanShi_40++;
                    } break;
                    case 4:
                    {
                        shiwu_50++;
                    } break;
                    case 5:
                    {
                        wushi_60++;
                    } break;
                    case 6:
                    {
                        liushi_70++;
                    } break;
                    case 7:
                    {
                        qishi_80++;
                    } break;
                    case 8:
                    {
                        bashi_90++;
                    } break;
                    default:
                        jiushi_Up++;
                        break;
                }
            }
            //清除默认的series
            CharNainFenBu.Series.Clear();
            //new 一个叫做【Strength】的系列
            Series Strength = new Series("人员数量");
            //设置chart的类型，这里为柱状图
            Strength.ChartType = SeriesChartType.Column;
            //给系列上的点进行赋值，分别对应横坐标和纵坐标的值
            Strength.Points.AddXY("0~10", zero_10);
            Strength.Points.AddXY("10~20", shi_20);
            Strength.Points.AddXY("20~30", ErShi_30);
            Strength.Points.AddXY("30~40", SanShi_40);
            Strength.Points.AddXY("40~50", shiwu_50);
            Strength.Points.AddXY("50~60", wushi_60);
            Strength.Points.AddXY("60~70", liushi_70);
            Strength.Points.AddXY("70~80", qishi_80);
            Strength.Points.AddXY("80~90", bashi_90);
            Strength.Points.AddXY("90~", jiushi_Up);
            //把series添加到chart上
            CharNainFenBu.Series.Add(Strength); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dbvwNumberInfo num = new dbvwNumberInfo();
            DataTable td = num.GetAllDataFrom_vwNumberInfo("Nistate = 40");
            int zero_10 = 0;
            int shi_20 = 0;
            int ErShi_30 = 0;
            int SanShi_40 = 0;
            int shiwu_50 = 0;
            int wushi_60 = 0;
            int liushi_70 = 0;
            int qishi_80 = 0;
            int bashi_90 = 0;
            int jiushi_Up = 0;
            for (int i = 0; i < td.Rows.Count; i++)
            {
                int NianLing = Convert.ToInt32(td.Rows[i]["年龄"]);
                switch (NianLing / 10)
                {
                    case 0:
                    {
                        zero_10++;
                    } break;
                    case 1:
                    {
                        shi_20++;
                    } break;
                    case 2:
                    {
                        ErShi_30++;
                    } break;
                    case 3:
                    {
                        SanShi_40++;
                    } break;
                    case 4:
                    {
                        shiwu_50++;
                    } break;
                    case 5:
                    {
                        wushi_60++;
                    } break;
                    case 6:
                    {
                        liushi_70++;
                    } break;
                    case 7:
                    {
                        qishi_80++;
                    } break;
                    case 8:
                    {
                        bashi_90++;
                    } break;
                    default:
                        jiushi_Up++;
                        break;
                }
            }
            //清除默认的series
            CharNainFenBu.Series.Clear();
            //new 一个叫做【Strength】的系列
            Series Strength = new Series("人员数量");
            //设置chart的类型，这里为柱状图
            Strength.ChartType = SeriesChartType.Column;
            //给系列上的点进行赋值，分别对应横坐标和纵坐标的值
            Strength.Points.AddXY("0~10", zero_10);
            Strength.Points.AddXY("10~20", shi_20);
            Strength.Points.AddXY("20~30", ErShi_30);
            Strength.Points.AddXY("30~40", SanShi_40);
            Strength.Points.AddXY("40~50", shiwu_50);
            Strength.Points.AddXY("50~60", wushi_60);
            Strength.Points.AddXY("60~70", liushi_70);
            Strength.Points.AddXY("70~80", qishi_80);
            Strength.Points.AddXY("80~90", bashi_90);
            Strength.Points.AddXY("90~", jiushi_Up);
            //把series添加到chart上
            CharNainFenBu.Series.Add(Strength); 
        }
      
    }
}

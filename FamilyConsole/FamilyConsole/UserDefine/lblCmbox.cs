using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyConsole.UserDefine
{
    public partial class lblCmbox : UserControl
    {
        public lblCmbox()
        {
            InitializeComponent();
        }
        #region MyRegion
        /*
            C#创建datatable

            方法一:

            DataTable tblDatas = new DataTable("Datas");
            DataColumn dc = null;
            dc = tblDatas.Columns.Add("ID", Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = false;//

            dc = tblDatas.Columns.Add("Product", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("Version", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("Description", Type.GetType("System.String"));

            DataRow newRow;
            newRow = tblDatas.NewRow();
            newRow["Product"] = "大话西游";
            newRow["Version"] = "2.0";
            newRow["Description"] = "我很喜欢";
            tblDatas.Rows.Add(newRow);

            newRow = tblDatas.NewRow();
            newRow["Product"] = "梦幻西游";
            newRow["Version"] = "3.0";
            newRow["Description"] = "比大话更幼稚";
            tblDatas.Rows.Add(newRow);

            方法二:

            DataTable tblDatas = new DataTable("Datas");
            tblDatas.Columns.Add("ID", Type.GetType("System.Int32"));
            tblDatas.Columns[0].AutoIncrement = true;
            tblDatas.Columns[0].AutoIncrementSeed = 1;
            tblDatas.Columns[0].AutoIncrementStep = 1;

            tblDatas.Columns.Add("Product", Type.GetType("System.String"));
            tblDatas.Columns.Add("Version", Type.GetType("System.String"));
            tblDatas.Columns.Add("Description", Type.GetType("System.String"));

            tblDatas.Rows.Add(new object[]{null,"a","b","c"});
            tblDatas.Rows.Add(new object[] { null, "a", "b", "c" });
            tblDatas.Rows.Add(new object[] { null, "a", "b", "c" });
            tblDatas.Rows.Add(new object[] { null, "a", "b", "c" });
            tblDatas.Rows.Add(new object[] { null, "a", "b", "c" });

            方法三：
            DataTable table = new DataTable ();

            //创建table的第一列
            DataColumn priceColumn = new DataColumn();
            //该列的数据类型
            priceColumn.DataType = System.Type.GetType("System.Decimal");
            //该列得名称
            priceColumn.ColumnName = "price";
            //该列得默认值
            priceColumn.DefaultValue = 50;

            // 创建table的第二列
            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.Decimal");
            //列名
            taxColumn.ColumnName = "tax";
            //设置该列得表达式，用于计算列中的值或创建聚合列
            taxColumn.Expression = "price * 0.0862";
            // Create third column.
            DataColumn totalColumn = new DataColumn();
            totalColumn.DataType = System.Type.GetType("System.Decimal");
            totalColumn.ColumnName = "total";
            //该列的表达式，值是得到的是第一列和第二列值得和
            totalColumn.Expression = "price + tax";

            // 将所有的列添加到table上
            table.Columns.Add(priceColumn);
            table.Columns.Add(taxColumn);
            table.Columns.Add(totalColumn);

            //创建一行
            DataRow row = table.NewRow();
            //将此行添加到table中
            table.Rows.Add(row);

            //将table放在试图中
            DataView view = new DataView(table);
            dg.DataSource = view;

            dg.DataBind();
         
         */
        #endregion
        public DataTable Sex
        {
            get
            {
                DataTable Tb=new DataTable("SexList");
                DataColumn dataColumn = null;
                dataColumn = Tb.Columns.Add("ID",Type.GetType("System.Int32"));
                dataColumn.AutoIncrement = true;//自动增加
                dataColumn.AutoIncrementSeed = 1;//起始为1
                dataColumn.AutoIncrementStep = 1;//步长为1
                dataColumn.AllowDBNull = false;//
                Tb.Columns.Add("SexName", Type.GetType("System.String"));
                Tb.Rows.Add(new Object[] { 1, "女"});
                Tb.Rows.Add(new Object[] { 2, "男" });
                Tb.Rows.Add(new Object[] { 3, "全部选择" });
                return Tb;
            }
            set { Sex = value; }
        }
    }
}

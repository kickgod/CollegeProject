using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FamilyConsole
{
    class dbtblNumberInfo : dbConnection
    {
        /// <summary>
        /// 返回表tblNumberInfo里面所有的数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllDataFromtblNumberInfo()
        {
            SqlConnection con = GetSqlConnection();
            DataTable td = new DataTable();
            if (con.State != ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblNumberInfo";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(td);
            cmd.Dispose();
            con.Dispose();
            con.Close();
            return td;
        }
        /// <summary>
        /// 返回表tblNumberInfo里面加上where条件的所有数据
        /// </summary>
        /// <param name="Where"></param>
        /// <returns></returns>
        public DataTable GetAllDataFromtblNumberInfo(String Where)
        {
            SqlConnection con = GetSqlConnection();
            DataTable td = new DataTable();
            if (con.State != ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (Where == "")
            {
                cmd.CommandText = "SELECT * FROM tblNumberInfo";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM tblNumberInfo Where " + Where;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(td);
            cmd.Dispose();
            con.Dispose();
            con.Close();
            return td;
        }
        public int GetPersonSex(int i)
        {
            DataTable db = GetAllDataFromtblNumberInfo(" NiId =" + i);
            if (db.Rows.Count == 0)
            {
                System.Environment.Exit(0);
            }
            bool sex = Convert.ToBoolean(db.Rows[0]["NiSex"]);
            if (sex)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public bool IsHavePeiOu(int i)
        {
            string result = CarryOutSqlGetFirstColmun("select count(*) from [Family].[dbo].[tblNumberInfo]  where NiSpouseId !=NULL and NiId=1");
            if (result == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 得到配偶信息
        /// </summary>
        /// <param name="i">求的她</param>
        /// <returns>返回配偶信息</returns>
        public DataTable GetPeiOuInfo(int i)
        {
            DataTable result = CarryOutSqlGeDataTable("select * from [Family].[dbo].[vwNumberInfo]  where NiSpouseId=" + i);
            return result;
        }
        public DataTable FatherGetChilDataTable(int i)
        {
            DataTable result;
            result= GetAllDataFromtblNumberInfo("NiFatherId = " + i);
            return result;
        }
        public DataTable MotherGetChilDataTable(int i)
        {
            DataTable result;
            result = GetAllDataFromtblNumberInfo("NiMotherId = " + i);
            return result;
        }
        public DataTable GetPersonInfo(int i)
        {
            DataTable result;
            result = GetAllDataFromtblNumberInfo("NiId = " + i);
            return result;
        }
        public int GetChildCount(int i)
        {
            int result=0;
            int sex=GetPersonSex(i);
            if (sex == 1) //女人
            {
                result=Convert.ToInt32(CarryOutSqlGetFirstColmun(" select count(*) from [Family].[dbo].[tblNumberInfo] where NiMotherId= " +i));
            }
            else if(sex==0)
            {
                result=Convert.ToInt32(CarryOutSqlGetFirstColmun(" select count(*) from [Family].[dbo].[tblNumberInfo] where NiFatherId= " +i));
            }
            return result;
        }
        public int GetChildCount(int i,int sexKnow)
        {
            int result = 0;
            if (sexKnow == 1) //女人
            {
                result = Convert.ToInt32(CarryOutSqlGetFirstColmun(" select count(*) from [Family].[dbo].[tblNumberInfo] where NiMotherId= " + i));
            }
            else if (sexKnow == 0)
            {
                result = Convert.ToInt32(CarryOutSqlGetFirstColmun(" select count(*) from [Family].[dbo].[tblNumberInfo] where NiFatherId= " + i));
            }
            return result;
        }
    }
}

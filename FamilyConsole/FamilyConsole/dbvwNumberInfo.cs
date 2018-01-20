using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyConsole
{
    class dbvwNumberInfo : dbConnection
    {
        /// <summary>
        /// 返回视图vwNumberInfo里面所有的数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllDataFrom_vwNumberInfo()
        {
            SqlConnection con = GetSqlConnection();
            DataTable td = new DataTable();
            if (con.State != ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM vwNumberInfo";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(td);
            cmd.Dispose();
            con.Dispose();
            con.Close();
            return td;
        }
        /// <summary>
        /// 返回视图vwNumberInfo里面加上where条件的所有数据
        /// </summary>
        /// <param name="Where"></param>
        /// <returns></returns>
        public DataTable GetAllDataFrom_vwNumberInfo(String Where)
        {
            SqlConnection con = GetSqlConnection();
            DataTable td = new DataTable();
            if (con.State != ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (Where != "")
            {
                cmd.CommandText = "SELECT * FROM vwNumberInfo Where " + Where;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM vwNumberInfo";
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(td);
            return td;
        }
        public DataTable GetFirstPerson(){
            SqlConnection con = GetSqlConnection();
            DataTable td = new DataTable();
            if (con.State != ConnectionState.Closed)
            {
                con.Open();
            }           
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from  [Family].[dbo].[vwNumberInfo] where NiFatherId=0";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(td);
            cmd.Dispose();
            con.Dispose();
            con.Close();
            return td;
        }
        /// <summary>
        /// 得到族人的性别
        /// </summary>
        /// <param name="i">族人编号</param>
        /// <returns>
        /// 1.为女
        /// 0.为男
        /// </returns>
        public int GetPersonSex(int i)
        {
            DataTable db=GetAllDataFrom_vwNumberInfo(" [NiId] =" +i);
            if (db.Rows.Count == 0)
            {
                System.Environment.Exit(0);
            }
            bool sex=Convert.ToBoolean(db.Rows[0]["NiSex"]);
            if (sex)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public DataTable GetPersonInfo(int i)
        {
            DataTable result;
            result = GetAllDataFrom_vwNumberInfo("NiId = " + i);
            return result;
        }
    }

}

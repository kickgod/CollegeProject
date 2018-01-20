using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyConsole
{
    class dbConnection
    {
        /// <summary>
        /// 得到链接字符串
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetSqlConnection()
        {
            String Connectstring = "Data Source=39.108.83.255;Initial Catalog=Family;Persist Security Info=True;User ID=W32;Password=123456 ";
            SqlConnection con = new SqlConnection(Connectstring);
            return con;
        }
        /// <summary>
        /// 执行sql语句返回影响的行数 可以做以作用于表或者视图
        /// 返回-1 表示sql语句为空
        /// </summary>
        /// <param name="SentenceSql">sql语句</param>
        /// <returns>返回影响的行数</returns>
        public int CarryOutSqlSentence(string SentenceSql)
        {
            int HangShu;
            if (SentenceSql == "")
            {
                return -1;
            }
            SqlConnection con = GetSqlConnection();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = SentenceSql;
            HangShu = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Dispose();
            con.Close();
            return HangShu;
        }
        /// <summary>
        /// 执行sql 语句返回结果的第一行第一列 可以做以作用于表或者视图
        /// 返回-1表示sql 语句为空 
        /// </summary>
        /// <param name="SentenceSql">sql语句</param>
        /// <returns>返回结果的第一行第一列</returns>
        public String CarryOutSqlGetFirstColmun(string SentenceSql)
        {
            if (SentenceSql == "")
            {
                return "-1";
            }
            string Result;
            SqlConnection con = GetSqlConnection();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = SentenceSql;
            Result = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
            con.Dispose();
            con.Close();
            return Result;
        }
        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <param name="SentenceSql"></param>
        /// <returns></returns>
        public DataTable CarryOutSqlGeDataTable(string SentenceSql)
        {
            if (SentenceSql == "")
            {
                return null;
            }
            SqlConnection con = GetSqlConnection();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = SentenceSql;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable td = new DataTable();
            adapter.Fill(td);
            cmd.Dispose();
            con.Dispose();
            con.Close();
            return td;
        }   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyConsole
{
    class UserConnection:dbConnection
    {
        public UserConnection()
        {
            
        }
        /// <summary>
        /// 判断用户是否为管理员
        /// </summary>
        /// <param name="UserId">用户账号</param>
        /// <param name="UserPwd">用户密码</param>
        /// <returns>返回1表示密码账号正确/且是管理员  返回0  密码或者账号错误！ 返回-1 账号密码正确 但不是管理员 是普通用户</returns>
        public int CheckIsGoverment(string UserId,string UserPwd)
        {
             /*账号密码是否错误*/
             string sqlOne = String.Format("SELECT count(*)   FROM  [Family].[dbo].[tblUserLogin] where [LoginUser]='{0}' and [LoginPwd]='{1}' ", UserId, UserPwd);
              sqlOne = CarryOutSqlGetFirstColmun(sqlOne);
             if (sqlOne != "1") return -1;
             /*是否拥有权限*/
             string sql= String.Format("SELECT count(*)   FROM  [Family].[dbo].[tblUserLogin] where [LoginUser]='{0}' and [LoginPwd]='{1}' and  [Loginstate]=30 ", UserId, UserPwd);
             sql = CarryOutSqlGetFirstColmun(sql);
             if (sql!="1") 
            {  return 0; }
            else{  return 1;}
        }
        /// <summary>
        /// 判断用户是否为普通用户
        /// </summary>
        /// <param name="UserId">用户账号</param>
        /// <param name="UserPwd">用户密码</param>
        /// <returns>返回1表示密码账号正确/且是管理员  返回0  密码或者账号错误！ 返回-1 账号密码正确 但是不是普通用户</returns>
        public int CheckIsUser(string UserId, string UserPwd)
        {
            /*账号密码是否错误*/
            string sqlOne = String.Format("SELECT count(*) FROM  [Family].[dbo].[tblUserLogin] where LoginUser='{0}' and LoginPwd='{1}' ", UserId, UserPwd);
            int result = Convert.ToInt32(CarryOutSqlGetFirstColmun(sqlOne));
            if (result!=1) return -1;
            /*是否拥有权限*/
            string sql = String.Format("SELECT count(*)   FROM  [Family].[dbo].[tblUserLogin] where LoginUser='{0}' and LoginPwd='{1}' and  Loginstate=20", UserId, UserPwd);
            sql = CarryOutSqlGetFirstColmun(sql);
            if (sql != "1")
            { return 0; }
            else { return 1; }
        }
    }
}

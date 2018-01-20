using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace FamilyConsole
{

    class Rule
    {
        /// <summary>
        /// 拥有儿子的合理性
        /// 1.年龄小于十岁不可以拥有儿子
        /// 2.未有婚配不可以拥有儿子
        /// 3.儿子出生日期 必修在父亲壮年 10岁到死亡的时间
        /// </summary>
        /// <returns></returns>
        public bool CheckCanHaveSon(DateTime dtSnoBirth,int FatherId)
        {
            dbConnection Get =new dbConnection();
            //父亲出生日期
            DateTime dt = Convert.ToDateTime(Get.CarryOutSqlGetFirstColmun(String.Format("  select NiBirthDay from [Family].[dbo].[tblNumberInfo] where NiId ={0}",FatherId)));
            int NianLingFather=Convert.ToInt32(Get.CarryOutSqlGetFirstColmun(String.Format("select 年龄 from [Family].[dbo].[vwNumberInfo] where NiId ={0}",FatherId)));
            //年龄 
            DateTime dtmin = dt.AddYears(10);
            DateTime max = dt.AddYears(NianLingFather);
            if (dtSnoBirth > max || dtSnoBirth < dtmin)
            {
                return false;
            }
            //最大时间
            return true;
        }
        /// <summary>
        /// 配偶的出生日期必须在本人的健在时间段内
        /// </summary>
        /// <param name="dtPeiOuBirth"></param>
        /// <param name="FatherId"></param>
        /// <returns></returns>
        public bool CheckHavePeiOu(DateTime dtPeiOuBirth, int FatherId)
        {
            dbConnection Get = new dbConnection();
            //父亲出生日期
            DateTime dt = Convert.ToDateTime(Get.CarryOutSqlGetFirstColmun(String.Format("  select NiBirthDay from [Family].[dbo].[tblNumberInfo] where NiId ={0}", FatherId)));
            int NianLingFather = Convert.ToInt32(Get.CarryOutSqlGetFirstColmun(String.Format("select 年龄 from [Family].[dbo].[vwNumberInfo] where NiId ={0}", FatherId)));
            //年龄     
            DateTime dtmin = dt.AddYears(0);
            DateTime max = dt.AddYears(NianLingFather);
            if (dtPeiOuBirth > max || dtPeiOuBirth < dtmin)
            {
                return false;
            }
            return true;
        }
    }
}

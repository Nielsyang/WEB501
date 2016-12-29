using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using System.Data;
using System.Data.SqlClient;
using WebPlat.Commons;

namespace DAL
{
    public class AnalyseInfoDAL
    {   
        public void PushAnalyseInfo(string UserIp, string SelectedItem, string Category)
        {
            string datetime = System.DateTime.Now.ToString();
            string sql = "insert into user_information_page2([user_ip], [date_time], [select_item], [item_category]) values(@U_ip, @D_time, @S_item, @I_cate)";
            SqlHelper.ExecuteScalar(sql, new SqlParameter("@U_ip", UserIp), new SqlParameter("@D_time", datetime), new SqlParameter("@S_item", SelectedItem),new SqlParameter("@I_cate", Category));
        }
    }
}

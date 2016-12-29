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
    public class UserInfoDAL
    {
        public void PushUserInfo(string UserIp)
        {
            string datetime = System.DateTime.Now.ToString();
            string sql = "insert into user_information_page1([user_ip], [date_time]) values(@U_ip, @D_time)";
            SqlHelper.ExecuteScalar(sql, new SqlParameter("@U_ip", UserIp), new SqlParameter("@D_time", datetime));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;

namespace BLL
{
    public class UserInfoBLL
    {
        private UserInfoDAL push_userinfo = new UserInfoDAL();
        public void PushUserInfo(string UserIp)
        {
            push_userinfo.PushUserInfo(UserIp);
        }
    }
}

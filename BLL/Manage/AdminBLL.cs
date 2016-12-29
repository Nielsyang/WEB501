using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Manage;
using MODEL.Manage;

namespace BLL.Manage
{
    public class AdminBLL
    {
        public bool CheckLogin(string username, string password)
        {
            return new AdminDAL().checkLogin(username, password);
        }
        public Admin  Add(Admin admin)
        {
            return new AdminDAL().Add(admin);
        }

        public int DeleteById(int id)
        {
            return new AdminDAL().DeleteById(id);
        }
        public int DeleteAdmin(Admin admin)
        {
            return new AdminDAL().DeleteAdmin(admin);
        }
        public int Update(Admin admin)
        {
            return new AdminDAL().Update(admin);
        }


        public Admin GetById(int id)
        {
            return new AdminDAL().GetById(id);
        }
        public int GetTotalCount()
        {
            return new AdminDAL().GetTotalCount();
        }

        public List<Admin> GetPagedData(int minrownum, int maxrownum)
        {
            return new AdminDAL().GetPagedData(minrownum, maxrownum);
        }

        public List<Admin> GetAll()
        {
            return new AdminDAL().GetAll();
        }
    }
}
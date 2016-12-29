using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Manage;
using MODEL.Manage;

namespace BLL.Manage
{
    public class WebSiteBLL
    {
        public WebSite  Add(WebSite website)
        {
            return new WebSiteDAL().Add(website);
        }

        public int DeleteByid(int id)
        {
            return new WebSiteDAL().DeleteByid(id);
        }

        public int Update(WebSite website)
        {
            return new WebSiteDAL().Update(website);
        }


        public WebSite GetByid(int id)
        {
            return new WebSiteDAL().GetByid(id);
        }
        public int GetTotalCount()
        {
            return new WebSiteDAL().GetTotalCount();
        }

        public List<WebSite> GetPagedData(int minrownum, int maxrownum)
        {
            return new WebSiteDAL().GetPagedData(minrownum, maxrownum);
        }

        public List<WebSite> GetAll()
        {
            return new WebSiteDAL().GetAll();
        }
    }
}

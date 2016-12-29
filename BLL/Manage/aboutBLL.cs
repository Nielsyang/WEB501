using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MODEL.Manage;
using DAL.Manage;
namespace BLL.Manage
{
    public partial class AboutManager
    {
        public About Add(About about)
        {
            return new AboutService().Add(about);
        }

        public int DeleteById(int id)
        {
            return new AboutService().DeleteById(id);
        }
        public int DeleteAbout(About about)
        {
            return new AboutService().DeleteAbout(about);
        }

        public int Update(About about)
        {
            return new AboutService().Update(about);
        }


        public About GetById(int id)
        {
            return new AboutService().GetById(id);
        }
        public int GetTotalCount()
        {
            return new AboutService().GetTotalCount();
        }

        public List<About> GetPagedData(int startRowIndex, int maximumRows)
        {
            return new AboutService().GetPagedData(startRowIndex, maximumRows);
        }

        public List<About> GetAll()
        {
            return new AboutService().GetAll();
        }
    }
}
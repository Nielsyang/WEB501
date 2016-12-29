using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.Manage;
using DAL.Manage;

namespace BLL.Manage
{
    public class PublicationBLL
    {
        public Publication Add(Publication publication)
        {
            return new PublicationDAL().Add(publication);
        }

        public int DeleteByid(int id)
        {
            return new PublicationDAL().DeleteByid(id);
        }

        public int Update(Publication publication)
        {
            return new PublicationDAL().Update(publication);
        }


        public Publication GetByid(int id)
        {
            return new PublicationDAL().GetByid(id);
        }
        public int GetTotalCount()
        {
            return new PublicationDAL().GetTotalCount();
        }

        public List<Publication> GetPagedData(int minrownum, int maxrownum)
        {
            return new PublicationDAL().GetPagedData(minrownum, maxrownum);
        }

        public List<Publication> GetAll()
        {
            return new PublicationDAL().GetAll();
        }
    }
}

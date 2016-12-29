using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.Manage;
using DAL.Manage;

namespace BLL.Manage
{
    public class DownloadBLL
    {
        public  FileDownload Add(FileDownload download)
        {
            return new DownLoadDAL().Add(download);
        }

        public int DeleteByid(int id)
        {
            return new DownLoadDAL().DeleteByid(id);
        }

        public int Update(FileDownload download)
        {
            return new DownLoadDAL().Update(download);
        }


        public FileDownload GetByid(int id)
        {
            return new DownLoadDAL().GetByid(id);
        }
        public int GetTotalCount()
        {
            return new DownLoadDAL().GetTotalCount();
        }

        public List<FileDownload> GetPagedData(int minrownum, int maxrownum)
        {
            return new DownLoadDAL().GetPagedData(minrownum, maxrownum);
        }

        public List<FileDownload> GetAll()
        {
            return new DownLoadDAL().GetAll();
        }
    }
}

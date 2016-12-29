using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;

namespace BLL
{
    public class AnalyseInfoBLL
    {
        private AnalyseInfoDAL push_analyseinfo = new AnalyseInfoDAL();
        public void PushAnalyseInfo(string UserIp, string SelectedItem, string Category)
        {
            push_analyseinfo.PushAnalyseInfo(UserIp, SelectedItem, Category);
        }
    }
}

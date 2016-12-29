using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;

namespace BLL
{
    public class NetBLL
    {
        private NetDAL net_dal = new NetDAL();
        public string GetNodes()
        {
            return net_dal.GetNodes();
        }
        public void Generate_Net(string formula, string herb, string disease, string tissue, float ptvalue, float pdvalue)
        {
            net_dal.Generate_Net(formula, herb, disease, tissue, ptvalue, pdvalue);
        }
        public string[] GetNodeNums(string AnalyseType, int num)
        {
            return net_dal.GetNodeNums(AnalyseType, num);
        }
        public string GetLinks()
        {
            return net_dal.GetLinks();
        }
    }
}

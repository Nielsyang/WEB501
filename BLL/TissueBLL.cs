using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using DAL;


namespace BLL
{
    public class TissueBLL
    {
        private TissueDAL tissue_display = new TissueDAL();
        public List<Model> GetAllTissue()
        {
            return tissue_display.GetAllTissue();
        }
        public string GetAllTissueName()
        {
            return tissue_display.GetAllTissueName();
        }
    }
}
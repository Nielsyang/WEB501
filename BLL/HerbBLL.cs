using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using DAL;


namespace BLL
{
    public class HerbBLL
    {
        private HerbDAL herb_displayNameDal = new HerbDAL();
        public List<Model> GetAllHerb()
        {
            return herb_displayNameDal.GetAllHerb();
        }
        public string GetAllHerbName()
        {
            return herb_displayNameDal.GetAllHerbName();
        }
        public string GetAllHerbName_Cn()
        {
            return herb_displayNameDal.GetAllHerbName_Cn();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL.Client;
using DAL.Client;

namespace WebPlat.BLL
{
    public class DiseaseBll
    {
        DiseaseDal diseasedal = new DiseaseDal();
        public  IEnumerable<DiseaseModel> getAllRoot()
        {
            return diseasedal.getAll();
        }
        public IEnumerable<Disease_ALL> getDiseasesByCategory(string Category)
        {
            return diseasedal.getDiseaseByCategory(Category);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using MODEL;
using WebPlat.Commons;
using System.Text;

namespace DAL
{
    public class TissueDAL
    {
        public List<Model> GetAllTissue()
        {
            string sql = "select Tissue_Id,Tissue_Name from Tissue order by Tissue_Name";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableConvertToModel(dt);
        }
        public string GetAllTissueName()
        {
            string sql = "select Tissue_Name from Tissue order by Tissue_Name";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableToString(dt);
        }
        public string TableToString(DataTable dt)
        {
            string res = "";
            if (dt.Rows.Count == 0)
                return res;
            foreach (DataRow dr in dt.Rows)
            {
                res += dr["Tissue_Name"].ToString() + ",";
            }

            return res.Substring(0, res.Length - 1);
        }
        public List<Model> TableConvertToModel(DataTable dt)
        {
            List<Model> listModel = new List<Model>();
            foreach (DataRow dr in dt.Rows)
            {
                Model model = new Model();
                model.ModelId = Convert.ToInt32(dr["Tissue_Id"]);
                model.ModelName = dr["Tissue_Name"].ToString();
                listModel.Add(model);
            }
            return listModel;
        }
    }
}

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
    public class HerbDAL
    {
        public List<Model> GetAllHerb()
        {
            string sql = "select Herb_Id,Herb_Name from Herb_updated order by Herb_Name";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableConvertToModel(dt);
        }
        public string GetAllHerbName()
        {
            string sql = "select name from All_Herb_Name";
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
                res += dr["name"].ToString() + ",";
            }

            return res.Substring(0, res.Length - 1);
        }
        public string GetAllHerbName_Cn()
        {
            string sql = "select Herb_Name from Herb_updated";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableToString_Cn(dt);
        }
        public string TableToString_Cn(DataTable dt)
        {
            string res = "";
            if (dt.Rows.Count == 0)
                return res;
            foreach (DataRow dr in dt.Rows)
            {
                res += dr["Herb_Name"].ToString() + ",";
            }

            return res.Substring(0, res.Length - 1);
        }
        public List<Model> TableConvertToModel(DataTable dt)
        {
            List<Model> listModel = new List<Model>();
            foreach (DataRow dr in dt.Rows)
            {
                Model model = new Model();
                model.ModelId = Convert.ToInt32(dr["Herb_Id"]);
                model.ModelName = dr["Herb_Name"].ToString();
                listModel.Add(model);
            }
            return listModel;
        }
    }
}

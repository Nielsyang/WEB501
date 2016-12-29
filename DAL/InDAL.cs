using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using System.Data.SqlClient;
using System.Data;
using WebPlat.Commons;

namespace DAL
{
    public class InDAL
    {
        public List<Edge_displayName> GetInByHerbIdandPValue(int herbId, string pValue)
        {
            string procName = "GetSingleByIdandPvalue";
            string type = "In";
            SqlParameter typePara = new SqlParameter("@Type",type);
            SqlParameter idPara = new SqlParameter("@Id",herbId);
            SqlParameter pValuePara = new SqlParameter("@Pvalue", pValue);
            DataTable dt = SqlHelper.ExecuteStoredProcedureTable(procName, typePara, idPara, pValuePara);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            return TableConvertToList(dt);
        }
        public List<Edge_displayName> TableConvertToList(DataTable dt)
        {
            List<Edge_displayName> list = new List<Edge_displayName>();
            foreach (DataRow dr in dt.Rows)
            {
                Edge_displayName edge = new Edge_displayName();
                edge.DB_ID_displayName=dr["DB_ID_displayName"].ToString();
                edge.HasEvent_displayName=dr["hasEvent_displayName"].ToString();
                list.Add(edge);
            }
            return list;
        }
        public string GetInName(int HerbId)
        {
            string sql = "select distinct Herb_Name from [Herb] where Herb_Id=@Herb_Id";
            return (string)SqlHelper.ExecuteScalar(sql, new SqlParameter("@Herb_Id", HerbId));
        }
        public List<Model> GetAllHerb()
        {
            string sql = "select Herb_Id,Herb_Name from Herb";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableConvertToModel(dt);
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

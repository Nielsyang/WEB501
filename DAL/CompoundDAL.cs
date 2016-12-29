using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MODEL;
using WebPlat.Commons;

namespace DAL
{
    public class CompoundDAL
    {
        public List<Edge_displayName> GetCompoundByCompoundandPValue(int compoundId, string pValue)
        {
            string procName = "GetSingleByIdandPvalue";
            string type = "Compound";
            SqlParameter typePara = new SqlParameter("@Type",type);
            SqlParameter idPara = new SqlParameter("@Id",compoundId);
            SqlParameter pValuePara = new SqlParameter("@Pvalue", pValue);
            DataTable dt = SqlHelper.ExecuteStoredProcedureTable(procName,typePara,idPara,pValuePara);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            return TableConvertToList(dt);
        }
        public List<Edge_displayName> TableConvertToList(DataTable dt)
        {
            List<Edge_displayName> list = new List<Edge_displayName>();
            foreach(DataRow dr in dt.Rows)
            {
                Edge_displayName edge = new Edge_displayName();
                edge.DB_ID_displayName=dr["DB_ID_displayName"].ToString();
                edge.HasEvent_displayName=dr["hasEvent_displayName"].ToString();
                list.Add(edge);
            }
            return list;
        }
        public string GetCompoundName(int compoundId)
        {
            string sql = "select compound_Name from [Compound] where compound_Id=@compoundId";
            return (string)SqlHelper.ExecuteScalar(sql,new SqlParameter("@compoundId",compoundId));
        }
        public List<Model> GetAllCompound()
        {
            string sql = "select compound_Id,compound_Name from Compound order by compound_Name";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableConvertToModel(dt);
        }
        public string GetAllCompoundName()
        {
            string sql = "select name from All_Compound_Name";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableConvertToString(dt);
        }
        public string TableConvertToString(DataTable dt)
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
        public List<Model> TableConvertToModel(DataTable dt)
        {
            List<Model> listModel = new List<Model>();
            foreach (DataRow dr in dt.Rows)
            {
                Model model = new Model();
                model.ModelId=Convert.ToInt32(dr["compound_Id"]);
                model.ModelName = dr["compound_Name"].ToString();
                listModel.Add(model);
            }
            return listModel;
        }

    }
}

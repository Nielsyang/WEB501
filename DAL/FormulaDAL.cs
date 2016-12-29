using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using System.Data;
using System.Data.SqlClient;
using WebPlat.Commons;

namespace DAL
{
    public class FormulaDAL
    {
        public List<Model> GetAllFormula()
        {
            string sql = "select F_Id,F_name from Formula_updated order by F_name";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableConvertToModel(dt);
        }
        public string GetAllFormulaName()
        {
            string sql = "select F_name from Formula_updated order by F_name";
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
                res += dr["F_Name"].ToString() + ",";
            }

            return res.Substring(0, res.Length - 1);
        }
        public List<Model> TableConvertToModel(DataTable dt)
        {
            List<Model> listModel = new List<Model>();
            foreach (DataRow dr in dt.Rows)
            {
                Model model = new Model();
                model.ModelId = Convert.ToInt32(dr["F_Id"]);
                model.ModelName = dr["F_name"].ToString();
                listModel.Add(model);
            }
            return listModel;
        }
        public string GetFormuName(int formulaId)
        {
            string sql = "select distinct F_name from [Formula] where F_Id=@F_Id";
            return (string)SqlHelper.ExecuteScalar(sql, new SqlParameter("@F_Id", formulaId));
        }
        public List<Model> GetHerbsByFormulaId(int formulaId)
        {
            string sql = @"select A.Herb_Id as F_Id,A.Herb_Name as F_name
                             from Herb A,
                                  FormulatoHerb B
                             where A.Herb_Id=B.Herb_Id
                                  and B.F_Id=@formulaId";
            SqlParameter formulaIdPara = new SqlParameter("@formulaId", formulaId);
            DataTable dt = SqlHelper.ExecuteDataTable(sql, formulaIdPara);
            return TableConvertToModel(dt);
        }
        public List<Edge_displayName> GetFormulaByFormulaandPValue(int formulaId, string pValue)
        {
            string procName = "GetSingleByIdandPvalue";
            string type = "Formula";
            SqlParameter typePara = new SqlParameter("@Type",type);
            SqlParameter idPara = new SqlParameter("@Id",formulaId);
            SqlParameter pValuePara = new SqlParameter("@Pvalue",pValue);
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
                edge.DB_ID_displayName = dr["DB_ID_displayName"].ToString();
                edge.HasEvent_displayName = dr["hasEvent_displayName"].ToString();
                list.Add(edge);
            }
            return list;
        }
    }
}

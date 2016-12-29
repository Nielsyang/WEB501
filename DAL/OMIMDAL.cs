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
    public class OMIMDAL
    {
        public List<Edge_displayName> GetOMIMByDiseaseIdandPValue(int diseaseId, string pValue)
        {
            //执行存储过程
            string procName = "GetSingleByIdandPvalue";
            string Type = "OMIM";
            SqlParameter typePara = new SqlParameter("@Type",Type);
            SqlParameter idPara = new SqlParameter("@Id",diseaseId);
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
        public string GetDiseaseName(int DiseaseId)
        {
            string sql = "select distinct Name_En from [Disease_Id_Name] where DiseaseId=@DiseaseId";
            return (string)SqlHelper.ExecuteScalar(sql, new SqlParameter("@DiseaseId", DiseaseId));
        }
        public string GetDiseaseNameEnFromCn(string namecn)
        {
            string sql = "select Name_En from [Disease_Id_Name] where Name_Cn=@namecn";
            return (string)SqlHelper.ExecuteScalar(sql, new SqlParameter("@namecn", namecn));
        }
        public string GetDiseaseNameCnFromEn(string nameen)
        {
            string sql = "select Name_Cn from [Disease_Id_Name] where Name_En=@nameen";
            return (string)SqlHelper.ExecuteScalar(sql, new SqlParameter("@nameen", nameen));
        }
        public List<Model> GetAllDisease()
        {
            string sql="select distinct DiseaseId,Name_En from Disease_Id_Name";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableConvertToModel(dt);
        }

        public List<Model> GetAllDisease_Cn()
        {
            string sql = "select distinct DiseaseId,Name_Cn from Disease_Id_Name order by Name_Cn";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableConvertToModel_Cn(dt);
        }

        public string GetAllDiseaseName()
        {
            string sql = "select distinct Name_Cn,Name_En from Disease_Id_Name";
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
                res += dr["Name_Cn"].ToString() + "," + dr["Name_En"].ToString() + ",";
            }

            return res.Substring(0, res.Length - 1);
        }
        public List<Model> TableConvertToModel(DataTable dt)
        {
            List<Model> listModel = new List<Model>();
            foreach (DataRow dr in dt.Rows)
            {
                Model model = new Model();
                model.ModelId = Convert.ToInt32(dr["DiseaseId"]);
                model.ModelName = dr["Name_En"].ToString();
                listModel.Add(model);
            }
            return listModel;
        }

        public List<Model> TableConvertToModel_Cn(DataTable dt)
        {
            List<Model> listModel = new List<Model>();
            foreach (DataRow dr in dt.Rows)
            {
                Model model = new Model();
                model.ModelId = Convert.ToInt32(dr["DiseaseId"]);
                model.ModelName = dr["Name_Cn"].ToString();
                listModel.Add(model);
            }
            return listModel;
        }
    }
}

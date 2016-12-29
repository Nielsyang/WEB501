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
    public class GetUnionDAL
    {
        public List<Edge_displayName> GetCompoundandDiseaseUnionSimple(int diseaseId, int compoundId,out string pDisease,out string pCompound)
        {
            string procName = "GetCompoundandDiseaseUnion";
            SqlParameter diseasePara = new SqlParameter("@DiseaseId",diseaseId);
            SqlParameter compoundPara = new SqlParameter("@CompoundId",compoundId);
            SqlParameter pDiseasePara = new SqlParameter("@PDisease",SqlDbType.NVarChar,20);
            pDiseasePara.Direction = ParameterDirection.Output;
            SqlParameter pCompoundPara = new SqlParameter("@PCompound",SqlDbType.NVarChar,20);
            pCompoundPara.Direction = ParameterDirection.Output;
            DataTable dt = SqlHelper.ExecuteStoredProcedureTable(procName, diseasePara, compoundPara, pDiseasePara, pCompoundPara);
            if (dt.Rows.Count <= 0)
            {
                pDisease = string.Empty;
                pCompound = string.Empty;
                return null;
            }
            pDisease = pDiseasePara.Value.ToString();
            pCompound = pCompoundPara.Value.ToString();
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
        public List<Edge_displayName> GetCompoundorHerbandDiseaseUnion(string type, int diseaseId, int compoundIdorHerbId, string pDisease, string pCompoundorPHerb)
        {
            string procName = "GetUnionByPvalue";
            SqlParameter typePara = new SqlParameter("@Type",type);
            SqlParameter diseasePara = new SqlParameter("@DiseaseId", diseaseId);
            SqlParameter compoundPara = new SqlParameter("@CompoundIdorHerbId", compoundIdorHerbId);
            SqlParameter pDiseasePara = new SqlParameter("@PDisease", pDisease);
            SqlParameter pCompoundPara = new SqlParameter("@PCompoundorPHerb",pCompoundorPHerb);
            DataTable dt = SqlHelper.ExecuteStoredProcedureTable(procName, typePara, diseasePara, compoundPara, pDiseasePara, pCompoundPara);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            return TableConvertToList(dt);
        }
    } 
}

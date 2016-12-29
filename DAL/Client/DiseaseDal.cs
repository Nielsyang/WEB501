using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebPlat.Commons;
using MODEL.Client;

namespace DAL.Client
{
    public class DiseaseDal
    {
        public IEnumerable<DiseaseModel> getAll()
        {
            var list = new List<DiseaseModel>();
            string sql = "SELECT * FROM  Disease_has_Name_Root";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				while(reader.Read())
				{
					list.Add(ToModelRoot(reader));
				}				
			}
			return list;
        }
        public IEnumerable<Disease_ALL> getDiseaseByCategory(string category)
        {
            var list = new List<Disease_ALL>();
            string sql = "select  * from  Disease_has_Name where Name_Cn=@Name_Cn";
            using(SqlDataReader reader=SqlHelper.ExecuteDataReader(sql,new SqlParameter("@Name_Cn",category)))
            {
                   while(reader.Read())
                   {
                       list.Add(ToModelDiseaseAll(reader));
                   }
            }
            return list;
        }
     
        public DiseaseModel ToModelRoot(SqlDataReader reader)
        {
            DiseaseModel disease = new DiseaseModel();
            disease.row =(long)ToModelValue(reader, "row");
            disease.Name_Cn =(string ) ToModelValue(reader, "Name_Cn");
            return disease;
            

        }
        public Disease_ALL ToModelDiseaseAll(SqlDataReader reader)
        {
            Disease_ALL diseaseall = new Disease_ALL();
            diseaseall.id = (int)ToModelValue(reader,"ID");
            diseaseall.Name_Cn = (string)ToModelValue(reader,"Name_Cn");
            diseaseall.Name_En = (string)ToModelValue(reader,"Name_En");
            diseaseall.has_Name_Cn = (string)ToModelValue(reader,"has_Name_Cn");
            diseaseall.has_Name_En = (string)ToModelValue(reader,"has_Name_En");
            diseaseall.Category = (string)ToModelValue(reader,"Category");
            return diseaseall;
        }
        public object ToModelValue(SqlDataReader reader, string columnName)
        {
            if (reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return null;
            }
            else
            {
                return reader[columnName];
            }
        }
    }
}
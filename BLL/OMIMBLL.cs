using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using DAL;

namespace BLL
{
    public class OMIMBLL
    {
        private OMIMDAL omim_displayNameDal = new OMIMDAL();
        public List<Edge_displayName> GetOMIMByDiseaseIdandPValue(int diseaseId, string pValue)
        {
            return omim_displayNameDal.GetOMIMByDiseaseIdandPValue(diseaseId,pValue);
        }
        public string GetDiseaseName(int DiseaseId)
        {
            return omim_displayNameDal.GetDiseaseName(DiseaseId);
        }
        public string GetDiseaseNameEnFromCn(string namecn)
        {
            return omim_displayNameDal.GetDiseaseNameEnFromCn(namecn);
        }
        public string GetDiseaseNameCnFromEn(string nameen)
        {
            return omim_displayNameDal.GetDiseaseNameCnFromEn(nameen);
        }
        public List<Model> GetAllDisease()
        {
            return omim_displayNameDal.GetAllDisease();
        }
        public List<Model> GetAllDisease_Cn()
        {
            return omim_displayNameDal.GetAllDisease_Cn();
        }
        public string GetAllDiseaseName()
        {
            return omim_displayNameDal.GetAllDiseaseName();
        }
        public string GetDiseaseJson(int diseaseId, string pValue,string diseaseName)
        {
            List<Edge_displayName> listEdges = GetOMIMByDiseaseIdandPValue(diseaseId,pValue);
            if (listEdges == null)
            {
                return null;
            }
            List<string> listNodes = Common.GetNodesByEdges(listEdges);
            StringBuilder DiseaseJson = new StringBuilder("{");
            for (int i = 0; i < listNodes.Count; i++)
            {
                List<string> Depend = new List<string>();
                List<string> DependOnBy = new List<string>();
                StringBuilder docs = new StringBuilder();
                docs.Append("<h2>" + listNodes[i]);
                DiseaseJson.Append("\"" + listNodes[i] + "\":");
                DiseaseJson.Append("{\"name\":" + "\"" + listNodes[i] + "\",");
                docs.Append("<em>" + diseaseName + "</em></h2>");
                docs.Append("<div class=\\\"alert alert-warning\\\">No documentation for this object</div>");
                DiseaseJson.Append("\"type\":\"" + diseaseName + "\",\"depends\":[");//属于OMIM
                for (int j = 0; j < listEdges.Count; j++)
                {
                    if (listEdges[j].HasEvent_displayName == listNodes[i])
                    {
                        Depend.Add(listEdges[j].DB_ID_displayName);
                    }
                    if (listEdges[j].DB_ID_displayName == listNodes[i])
                    {
                        DependOnBy.Add(listEdges[j].HasEvent_displayName);
                    }
                }
                if (Depend.Count != 0)
                {
                    docs.Append("<h3>Depends on</h3>");
                    docs.Append("<ul>");
                    for (int k = 0; k < Depend.Count; k++)
                    {
                        DiseaseJson.Append("\"" + Depend[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + Depend[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + Depend[k] + "\\\">" + Depend[k] + "</a></li>");
                    }
                    docs.Append("</ul>");
                    DiseaseJson.Remove(DiseaseJson.Length - 1, 1).Append("],\"dependedOnBy\":[");
                }
                else
                {
                    docs.Append("<h3>Depends on<em>(none)</em></h3>");
                    DiseaseJson.Append("],\"dependedOnBy\":[");
                }
                if (DependOnBy.Count != 0)
                {
                    docs.Append("<h3>Depended on by</h3>");
                    docs.Append("<ul>");
                    for (int k = 0; k < DependOnBy.Count; k++)
                    {
                        DiseaseJson.Append("\"" + DependOnBy[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + DependOnBy[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + DependOnBy[k] + "\\\">" + DependOnBy[k] + "</a></li>");
                    }
                    docs.Append("<ul>");
                    DiseaseJson.Remove(DiseaseJson.Length - 1, 1).Append("]");
                    DiseaseJson.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
                else
                {
                    docs.Append("<h3>Depended on by<em>(none)</em></h3>");
                    DiseaseJson.Append("]");
                    DiseaseJson.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
            }
            DiseaseJson.Remove(DiseaseJson.Length - 1, 1).Append("}");
            return DiseaseJson.ToString();
        }
    }
}

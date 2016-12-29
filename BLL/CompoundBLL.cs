using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;

namespace BLL
{
    public class CompoundBLL
    {
        private CompoundDAL compound_displayNameDal = new CompoundDAL();
        public List<Edge_displayName> GetCompoundByCompoundandPValue(int compoundId, string pValue)
        {
            return compound_displayNameDal.GetCompoundByCompoundandPValue(compoundId,pValue);
        }
        public string GetCompoundName(int compoundId)
        {
            return compound_displayNameDal.GetCompoundName(compoundId);
        }
        public List<Model> GetAllCompound()
        {
            return compound_displayNameDal.GetAllCompound();
        }
        public string GetAllCompoundName()
        {
            return compound_displayNameDal.GetAllCompoundName();
        }
        public string GetCompoundJson(int compoundId, string pValue, string compoundName)
        {
            List<Edge_displayName> listEdges = GetCompoundByCompoundandPValue(compoundId,pValue);
            if (listEdges == null)
            {
                return null;
            }
            List<string> listNodes = Common.GetNodesByEdges(listEdges);
            StringBuilder CompoundJson = new StringBuilder("{");
            for (int i = 0; i < listNodes.Count; i++)
            {
                List<string> Depend = new List<string>();
                List<string> DependOnBy = new List<string>();
                StringBuilder docs = new StringBuilder();
                docs.Append("<h2>" + listNodes[i]);
                CompoundJson.Append("\"" + listNodes[i] + "\":");
                CompoundJson.Append("{\"name\":" + "\"" + listNodes[i] + "\",");
                docs.Append("<em>" + compoundName + "</em></h2>");
                docs.Append("<div class=\\\"alert alert-warning\\\">No documentation for this object</div>");
                CompoundJson.Append("\"type\":\"" + compoundName + "\",\"depends\":[");//属于OMIM
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
                        CompoundJson.Append("\"" + Depend[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + Depend[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + Depend[k] + "\\\">" + Depend[k] + "</a></li>");
                    }
                    docs.Append("</ul>");
                    CompoundJson.Remove(CompoundJson.Length - 1, 1).Append("],\"dependedOnBy\":[");
                }
                else
                {
                    docs.Append("<h3>Depends on<em>(none)</em></h3>");
                    CompoundJson.Append("],\"dependedOnBy\":[");
                }
                if (DependOnBy.Count != 0)
                {
                    docs.Append("<h3>Depended on by</h3>");
                    docs.Append("<ul>");
                    for (int k = 0; k < DependOnBy.Count; k++)
                    {
                        CompoundJson.Append("\"" + DependOnBy[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + DependOnBy[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + DependOnBy[k] + "\\\">" + DependOnBy[k] + "</a></li>");
                    }
                    docs.Append("<ul>");
                    CompoundJson.Remove(CompoundJson.Length - 1, 1).Append("]");
                    CompoundJson.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
                else
                {
                    docs.Append("<h3>Depended on by<em>(none)</em></h3>");
                    CompoundJson.Append("]");
                    CompoundJson.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
            }
            CompoundJson.Remove(CompoundJson.Length - 1, 1).Append("}");
            return CompoundJson.ToString();
        }
    }
}

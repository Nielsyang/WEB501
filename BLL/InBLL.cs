using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;

namespace BLL
{
    public class InBLL
    {
        private InDAL in_displayNameDal = new InDAL();
        public List<Edge_displayName> GetInByHerbIdandPValue(int herbId, string pValue)
        {
            return in_displayNameDal.GetInByHerbIdandPValue(herbId,pValue);
        }
        public string GetInName(int HerbId)
        {
            return in_displayNameDal.GetInName(HerbId);
        }
        public List<Model> GetAllHerb()
        {
             return in_displayNameDal.GetAllHerb();
        }
        public string GetHerbJson(int herbId,string pValue,string herbName)
        {
            List<Edge_displayName> listEdges = GetInByHerbIdandPValue(herbId,pValue);
            if (listEdges == null)
            {
                return null;
            }
            List<string> listNodes=Common.GetNodesByEdges(listEdges);
            StringBuilder HerbJson = new StringBuilder("{");
            for (int i = 0; i < listNodes.Count; i++)
            {
                List<string> Depend = new List<string>();
                List<string> DependOnBy = new List<string>();
                StringBuilder docs = new StringBuilder();
                docs.Append("<h2>" + listNodes[i]);
                HerbJson.Append("\"" + listNodes[i] + "\":");
                HerbJson.Append("{\"name\":" + "\"" + listNodes[i] + "\",");
                docs.Append("<em>" + herbName + "</em></h2>");
                docs.Append("<div class=\\\"alert alert-warning\\\">No documentation for this object</div>");
                HerbJson.Append("\"type\":\"" + herbName + "\",\"depends\":[");//属于OMIM
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
                        HerbJson.Append("\"" + Depend[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + Depend[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + Depend[k] + "\\\">" + Depend[k] + "</a></li>");
                    }
                    docs.Append("</ul>");
                    HerbJson.Remove(HerbJson.Length - 1, 1).Append("],\"dependedOnBy\":[");
                }
                else
                {
                    docs.Append("<h3>Depends on<em>(none)</em></h3>");
                    HerbJson.Append("],\"dependedOnBy\":[");
                }
                if (DependOnBy.Count != 0)
                {
                    docs.Append("<h3>Depended on by</h3>");
                    docs.Append("<ul>");
                    for (int k = 0; k < DependOnBy.Count; k++)
                    {
                        HerbJson.Append("\"" + DependOnBy[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + DependOnBy[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + DependOnBy[k] + "\\\">" + DependOnBy[k] + "</a></li>");
                    }
                    docs.Append("<ul>");
                    HerbJson.Remove(HerbJson.Length - 1, 1).Append("]");
                    HerbJson.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
                else
                {
                    docs.Append("<h3>Depended on by<em>(none)</em></h3>");
                    HerbJson.Append("]");
                    HerbJson.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
            }
            HerbJson.Remove(HerbJson.Length - 1, 1).Append("}");
            return HerbJson.ToString();
        }
    }
}

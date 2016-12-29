using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;

namespace BLL
{
    public class FormulaBLL
    {
        private FormulaDAL formulaDal = new FormulaDAL();
        public List<Model> GetAllFormula()
        {
            return formulaDal.GetAllFormula();
        }
        public string GetAllFormulaName()
        {
            return formulaDal.GetAllFormulaName();
        }
        public List<Model> GetHerbsByFormulaId(int formulaId)
        {
            return formulaDal.GetHerbsByFormulaId(formulaId);
        }
        public List<Edge_displayName> GetFormulaByFormulaandPValue(int formulaId, string pValue)
        {
            return formulaDal.GetFormulaByFormulaandPValue(formulaId,pValue);
        }
        public string GetFormulaJson(int formulaId, string pValue, string formulaName)
        {
            List<Edge_displayName> listEdges = GetFormulaByFormulaandPValue(formulaId,pValue);
            if (listEdges == null)
            {
                return null;
            }
            List<string> listNodes = Common.GetNodesByEdges(listEdges);
            StringBuilder formulaJson = new StringBuilder("{");
            for (int i = 0; i < listNodes.Count; i++)
            {
                List<string> Depend = new List<string>();
                List<string> DependOnBy = new List<string>();
                StringBuilder docs = new StringBuilder();
                docs.Append("<h2>" + listNodes[i]);
                formulaJson.Append("\"" + listNodes[i] + "\":");
                formulaJson.Append("{\"name\":" + "\"" + listNodes[i] + "\",");
                docs.Append("<em>" + formulaName + "</em></h2>");
                docs.Append("<div class=\\\"alert alert-warning\\\">No documentation for this object</div>");
                formulaJson.Append("\"type\":\"" + formulaName + "\",\"depends\":[");//属于OMIM
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
                        formulaJson.Append("\"" + Depend[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + Depend[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + Depend[k] + "\\\">" + Depend[k] + "</a></li>");
                    }
                    docs.Append("</ul>");
                    formulaJson.Remove(formulaJson.Length - 1, 1).Append("],\"dependedOnBy\":[");
                }
                else
                {
                    docs.Append("<h3>Depends on<em>(none)</em></h3>");
                    formulaJson.Append("],\"dependedOnBy\":[");
                }
                if (DependOnBy.Count != 0)
                {
                    docs.Append("<h3>Depended on by</h3>");
                    docs.Append("<ul>");
                    for (int k = 0; k < DependOnBy.Count; k++)
                    {
                        formulaJson.Append("\"" + DependOnBy[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + DependOnBy[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + DependOnBy[k] + "\\\">" + DependOnBy[k] + "</a></li>");
                    }
                    docs.Append("<ul>");
                    formulaJson.Remove(formulaJson.Length - 1, 1).Append("]");
                    formulaJson.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
                else
                {
                    docs.Append("<h3>Depended on by<em>(none)</em></h3>");
                    formulaJson.Append("]");
                    formulaJson.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
            }
            formulaJson.Remove(formulaJson.Length - 1, 1).Append("}");
            return formulaJson.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using DAL;

namespace BLL
{
    public class GetUnionBLL
    {
        public string GetCompoundandDiseaseUnionJsonSimple(int diseaseId, int compoundId,out string pDisease,out string pCompound)
        {
            GetUnionDAL getUnionDal = new GetUnionDAL();
            //获得疾病和化合物的并集，并将它们所对应的p值取到
            List<Edge_displayName> compoundandDiseaseUnionData = getUnionDal.GetCompoundandDiseaseUnionSimple(diseaseId, compoundId, out pDisease, out pCompound);
            if (compoundandDiseaseUnionData == null)
            {
                return null;
            }
            OMIMBLL omim_displayNameBll = new OMIMBLL();
            CompoundBLL compound_displayNameBll = new CompoundBLL();
            ////获得对应id和P值的疾病的边
            List<Edge_displayName> diseaseData = omim_displayNameBll.GetOMIMByDiseaseIdandPValue(diseaseId, pDisease);
            if (diseaseData == null)
            {
                return null;
            }
            ////获得对应id和P值的化合物的边
            List<Edge_displayName> compoundData = compound_displayNameBll.GetCompoundByCompoundandPValue(compoundId, pCompound);
            if (compoundData == null)
            {
                return null;
            }
            string DiseaseName = omim_displayNameBll.GetDiseaseName(diseaseId);//获得疾病的英文的名字
            string compoundName = compound_displayNameBll.GetCompoundName(compoundId);//获得化合物的名字
            List<string> diseaseNodes =Common.GetNodesByEdges(diseaseData); //存储所得到的疾病的节点
            List<string> compoundNodes =Common.GetNodesByEdges(compoundData);//存储所得到的化合物的节点
            List<string> unionNodes =Common.GetNodesByEdges(compoundandDiseaseUnionData);
            StringBuilder Union= new StringBuilder("{");
            for (int i = 0; i < unionNodes.Count; i++)
            {
                List<string> Depend = new List<string>();
                List<string> DependOnBy = new List<string>();
                StringBuilder docs = new StringBuilder();
                docs.Append("<h2>"+unionNodes[i]);
                Union.Append("\""+unionNodes[i]+"\":");
                Union.Append("{\"name\":"+"\""+unionNodes[i]+"\",");
                if ((diseaseNodes.Contains(unionNodes[i])) && (compoundNodes.Contains(unionNodes[i])))
                {
                    docs.Append("<em>[" + DiseaseName + "]_[" + compoundName+"]</em></h2>");
                    docs.Append("<div class=\\\"alert alert-warning\\\">No documentation for this object</div>");
                    Union.Append("\"type\":\"["+DiseaseName+"]_["+compoundName+"]\",\"depends\":[");//属于交集
                }
                else if ((diseaseNodes.Contains(unionNodes[i])) && (!compoundNodes.Contains(unionNodes[i])))
                {
                    docs.Append("<em>"+DiseaseName+"</em></h2>");
                    docs.Append("<div class=\\\"alert alert-warning\\\">No documentation for this object</div>");
                    Union.Append("\"type\":\""+DiseaseName+"\",\"depends\":[");//属于OMIM
                }
                else if ((!diseaseNodes.Contains(unionNodes[i])) && (compoundNodes.Contains(unionNodes[i])))
                {
                    docs.Append("<em>"+compoundName+"</em></h2>");
                    docs.Append("<div class=\\\"alert alert-warning\\\">No documentation for this object</div>");
                    Union.Append("\"type\":\""+compoundName+"\",\"depends\":[");//属于Compound
                }
                for (int j = 0; j < compoundandDiseaseUnionData.Count; j++)
                {
                    if (compoundandDiseaseUnionData[j].HasEvent_displayName == unionNodes[i])
                    {
                        Depend.Add(compoundandDiseaseUnionData[j].DB_ID_displayName);
                    }
                    if (compoundandDiseaseUnionData[j].DB_ID_displayName == unionNodes[i])
                    {
                        DependOnBy.Add(compoundandDiseaseUnionData[j].HasEvent_displayName);
                    }
                }
                if (Depend.Count != 0)
                {
                    docs.Append("<h3>Depends on</h3>");
                    docs.Append("<ul>");
                    for (int k = 0; k < Depend.Count; k++)
                    {
                        Union.Append("\"" + Depend[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + Depend[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + Depend[k] + "\\\">" + Depend[k]+ "</a></li>");
                    }
                    docs.Append("</ul>");
                    Union.Remove(Union.Length - 1, 1).Append("],\"dependedOnBy\":[");
                }
                else
                {
                    docs.Append("<h3>Depends on<em>(none)</em></h3>");
                    Union.Append("],\"dependedOnBy\":[");
                }
                if (DependOnBy.Count != 0)
                {
                    docs.Append("<h3>Depended on by</h3>");
                    docs.Append("<ul>");
                    for (int k = 0; k < DependOnBy.Count; k++)
                    {
                        Union.Append("\"" + DependOnBy[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + DependOnBy[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + DependOnBy[k] + "\\\">" + DependOnBy[k] + "</a></li>");
                    }
                    docs.Append("</ul>");
                    Union.Remove(Union.Length - 1, 1).Append("]");
                    Union.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
                else
                {
                    docs.Append("<h3>Depended on by<em>(none)</em></h3>");
                    Union.Append("]");
                    Union.Append(",\"docs\":\""+docs.ToString()+"\"},");
                }
            }
            Union.Remove(Union.Length-1,1).Append("}");
            return Union.ToString();
        }
        public string GetCompoundorHerbandDiseaseUnionJson(string type, int diseaseId, int compoundorHerbId, string diseaseName, string herborCompoundName, string pDvalue, string pHerborPCompound)
        {

            GetUnionDAL getUnionDal = new GetUnionDAL();
            List<Edge_displayName> diseaseData=new List<Edge_displayName>();
            List<Edge_displayName> herborCompoundData=new List<Edge_displayName>();
            //获得疾病和化合物的并集，并将它们所对应的p值取到
            List<Edge_displayName> compoundorHerbandDiseaseUnionData = getUnionDal.GetCompoundorHerbandDiseaseUnion(type, diseaseId, compoundorHerbId, pDvalue, pHerborPCompound);
            if (compoundorHerbandDiseaseUnionData == null)
            {
                return null;
            }
            OMIMBLL omim_displayNameBll = new OMIMBLL();
            ////获得对应id和P值的疾病的边
            diseaseData = omim_displayNameBll.GetOMIMByDiseaseIdandPValue(diseaseId, pDvalue);
            if (diseaseData == null)
            {
                return null;
            }
            if (type == "DiseaseAndCompound")
            {
                CompoundBLL compound_displayNameBll = new CompoundBLL();
                ////获得对应id和P值的化合物的边
                herborCompoundData = compound_displayNameBll.GetCompoundByCompoundandPValue(compoundorHerbId, pHerborPCompound);
                if (herborCompoundData == null)
                {
                    return null;
                }
            }
            if (type == "DiseaseAndHerb")
            {
                InBLL in_displayNameBll = new InBLL();
                ////获得对应id和P值的化合物的边
                herborCompoundData = in_displayNameBll.GetInByHerbIdandPValue(compoundorHerbId, pHerborPCompound);
                if (herborCompoundData == null)
                {
                    return null;
                }
            }
            if (type == "DiseaseAndFormula")
            {
                FormulaBLL formulaBll = new FormulaBLL();
                herborCompoundData = formulaBll.GetFormulaByFormulaandPValue(compoundorHerbId, pHerborPCompound);
                if (herborCompoundData == null)
                {
                    return null;
                }
            }
            List<string> diseaseNodes = Common.GetNodesByEdges(diseaseData); //存储所得到的疾病的节点
            List<string> compoundorHerbNodes = Common.GetNodesByEdges(herborCompoundData);//存储所得到的化合物或者是Herb的节点
            List<string> unionNodes = Common.GetNodesByEdges(compoundorHerbandDiseaseUnionData);
            StringBuilder Union = new StringBuilder("{");
            for (int i = 0; i < unionNodes.Count; i++)
            {
                List<string> Depend = new List<string>();
                List<string> DependOnBy = new List<string>();
                StringBuilder docs = new StringBuilder();
                docs.Append("<h2>" + unionNodes[i]);
                Union.Append("\"" + unionNodes[i] + "\":");
                Union.Append("{\"name\":" + "\"" + unionNodes[i] + "\",");
                if ((diseaseNodes.Contains(unionNodes[i])) && (compoundorHerbNodes.Contains(unionNodes[i])))
                {
                    docs.Append("<em>[" + diseaseName + "]_[" + herborCompoundName + "]</em></h2>");
                    docs.Append("<div class=\\\"alert alert-warning\\\">No documentation for this object</div>");
                    Union.Append("\"type\":\"[" + diseaseName + "]_[" + herborCompoundName + "]\",\"depends\":[");//属于交集
                }
                else if ((diseaseNodes.Contains(unionNodes[i])) && (!compoundorHerbNodes.Contains(unionNodes[i])))
                {
                    docs.Append("<em>" + diseaseName + "</em></h2>");
                    docs.Append("<div class=\\\"alert alert-warning\\\">No documentation for this object</div>");
                    Union.Append("\"type\":\"" + diseaseName + "\",\"depends\":[");//属于OMIM
                }
                else if ((!diseaseNodes.Contains(unionNodes[i])) && (compoundorHerbNodes.Contains(unionNodes[i])))
                {
                    docs.Append("<em>" + herborCompoundName + "</em></h2>");
                    docs.Append("<div class=\\\"alert alert-warning\\\">No documentation for this object</div>");
                    Union.Append("\"type\":\"" + herborCompoundName + "\",\"depends\":[");//属于Compound
                }
                for (int j = 0; j < compoundorHerbandDiseaseUnionData.Count; j++)
                {
                    if (compoundorHerbandDiseaseUnionData[j].HasEvent_displayName == unionNodes[i])
                    {
                        Depend.Add(compoundorHerbandDiseaseUnionData[j].DB_ID_displayName);
                    }
                    if (compoundorHerbandDiseaseUnionData[j].DB_ID_displayName == unionNodes[i])
                    {
                        DependOnBy.Add(compoundorHerbandDiseaseUnionData[j].HasEvent_displayName);
                    }
                }
                if (Depend.Count != 0)
                {
                    docs.Append("<h3>Depends on</h3>");
                    docs.Append("<ul>");
                    for (int k = 0; k < Depend.Count; k++)
                    {
                        Union.Append("\"" + Depend[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + Depend[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + Depend[k] + "\\\">" + Depend[k] + "</a></li>");
                    }
                    docs.Append("</ul>");
                    Union.Remove(Union.Length - 1, 1).Append("],\"dependedOnBy\":[");
                }
                else
                {
                    docs.Append("<h3>Depends on<em>(none)</em></h3>");
                    Union.Append("],\"dependedOnBy\":[");
                }
                if (DependOnBy.Count != 0)
                {
                    docs.Append("<h3>Depended on by</h3>");
                    docs.Append("<ul>");
                    for (int k = 0; k < DependOnBy.Count; k++)
                    {
                        Union.Append("\"" + DependOnBy[k] + "\",");
                        docs.Append("<li><a href=\\\"#obj-" + DependOnBy[k] + "\\\" class=\\\"select-object\\\" data-name=\\\"" + DependOnBy[k] + "\\\">" + DependOnBy[k] + "</a></li>");
                    }
                    docs.Append("</ul>");
                    Union.Remove(Union.Length - 1, 1).Append("]");
                    Union.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
                else
                {
                    docs.Append("<h3>Depended on by<em>(none)</em></h3>");
                    Union.Append("]");
                    Union.Append(",\"docs\":\"" + docs.ToString() + "\"},");
                }
            }
            Union.Remove(Union.Length - 1, 1).Append("}");
            return Union.ToString();
        }
    }      
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MODEL;

namespace Test
{
    public partial class Formula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OMIMBLL omim_displayNameBll = new OMIMBLL();
                List<Model> listDisease = omim_displayNameBll.GetAllDisease();
                DiseaseDropdown.DataSource = listDisease;
                DiseaseDropdown.DataBind();
                FormulaBLL formulaBll = new FormulaBLL();
                List<Model> listFormula = formulaBll.GetAllFormula();
                FormulaDropdown.DataSource = listFormula;
                FormulaDropdown.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int diseaseId = Convert.ToInt32(DiseaseDropdown.SelectedValue);
            int formulaId = Convert.ToInt32(FormulaDropdown.SelectedValue);
            string diseaseName = DiseaseDropdown.SelectedItem.Text;
            string formulaName = FormulaDropdown.SelectedItem.Text;
            string type = Request["type"].ToString();
            string pDvalue = PDiseaseDropdown.SelectedValue;
            string pFvalue = PFormulaDropdown.SelectedValue;
            string JsonData = string.Empty;
            if (type == "Disease")
            {
                OMIMBLL omimBll = new OMIMBLL();
                JsonData = omimBll.GetDiseaseJson(diseaseId,pDvalue,diseaseName);
                if (JsonData == null)
                {
                    JsonId.Value = "";
                    PFormula.Text = "";
                    PDisease.Text = "";
                    AlterLabel.Text = "您选择的数据不存在！";
                    return;
                }
                JsonId.Value = JsonData;//"{'nodes' : [{'name' : 'A'}, {'name' : 'B'}], 'type' : [{'source' : 0, 'target' : 1}]}";//JsonData;
                AlterLabel.Text = "";
                PFormula.Text = "";
                PDisease.Text = "pDisease="+pDvalue;
                return;
            }
            if (type == "Formula")
            {
                FormulaBLL formulaBll = new FormulaBLL();
                JsonData = formulaBll.GetFormulaJson(formulaId,pFvalue,formulaName);
                if (JsonData == null)
                {
                    JsonId.Value = "";
                    PFormula.Text = "";
                    PDisease.Text = "";
                    AlterLabel.Text = "您选择的数据不存在！";
                    return;
                }
                JsonId.Value = JsonData;
                AlterLabel.Text = "";
                PFormula.Text = "PFormula=" + pFvalue;
                PDisease.Text = "";
                return;
            }
            if (type == "DiseaseAndFormula")
            {
                GetUnionBLL unionBll = new GetUnionBLL();
                JsonData = unionBll.GetCompoundorHerbandDiseaseUnionJson(type, diseaseId, formulaId, diseaseName, formulaName, pDvalue, pFvalue);
                if (JsonData == null)
                {
                    JsonId.Value = "";
                    PFormula.Text = "";
                    PDisease.Text = "";
                    AlterLabel.Text = "您选择的数据不存在！";
                    return;
                }
                JsonId.Value = JsonData;
                AlterLabel.Text = "";
                PDisease.Text = "pDisease=" + pDvalue;
                PFormula.Text = "pCompound=" + pFvalue;
                return;
            }
        }
    }
}
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
    public partial class Compound: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OMIMBLL omim_displayNameBll = new OMIMBLL();
                List<Model> listDisease = omim_displayNameBll.GetAllDisease();
                CompoundBLL compound_displayNameBll = new CompoundBLL();
                List<Model> listCompound = compound_displayNameBll.GetAllCompound();
                DiseaseDropdown.DataSource = listDisease;
                DiseaseDropdown.DataBind();
                CompoundDropdown.DataSource = listCompound;
                CompoundDropdown.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //int DiseaseId = Convert.ToInt32(DiseaseDropdown.SelectedValue);
            //int CompoundId = Convert.ToInt32(CompoundDropdown.SelectedValue);
            //string pDisease = string.Empty;
            //string pCompound = string.Empty;
            //JsonData = getUnionBll.GetCompoundandDiseaseUnionJson(DiseaseId, CompoundId, out pDisease, out pCompound);
            //PDisease.Text = "pDisease=" + pDisease;
            //PCompound.Text = "pCompound=" + pCompound;
            int diseaseId=Convert.ToInt32(DiseaseDropdown.SelectedValue);
            int compoundId=Convert.ToInt32(CompoundDropdown.SelectedValue);
            string diseaseName = DiseaseDropdown.SelectedItem.Text;
            string compoundName = CompoundDropdown.SelectedItem.Text;
            string type =Request["type"].ToString();
            string pDvalue = PDiseaseDropdown.SelectedValue;
            string pCvalue = PCompoundDropdown.SelectedValue;
            string JsonData = string.Empty;
            if (type == "Disease")
            {
                OMIMBLL omimBll=new OMIMBLL();
                JsonData = omimBll.GetDiseaseJson(diseaseId, pDvalue, diseaseName);
                if (JsonData == null)
                {
                    JsonId.Value = "";
                    PCompound.Text= "";
                    PDisease.Text = "";
                    AlterLabel.Text = "您选择的数据不存在！";
                    return;
                }
                JsonId.Value = JsonData;
                AlterLabel.Text = "";
                PCompound.Text = "";
                PDisease.Text ="pDisease="+pDvalue;
                return;
            }
            if (type == "Compound")
            {
                CompoundBLL compoundBll = new CompoundBLL();
                JsonData = compoundBll.GetCompoundJson(compoundId,pCvalue,compoundName);
                if (JsonData == null)
                {
                    JsonId.Value = "";
                    PCompound.Text = "";
                    PDisease.Text = "";
                    AlterLabel.Text = "您选择的数据不存在！";
                    return;
                }
                JsonId.Value = JsonData;
                AlterLabel.Text = "";
                PDisease.Text = "";
                PCompound.Text = "pCompound=" + pCvalue;
                return;
            }
            if (type == "DiseaseAndCompound")
            {
                GetUnionBLL unionBll = new GetUnionBLL();
                JsonData = unionBll.GetCompoundorHerbandDiseaseUnionJson(type, diseaseId, compoundId, diseaseName, compoundName, pDvalue, pCvalue);
                if (JsonData == null)
                {
                    JsonId.Value = "";
                    PCompound.Text = "";
                    PDisease.Text = "";
                    AlterLabel.Text = "您选择的数据不存在！";
                    return;
                }
                JsonId.Value = JsonData;
                AlterLabel.Text = "";
                PDisease.Text = "pDisease=" + pDvalue;
                PCompound.Text = "pCompound=" + pCvalue;
                return;
            }
        }
    }
}
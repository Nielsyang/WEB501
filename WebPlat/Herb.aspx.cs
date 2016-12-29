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
    public partial class Herb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OMIMBLL omim_displayNameBll = new OMIMBLL();
                List<Model> listDisease = omim_displayNameBll.GetAllDisease();
                InBLL herb_displayNameBll = new InBLL();
                List<Model> listCompound = herb_displayNameBll.GetAllHerb();
                DiseaseDropdown.DataSource = listDisease;
                DiseaseDropdown.DataBind();
                HerbDropdown.DataSource = listCompound;
                HerbDropdown.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int diseaseId = Convert.ToInt32(DiseaseDropdown.SelectedValue);
            int herbId = Convert.ToInt32(HerbDropdown.SelectedValue);
            string diseaseName = DiseaseDropdown.SelectedItem.Text;
            string herbName = HerbDropdown.SelectedItem.Text;
            string type = RadioButtonList1.SelectedValue;
            string pDvalue = PDiseaseDropdown.SelectedValue;
            string pHvalue = PHerbDropdown.SelectedValue;
            string JsonData = string.Empty;
            if (type == "Disease")
            {
                OMIMBLL omimBll = new OMIMBLL();
                JsonData = omimBll.GetDiseaseJson(diseaseId,pDvalue,diseaseName);
                if (JsonData == null)
                {
                    JsonId.Value = "";
                    PHerb.Text = "";
                    PDisease.Text = "";
                    AlterLabel.Text = "您选择的数据不存在！";
                    return;
                }
                JsonId.Value = JsonData;
                AlterLabel.Text = "";
                PHerb.Text = "";
                PDisease.Text = "pDisease=" + pDvalue;
                return;
            }
            if (type == "Herb")
            {
                InBLL inBll = new InBLL();
                JsonData = inBll.GetHerbJson(herbId, pHvalue, herbName);
                if (JsonData == null)
                {
                    JsonId.Value = "";
                    PHerb.Text = "";
                    PDisease.Text = "";
                    AlterLabel.Text = "您选择的数据不存在！";
                    return;
                }
                JsonId.Value = JsonData;
                AlterLabel.Text = "";
                PHerb.Text = "pHerb=" + pHvalue;
                PDisease.Text = "";
                return;
            }
            if (type == "DiseaseAndHerb")
            {
                GetUnionBLL unionBll = new GetUnionBLL();
                JsonData = unionBll.GetCompoundorHerbandDiseaseUnionJson(type, diseaseId, herbId, diseaseName, herbName, pDvalue, pHvalue);
                if (JsonData == null)
                {
                    JsonId.Value = "";
                    PHerb.Text = "";
                    PDisease.Text = "";
                    AlterLabel.Text = "您选择的数据不存在！";
                    return;
                }
                JsonId.Value = JsonData;
                AlterLabel.Text = "";
                PHerb.Text = "pHerb=" + pHvalue;
                PDisease.Text = "pDisease=" + pDvalue;
                return;
            }
        }
    }
}
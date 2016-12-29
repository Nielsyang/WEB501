using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MODEL;
using System.Text.RegularExpressions;

namespace WebPlat
{
    public partial class GenerateNet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string diseaseName = Dbox.Text;
            string diseaseName_ = Dbox.Text;
            string formulaName = Formulatextbox.Text;
            string tissueName = Tissuetextbox.Text;
            string herbName = Herbtextbox.Text;
            string type = Request["type"].ToString();
            string Analyse_type = Request["Analyse_type"].ToString();
            string pDvalue = PDiseaseDropdown.SelectedValue;
            string pTvalue = PTissueDropdown.SelectedValue;
            float pdvalue_dec;
            float ptvalue_dec;
            int nodeclass;
            if (Analyse_type == "Formula") {herbName = "";nodeclass = 4;}
            else {formulaName = ""; nodeclass = 3;}
            if (type == "Disease") tissueName = "";
            else if (type == "Tissue") diseaseName = "";
            if (pDvalue == "don't care") pdvalue_dec = 0; else pdvalue_dec = float.Parse(pDvalue);
            if (pTvalue == "don't care") ptvalue_dec = 0; else ptvalue_dec = float.Parse(pTvalue);

            string Jsonnodes = string.Empty;
            string Jsonlinks = string.Empty;
            NetBLL netbll = new NetBLL();
            netbll.Generate_Net(formulaName, herbName, diseaseName, tissueName, ptvalue_dec, pdvalue_dec);
            Jsonlinks = netbll.GetLinks();
            Jsonnodes = netbll.GetNodes();
            string[] nodenums = netbll.GetNodeNums(Analyse_type, nodeclass);
            if (Analyse_type == "Formula")
            {
                LabelFN.Text = nodenums[0];
                LabelHN.Text = nodenums[1];
                LabelCN.Text = nodenums[2];
                LabelTN.Text = nodenums[3];
            }
            else 
            {
                LabelFN.Text = "0";
                LabelHN.Text = nodenums[0];
                LabelCN.Text = nodenums[1];
                LabelTN.Text = nodenums[2];
            }
            JsonNodes.Value = Jsonnodes;
            JsonLinks.Value = Jsonlinks;



        }

        protected void Dbox_onchanged(object sender, EventArgs e)
        {
            OMIMBLL omim = new OMIMBLL();
            string txt = "";
            if (Regex.IsMatch(Dbox.Text, @"[\u4e00-\u9fa5]"))
                txt = omim.GetDiseaseNameEnFromCn(Dbox.Text);            
            else 
                txt = omim.GetDiseaseNameCnFromEn(Dbox.Text);
            DiseaseCnEn.Text = txt;
        }
    }
}
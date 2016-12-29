using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MODEL;

namespace WebPlat
{
    public partial class graph_bottom : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string n;
            n = Session["name"].ToString();
            if (n == "disease")
                lable.Text = "Herb";
            else
                lable.Text = "Compound";
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            AnalyseInfoBLL analyse_info = new AnalyseInfoBLL();
            string selected_item = "";
            string category = "";
            selected_item = VisitAllTextBox(this.Controls);
            
            if (selected_item.Length == 0)
                return;
            selected_item = selected_item.Substring(0, selected_item.Length - 1);

            if (lable.Text == "Herb")
                category = "Herb:Disease:Tissue";
            if (lable.Text == "Compound")
                category = "Compound:Disease:Tissue";

            analyse_info.PushAnalyseInfo(Request.ServerVariables.Get("Remote_Addr").ToString(), selected_item, category);

        }

        public string VisitAllTextBox(ControlCollection control)
        {
            string res = "";
            foreach (Control txtobj in control)
            {
                if (txtobj.HasControls())
                {
                    res += VisitAllTextBox(txtobj.Controls);
                }

                if (txtobj is TextBox)
                {
                    if(((TextBox)txtobj).Text != "")
                        res += ((TextBox)txtobj).Text + ",";//这是第一种方法赋值，第二种在下面   
                }

            }
            return res;
        }
    }
}
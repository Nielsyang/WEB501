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
    public partial class syndroms_pre : System.Web.UI.Page
    {
        //public SyndromsBLL syn_pre = new SyndromsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SyndromsBLL syn_pre = new SyndromsBLL();
                syn_pre.GetDataXuhaoToZhengzhuang();
                syn_pre.GetDataZhenghouToXuhao();
                syn_pre.GetDataZhengzhuangToId();
                Session["synpre"] = syn_pre;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> input_data = new List<string>();
            string selected_item = "";
            selected_item = VisitAllTextBox(this.Controls);

            if (selected_item.Length == 0)
                return;
            selected_item = selected_item.Substring(0, selected_item.Length - 1);
            string[] temp = selected_item.Split(',');

            for (int i = 0; i < temp.Length; ++i)
                input_data.Add(temp[i]);

            SyndromsBLL p = Session["synpre"] as SyndromsBLL;
            textbox13.Text = p.GetResults(input_data);



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
                    if (((TextBox)txtobj).Text != "" && ((TextBox)txtobj).ID !="textbox13")
                        res += ((TextBox)txtobj).Text + ",";//这是第一种方法赋值，第二种在下面   
                }

            }
            return res;
        }
    }
}
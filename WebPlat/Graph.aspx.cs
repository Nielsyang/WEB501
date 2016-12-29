using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL;
using BLL;

namespace WebPlat
{
    public partial class Graph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string n;
            n = Session["name"].ToString();
            if (n == "formula")
            {
                FormulaBLL formulaBll = new FormulaBLL();
                List<Model> listFormula = formulaBll.GetAllFormula();
                dropdown.DataSource = listFormula;
                dropdown.DataBind();
            }
            else if (n == "disease")
            {
                OMIMBLL omim_displayNameBll = new OMIMBLL();
                List<Model> listDisease = omim_displayNameBll.GetAllDisease();
                dropdown.DataSource = listDisease;
                dropdown.DataBind();
            }
            else if (n == "compound")
            {
                CompoundBLL compoundBll = new CompoundBLL();
                List<Model> listCompound = compoundBll.GetAllCompound();
                dropdown.DataSource = listCompound;
                dropdown.DataBind();
            }
            Session.Remove("name");


        }
    }
}
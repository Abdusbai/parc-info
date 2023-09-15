using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestion_du_pac_informatique
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                NomPrenom.Text = Session["Nom"] + " " + Session["Prenom"];
                Role.Text = Session["Role"].ToString();
            }
            catch
            {

            }
        }
    }
}
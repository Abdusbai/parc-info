using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Gestion_du_pac_informatique
{
    public partial class Utilisateur : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        private void InfoLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Utilisateur", connection);
                SqlDataReader R = cmd.ExecuteReader();
                DataTable T = new DataTable();
                T.Load(R);

                GridView1.DataSource = T;
                GridView1.DataBind();
                R.Close();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CinUser"] == null)
            {
                Response.Redirect("Connexion.aspx");
            }
            else if (Session["Role"].ToString() != "Administrateur")
            {
                Response.Redirect("Autorise.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    InfoLoad();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Utilisateur where CinUser like '%{0}%' or MotDePasse like '%{1}%' or NomUser like '%{2}%' or PrenomUser like '%{3}%' or RoleUser like '%{4}%'", TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text), connection);
                SqlDataReader R = cmd.ExecuteReader();
                DataTable T = new DataTable();
                T.Load(R);
                GridView1.DataSource = T;
                GridView1.DataBind();
                Label1.Text = GridView1.Rows.Count + " résultats";
                R.Close();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        protected void NouveauBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("UtilisateurNouveau.aspx");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                int a = e.NewSelectedIndex;
                string code = GridView1.Rows[a].Cells[0].Text;
                Response.Redirect(string.Format("UtilisateurDetails.aspx?COUT={0}", code));
            }
            catch
            {
                connection.Close();
            }
        }
    }
}
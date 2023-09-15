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
    public partial class Technicien : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        private void InfoLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            if (!IsPostBack)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select * from Technicien", connection);
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

        protected void NouveauBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("TechnicienNouveau.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Technicien where CinTech like '%{0}%' or NomTech like '%{1}%' or PrenomTech like '%{2}%' or DateNeTech like '%{3}%' or DateRecTech like '%{4}%' or NumBurTech like '%{5}%' or TeleBurTech like '%{6}%' or GsmTech like '%{7}%' or EmailTech like '%{8}%'", TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text), connection);
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

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                int a = e.NewSelectedIndex;
                string code = GridView1.Rows[a].Cells[0].Text;
                Response.Redirect(string.Format("TechnicienDetails.aspx?CINT={0}", code));
            }
            catch
            {
                connection.Close();
            }
        }
    }
}
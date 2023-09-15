using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Gestion_du_pac_informatique
{
    public partial class EntiteNouveau : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

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
        }

        private bool RechercheEntite(string LocaE)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Entite where LocalisationEn='{0}'", LocaE), connection);
                SqlDataReader r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    a = true;
                }
                r.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
            return a;
        }

        private void Clear()
        {
            Loca.Text = "";
            Abre.Text = "";
            Dire.Text = "";
            Div.Text = "";
            Serv.Text = "";
        }

        protected void AjouterBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Loca.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheEntite(Loca.Text) == true)
                {
                    MessageLabel.Text = "Il existe déjà une entité avec le même code de localisation !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Entite values(@L, @Di, @Div, @S, @A)", connection);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@L", Loca.Text);
                    cmd.Parameters.AddWithValue("@Di", Dire.Text);
                    cmd.Parameters.AddWithValue("@Div", Div.Text);
                    cmd.Parameters.AddWithValue("@S", Serv.Text);
                    cmd.Parameters.AddWithValue("@A", Abre.Text);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Clear();
                        MessageLabel.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Entité Ajoutée avec succès.');", true);
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        protected void AnnulerBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entite.aspx");
        }
    }
}
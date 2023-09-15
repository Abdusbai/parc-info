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
    public partial class TechnicienNouveau : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        private bool RechercheTech(string Tech)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Technicien where CinTech='{0}'", Tech), connection);
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
            CinText.Text = "";
            NomText.Text = "";
            PrenomText.Text = "";
            DateNaissText.Text = "";
            DateRecrText.Text = "";
            NumBurText.Text = "";
            TeleBText.Text = "";
            GsmText.Text = "";
            MailText.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CinUser"] == null)
            {
                Response.Redirect("Connexion.aspx");
            }
            else if (Session["Role"].ToString() == "Technicien")
            {
                Response.Redirect("Autorise.aspx");
            }
        }

        protected void AnnulerBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Technicien.aspx");
        }

        protected void AjouterBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (CinText.Text == "" || NomText.Text == "" || PrenomText.Text == "" || DateNaissText.Text == "" || DateRecrText.Text == "" || NumBurText.Text == "" || TeleBText.Text == "" || GsmText.Text == "" || MailText.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheTech(CinText.Text) == true)
                {
                    MessageLabel.Text = "Il existe déjà un Technicien avec le même  CIN !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Technicien values(@Cin_P, @Nom_P, @prenom_P, @DateN_P, @DateR_P, @NumB_P, @Tele_P, @Gsm_P, @Mail_P)", connection);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Cin_P", CinText.Text);
                    cmd.Parameters.AddWithValue("@Nom_P", NomText.Text);
                    cmd.Parameters.AddWithValue("@prenom_P", PrenomText.Text);
                    cmd.Parameters.AddWithValue("@DateN_P", DateNaissText.Text);
                    cmd.Parameters.AddWithValue("@DateR_P", DateRecrText.Text);
                    cmd.Parameters.AddWithValue("@NumB_P", NumBurText.Text);
                    cmd.Parameters.AddWithValue("@Tele_P", TeleBText.Text);
                    cmd.Parameters.AddWithValue("@Gsm_P", GsmText.Text);
                    cmd.Parameters.AddWithValue("@Mail_P", MailText.Text);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Clear();
                        MessageLabel.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Technicien Ajoutée avec succès.');", true);
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
    }
}
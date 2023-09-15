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
    public partial class Connexion : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CinUser"] != null)
            {
                Response.Redirect("Accueil.aspx");
            }
        }

        protected void SeConnecter_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Identifiant.Text == "" || MotDePasse.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select * from Utilisateur where CinUser = '{0}' and MotDePasse = '{1}'", Identifiant.Text, MotDePasse.Text), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        string etatCompte = R[5].ToString();
                        if (etatCompte == "Désactivé")
                        {
                            MessageLabel.Text = "Votre compte est actuellement désactivé !";
                        }
                        else
                        {
                            Session["CinUser"] = R[0].ToString();
                            Session["Nom"] = R[2].ToString();
                            Session["Prenom"] = R[3].ToString();
                            Session["Role"] = R[4].ToString();
                            R.Close();
                            connection.Close();
                            Response.Redirect("Accueil.aspx");
                        }
                    }
                    else
                    {
                        MessageLabel.Text = "Identifiant ou mot de passe incorrect !";
                        connection.Close();
                    }
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
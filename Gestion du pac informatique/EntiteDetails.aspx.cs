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
    public partial class EntiteDetails : System.Web.UI.Page
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
            else
            {
                SqlConnection connection = new SqlConnection(STRCON);
                if (!IsPostBack)
                {
                    if (Request.QueryString["LO"] != null)
                    {
                        try
                        {
                            string Local = Request.QueryString["LO"].ToString();
                            connection.Open();
                            SqlCommand cmd = new SqlCommand(string.Format("select * from Entite where LocalisationEn = '{0}'", Local), connection);
                            SqlDataReader R = cmd.ExecuteReader();
                            if (R.HasRows)
                            {
                                R.Read();
                                if (R[0].ToString() == null || R[0].ToString() == "")
                                    Loca.Text = "SANS";
                                else
                                    Loca.Text = R[0].ToString();

                                if (R[1].ToString() == null || R[1].ToString() == "")
                                    Dire.Text = "SANS";
                                else
                                    Dire.Text = R[1].ToString();

                                if (R[2].ToString() == null || R[2].ToString() == "")
                                    Div.Text = "SANS";
                                else
                                    Div.Text = R[2].ToString();

                                if (R[3].ToString() == null || R[3].ToString() == "")
                                    Serv.Text = "SANS";
                                else
                                    Serv.Text = R[3].ToString();

                                if (R[4].ToString() == null || R[4].ToString() == "")
                                    Abre.Text = "SANS";
                                else
                                    Abre.Text = R[4].ToString();
                            }
                            R.Close();
                            connection.Close();
                        }
                        catch
                        {
                            MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                            connection.Close();
                        }
                    }
                }
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

        protected void SupprimerBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Loca.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheEntite(Loca.Text) == false)
                {
                    MessageLabel.Text = "L'entité n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("delete from Entite where LocalisationEn='{0}'", Loca.Text), connection);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Response.Redirect("Entite.aspx");
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

        protected void ModifierBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Loca.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheEntite(Loca.Text) == false)
                {
                    MessageLabel.Text = "L'entité n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("update Entite set DirectionEn='{0}', DivisionEn='{1}', ServiceEn='{2}', AbreviationEn='{3}' where LocalisationEn='{4}'", Dire.Text, Div.Text, Serv.Text, Abre.Text, Loca.Text), connection);
                    cmd.ExecuteNonQuery();
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        MessageLabel.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été modifiées avec succès.');", true);
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
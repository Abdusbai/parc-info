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
    public partial class TechnicienDetails : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        protected void InfoLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Request.QueryString["CINT"] != null)
                {
                    string CinTech = Request.QueryString["CINT"].ToString();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select * from Technicien where CinTech = '{0}'", CinTech), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        CinText.Text = R[0].ToString();
                        NomText.Text = R[1].ToString();
                        PrenomText.Text = R[2].ToString();
                        DateNaissText.Text = Convert.ToDateTime(R[3]).ToString("yyyy-MM-dd");
                        DateRecrText.Text = Convert.ToDateTime(R[4]).ToString("yyyy-MM-dd");
                        NumBurText.Text = R[5].ToString();
                        TeleBText.Text = R[6].ToString();
                        GsmText.Text = R[7].ToString();
                        MailText.Text = R[8].ToString();
                    }
                    R.Close();
                    connection.Close();
                }
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

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

        protected void ModifierBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (CinText.Text == "" || NomText.Text == "" || PrenomText.Text == "" || DateNaissText.Text == "" || DateRecrText.Text == "" || NumBurText.Text == "" || TeleBText.Text == "" || GsmText.Text == "" || MailText.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheTech(CinText.Text) == false)
                {
                    MessageLabel.Text = "Technicien n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("update Technicien set NomTech='{0}', PrenomTech='{1}', DateNeTech='{2}', DateRecTech='{3}', NumBurTech='{4}', TeleBurTech='{5}', GsmTech='{6}', EmailTech='{7}' where CinTech='{8}'", NomText.Text, PrenomText.Text, DateNaissText.Text, DateRecrText.Text, NumBurText.Text, TeleBText.Text, GsmText.Text, MailText.Text, CinText.Text), connection);
                    cmd.ExecuteNonQuery();
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        MessageLabel.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été Modifiées avec succès.');", true);
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

        protected void SupprimerBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (CinText.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheTech(CinText.Text) == false)
                {
                    MessageLabel.Text = "Technicien n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("delete from Technicien where CinTech='{0}'", CinText.Text), connection);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Response.Redirect("Technicien.aspx");
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
            Response.Redirect("Technicien.aspx");
        }
    }
}
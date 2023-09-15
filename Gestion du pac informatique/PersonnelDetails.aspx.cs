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
    public partial class PersonnelDetails : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        protected void FonctionLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Fonction", connection);
                SqlDataReader R = cmd.ExecuteReader();
                FonctionDropDown.DataSource = R;
                FonctionDropDown.DataValueField = "CodeFo";
                FonctionDropDown.DataTextField = "DescFo";
                FonctionDropDown.DataBind();
                FonctionDropDown.Items.Insert(0, new ListItem("-- Fonction * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        protected void InfoLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Request.QueryString["DRPP"] != null)
                {
                    string DRPP = Request.QueryString["DRPP"].ToString();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select * from Personnel where DrppPerso = '{0}'", DRPP), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        DrppText.Text = R[0].ToString();
                        CinText.Text = R[1].ToString();
                        NomText.Text = R[2].ToString();
                        PrenomText.Text = R[3].ToString();
                        DateNaissText.Text = Convert.ToDateTime(R[4]).ToString("yyyy-MM-dd");
                        DateRecrText.Text = Convert.ToDateTime(R[5]).ToString("yyyy-MM-dd");
                        FonctionDropDown.SelectedValue = R[6].ToString();
                        NumBurText.Text = R[7].ToString();
                        TeleBText.Text = R[8].ToString();
                        GsmText.Text = R[9].ToString();
                        MailText.Text = R[10].ToString();
                        SiteText.Text = R[11].ToString();
                        BatimentText.Text = R[12].ToString();
                        if (R[13].ToString() == "Oui")
                            ActifDropDown.SelectedIndex = 1;
                        else if(R[13].ToString() == "Non")
                            ActifDropDown.SelectedIndex = 2;
                        LODropwDown.SelectedValue = R[14].ToString();
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

        protected void LocaLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Entite", connection);
                SqlDataReader R = cmd.ExecuteReader();
                LODropwDown.DataSource = R;
                LODropwDown.DataValueField = "LocalisationEn";
                LODropwDown.DataTextField = "AbreviationEn";
                LODropwDown.DataBind();
                LODropwDown.Items.Insert(0, new ListItem("-- Localisation * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        private bool RecherchePerso(string DRPP)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Personnel where DrppPerso='{0}'", DRPP), connection);
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
                    LocaLoad();
                    FonctionLoad();
                    InfoLoad();
                }
            }
        }

        protected void AnnulerBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personnel.aspx");
        }

        protected void SupprimerBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (DrppText.Text=="")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RecherchePerso(DrppText.Text) == false)
                {
                    MessageLabel.Text = "Personnel n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("delete from Personnel where DrppPerso='{0}'", DrppText.Text), connection);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Response.Redirect("Personnel.aspx");
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageLabel.Text = "Veuillez vérifier si cet employé a des matériels ou des logiciels, si oui il faut d'abord le supprimer.";
                connection.Close();
            }
        }

        protected void ModifierBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (DrppText.Text == "" || CinText.Text == "" || NomText.Text == "" || PrenomText.Text == "" || DateNaissText.Text == "" || DateRecrText.Text == "" || FonctionDropDown.SelectedIndex == 0 || NumBurText.Text == "" || SiteText.Text == "" || BatimentText.Text == "" || LODropwDown.SelectedIndex == 0 || ActifDropDown.SelectedIndex == 0 || TeleBText.Text == "" || GsmText.Text == "" || MailText.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RecherchePerso(DrppText.Text) == false)
                {
                    MessageLabel.Text = "Personnel n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("update Personnel set NomPerso='{0}', PrenomPerso='{1}', DateNePerso='{2}', DateRecPerso='{3}', CodeFo='{4}', NumBurPerso='{5}', TeleBurPerso='{6}', GsmPerso='{7}', EmailPerso='{8}', SitePerso='{9}', BatimentPerso='{10}', ActifPerso='{11}', LocalisationEn='{12}' where DrppPerso='{13}'", NomText.Text, PrenomText.Text, DateNaissText.Text, DateRecrText.Text, FonctionDropDown.SelectedValue, NumBurText.Text, TeleBText.Text, GsmText.Text, MailText.Text, SiteText.Text, BatimentText.Text, ActifDropDown.SelectedItem.Text, LODropwDown.SelectedValue, DrppText.Text), connection);
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
    }
}
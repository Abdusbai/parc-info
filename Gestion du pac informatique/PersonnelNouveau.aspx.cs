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
    public partial class PersonnelNouveau : System.Web.UI.Page
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
                FonctionDropDown.Items.Insert(0, new ListItem("-- Choisir fonction * --", "-1", true));
                R.Close();
                connection.Close();
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
                LODropwDown.Items.Insert(0, new ListItem("-- Choisir localisation * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        private bool RecherchePerso(string DRPP, string CIN)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Personnel where DrppPerso='{0}' or CinPerso='{1}'", DRPP, CIN), connection);
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
            DrppText.Text = "";
            NomText.Text = "";
            PrenomText.Text = "";
            DateNaissText.Text = "";
            DateRecrText.Text = "";
            FonctionDropDown.SelectedIndex = 0;
            NumBurText.Text = "";
            TeleBText.Text = "";
            GsmText.Text = "";
            MailText.Text = "";
            SiteText.Text = "";
            BatimentText.Text = "";
            ActifDropDown.SelectedIndex = 0;
            LODropwDown.SelectedIndex = 0;
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
                    FonctionLoad();
                    LocaLoad();
                }
            }
        }

        protected void AnnulerBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personnel.aspx");
        }

        protected void AjouterBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (DrppText.Text == "" || CinText.Text == "" || NomText.Text == "" || PrenomText.Text == "" || DateNaissText.Text == "" || DateRecrText.Text == "" || FonctionDropDown.SelectedIndex == 0 || NumBurText.Text == "" || SiteText.Text == "" || BatimentText.Text == "" || LODropwDown.SelectedIndex == 0 || ActifDropDown.SelectedIndex == 0 || TeleBText.Text == "" || GsmText.Text == "" || MailText.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RecherchePerso(DrppText.Text, CinText.Text) == true)
                {
                    MessageLabel.Text = "Il existe déjà un personnel avec le même DRPP ou le même CIN !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Personnel values(@Drpp_P, @Cin_P, @Nom_P, @prenom_P, @DateN_P, @DateR_P, @CodeF_P, @NumB_P, @Tele_P, @Gsm_P, @Mail_P, @Site_P, @Bati_P, @Actif_P, @Loca_P )", connection);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Drpp_P", DrppText.Text);
                    cmd.Parameters.AddWithValue("@Cin_P", CinText.Text);
                    cmd.Parameters.AddWithValue("@Nom_P", NomText.Text);
                    cmd.Parameters.AddWithValue("@prenom_P", PrenomText.Text);
                    cmd.Parameters.AddWithValue("@DateN_P", DateNaissText.Text);
                    cmd.Parameters.AddWithValue("@DateR_P", DateRecrText.Text);
                    cmd.Parameters.AddWithValue("@CodeF_P", FonctionDropDown.SelectedValue);
                    cmd.Parameters.AddWithValue("@NumB_P", NumBurText.Text);
                    cmd.Parameters.AddWithValue("@Tele_P", TeleBText.Text);
                    cmd.Parameters.AddWithValue("@Gsm_P", GsmText.Text);
                    cmd.Parameters.AddWithValue("@Mail_P", MailText.Text);
                    cmd.Parameters.AddWithValue("@Site_P", SiteText.Text);
                    cmd.Parameters.AddWithValue("@Bati_P", BatimentText.Text);
                    cmd.Parameters.AddWithValue("@Actif_P", ActifDropDown.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Loca_P", LODropwDown.SelectedValue);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Clear();
                        MessageLabel.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Personnel Ajoutée avec succès.');", true);
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
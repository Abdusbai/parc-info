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
    public partial class LogicielNouveau : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        protected void DrppLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select DrppPerso from Personnel", connection);
                SqlDataReader R = cmd.ExecuteReader();
                DrppDropDown.DataSource = R;
                DrppDropDown.DataValueField = "DrppPerso";
                DrppDropDown.DataTextField = "DrppPerso";
                DrppDropDown.DataBind();
                DrppDropDown.Items.Insert(0, new ListItem("-- Choisir DRPP * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        private bool RechercheLog(string NumLo)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Logiciel where NumLogic='{0}'", NumLo), connection);
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
            NumeroText.Text = "";
            NomText.Text = "";
            NomEnText.Text = "";
            VersionText.Text = "";
            DrppDropDown.SelectedIndex = 0;
            NomPTesxt.Text = "";
            PrenomPText.Text = "";
            CinText.Text = "";
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
                    DrppLoad();
                }
            }
        }

        protected void AjouterBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (NumeroText.Text == "" || VersionText.Text == "" || NomText.Text == "" || NomEnText.Text == "" || DrppDropDown.SelectedIndex == 0)
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheLog(NumeroText.Text) == true)
                {
                    MessageLabel.Text = "Il existe déjà un logiciel avec le même numéro !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Logiciel values(@NumLo, @NomLo, @NomCo, @VerLo, @DrppP)", connection);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@NumLo", NumeroText.Text);
                    cmd.Parameters.AddWithValue("@NomLo", NomText.Text);
                    cmd.Parameters.AddWithValue("@NomCo", NomEnText.Text);
                    cmd.Parameters.AddWithValue("@VerLo", VersionText.Text);
                    cmd.Parameters.AddWithValue("@DrppP", DrppDropDown.SelectedValue);                  
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Clear();
                        MessageLabel.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Logiciel Ajoutée avec succès.');", true);
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
            Response.Redirect("Logiciel.aspx");
        }

        protected void DrppDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrppDropDown.SelectedIndex == 0)
            {
                CinText.Text = "";
                NomPTesxt.Text = "";
                PrenomPText.Text = "";
            }
            else
            {
                SqlConnection connection = new SqlConnection(STRCON);
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select CinPerso, NomPerso, PrenomPerso from Personnel where DrppPerso = '{0}'", DrppDropDown.SelectedValue.ToString()), connection);
                SqlDataReader R = cmd.ExecuteReader();
                if (R.HasRows)
                {
                    R.Read();
                    CinText.Text = R[0].ToString();
                    NomPTesxt.Text = R[1].ToString();
                    PrenomPText.Text = R[2].ToString();
                }
                R.Close();
                connection.Close();
            }
        }
    }
}
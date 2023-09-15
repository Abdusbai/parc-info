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
    public partial class MaterielNouveau : System.Web.UI.Page
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
                DrppDropDown.Items.Insert(0, new ListItem("-- DRPP * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        protected void MarqueLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Marque", connection);
                SqlDataReader R = cmd.ExecuteReader();
                MarDropDown.DataSource = R;
                MarDropDown.DataValueField = "CodeMar";
                MarDropDown.DataTextField = "DescMar";
                MarDropDown.DataBind();
                MarDropDown.Items.Insert(0, new ListItem("-- Marque * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        protected void CategorieLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Categorie", connection);
                SqlDataReader R = cmd.ExecuteReader();
                CatDropDown.DataSource = R;
                CatDropDown.DataValueField = "CodeCat";
                CatDropDown.DataTextField = "DescCat";
                CatDropDown.DataBind();
                CatDropDown.Items.Insert(0, new ListItem("-- Catégorie * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        private bool RechercheMa(string NumMa)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Materiel where NumSerMat='{0}'", NumMa), connection);
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
            NumSerText.Text = "";
            CatDropDown.SelectedIndex = 0;
            MarDropDown.SelectedIndex = 0;
            NumInvText.Text = "";
            DesiText.Text = "";
            RefeText.Text = "";
            DrppDropDown.SelectedIndex = 0;
            NomPTesxt.Text = "";
            CinText.Text = "";
            PrenomPText.Text = "";
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
                    CategorieLoad();
                    MarqueLoad();
                }
            }
        }

        protected void AnnulerBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Materiel.aspx");
        }

        protected void AjouterBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (NumSerText.Text == "" || CatDropDown.SelectedIndex == 0 || MarDropDown.SelectedIndex == 0 || NumInvText.Text == "" || DesiText.Text == "" || RefeText.Text == "" || DrppDropDown.SelectedIndex == 0)
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheMa(NumSerText.Text) == true)
                {
                    MessageLabel.Text = "Il existe déjà une matériel avec le même numéro de série !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Materiel values(@NumSer, @CoCa, @CoMa, @NumIn, @Des, @Refe, @DrppP)", connection);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@NumSer", NumSerText.Text);
                    cmd.Parameters.AddWithValue("@CoCa", CatDropDown.SelectedValue);
                    cmd.Parameters.AddWithValue("@CoMa", MarDropDown.SelectedValue);
                    cmd.Parameters.AddWithValue("@NumIn", NumInvText.Text);
                    cmd.Parameters.AddWithValue("@Des", DesiText.Text);
                    cmd.Parameters.AddWithValue("@Refe", RefeText.Text);
                    cmd.Parameters.AddWithValue("@DrppP", DrppDropDown.SelectedValue);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Clear();
                        MessageLabel.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Matériel Ajoutée avec succès.');", true);
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

        protected void DrppDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (DrppDropDown.SelectedIndex == 0)
                {
                    CinText.Text = "";
                    NomPTesxt.Text = "";
                    PrenomPText.Text = "";
                }
                else
                {
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
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }
    }
}
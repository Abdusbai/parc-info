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
    public partial class MaterielDetails : System.Web.UI.Page
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

        protected void InfoLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Request.QueryString["COMA"] != null)
                {
                    string CODMA = Request.QueryString["COMA"].ToString();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select * from Materiel where NumSerMat = '{0}'", CODMA), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        NumSerText.Text = R[0].ToString();
                        CatDropDown.SelectedValue = R[1].ToString();
                        MarDropDown.SelectedValue = R[2].ToString();
                        NumInvText.Text = R[3].ToString();
                        DesiText.Text = R[4].ToString();
                        RefeText.Text = R[5].ToString();
                        string DrppPerso = R[6].ToString();
                        DrppDropDown.SelectedValue = DrppPerso;
                        R.Close();
                        cmd.CommandText = string.Format("select CinPerso, NomPerso, PrenomPerso from Personnel where DrppPerso = '{0}'", DrppPerso);
                        R = cmd.ExecuteReader();
                        if (R.HasRows)
                        {
                            R.Read();
                            CinText.Text = R[0].ToString();
                            NomPTesxt.Text = R[1].ToString();
                            PrenomPText.Text = R[2].ToString();
                        }
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
                    InfoLoad();
                }
            }
        }

        protected void ModifierBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (NumSerText.Text == "" || CatDropDown.SelectedIndex == -1 || MarDropDown.SelectedIndex == 0 || NumInvText.Text == "" || DesiText.Text == "" || RefeText.Text == "" || DrppDropDown.SelectedIndex == 0)
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheMa(NumSerText.Text) == false)
                {
                    MessageLabel.Text = "Matériel n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("update Materiel set CodeCat='{0}', CodeMar='{1}', NumInvMat='{2}', DesignMat='{3}', ReferMat='{4}', DrppPerso='{5}' where NumSerMat='{6}'", CatDropDown.SelectedValue, MarDropDown.SelectedValue, NumInvText.Text, DesiText.Text, RefeText.Text, DrppDropDown.SelectedValue, NumSerText.Text), connection);
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
                if (NumSerText.Text == "" || CatDropDown.SelectedIndex == 0 || MarDropDown.SelectedIndex == 0 || NumInvText.Text == "" || DesiText.Text == "" || RefeText.Text == "" || DrppDropDown.SelectedIndex == 0)
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheMa(NumSerText.Text) == false)
                {
                    MessageLabel.Text = "Matériel n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("delete from Materiel where NumSerMat='{0}'", NumSerText.Text), connection);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Response.Redirect("Materiel.aspx");
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageLabel.Text = "Veuillez vérifier s'il y a des ticket avec ce matériel, si oui il faut d'abord le supprimer.";
                connection.Close();
            }

        }

        protected void AnnulerBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Materiel.aspx");
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
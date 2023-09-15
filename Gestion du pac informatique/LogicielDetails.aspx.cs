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
    public partial class LogicielDetails : System.Web.UI.Page
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

        protected void InfoLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Request.QueryString["COLO"] != null)
                {
                    string CODLO = Request.QueryString["COLO"].ToString();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select * from Logiciel where NumLogic = '{0}'", CODLO), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        NumeroText.Text = R[0].ToString();
                        NomText.Text = R[1].ToString();
                        NomEnText.Text = R[2].ToString();
                        VersionText.Text = R[3].ToString();
                        string DrppPerso = R[4].ToString();
                        DrppDropDown.SelectedValue = DrppPerso;
                        R.Close();
                        cmd.CommandText = string.Format("select CinPerso, NomPerso, PrenomPerso from Personnel where DrppPerso = '{0}'", DrppPerso);
                        R = cmd.ExecuteReader();
                        if(R.HasRows)
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
                    InfoLoad();
                }
            }
        }

        protected void ModifierBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (NumeroText.Text == "" || VersionText.Text == "" || NomText.Text == "" || NomEnText.Text == "" || DrppDropDown.SelectedIndex == 0)
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheLog(NumeroText.Text) == false)
                {
                    MessageLabel.Text = "Logiciel n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("update Logiciel set NomLogic='{0}', NomCompag='{1}', VersionLogic='{2}', DrppPerso='{3}' where NumLogic='{4}'", NomText.Text, NomEnText.Text, VersionText.Text, DrppDropDown.SelectedValue, NumeroText.Text), connection);
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

        protected void SupprimerBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (NumeroText.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheLog(NumeroText.Text) == false)
                {
                    MessageLabel.Text = "Logiciel n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("delete from Logiciel where NumLogic='{0}'", NumeroText.Text), connection);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Response.Redirect("Logiciel.aspx");
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageLabel.Text = "Veuillez vérifier s'il y a des ticket avec ce logiciel, si oui il faut d'abord le supprimer.";
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
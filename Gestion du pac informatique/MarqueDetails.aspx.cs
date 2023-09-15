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
    public partial class MarqueDetails : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        protected void InfoLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Request.QueryString["COMA"] != null)
                {
                    int CodeMa = int.Parse(Request.QueryString["COMA"].ToString());
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select * from Marque where CodeMar = '{0}'", CodeMa), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        CodeText.Text = R[0].ToString();
                        DesText.Text = R[1].ToString();
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

        private bool RechercheMa(int CodeMa)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Marque where CodeMar='{0}'", CodeMa), connection);
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
                if (CodeText.Text == "" || DesText.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheMa(int.Parse(CodeText.Text)) == false)
                {
                    MessageLabel.Text = "Marque n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("update Marque set DescMar='{0}' where CodeMar='{1}'", DesText.Text, int.Parse(CodeText.Text)), connection);
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
            Response.Redirect("Marque.aspx");
        }

        protected void SupprimerBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (DesText.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheMa(int.Parse(CodeText.Text)) == false)
                {
                    MessageLabel.Text = "Marque n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("delete from Marque where CodeMar='{0}'", int.Parse(CodeText.Text)), connection);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Response.Redirect("Marque.aspx");
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
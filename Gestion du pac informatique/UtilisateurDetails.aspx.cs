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
    public partial class UtilisateurDetails : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        protected void InfoLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Request.QueryString["COUT"] != null)
                {
                    string COU = Request.QueryString["COUT"].ToString();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select * from Utilisateur where CinUser = '{0}'", COU), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        CinText.Text = R[0].ToString();
                        PassText.Text = R[1].ToString();
                        NomText.Text = R[2].ToString();
                        PrenomText.Text = R[3].ToString();
                        if (R[4].ToString() == "Administrateur")
                            RoleDropDown.SelectedValue = "0";
                        else if (R[4].ToString() == "Helpdesk")
                            RoleDropDown.SelectedValue = "1";
                        else if (R[4].ToString() == "Technicien")
                        {
                            NomText.ReadOnly = true;
                            PrenomText.ReadOnly = true;
                            RoleDropDown.Enabled = false;
                            RoleDropDown.SelectedValue = "2";
                        }
                        if (R[5].ToString() == "Activé")
                            StatutDropDownList.SelectedValue = "0";
                        else if (R[5].ToString() == "Désactivé")
                            StatutDropDownList.SelectedValue = "1";
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

        private bool RechercheUser(string CinU)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Utilisateur where CinUser='{0}'", CinU), connection);
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
                if (RoleDropDown.SelectedValue == "2")
                {
                    if (CinText.Text == "" || PassText.Text == "" || StatutDropDownList.SelectedIndex == 0)
                    {
                        MessageLabel.Text = "(*) Champs obligatoire !";
                    }
                    else if (RechercheUser(CinText.Text) == false)
                    {
                        MessageLabel.Text = "Utilisateur n'existe pas !";
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(string.Format("update Utilisateur set MotDePasse='{0}', etat_Compte ='{1}' where CinUser='{2}'", PassText.Text,StatutDropDownList.SelectedItem.Text ,CinText.Text), connection);
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
                else
                {
                    if (CinText.Text == "" || PassText.Text == "" || NomText.Text == "" || PrenomText.Text == "" || RoleDropDown.SelectedIndex == 0 || StatutDropDownList.SelectedIndex ==0 )
                    {
                        MessageLabel.Text = "(*) Champs obligatoire !";
                    }
                    else if (RechercheUser(CinText.Text) == false)
                    {
                        MessageLabel.Text = "Utilisateur n'existe pas !";
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("select count(*) from Utilisateur where etat_Compte='Activé' and RoleUser='Administrateur'", connection);
                        int Count = int.Parse(cmd.ExecuteScalar().ToString());
                        if(Count <= 1 && RoleDropDown.SelectedValue == "0" && StatutDropDownList.SelectedValue == "1")
                        {
                            MessageLabel.Text = "Au moins un compte de type Administrateur doit être activé !";
                        }
                        else
                        {
                            if(CinText.Text == Session["CinUser"].ToString() && StatutDropDownList.SelectedValue == "1")
                            {
                                cmd.CommandText = string.Format("update Utilisateur set MotDePasse = '{0}', NomUser = '{1}', PrenomUser = '{2}', RoleUser = '{3}', etat_Compte = '{4}' where CinUser = '{5}'", PassText.Text, NomText.Text, PrenomText.Text, RoleDropDown.SelectedItem.Text, StatutDropDownList.SelectedItem.Text, CinText.Text);
                                int a = cmd.ExecuteNonQuery();
                                if (a != 0)
                                {
                                    MessageLabel.Text = "";
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été Modifiées avec succès.');", true);
                                    Session["CinUser"] = null;
                                    Response.Redirect("Connexion.aspx");
                                }
                                connection.Close();
                            }
                            else
                            {
                                cmd.CommandText = string.Format("update Utilisateur set MotDePasse = '{0}', NomUser = '{1}', PrenomUser = '{2}', RoleUser = '{3}', etat_Compte = '{4}' where CinUser = '{5}'", PassText.Text, NomText.Text, PrenomText.Text, RoleDropDown.SelectedItem.Text, StatutDropDownList.SelectedItem.Text, CinText.Text);
                                int a = cmd.ExecuteNonQuery();
                                if (a != 0)
                                {
                                    MessageLabel.Text = "";
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été Modifiées avec succès.');", true);
                                }
                                connection.Close();
                            }
                        }      
                    }
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
            Response.Redirect("Utilisateur.aspx");
        }
    }
}
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
    public partial class UtilisateurNouveau : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        protected void TechLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Technicien", connection);
                SqlDataReader R = cmd.ExecuteReader();
                DropDownTech.DataSource = R;
                DropDownTech.DataValueField = "CinTech";
                DropDownTech.DataTextField = "CinTech";
                DropDownTech.DataBind();
                DropDownTech.Items.Insert(0, new ListItem("-- Choisir un technicien * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        private bool RechercheUti(string CIN)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Utilisateur where CinUser='{0}'", CIN), connection);
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
            TextCin.Text = "";       
            TextNom.Text = "";
            TextPrenom.Text = "";
            TextPass.Text = "";
            DropDownTech.SelectedIndex = 0;
            RoleDropDown.SelectedIndex = 0;

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
                    DropDownTech.Enabled = false;
                    TechLoad();
                }
            }
        }

        protected void TechDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select CinTech, NomTech, PrenomTech from Technicien where CinTech = '{0}'", DropDownTech.SelectedValue), connection);
                SqlDataReader R = cmd.ExecuteReader();
                if (R.HasRows)
                {
                    R.Read();
                    TextCin.Text = R[0].ToString();
                    TextNom.Text = R[1].ToString();
                    TextPrenom.Text = R[2].ToString();
                    R.Close();
                }
                connection.Close();
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

        protected void RoleDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoleDropDown.SelectedItem.Text == "Technicien")
            {
                DropDownTech.Enabled = true;
                TextNom.ReadOnly = true;
                TextPrenom.ReadOnly = true;
                TextCin.ReadOnly = true;
            }
            else
            {
                DropDownTech.Enabled = false;
                TextNom.ReadOnly = false;
                TextPrenom.ReadOnly = false;
                TextCin.ReadOnly = false;
                TextCin.Text = "";
                TextNom.Text = "";
                TextPrenom.Text = "";
                TextPass.Text = "";
                DropDownTech.SelectedIndex = 0;
            }
        }

        protected void AjouterBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (RoleDropDown.SelectedIndex == 0)
                {
                    MessageLabel.Text = "Veuillez choisir un rôle !";
                }
                else if (RoleDropDown.SelectedItem.Text == "Technicien")
                {
                    if (DropDownTech.SelectedIndex == 0)
                    {
                        MessageLabel.Text = "Veuillez choisir un Technicien !";
                    }
                    else if (TextCin.Text == "" || TextPass.Text == "" || TextNom.Text == "" || TextPrenom.Text == "")
                    {
                        MessageLabel.Text = "(*) Champs obligatoire !";
                    }
                    else if (RechercheUti(TextCin.Text) == true)
                    {
                        MessageLabel.Text = "Il existe déjà un Utilisateur avec le même  CIN !";
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(string.Format("insert into Utilisateur values('{0}','{1}','{2}','{3}','{4}')", TextCin.Text, TextPass.Text, TextNom.Text, TextPrenom.Text, RoleDropDown.SelectedItem.Text), connection);
                        int a = cmd.ExecuteNonQuery();
                        if (a != 0)
                        {
                            Clear();
                            MessageLabel.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Utilisateur Ajoutée avec succès.');", true);
                        }
                        connection.Close();
                    }
                }
                else
                {
                    if (TextCin.Text == "" || TextPass.Text == "" || TextNom.Text == "" || TextPrenom.Text == "")
                    {
                        MessageLabel.Text = "(*) Champs obligatoire !";
                    }
                    else if (RechercheUti(TextCin.Text) == true)
                    {
                        MessageLabel.Text = "Il existe déjà un Utilisateur avec le même  CIN !";
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("insert into Utilisateur values(@Cin_U, @Pass_U, @Nom_U, @prenom_U, @Role_U)", connection);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Cin_U", TextCin.Text);
                        cmd.Parameters.AddWithValue("@Pass_U", TextPass.Text);
                        cmd.Parameters.AddWithValue("@Nom_U", TextNom.Text);
                        cmd.Parameters.AddWithValue("@prenom_U", TextPrenom.Text);
                        
                        cmd.Parameters.AddWithValue("@Role_U", RoleDropDown.SelectedItem.Text);
                        int a = cmd.ExecuteNonQuery();
                        if (a != 0)
                        {
                            Clear();
                            MessageLabel.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Utilisateur Ajoutée avec succès.');", true);
                        }
                        connection.Close();
                    }
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
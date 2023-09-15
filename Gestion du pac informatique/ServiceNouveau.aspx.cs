﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Gestion_du_pac_informatique
{
    public partial class ServiceNouveau : System.Web.UI.Page
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

        private bool RechercheSe(string CodeSe)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Service_de_transfert where CodeServ='{0}'", CodeSe), connection);
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
                }
            }
        }

        private void Clear()
        {
            CodeText.Text = "";
            NomText.Text = "";
            DrppDropDown.SelectedIndex = 0;
            CinText.Text = "";
            NomPTesxt.Text = "";
            PrenomPText.Text = "";
            FonCText.Text = "";
        }


        protected void AjouterBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (CodeText.Text == "" || NomText.Text == "" || DrppDropDown.SelectedIndex == 0)
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheSe(CodeText.Text) == true)
                {
                    MessageLabel.Text = "Il existe déjà un service avec le même Code !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Service_de_transfert values(@codeS, @nomS, @drppP)", connection);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@codeS", CodeText.Text);
                    cmd.Parameters.AddWithValue("@nomS", NomText.Text);
                    cmd.Parameters.AddWithValue("@drppP", DrppDropDown.SelectedValue);

                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        MessageLabel.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Service ajoutée avec succès.');", true);
                    }
                    connection.Close();
                    Clear();
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
            Response.Redirect("ServiceDeTransfert.aspx");
        }

        protected void DrppDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrppDropDown.SelectedIndex == 0)
            {
                CinText.Text = "";
                NomPTesxt.Text = "";
                PrenomPText.Text = "";
                FonCText.Text = "";
            }
            else
            {
                SqlConnection connection = new SqlConnection(STRCON);
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select CinPerso, NomPerso, PrenomPerso, Fonction.DescFo from Personnel inner join Fonction on Personnel.CodeFo = Fonction.CodeFo where DrppPerso = '{0}'", DrppDropDown.SelectedValue.ToString()), connection);
                SqlDataReader R = cmd.ExecuteReader();
                if (R.HasRows)
                {
                    R.Read();
                    CinText.Text = R[0].ToString();
                    NomPTesxt.Text = R[1].ToString();
                    PrenomPText.Text = R[2].ToString();
                    FonCText.Text = R[3].ToString();
                }
                R.Close();
                connection.Close();
            }
        }
    }
}
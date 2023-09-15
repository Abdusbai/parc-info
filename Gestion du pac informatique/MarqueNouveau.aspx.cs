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
    public partial class MarqueNouveau : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

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

        private int NextCode()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            int i = 0;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT CASE WHEN (SELECT COUNT(1) FROM Marque) = 0 THEN 1 ELSE IDENT_CURRENT('Marque') +1 END", connection);
                i = int.Parse(cmd.ExecuteScalar().ToString());
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
            return i;
        }

        private void Clear()
        {
            CodeText.Text = NextCode().ToString();
            DesText.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CodeText.Text = NextCode().ToString();
            }
        }

        protected void AjouterBTN_Click(object sender, EventArgs e)
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
                SqlConnection connection = new SqlConnection(STRCON);
                try
                {
                    if (CodeText.Text == "" || DesText.Text == "")
                    {
                        MessageLabel.Text = "(*) Champs obligatoire !";
                    }
                    else if (RechercheMa(int.Parse(CodeText.Text)) == true)
                    {
                        MessageLabel.Text = "Il existe déjà une Marque avec le même Code !";
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("insert into Marque values(@DescMa)", connection);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@DescMa", DesText.Text);

                        int a = cmd.ExecuteNonQuery();
                        if (a != 0)
                        {
                            MessageLabel.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Marque Ajoutée avec succès.');", true);
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
        }

        protected void AnnulerBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marque.aspx");
        }
    }
}
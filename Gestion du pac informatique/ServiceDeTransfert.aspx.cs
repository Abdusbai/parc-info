﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Gestion_du_pac_informatique
{
    public partial class ServiceDeTransfert : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
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
                SqlConnection connection = new SqlConnection(STRCON);
                if (!IsPostBack)
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("select * from Service_de_transfert", connection);
                        SqlDataReader R = cmd.ExecuteReader();
                        DataTable T = new DataTable();
                        T.Load(R);

                        GridView1.DataSource = T;
                        GridView1.DataBind();
                        R.Close();
                        connection.Close();
                    }
                    catch
                    {
                        connection.Close();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Service_de_transfert where CodeServ like '%{0}%' or NomServ like '%{1}%' or DrppPerso like '%{2}%'", TextBox1.Text, TextBox1.Text, TextBox1.Text), connection);
                SqlDataReader R = cmd.ExecuteReader();
                DataTable T = new DataTable();
                T.Load(R);
                GridView1.DataSource = T;
                GridView1.DataBind();
                Label1.Text = GridView1.Rows.Count + " résultats";
                R.Close();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                int a = e.NewSelectedIndex;
                string code = GridView1.Rows[a].Cells[0].Text;
                Response.Redirect(string.Format("ServiceDetails.aspx?COSE={0}", code));
            }
            catch
            {
                connection.Close();
            }
        }

        protected void NouveauBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceNouveau.aspx");
        }
    }
}
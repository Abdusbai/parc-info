using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Gestion_du_pac_informatique
{
    public partial class Ticket : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CinUser"] == null)
            {
                Response.Redirect("Connexion.aspx");
            }
            else if (Session["Role"].ToString() == "Technicien")
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
                        SqlCommand cmd = new SqlCommand("select CodeTicket, Probleme.TypeProb, Contacte.TypeCont, DateTicket, HeureTicket, DescTicket, NumSerMat, NumLogi, EtatTicket from Ticket inner join Probleme on Ticket.CodProb = Probleme.CodProb inner join Contacte on Ticket.CodCont = Contacte.CodCont", connection);
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

        protected void NouveauBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("TicketNouveau.aspx");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                int a = e.NewSelectedIndex;
                string code = GridView1.Rows[a].Cells[0].Text;
                Response.Redirect(string.Format("TicketDetails.aspx?COTI={0}", code));
            }
            catch
            {
                connection.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select CodeTicket, Probleme.TypeProb, Contacte.TypeCont, DateTicket, HeureTicket, DescTicket, NumSerMat, NumLogi, EtatTicket from Ticket inner join Probleme on Ticket.CodProb = Probleme.CodProb inner join Contacte on Ticket.CodCont = Contacte.CodCont where CodeTicket like '%{0}%' or Probleme.TypeProb like '%{1}%' or Contacte.TypeCont like '%{2}%' or DateTicket like '%{3}%' or HeureTicket like '%{4}%' or DescTicket like '%{5}%' or NumSerMat like '%{6}%' or NumLogi like '%{7}%' or EtatTicket like '%{8}%'", TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text), connection);
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
    }
}
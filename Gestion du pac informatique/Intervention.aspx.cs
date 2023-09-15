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
    public partial class Intervention : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CinUser"] == null)
            {
                Response.Redirect("Connexion.aspx");
            }
            else if(Session["Role"].ToString()== "Technicien")
            {
                SqlConnection connection = new SqlConnection(STRCON);
                if (!IsPostBack)
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(string.Format("select NumInter, DateInter, CodeTicket, CinTech, DateAffectTech, Suite_a_donner.DescSd, DateSd, CodeServ, DateServ, DateRetourServ, CinTechReaff, DateReaff, EtatInter, DateColutre  from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd where CinTech = '{0}' and EtatInter = 'Ouverte'", Session["CinUser"].ToString()), connection);
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
            else
            {
                SqlConnection connection = new SqlConnection(STRCON);
                if (!IsPostBack)
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("select NumInter, DateInter, CodeTicket, CinTech, DateAffectTech, Suite_a_donner.DescSd, DateSd, CodeServ, DateServ, DateRetourServ, CinTechReaff, DateReaff, EtatInter, DateColutre  from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd", connection);
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
                SqlCommand cmd = new SqlCommand(string.Format("select NumInter, DateInter, CodeTicket, CinTech, DateAffectTech, Suite_a_donner.DescSd, DateSd, CodeServ, DateServ, DateRetourServ, CinTechReaff, DateReaff, EtatInter, DateColutre  from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd where NumInter like '%{0}%' or DateInter like '%{1}%' or CodeTicket like '%{2}%' or  CinTech like '%{3}%' or  DateAffectTech like '%{4}%' or Suite_a_donner.DescSd like '%{5}%' or DateSd like '%{6}%' or CodeServ like '%{7}%' or  DateServ like '%{8}%' or  DateRetourServ like '%{9}%' or CinTechReaff like '%{10}%' or DateReaff like '%{11}%' or EtatInter like '%{12}%' or  DateColutre like '%{13}%'", TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text, TextBox1.Text), connection);
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

        protected void NouveauBTN_Click(object sender, EventArgs e)
        {
            if (Session["Role"].ToString() == "Technicien")
            {
                Response.Redirect("Autorise.aspx");
            }
            else
            {
                Response.Redirect("InterventionNouveau.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                int a = e.NewSelectedIndex;
                string code = GridView1.Rows[a].Cells[0].Text;
                Response.Redirect(string.Format("InterventionDetails.aspx?COIN={0}", code));
            }
            catch
            {
                connection.Close();
            }
        }

        protected void SdDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (SdDropDown.SelectedItem.Text == "Sans")
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select NumInter, DateInter, CodeTicket, CinTech, DateAffectTech, Suite_a_donner.DescSd, DateSd, CodeServ, DateServ, DateRetourServ, CinTechReaff, DateReaff, EtatInter, DateColutre  from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd where Suite_a_donner.CodeSd is null ", connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    DataTable T = new DataTable();
                    T.Load(R);
                    GridView1.DataSource = T;
                    GridView1.DataBind();
                    Label1.Text = GridView1.Rows.Count + " résultats";
                    R.Close();
                    connection.Close();
                }
                else if (SdDropDown.SelectedIndex == 0)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select NumInter, DateInter, CodeTicket, CinTech, DateAffectTech, Suite_a_donner.DescSd, DateSd, CodeServ, DateServ, DateRetourServ, CinTechReaff, DateReaff, EtatInter, DateColutre  from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd", connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    DataTable T = new DataTable();
                    T.Load(R);

                    GridView1.DataSource = T;
                    GridView1.DataBind();
                    R.Close();
                    connection.Close();
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select NumInter, DateInter, CodeTicket, CinTech, DateAffectTech, Suite_a_donner.DescSd, DateSd, CodeServ, DateServ, DateRetourServ, CinTechReaff, DateReaff, EtatInter, DateColutre  from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd where Suite_a_donner.DescSd like '%{0}%' ", SdDropDown.SelectedItem.Text), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    DataTable T = new DataTable();
                    T.Load(R);
                    GridView1.DataSource = T;
                    GridView1.DataBind();
                    Label1.Text = GridView1.Rows.Count + " résultats";
                    R.Close();
                    connection.Close();
                }
            }
            catch
            {
                connection.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace Gestion_du_pac_informatique
{
    public partial class InterventionTypeProb : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        private void getdata()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {               
                Series series = Chart1.Series["Series1"];
                connection.Open();
                SqlCommand cmd = new SqlCommand("select count(NumInter),  isnull(Suite_a_donner.DescSd,'Sans') from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd group by Suite_a_donner.DescSd", connection);
                SqlDataReader R = cmd.ExecuteReader();
                while (R.Read())
                {
                    series.Points.AddXY(R[1].ToString(), R[0].ToString());
                }
                R.Close();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        private void interLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
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
                    getdata();
                    interLoad();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (TextBox1.Text == "")
                {
                    getdata();
                    interLoad();
                }
                else
                {
                    Series series = Chart1.Series["Series1"];
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select count(NumInter),  isnull(Suite_a_donner.DescSd,'Sans') from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd  where DateInter = '{0}' group by Suite_a_donner.DescSd", TextBox1.Text), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        Label1.Text = "";
                        while (R.Read())
                        {
                            series.Points.AddXY(R[1].ToString(), R[0].ToString());
                        }
                        R.Close();
                        cmd.CommandText = string.Format("select NumInter, DateInter, CodeTicket, CinTech, DateAffectTech, Suite_a_donner.DescSd, DateSd, CodeServ, DateServ, DateRetourServ, CinTechReaff, DateReaff, EtatInter, DateColutre from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd where DateInter = '{0}'", TextBox1.Text);
                        R = cmd.ExecuteReader();
                        DataTable T = new DataTable();
                        T.Load(R);
                        GridView1.DataSource = T;
                        GridView1.DataBind();
                        R.Close();
                        connection.Close();
                    }
                    else
                    {
                        Label1.Text = "Il n'y a pas de données à afficher";
                    }
                    R.Close();
                    connection.Close();
                }
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
                Response.Redirect(string.Format("InterventionDetails.aspx?COIN={0}", code));
            }
            catch
            {
                connection.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (SdDropDown.SelectedIndex == 0)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select NumInter, DateInter, CodeTicket, CinTech, DateAffectTech, Suite_a_donner.DescSd, DateSd, CodeServ, DateServ, DateRetourServ, CinTechReaff, DateReaff, EtatInter, DateColutre  from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd where NumInter like '%{0}%' or DateInter like '%{1}%' or CodeTicket like '%{2}%' or  CinTech like '%{3}%' or  DateAffectTech like '%{4}%' or Suite_a_donner.DescSd like '%{5}%' or DateSd like '%{6}%' or CodeServ like '%{7}%' or  DateServ like '%{8}%' or  DateRetourServ like '%{9}%' or CinTechReaff like '%{10}%' or DateReaff like '%{11}%' or EtatInter like '%{12}%' or  DateColutre like '%{13}%'", TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    DataTable T = new DataTable();
                    T.Load(R);
                    GridView1.DataSource = T;
                    GridView1.DataBind();
                    Label2.Text = GridView1.Rows.Count + " résultats";
                    R.Close();
                    connection.Close();
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select NumInter, DateInter, CodeTicket, CinTech, DateAffectTech, Suite_a_donner.DescSd, DateSd, CodeServ, DateServ, DateRetourServ, CinTechReaff, DateReaff, EtatInter, DateColutre  from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd where Suite_a_donner.DescSd like '%{0}%' and ( NumInter like '%{1}%' or DateInter like '%{2}%' or CodeTicket like '%{3}%' or  CinTech like '%{4}%' or  DateAffectTech like '%{5}%' or Suite_a_donner.DescSd like '%{6}%' or DateSd like '%{7}%' or CodeServ like '%{8}%' or  DateServ like '%{9}%' or  DateRetourServ like '%{10}%' or CinTechReaff like '%{11}%' or DateReaff like '%{12}%' or EtatInter like '%{13}%' or  DateColutre like '%{14}%')", SdDropDown.SelectedItem.Text,TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text, TextBox2.Text), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    DataTable T = new DataTable();
                    T.Load(R);
                    GridView1.DataSource = T;
                    GridView1.DataBind();
                    Label2.Text = GridView1.Rows.Count + " résultats";
                    R.Close();
                    connection.Close();
                }
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
                    Label2.Text = GridView1.Rows.Count + " résultats";
                    R.Close();

                    Series series = Chart1.Series["Series1"];
                    cmd.CommandText = "select count(NumInter),  isnull(Suite_a_donner.DescSd,'Sans') from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd where Suite_a_donner.DescSd is null group by Suite_a_donner.DescSd ";
                    R = cmd.ExecuteReader();
                    while (R.Read())
                    {
                        series.Points.AddXY(R[1].ToString(), R[0].ToString());
                    }
                    R.Close();
                    connection.Close();
                }
                else if(SdDropDown.SelectedIndex==0)
                {
                    interLoad();
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
                    Label2.Text = GridView1.Rows.Count + " résultats";
                    R.Close();

                    Series series = Chart1.Series["Series1"];
                    cmd.CommandText = string.Format("select count(NumInter),  isnull(Suite_a_donner.DescSd,'Sans') from Intervention left join Suite_a_donner on Intervention.CodeSd = Suite_a_donner.CodeSd where Suite_a_donner.DescSd like '%{0}%' group by Suite_a_donner.DescSd", SdDropDown.SelectedItem.Text);
                    R = cmd.ExecuteReader();
                    while (R.Read())
                    {
                        series.Points.AddXY(R[1].ToString(), R[0].ToString());
                    }
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
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
    public partial class TicketNouveau : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        private void DateHeureLoad()
        {
            Datetext.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HeureText.Text = DateTime.Now.ToString("HH:mm");
        }

        protected void MatLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Materiel", connection);
                SqlDataReader R = cmd.ExecuteReader();
                MatDropDown.DataSource = R;
                MatDropDown.DataValueField = "NumSerMat";
                MatDropDown.DataTextField = "NumSerMat";
                MatDropDown.DataBind();
                MatDropDown.Items.Insert(0, new ListItem("-- Numéro de série du matériel * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        protected void ContacLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Contacte", connection);
                SqlDataReader R = cmd.ExecuteReader();
                ContaDropDown.DataSource = R;
                ContaDropDown.DataValueField = "CodCont";
                ContaDropDown.DataTextField = "TypeCont";
                ContaDropDown.DataBind();
                ContaDropDown.Items.Insert(0, new ListItem("-- Type de contacte * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        protected void ProbLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Probleme", connection);
                SqlDataReader R = cmd.ExecuteReader();
                ProbDropDown.DataSource = R;
                ProbDropDown.DataValueField = "CodProb";
                ProbDropDown.DataTextField = "TypeProb";
                ProbDropDown.DataBind();
                ProbDropDown.Items.Insert(0, new ListItem("-- Type de problème * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        protected void LogLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Logiciel", connection);
                SqlDataReader R = cmd.ExecuteReader();
                LogDrowDown.DataSource = R;
                LogDrowDown.DataValueField = "NumLogic";
                LogDrowDown.DataTextField = "NumLogic";
                LogDrowDown.DataBind();
                LogDrowDown.Items.Insert(0, new ListItem("-- Numéro de série du logiciel * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        private int NextCode()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            int i = 0;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT CASE WHEN (SELECT COUNT(1) FROM Ticket) = 0 THEN 1 ELSE IDENT_CURRENT('Ticket') +1 END", connection);
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CinUser"] == null)
            {
                Response.Redirect("Connexion.aspx");
            }
            else if (Session["Role"].ToString() != "Administrateur" && Session["Role"].ToString() != "Helpdesk")
            {
                Response.Redirect("Autorise.aspx");
            }
            else
            {
                DateHeureLoad();
                if (!IsPostBack)
                {
                    MatDropDown.Enabled = false;
                    LogDrowDown.Enabled = false;
                    MatLoad();
                    LogLoad();
                    ContacLoad();
                    ProbLoad();
                    CodeText.Text = NextCode().ToString();
                }
            }
        }

        protected void ProbDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ProbDropDown.SelectedItem.Text== "Logiciel")
            {
                MatDropDown.Enabled = false;
                InterText.Text = "";
                DesiText.Text = "";
                RefeText.Text = "";
                MarText.Text = "";
                CatText.Text = "";
                LogDrowDown.Enabled = true;
            }
            else if(ProbDropDown.SelectedItem.Text == "Matèriel")
            {
                MatDropDown.Enabled = true;
                LogDrowDown.Enabled = false;
                VersLogi.Text = "";
                NomLogi.Text = "";
                NomEnt.Text = "";
            }
            else
            {
                MatDropDown.Enabled = false;
                InterText.Text = "";
                DesiText.Text = "";
                RefeText.Text = "";
                MarText.Text = "";
                CatText.Text = "";
                LogDrowDown.Enabled = false;
                VersLogi.Text = "";
                NomLogi.Text = "";
                NomEnt.Text = "";
            }
        }

        protected void MatDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (MatDropDown.SelectedIndex == 0)
                {
                    InterText.Text = "";
                    DesiText.Text = "";
                    RefeText.Text = "";
                    MarText.Text = "";
                    CatText.Text = "";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select Categorie.DescCat, Marque.DescMar, NumInvMat, DesignMat, ReferMat, DrppPerso from Materiel inner join Categorie on Materiel.CodeCat = Categorie.CodeCat inner join Marque on Materiel.CodeMar = Marque.CodeMar where NumSerMat = '{0}'", MatDropDown.SelectedValue), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        CatText.Text = R[0].ToString();
                        MarText.Text = R[1].ToString();
                        InterText.Text = R[2].ToString();
                        DesiText.Text = R[3].ToString();
                        RefeText.Text = R[4].ToString();
                        DrppPText.Text = R[5].ToString();
                        R.Close();
                        cmd.CommandText = string.Format("select CinPerso, NomPerso, PrenomPerso from Personnel where DrppPerso = '{0}'", DrppPText.Text);
                        R = cmd.ExecuteReader();
                        if (R.HasRows)
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

        protected void LogDrowDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (LogDrowDown.SelectedIndex == 0)
                {
                    VersLogi.Text = "";
                    NomLogi.Text = "";
                    NomEnt.Text = "";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select * from Logiciel where NumLogic = '{0}'", LogDrowDown.SelectedValue), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        NomLogi.Text = R[1].ToString();
                        NomEnt.Text = R[2].ToString();
                        VersLogi.Text = R[3].ToString();
                        DrppPText.Text = R[4].ToString();
                        R.Close();
                        cmd.CommandText = string.Format("select CinPerso, NomPerso, PrenomPerso from Personnel where DrppPerso = '{0}'", DrppPText.Text);
                        R = cmd.ExecuteReader();
                        if (R.HasRows)
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

        private void Clear()
        {
            CodeText.Text = NextCode().ToString();
            HeureText.Text = DateTime.Now.ToString("HH:mm");
            Datetext.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ProbDropDown.SelectedIndex = 0;
            ContaDropDown.SelectedIndex = 0;
            DescText.Text = "";
            EtatDropDown.SelectedIndex = 0;
            MatDropDown.SelectedIndex = 0;          
            InterText.Text = "";
            DesiText.Text = "";
            RefeText.Text = "";
            MarText.Text = "";
            CatText.Text = "";
            LogDrowDown.SelectedIndex = 0;
            VersLogi.Text = "";
            NomLogi.Text = "";
            NomEnt.Text = "";
            CinText.Text = "";
            DrppPText.Text = "";
            NomPTesxt.Text = "";
            PrenomPText.Text = "";
        }

        protected void AjouterBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (ProbDropDown.SelectedIndex == 0 || ContaDropDown.SelectedIndex == 0 || DescText.Text == "" || EtatDropDown.SelectedIndex == 0)
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (ProbDropDown.SelectedIndex == 1)
                {
                    if (LogDrowDown.SelectedIndex == 0)
                    {
                        MessageLabel.Text = "Veuillez choisir un logiciel !";
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("insert into Ticket(CodProb,CodCont, DateTicket, HeureTicket, DescTicket,NumLogi, EtatTicket) values(@prob, @conta, @date, @heure, @desc, @numLo, @etat)", connection);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@prob", ProbDropDown.SelectedValue);
                        cmd.Parameters.AddWithValue("@conta", ContaDropDown.SelectedValue);
                        cmd.Parameters.AddWithValue("@date", Datetext.Text);
                        cmd.Parameters.AddWithValue("@heure", HeureText.Text);
                        cmd.Parameters.AddWithValue("@desc", DescText.Text);
                        cmd.Parameters.AddWithValue("@numLo", LogDrowDown.SelectedValue);
                        cmd.Parameters.AddWithValue("@etat", EtatDropDown.SelectedItem.Text);
                        int a = cmd.ExecuteNonQuery();
                        if (a != 0)
                        {
                            MessageLabel.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ticket Ajoutée avec succès.');", true);
                        }
                        connection.Close();
                        Clear();
                    }
                }
                else if (ProbDropDown.SelectedIndex == 2)
                {
                    if (MatDropDown.SelectedIndex == 0)
                    {
                        MessageLabel.Text = "Veuillez choisir une matériel !";
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("insert into Ticket(CodProb,CodCont, DateTicket, HeureTicket, DescTicket,NumSerMat, EtatTicket) values(@prob, @conta, @date, @heure, @desc, @numMa, @etat)", connection);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@prob", ProbDropDown.SelectedValue);
                        cmd.Parameters.AddWithValue("@conta", ContaDropDown.SelectedValue);
                        cmd.Parameters.AddWithValue("@date", Datetext.Text);
                        cmd.Parameters.AddWithValue("@heure", HeureText.Text);
                        cmd.Parameters.AddWithValue("@desc", DescText.Text);
                        cmd.Parameters.AddWithValue("@numMa", MatDropDown.SelectedValue);
                        cmd.Parameters.AddWithValue("@etat", EtatDropDown.SelectedItem.Text);
                        int a = cmd.ExecuteNonQuery();
                        if (a != 0)
                        {
                            MessageLabel.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ticket ajoutée avec succès !');", true);
                        }
                        connection.Close();
                        Clear();
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
            Response.Redirect("Ticket.aspx");
        }
    }
}
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
    public partial class InterventionNouveau : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        private int NextCode()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            int i = 0;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT CASE WHEN (SELECT COUNT(1) FROM Intervention) = 0 THEN 1 ELSE IDENT_CURRENT('Intervention') +1 END", connection);
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

        private void LoadInter()
        {
            NumInterText.Text = NextCode().ToString();
            DateInterText.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HeureInterText.Text = DateTime.Now.ToString("HH:mm");
        }

        protected void LoadTicket()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select CodeTicket from Ticket", connection);
                SqlDataReader R = cmd.ExecuteReader();
                CodeTicketDropDown.DataSource = R;
                CodeTicketDropDown.DataValueField = "CodeTicket";
                CodeTicketDropDown.DataTextField = "CodeTicket";
                CodeTicketDropDown.DataBind();
                CodeTicketDropDown.Items.Insert(0, new ListItem("-- N° séquentiel * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        protected void LoadTech()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select CinTech from Technicien", connection);
                SqlDataReader R = cmd.ExecuteReader();
                CinTechDropDown.DataSource = R;
                CinTechDropDown.DataValueField = "CinTech";
                CinTechDropDown.DataTextField = "CinTech";
                CinTechDropDown.DataBind();
                CinTechDropDown.Items.Insert(0, new ListItem("-- Cin du technicien * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        private void Clear()
        {
            NumInterText.Text = NextCode().ToString();
            DateInterText.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HeureInterText.Text = DateTime.Now.ToString("HH:mm");
            DescInterText.Text = "";
            CodeTicketDropDown.SelectedIndex = 0;
            Datetext.Text = "";
            HeureText.Text = "";
            TypeProbText.Text = "";
            ContaText.Text = "";
            DescText.Text = "";
            EtatTicketText.Text = "";
            NumSerMatText.Text = "";
            InterText.Text = "";
            DesiText.Text = "";
            RefeText.Text = "";
            MarText.Text = "";
            CatText.Text = "";
            NumSerLog.Text = "";
            VersLogi.Text = "";
            NomLogi.Text = "";
            NomEnt.Text = "";
            DrppPText.Text = "";
            CinText.Text = "";
            NomPTesxt.Text = "";
            PrenomPText.Text = "";
            CinTechDropDown.SelectedIndex = -1;
            NomTech.Text = "";
            PreTech.Text = "";
            DateAff.Text = "";
            HeureAff.Text = "";
        }


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
                if (!IsPostBack)
                {
                    LoadInter();
                    LoadTicket();
                    LoadTech();
                }
            }
        }

        protected void AjouterBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (DescInterText.Text == "" || CodeTicketDropDown.SelectedIndex == 0 || CinTechDropDown.SelectedIndex==0 || DateAff.Text==""||HeureAff.Text=="")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else
                {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("insert into Intervention(DateInter, HeureInter, DescInter, CodeTicket, CinTech, DateAffectTech, HeureAffectTech, EtatInter) values(@DateI, @HeureI, @DesI, @CodeT, @TechA, @DateA, @HeureA, @Etat)", connection);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@DateI", DateInterText.Text);
                        cmd.Parameters.AddWithValue("@HeureI", HeureInterText.Text);
                        cmd.Parameters.AddWithValue("@DesI", DescInterText.Text);
                        cmd.Parameters.AddWithValue("@CodeT", CodeTicketDropDown.SelectedValue);
                        cmd.Parameters.AddWithValue("@TechA", CinTechDropDown.SelectedValue);
                        cmd.Parameters.AddWithValue("@DateA", DateAff.Text);
                        cmd.Parameters.AddWithValue("@HeureA", HeureAff.Text);
                        cmd.Parameters.AddWithValue("@Etat", "Ouverte");
                        int a = cmd.ExecuteNonQuery();
                        if (a != 0)
                        {
                            MessageLabel.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Intervention Ajoutée avec succès.');", true);
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
            Response.Redirect("Intervention.aspx");
        }

        protected void ProbDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (CodeTicketDropDown.SelectedIndex == 0)
                {
                    Datetext.Text = "";
                    HeureText.Text = "";
                    TypeProbText.Text = "";
                    ContaText.Text = "";
                    DescText.Text = "";
                    EtatTicketText.Text = "";
                    CinText.Text = "";
                    NomPTesxt.Text = "";
                    PrenomPText.Text = "";
                    DrppPText.Text = "";
                    NumSerLog.Text = "";
                    NomLogi.Text = "";
                    NomEnt.Text = "";
                    VersLogi.Text = "";

                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select Probleme.TypeProb, Contacte.TypeCont, DateTicket, HeureTicket, DescTicket, NumSerMat, NumLogi, EtatTicket from Ticket inner join Probleme on Ticket.CodProb = Probleme.CodProb inner join Contacte on Ticket.CodCont = Contacte.CodCont where CodeTicket = '{0}'", CodeTicketDropDown.SelectedValue), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        TypeProbText.Text = R[0].ToString();
                        ContaText.Text = R[1].ToString();
                        Datetext.Text = R[2].ToString();
                        HeureText.Text = R[3].ToString();
                        DescText.Text = R[4].ToString();
                        EtatTicketText.Text = R[7].ToString();
                        string NumMaTT = R[5].ToString();
                        string NumLog = R[6].ToString();
                        R.Close();
                        if (NumMaTT != "" && NumLog == "")
                        {
                            NumSerLog.Text = "";
                            NomLogi.Text = "";
                            NomEnt.Text = "";
                            VersLogi.Text = "";
                            cmd.CommandText = string.Format("select NumSerMat, Categorie.DescCat, Marque.DescMar, NumInvMat, DesignMat, ReferMat, DrppPerso from Materiel inner join Categorie on Materiel.CodeCat = Categorie.CodeCat inner join Marque on Materiel.CodeMar = Marque.CodeMar where NumSerMat = '{0}'", NumMaTT);
                            R = cmd.ExecuteReader();
                            if (R.HasRows)
                            {
                                R.Read();
                                NumSerMatText.Text = R[0].ToString();
                                CatText.Text = R[1].ToString();
                                MarText.Text = R[2].ToString();
                                InterText.Text = R[3].ToString();
                                DesiText.Text = R[4].ToString();
                                RefeText.Text = R[5].ToString();
                                DrppPText.Text = R[6].ToString();
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
                        }
                        else if(NumMaTT == "" && NumLog != "")
                        {
                            NumSerMatText.Text = "";
                            CatText.Text = "";
                            MarText.Text = "";
                            InterText.Text = "";
                            DesiText.Text = "";
                            RefeText.Text = "";
                            DrppPText.Text = "";
                            cmd.CommandText = string.Format("select * from Logiciel where NumLogic = '{0}'", NumLog);
                            R = cmd.ExecuteReader();
                            if (R.HasRows)
                            {
                                R.Read();
                                NumSerLog.Text = R[0].ToString();
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

        protected void CinTechDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (CinTechDropDown.SelectedIndex == 0)
                {
                    NomTech.Text = "";
                    PreTech.Text = "";
                    DateAff.Text = "";
                    HeureAff.Text = "";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select NomTech, PrenomTech from Technicien where CinTech = '{0}'", CinTechDropDown.SelectedValue), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        NomTech.Text = R[0].ToString();
                        PreTech.Text = R[1].ToString();
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
    }
}
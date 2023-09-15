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
    public partial class TicketDetails : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        protected void InfoLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Request.QueryString["COTI"] != null)
                {
                    string COT = Request.QueryString["COTI"].ToString();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select CodeTicket, Probleme.TypeProb, Contacte.TypeCont, DateTicket, HeureTicket, DescTicket, NumSerMat, NumLogi, EtatTicket from Ticket inner join Probleme on Ticket.CodProb = Probleme.CodProb inner join Contacte on Ticket.CodCont = Contacte.CodCont where CodeTicket = '{0}'", COT), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        CodeText.Text = R[0].ToString();
                        ProbText.Text = R[1].ToString();
                        ContaText.Text = R[2].ToString();
                        Datetext.Text = Convert.ToDateTime(R[3]).ToString("yyyy-MM-dd");
                        HeureText.Text = Convert.ToDateTime(R[4]).ToString("HH:mm");
                        DescText.Text = R[5].ToString();
                        if (R[8].ToString() == "Ouverte")
                            EtatDropDown.SelectedValue = "0";
                        else if (R[8].ToString() == "Fermée")
                            EtatDropDown.SelectedValue = "1";
                        if (R[6].ToString() != "" && R[7].ToString() == "")
                        {
                            NumSerMat.Text = R[6].ToString();
                            R.Close();                           
                            cmd.CommandText = string.Format("select Categorie.DescCat, Marque.DescMar, NumInvMat, DesignMat, ReferMat, DrppPerso from Materiel inner join Categorie on Materiel.CodeCat = Categorie.CodeCat inner join Marque on Materiel.CodeMar = Marque.CodeMar where NumSerMat = '{0}'", NumSerMat.Text);
                            R = cmd.ExecuteReader();
                            if (R.HasRows)
                            {
                                R.Read();
                                InterText.Text = R[2].ToString();
                                DesiText.Text = R[3].ToString();
                                RefeText.Text = R[4].ToString();
                                MarText.Text = R[1].ToString();
                                CatText.Text = R[0].ToString();
                                DrppP.Text = R[5].ToString();
                                R.Close();
                                cmd.CommandText = string.Format("select CinPerso, NomPerso, PrenomPerso from Personnel where DrppPerso = '{0}'", DrppP.Text);
                                R = cmd.ExecuteReader();
                                if(R.HasRows)
                                {
                                    R.Read();
                                    CinText.Text = R[0].ToString();
                                    NomPTesxt.Text = R[1].ToString();
                                    PrenomPText.Text = R[2].ToString();
                                    R.Close();
                                }
                            }
                        }
                        else if (R[6].ToString() == "" && R[7].ToString() != "")
                        {
                            NumSerLog.Text = R[7].ToString();
                            R.Close();
                            cmd.CommandText = string.Format("select * from Logiciel where NumLogic = '{0}'",NumSerLog.Text);
                            R = cmd.ExecuteReader();
                            if(R.HasRows)
                            {
                                R.Read();
                                NomLogi.Text = R[1].ToString();
                                NomEnt.Text = R[2].ToString();
                                VersLogi.Text = R[3].ToString();
                                DrppP.Text = R[4].ToString();
                                R.Close();
                                cmd.CommandText = string.Format("select CinPerso, NomPerso, PrenomPerso from Personnel where DrppPerso = '{0}'", DrppP.Text);
                                R = cmd.ExecuteReader();
                                if (R.HasRows)
                                {
                                    R.Read();
                                    CinText.Text = R[0].ToString();
                                    NomPTesxt.Text = R[1].ToString();
                                    PrenomPText.Text = R[2].ToString();
                                    R.Close();
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

        private bool RechercheTicket(int Code)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            bool a = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Ticket where CodeTicket='{0}'", Code), connection);
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
            else if (Session["Role"].ToString() == "Technicien")
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
                if (CodeText.Text == "" || EtatDropDown.SelectedIndex == 0)
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheTicket(int.Parse(CodeText.Text)) == false)
                {
                    MessageLabel.Text = "Ticket n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("update Ticket set EtatTicket='{0}' where CodeTicket='{1}'", EtatDropDown.SelectedItem.Text, int.Parse(CodeText.Text)), connection);
                    cmd.ExecuteNonQuery();
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        MessageLabel.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été modifiées avec succès.');", true);
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        protected void SupprimerBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (CodeText.Text == "")
                {
                    MessageLabel.Text = "(*) Champs obligatoire !";
                }
                else if (RechercheTicket(int.Parse(CodeText.Text)) == false)
                {
                    MessageLabel.Text = "Ticket n'existe pas !";
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("delete from Ticket where CodeTicket='{0}'", int.Parse(CodeText.Text)), connection);
                    int a = cmd.ExecuteNonQuery();
                    if (a != 0)
                    {
                        Response.Redirect("Ticket.aspx");
                    }
                    connection.Close();
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
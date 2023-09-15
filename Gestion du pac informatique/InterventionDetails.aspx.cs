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
    public partial class InterventionDetails : System.Web.UI.Page
    {
        string STRCON = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;

        private void InterLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Request.QueryString["COIN"] != null)
                {
                    string COI = Request.QueryString["COIN"].ToString();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select * from Intervention where NumInter = '{0}'", COI), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        NumInterText.Text = R[0].ToString();
                        DateInterText.Text = Convert.ToDateTime(R[1]).ToString("yyyy-MM-dd");
                        HeureInterText.Text = Convert.ToDateTime(R[2]).ToString("HH:mm");
                        DescInterText.Text = R[3].ToString();
                        CodeTicketText.Text = R[4].ToString();
                        CinTechAff.Text = R[5].ToString();
                        DateAff.Text = Convert.ToDateTime(R[6]).ToString("yyyy-MM-dd");
                        HeureAff.Text = Convert.ToDateTime(R[7]).ToString("HH:mm");
                        string NomS = "";
                        if (R[12].ToString() != "")
                        {
                            SerTranDropDown.SelectedValue = R[12].ToString();
                            NomS = R[12].ToString();
                        }

                        DateSerT.Text = R[13].ToString();
                        HeureSerT.Text = R[14].ToString();
                        DescSerT.Text = R[15].ToString();
                        if(R[16].ToString()!="")
                            DateRT.Text = Convert.ToDateTime(R[16]).ToString("yyyy-MM-dd");
                        if (R[17].ToString() != "")
                            HeureRT.Text = Convert.ToDateTime(R[17]).ToString("HH:mm");
                        if (R[18].ToString() != "")
                            TechReaffDropDown.SelectedValue = R[18].ToString();
                        if (R[19].ToString() != "")
                            DateReaff.Text = Convert.ToDateTime(R[19]).ToString("yyyy-MM-dd");
                        if (R[20].ToString() != "")
                            HeureReaff.Text = Convert.ToDateTime(R[20]).ToString("HH:mm");
                        if (R[21].ToString() != "")
                            DateCO.Text = Convert.ToDateTime(R[21]).ToString("yyyy-MM-dd");
                        if (R[22].ToString() != "")
                            HeureCO.Text = Convert.ToDateTime(R[22]).ToString("HH:mm");
                        DescCO.Text = R[23].ToString();

                        if (R[24].ToString() == "")
                            EtatInterDropDown.SelectedIndex = 0;
                        else if (R[24].ToString() == "Ouverte")
                            EtatInterDropDown.SelectedValue = "0";
                        else if (R[24].ToString() == "Fermée")
                            EtatInterDropDown.SelectedValue = "1";
                        R.Close();

                        if (NomS != "")
                        {
                            cmd.CommandText = string.Format("select NomServ from Service_de_transfert where CodeServ = '{0}'", NomS);
                            R = cmd.ExecuteReader();
                            if (R.HasRows)
                            {
                                R.Read();
                                NomSerT.Text = R[0].ToString();
                            }
                            R.Close();
                        }
                        cmd.CommandText = string.Format("select NomTech, PrenomTech from Technicien where CinTech = '{0}'", CinTechAff.Text);
                        R = cmd.ExecuteReader();
                        if (R.HasRows)
                        {
                            R.Read();
                            NomTech.Text = R[0].ToString();
                            PreTech.Text = R[1].ToString();
                        }
                        R.Close();
                        cmd.CommandText = string.Format("select CodeTicket, Probleme.TypeProb, Contacte.TypeCont, DateTicket, HeureTicket, DescTicket, NumSerMat, NumLogi, EtatTicket from Ticket inner join Probleme on Ticket.CodProb = Probleme.CodProb inner join Contacte on Ticket.CodCont = Contacte.CodCont where CodeTicket = '{0}'", CodeTicketText.Text);
                        R = cmd.ExecuteReader();
                        if (R.HasRows)
                        {
                            R.Read();
                            TypeProbText.Text = R[1].ToString();
                            ContaText.Text = R[2].ToString();
                            Datetext.Text = Convert.ToDateTime(R[3]).ToString("yyyy-MM-dd");
                            HeureText.Text = Convert.ToDateTime(R[4]).ToString("HH:mm");
                            DescText.Text = R[5].ToString();
                            EtatTicketText.Text = R[8].ToString();

                            if (R[1].ToString() == "Matèriel")
                                NumSerMatText.Text = R[6].ToString();

                            else if (R[1].ToString() == "Logiciel")
                                NumSerLog.Text = R[7].ToString();

                            R.Close();

                            if (NumSerMatText.Text != "")
                            {
                                cmd.CommandText = string.Format("select Categorie.DescCat, Marque.DescMar, NumInvMat, DesignMat, ReferMat, DrppPerso from Materiel inner join Categorie on Materiel.CodeCat = Categorie.CodeCat inner join Marque on Materiel.CodeMar = Marque.CodeMar where NumSerMat = '{0}'", NumSerMatText.Text);
                                R = cmd.ExecuteReader();
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
                                        R.Close();
                                    }
                                }
                            }
                            else if (NumSerLog.Text != "")
                            {
                                cmd.CommandText = string.Format("select * from Logiciel where NumLogic = '{0}'", NumSerLog.Text);
                                R = cmd.ExecuteReader();
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
                                        R.Close();
                                    }
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

        private void SdLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Suite_a_donner", connection);
                SqlDataReader R = cmd.ExecuteReader();
                SdDropDown.DataSource = R;
                SdDropDown.DataValueField = "CodeSd";
                SdDropDown.DataTextField = "DescSd";
                SdDropDown.DataBind();
                SdDropDown.Items.Insert(0, new ListItem("-- Suite à donner * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        private void ServTransLoad()
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Service_de_transfert", connection);
                SqlDataReader R = cmd.ExecuteReader();
                SerTranDropDown.DataSource = R;
                SerTranDropDown.DataValueField = "CodeServ";
                SerTranDropDown.DataTextField = "CodeServ";
                SerTranDropDown.DataBind();
                SerTranDropDown.Items.Insert(0, new ListItem("-- Service de transfert * --", "-1", true));
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
                TechReaffDropDown.DataSource = R;
                TechReaffDropDown.DataValueField = "CinTech";
                TechReaffDropDown.DataTextField = "CinTech";
                TechReaffDropDown.DataBind();
                TechReaffDropDown.Items.Insert(0, new ListItem("-- Cin du technicien * --", "-1", true));
                R.Close();
                connection.Close();
            }
            catch
            {
                MessageLabel.Text = "Une erreur s'est produite. veuillez réessayer !";
                connection.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            if (Session["CinUser"] == null)
            {
                Response.Redirect("Connexion.aspx");
            }
            else if (Session["Role"].ToString() == "Technicien")
            {
                if (!IsPostBack)
                {
                    SerTranDropDown.Enabled = false;
                    NomSerT.ReadOnly = true;
                    DateSerT.ReadOnly = true;
                    HeureSerT.ReadOnly = true;
                    DescSerT.ReadOnly = true;
                    DateRT.ReadOnly = true;
                    HeureRT.ReadOnly = true;
                    TechReaffDropDown.Enabled = false;
                    NomTechReff.ReadOnly = true;
                    PrenomTechReff.ReadOnly = true;
                    DateReaff.ReadOnly = true;
                    HeureReaff.ReadOnly = true;
                    DateCO.ReadOnly = true;
                    HeureCO.ReadOnly = true;
                    DescCO.ReadOnly = true;
                    EtatInterDropDown.Enabled = false;
                    InterLoad();
                    SdLoad();
                    ServTransLoad();
                    LoadTech();
                    connection.Open();
                    string COI = Request.QueryString["COIN"].ToString();
                    SqlCommand cmd = new SqlCommand(string.Format("select EtatInter from Intervention where NumInter = '{0}'", COI), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        R.Read();
                        if (R[0].ToString() == "Fermée")
                        {
                            SdDropDown.Enabled = false;
                            DateSd.ReadOnly = true;
                            HeureSd.ReadOnly = true;
                            DescSd.ReadOnly = true;
                            R.Close();
                            connection.Close();
                        }
                        else
                        {
                            R.Close();
                            cmd.CommandText = string.Format("select CodeSd, DateSd, HeureSd, DescSd from Intervention where NumInter = '{0}'", NumInterText.Text);
                            R = cmd.ExecuteReader();
                            if (R.HasRows)
                            {
                                try
                                {
                                    R.Read();
                                    SdDropDown.SelectedValue = R[0].ToString();
                                    DateSd.Text = Convert.ToDateTime(R[1]).ToString("yyyy-MM-dd");
                                    HeureSd.Text = Convert.ToDateTime(R[2]).ToString("HH:mm");
                                    DescSd.Text = R[3].ToString();
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
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    DateCO.ReadOnly = true;
                    HeureCO.ReadOnly = true;
                    DescCO.ReadOnly = true;
                    EtatInterDropDown.Enabled = false;
                    SdDropDown.Enabled = false;
                    DateSd.ReadOnly = true;
                    HeureSd.ReadOnly = true;
                    DescSd.ReadOnly = true;
                    InterLoad();
                    SdLoad();
                    ServTransLoad();
                    LoadTech();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("select CodeSd, DateSd, HeureSd, DescSd from Intervention where NumInter = '{0}'", NumInterText.Text), connection);
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.HasRows)
                    {
                        try
                        {
                            SerTranDropDown.Enabled = false;
                            TechReaffDropDown.Enabled = false;
                            DateSerT.ReadOnly = true;
                            HeureSerT.ReadOnly = true;
                            DescSerT.ReadOnly = true;
                            DateRT.ReadOnly = true;
                            HeureRT.ReadOnly = true;
                            R.Read();
                            SdDropDown.SelectedValue = R[0].ToString();
                            DateSd.Text = Convert.ToDateTime(R[1]).ToString("yyyy-MM-dd");
                            HeureSd.Text = Convert.ToDateTime(R[2]).ToString("HH:mm");
                            DescSd.Text = R[3].ToString();
                            R.Close();
                            if (SdDropDown.SelectedItem.Text == "A transférer")
                            {
                                TechReaffDropDown.Enabled = false;
                                SerTranDropDown.Enabled = true;
                                DateSerT.ReadOnly = false;
                                HeureSerT.ReadOnly = false;
                                DescSerT.ReadOnly = false;
                                DateRT.ReadOnly = false;
                                HeureRT.ReadOnly = false;
                                DateCO.ReadOnly = true;
                                HeureCO.ReadOnly = true;
                                DescCO.ReadOnly = true;
                                EtatInterDropDown.Enabled = false;
                                connection.Close();

                            }
                            else if (SdDropDown.SelectedItem.Text == "Différé")
                            {
                                TechReaffDropDown.Enabled = true;
                                DateReaff.ReadOnly = false;
                                HeureReaff.ReadOnly = false;
                                SerTranDropDown.Enabled = false;
                                DateSerT.ReadOnly = true;
                                HeureSerT.ReadOnly = true;
                                DescSerT.ReadOnly = true;
                                DateRT.ReadOnly = true;
                                HeureRT.ReadOnly = true;
                                DateCO.ReadOnly = true;
                                HeureCO.ReadOnly = true;
                                DescCO.ReadOnly = true;
                                EtatInterDropDown.Enabled = false;
                                connection.Close();
                            }
                            else if (SdDropDown.SelectedItem.Text == "Résolu")
                            {
                                DateCO.ReadOnly = false;
                                HeureCO.ReadOnly = false;
                                DescCO.ReadOnly = false;
                                EtatInterDropDown.Enabled = true;
                                SerTranDropDown.Enabled = false;
                                TechReaffDropDown.Enabled = false;
                                DateSerT.ReadOnly = true;
                                HeureSerT.ReadOnly = true;
                                DescSerT.ReadOnly = true;
                                DateRT.ReadOnly = true;
                                HeureRT.ReadOnly = true;
                                connection.Close();
                            }
                            else if (SdDropDown.SelectedItem.Text == "Non résolu")
                            {
                                TechReaffDropDown.Enabled = false;
                                SerTranDropDown.Enabled = false;
                                DateReaff.ReadOnly = true;
                                HeureReaff.ReadOnly = true;
                                DateSerT.ReadOnly = true;
                                HeureSerT.ReadOnly = true;
                                DescSerT.ReadOnly = true;
                                DateRT.ReadOnly = true;
                                HeureRT.ReadOnly = true;
                                DateCO.ReadOnly = false;
                                HeureCO.ReadOnly = false;
                                DescCO.ReadOnly = false;
                                EtatInterDropDown.Enabled = true;
                            }
                        }
                        catch
                        {
                            DateCO.ReadOnly = false;
                            HeureCO.ReadOnly = false;
                            DescCO.ReadOnly = false;
                            EtatInterDropDown.Enabled = true;
                            SerTranDropDown.Enabled = false;
                            TechReaffDropDown.Enabled = false;
                            DateSerT.ReadOnly = true;
                            HeureSerT.ReadOnly = true;
                            DescSerT.ReadOnly = true;
                            DateRT.ReadOnly = true;
                            HeureRT.ReadOnly = true;
                            connection.Close();
                        }
                    }
                    connection.Close();
                }

            }
        }

        protected void AnnulerBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Intervention.aspx");
        }

        protected void SerTranDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select NomServ from Service_de_transfert where CodeServ = '{0}'", SerTranDropDown.SelectedValue), connection);
                SqlDataReader R = cmd.ExecuteReader();
                if (R.HasRows)
                {
                    R.Read();
                    NomSerT.Text = R[0].ToString();
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

        protected void TechReaffDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select NomTech, PrenomTech from Technicien where CinTech = '{0}'", TechReaffDropDown.SelectedValue), connection);
                SqlDataReader R = cmd.ExecuteReader();
                if (R.HasRows)
                {
                    R.Read();
                    NomTechReff.Text = R[0].ToString();
                    PrenomTechReff.Text = R[1].ToString();
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

        protected void ModifierBTN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(STRCON);
            try
            {
                if (Session["Role"].ToString() == "Technicien")
                {
                    if (SdDropDown.SelectedIndex == 0 || DateSd.Text == "" || HeureSd.Text == "" || DescSd.Text == "")
                    {
                        MessageLabel.Text = "(*) Champs obligatoire !";
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(string.Format("update Intervention set CodeSd='{0}', DateSd='{1}', HeureSd='{2}', DescSd='{3}' where NumInter='{4}'", SdDropDown.SelectedValue, DateSd.Text, HeureSd.Text, DescSd.Text, NumInterText.Text), connection);
                        cmd.ExecuteNonQuery();
                        int a = cmd.ExecuteNonQuery();
                        if (a != 0)
                        {
                            MessageLabel.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été Modifiées avec succès.');", true);
                        }
                        connection.Close();
                    }
                }
                else
                {
                    if (SdDropDown.SelectedItem.Text == "A transférer")
                    {
                        if (SerTranDropDown.SelectedIndex == 0 || NomSerT.Text == "" || DateSerT.Text == "" || HeureSerT.Text == "" || DescSerT.Text == "" || DateRT.Text == "" || HeureRT.Text == "")
                        {
                            MessageLabel.Text = "Veuillez sélectionner un service de transfert !";
                        }
                        else
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand(string.Format("update Intervention set CodeServ='{0}', DateServ='{1}', HeureServ='{2}', DescServ='{3}', DateRetourServ='{4}', HeureRetourServ='{5}' where NumInter='{6}'", SerTranDropDown.SelectedValue, DateSerT.Text, HeureSerT.Text, DescSerT.Text, DateRT.Text, HeureRT.Text, NumInterText.Text), connection);
                            cmd.ExecuteNonQuery();
                            int a = cmd.ExecuteNonQuery();
                            if (a != 0)
                            {
                                MessageLabel.Text = "";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été Modifiées avec succès.');", true);
                            }
                            connection.Close();
                        }
                    }
                    else if (SdDropDown.SelectedItem.Text == "Différé")
                    {
                        if (TechReaffDropDown.SelectedIndex == 0 || DateReaff.Text == "" || HeureReaff.Text == "")
                        {
                            MessageLabel.Text = "Veuillez sélectionner un technicien !";
                        }
                        else
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand(string.Format("update Intervention set CinTechReaff='{0}', DateReaff='{1}', HeureReaff='{2}' where NumInter='{3}'", TechReaffDropDown.SelectedValue, DateReaff.Text, HeureReaff.Text, NumInterText.Text), connection);
                            cmd.ExecuteNonQuery();
                            int a = cmd.ExecuteNonQuery();
                            if (a != 0)
                            {
                                MessageLabel.Text = "";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été Modifiées avec succès.');", true);
                            }
                            connection.Close();
                        }
                    }
                    else if (SdDropDown.SelectedItem.Text == "Résolu")
                    {
                        if (DateCO.Text == "" || HeureCO.Text == "" || DescCO.Text == "")
                        {
                            MessageLabel.Text = "Veuillez remplir les données pour clôturer cette intervention !";
                        }
                        else if (EtatInterDropDown.SelectedValue != "1")
                        {
                            MessageLabel.Text = "Veuillez d'abord fermer l'intervention";
                        }
                        else
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand(string.Format("update Intervention set DateColutre='{0}', HeureColutre='{1}', DescColutre='{2}', EtatInter='{3}' where NumInter='{4}'", DateCO.Text, HeureCO.Text, DescCO.Text, EtatInterDropDown.SelectedItem.Text, NumInterText.Text), connection);
                            cmd.ExecuteNonQuery();
                            int a = cmd.ExecuteNonQuery();
                            if (a != 0)
                            {
                                MessageLabel.Text = "";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été Modifiées avec succès.');", true);
                            }
                            connection.Close();
                        }
                    }
                    else if (SdDropDown.SelectedItem.Text == "Non résolu")
                    {
                        if (DateCO.Text == "" || HeureCO.Text == "" || DescCO.Text == "")
                        {
                            MessageLabel.Text = "Veuillez remplir les données pour clôturer cette intervention !";
                        }
                        else if (EtatInterDropDown.SelectedValue != "1")
                        {
                            MessageLabel.Text = "Veuillez d'abord fermer l'intervention";
                        }
                        else
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand(string.Format("update Intervention set DateColutre='{0}', HeureColutre='{1}', DescColutre='{2}', EtatInter='{3}' where NumInter='{4}'", DateCO.Text, HeureCO.Text, DescCO.Text, EtatInterDropDown.SelectedItem.Text, NumInterText.Text), connection);
                            cmd.ExecuteNonQuery();
                            int a = cmd.ExecuteNonQuery();
                            if (a != 0)
                            {
                                MessageLabel.Text = "";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été Modifiées avec succès.');", true);
                            }
                            connection.Close();
                        }
                    }
                    else
                    {
                        if (DateCO.Text == "" || HeureCO.Text == "" || DescCO.Text == "" || EtatInterDropDown.SelectedIndex == 0)
                        {
                            MessageLabel.Text = "Veuillez remplir les données de clôture si vous souhaitez clôturer cette intervention !";
                        }
                        else
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand(string.Format("update Intervention set DateColutre='{0}', HeureColutre='{1}', DescColutre='{2}', EtatInter='{3}' where NumInter='{4}'", DateCO.Text, HeureCO.Text, DescCO.Text, EtatInterDropDown.SelectedItem.Text, NumInterText.Text), connection);
                            cmd.ExecuteNonQuery();
                            int a = cmd.ExecuteNonQuery();
                            if (a != 0)
                            {
                                MessageLabel.Text = "";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Les données ont été Modifiées avec succès.');", true);
                            }
                            connection.Close();
                        }
                    }
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
                if (Session["Role"].ToString() == "Technicien")
                {
                    Response.Redirect("Autorise.aspx");
                }
                else
                {
                    if (NumInterText.Text == "")
                    {
                        MessageLabel.Text = "Intervention introuvable !";
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(string.Format("delete from Intervention where NumInter='{0}'", NumInterText.Text), connection);
                        int a = cmd.ExecuteNonQuery();
                        if (a != 0)
                        {
                            Response.Redirect("Technicien.aspx");
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
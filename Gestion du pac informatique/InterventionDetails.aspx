<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InterventionDetails.aspx.cs" Inherits="Gestion_du_pac_informatique.InterventionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Détails d'Intervention</h1>
    <form runat="server" method="get">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card-body">
            <h6 class="mt-0">Détails d'Intervention</h6>
            <hr style="width: 610px; float: left; background-color: black; height: 2px" />
            <br />
            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="NumInterText" placeholder="N° séquentiel *" Width="611px" runat="server" ReadOnly="true"></asp:TextBox>
                <label for="NumInterText">N° séquentiel *</label>
            </div>

            <div class="input-group">
                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="DateInterText" placeholder="Date *" Width="300px" runat="server" ReadOnly="true" MaxLength="15" TextMode="Date"></asp:TextBox>
                    <label for="DateInterText">Date *</label>
                </div>

                <span class="input-group-btn" style="width: 11px;"></span>

                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="HeureInterText" placeholder="Heure *" Width="300px" runat="server" ReadOnly="true" MaxLength="15" TextMode="Time"></asp:TextBox>
                    <label for="HeureInterText">Heure *</label>
                </div>
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>


                    <div class="form-floating mb-5">
                        <asp:TextBox class="form-control" ID="DescInterText" placeholder="Description *" Width="611px" ReadOnly="true" runat="server" MaxLength="200"></asp:TextBox>
                        <label for="DescInterText">Description *</label>
                    </div>

                    <!--*****************************************************-->

                    <h6 class="mt-0">Détails du Ticket</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 3px" />
                    <br />
                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="CodeTicketText" placeholder="N° séquentiel *" Width="611px" ReadOnly="true" runat="server" MaxLength="200"></asp:TextBox>
                        <label for="CodeTicketText">N° séquentiel *</label>
                    </div>

                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="Datetext" placeholder="Date de ticket *" Width="300px" runat="server" ReadOnly="true" MaxLength="15" TextMode="Date"></asp:TextBox>
                            <label for="Datetext">Date de ticket *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="HeureText" placeholder="Heure de ticket *" Width="300px" runat="server" ReadOnly="true" MaxLength="15" TextMode="Time"></asp:TextBox>
                            <label for="HeureText">Heure de ticket *</label>
                        </div>
                    </div>
                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="TypeProbText" placeholder="Type de problème *" Width="300px" runat="server" ReadOnly="true"></asp:TextBox>
                            <label for="TypeProbText">Type de problème *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="ContaText" placeholder="Type de contacte *" Width="300px" runat="server" ReadOnly="true"></asp:TextBox>
                            <label for="ContaText">Type de contacte *</label>
                        </div>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="DescText" placeholder="Description *" Width="611px" ReadOnly="true" runat="server" MaxLength="250"></asp:TextBox>
                        <label for="DescText">Description *</label>
                    </div>

                    <div class="form-floating mb-5">
                        <asp:TextBox class="form-control" ID="EtatTicketText" placeholder="L'état du ticket *" Width="611px" ReadOnly="true" runat="server" MaxLength="250"></asp:TextBox>
                        <label for="EtatTicketText">L'état du ticket *</label>
                    </div>

                    <!--*****************************************************-->

                    <h6 class="mt-0">Détails du Matériel</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 2px" />
                    <br />
                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="NumSerMatText" placeholder="Numéro de dérie du matériel*" Width="300px" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                            <label for="NumSerMatText">Numéro de dérie du matériel *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="InterText" placeholder="Numéro d'inventaire *" Width="300px" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                            <label for="InterText">Numéro d'inventaire *</label>
                        </div>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="DesiText" placeholder="Désignation *" Width="611px" runat="server" MaxLength="250" ReadOnly="true"></asp:TextBox>
                        <label for="DesiText">Désignation *</label>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="RefeText" placeholder="Référence *" Width="611px" runat="server" MaxLength="250" ReadOnly="true"></asp:TextBox>
                        <label for="RefeText">Référence *</label>
                    </div>

                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="MarText" placeholder="Marque *" Width="300px" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                            <label for="MarText">Marque *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-5">
                            <asp:TextBox class="form-control" ID="CatText" placeholder="Catégorie *" Width="300px" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                            <label for="CatText">Catégorie *</label>
                        </div>
                    </div>

                    <!--*****************************************************-->

                    <h6 class="mt-0">Détails du logiciel</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 2px" />
                    <br />
                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="NumSerLog" placeholder="Numéro de dérie du logiciel*" Width="300px" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                            <label for="NumSerLog">Numéro de dérie du logiciel *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="VersLogi" placeholder="Numéro de version *" Width="300px" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                            <label for="VersLogi">Numéro de version *</label>
                        </div>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="NomLogi" placeholder="Nom du logiciel *" Width="611px" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                        <label for="NomLogi">Nom du logiciel *</label>
                    </div>

                    <div class="form-floating mb-5">
                        <asp:TextBox class="form-control" ID="NomEnt" placeholder="Nom d'entreprise *" Width="611px" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                        <label for="NomEnt">Nom d'entreprise *</label>
                    </div>
                    <!--*****************************************************-->
                    <h6 class="mt-0">Détails du personnel</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 3px" />
                    <br />
                    <div class="input-group">

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="DrppPText" placeholder="Drpp du personnel  *" Width="300px" MaxLength="10" runat="server" ReadOnly="true"></asp:TextBox>
                            <label for="DrppPText">Drpp du personnel *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="CinText" placeholder="CIN *" Width="300px" runat="server" MaxLength="20" ReadOnly="true"></asp:TextBox>
                            <label for="CinText">CIN *</label>
                        </div>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="NomPTesxt" placeholder="Nom *" Width="611px" runat="server" MaxLength="40" ReadOnly="true"></asp:TextBox>
                        <label for="NomPTesxt">Nom du personnel *</label>
                    </div>

                    <div class="form-floating mb-5">
                        <asp:TextBox class="form-control" ID="PrenomPText" placeholder="Prénom *" Width="611px" runat="server" MaxLength="40" ReadOnly="true"></asp:TextBox>
                        <label for="PrenomPText">Prénom du personnel *</label>
                    </div>

                    <!--*****************************************************-->

                    <h6 class="mt-0">Détails du technicien affecté</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 2px" />
                    <br />
                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="CinTechAff" placeholder="Cin du technicien  *" Width="611px" MaxLength="10" runat="server" ReadOnly="true"></asp:TextBox>
                        <label for="CinTechAff">Cin du technicien *</label>
                    </div>
                    <div class="input-group">

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="NomTech" placeholder="Nom  *" Width="300px" MaxLength="10" runat="server" ReadOnly="true"></asp:TextBox>
                            <label for="NomTech">Nom *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="PreTech" placeholder="Prénom *" Width="300px" runat="server" MaxLength="20" ReadOnly="true"></asp:TextBox>
                            <label for="PreTech">Prénom *</label>
                        </div>
                    </div>

                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="DateAff" placeholder="Date d'affectation *" Width="300px" runat="server" ReadOnly="true" MaxLength="15" TextMode="Date"></asp:TextBox>
                            <label for="DateAff">Date d'affectation *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-5">
                            <asp:TextBox class="form-control" ID="HeureAff" placeholder="Heure d'affectation *" Width="300px" runat="server" ReadOnly="true" MaxLength="15" TextMode="Time"></asp:TextBox>
                            <label for="HeureAff">Heure d'affectation *</label>
                        </div>
                    </div>

                    <!--*****************************************************-->

                    <h6 class="mt-0">Suite à donner au problème</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 3px" />
                    <br />
                    <div class="form-floating mb-3">
                        <small>Suite à donner *</small><br />
                        <asp:DropDownList ID="SdDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="DateSd" placeholder="Date *" Width="300px" runat="server" MaxLength="15" TextMode="Date"></asp:TextBox>
                            <label for="DateSd">Date *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="HeureSd" placeholder="Heure *" Width="300px" runat="server" MaxLength="15" TextMode="Time"></asp:TextBox>
                            <label for="HeureSd">Heure  *</label>
                        </div>
                    </div>
                    <div class="form-floating mb-5">
                        <asp:TextBox class="form-control" ID="DescSd" placeholder="Description *" Width="611px" runat="server" MaxLength="250"></asp:TextBox>
                        <label for="DescSd">Description *</label>
                    </div>

                    <!--*****************************************************-->

                    <h6 class="mt-0">Service de Transfert</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 2px" />
                    <br />
                    <div class="form-floating mb-3">
                        <small>Code de service de transfert *</small><br />
                        <asp:DropDownList ID="SerTranDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true" AutoPostBack="True" OnSelectedIndexChanged="SerTranDropDown_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                     <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="NomSerT" placeholder="Nom du service de transfert *" ReadOnly="true" Width="611px"  runat="server" MaxLength="250"></asp:TextBox>
                        <label for="NomSerT">Nom du service de transfert *</label>
                    </div>

                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="DateSerT" placeholder="Date *" Width="300px" runat="server"  MaxLength="15" TextMode="Date"></asp:TextBox>
                            <label for="DateSerT">Date *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="HeureSerT" placeholder="Heure *" Width="300px" runat="server"  MaxLength="15" TextMode="Time"></asp:TextBox>
                            <label for="HeureSerT">Heure  *</label>
                        </div>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="DescSerT" placeholder="Description *" Width="611px" runat="server" MaxLength="250"></asp:TextBox>
                        <label for="DescSerT">Description *</label>
                    </div>

                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="DateRT" placeholder="Date du retour au service de support *"  Width="300px" runat="server" MaxLength="15" TextMode="Date"></asp:TextBox>
                            <label for="DateRT">Date du retour au service de support *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-5">
                            <asp:TextBox class="form-control" ID="HeureRT" placeholder="Heure du retour au service de support *"  Width="300px" runat="server" MaxLength="15" TextMode="Time"></asp:TextBox>
                            <label for="HeureRT">Heure du retour au service de support  *</label>
                        </div>
                    </div>

                    <!--*****************************************************-->

                    <h6 class="mt-0">Détails du technicien réaffecté</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 2px" />
                    <br />
                    <div class="form-floating mb-3">
                        <small>Cin du technicien *</small><br />
                        <asp:DropDownList ID="TechReaffDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true" AutoPostBack="True" OnSelectedIndexChanged="TechReaffDropDown_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="input-group">

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="NomTechReff" placeholder="Nom  *" ReadOnly="true" Width="300px" MaxLength="10" runat="server" ></asp:TextBox>
                            <label for="NomTechReff">Nom *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="PrenomTechReff" placeholder="Prénom *"  Width="300px" runat="server" MaxLength="20" ReadOnly="true"></asp:TextBox>
                            <label for="PrenomTechReff">Prénom *</label>
                        </div>
                    </div>

                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="DateReaff" placeholder="Date d'affectation *" Width="300px" readonly="true" runat="server" MaxLength="15" TextMode="Date"></asp:TextBox>
                            <label for="DateReaff">Date de réaffectation *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-5">
                            <asp:TextBox class="form-control" ID="HeureReaff" placeholder="Heure d'affectation *" Width="300px" readonly="true" runat="server" MaxLength="15" TextMode="Time"></asp:TextBox>
                            <label for="HeureReaff">Heure de réaffectation *</label>
                        </div>
                    </div>


                    <!--*****************************************************-->

                    <h6 class="mt-0">Clôture de la fiche attestatant a la fin de l'intervention</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 3px" />
                    <br />

                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="DateCO" placeholder="Date *" Width="300px" runat="server" MaxLength="15" TextMode="Date"></asp:TextBox>
                            <label for="DateCO">Date  *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="HeureCO" placeholder="Heure *" Width="300px" runat="server" MaxLength="15" TextMode="Time"></asp:TextBox>
                            <label for="HeureCO">Heure *</label>
                        </div>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="DescCO" placeholder="Description *" Width="611px" runat="server" MaxLength="250"></asp:TextBox>
                        <label for="DescCO">Description *</label>
                    </div>

                    <small>L'état de lintervention *</small><br />
                    <asp:DropDownList ID="EtatInterDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true" AutoPostBack="True">
                        <asp:ListItem Value="-1">-- L'état lintervention * --</asp:ListItem>
                        <asp:ListItem Value="0">Ouverte</asp:ListItem>
                        <asp:ListItem Value="1">Fermée</asp:ListItem>
                    </asp:DropDownList>

                    <!--*****************************************************-->

                </ContentTemplate>
            </asp:UpdatePanel>
            <div>
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>

            <div class="mt-4 mb-0">
                <asp:Button ID="ModifierBTN" class="btn btn-success" runat="server" Text="Modifier" OnClick="ModifierBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Modifier les données de cette Intervention')" />
                <asp:Button ID="SupprimerBTN" class="btn btn-danger" runat="server" Text="Supprimer" OnClick="SupprimerBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Supprimer cette Intervention ?')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>
    </form>
</asp:Content>

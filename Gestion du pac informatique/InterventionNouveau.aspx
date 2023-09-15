<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InterventionNouveau.aspx.cs" Inherits="Gestion_du_pac_informatique.InterventionNouveau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Ajouter un Intervention</h1>
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
                        <asp:TextBox class="form-control" ID="DescInterText" placeholder="Description *" Width="611px" runat="server" MaxLength="200"></asp:TextBox>
                        <label for="DescInterText">Description *</label>
                    </div>

                    <h6 class="mt-0">Détails du Ticket</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 3px" />
                    <br />
                    <div class="form-floating mb-3">
                        <small>N° séquentiel *</small><br />
                        <asp:DropDownList ID="CodeTicketDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true" AutoPostBack="True" OnSelectedIndexChanged="ProbDropDown_SelectedIndexChanged">
                        </asp:DropDownList>
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

                    <h6 class="mt-0">Détails du technicien affecté</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 2px" />
                    <br />
                     <div class="form-floating mb-3">
                            <small>Cin du technicien *</small><br />
                            <asp:DropDownList ID="CinTechDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true" AutoPostBack="True" OnSelectedIndexChanged="CinTechDropDown_SelectedIndexChanged">
                            </asp:DropDownList>
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
                            <asp:TextBox class="form-control" ID="DateAff" placeholder="Date d'affectation *" Width="300px" runat="server"  MaxLength="15" TextMode="Date"></asp:TextBox>
                            <label for="DateAff">Date d'affectation *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="HeureAff" placeholder="Heure d'affectation *" Width="300px" runat="server"  MaxLength="15" TextMode="Time"></asp:TextBox>
                            <label for="HeureAff">Heure d'affectation *</label>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div>
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>

            <div class="mt-4 mb-0">
                <asp:Button ID="AjouterBTN" class="btn btn-success" runat="server" Text="Ajouter" OnClick="AjouterBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Ajouter une Intervention')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>
    </form>
</asp:Content>

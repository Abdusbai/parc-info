<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TicketDetails.aspx.cs" Inherits="Gestion_du_pac_informatique.TicketDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Ticket</h1>

    <form runat="server" method="get">
        <div class="card-body">
            <h6 class="mt-0">Détails du Ticket</h6>
            <hr style="width: 610px; float: left; background-color:black; height:2px" />
            <br />
            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="CodeText" placeholder="N° séquentiel *" Width="611px" runat="server" ReadOnly="true"></asp:TextBox>
                <label for="CodeText">N° séquentiel *</label>
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
                    <asp:TextBox class="form-control" ID="ProbText" placeholder="Type du problème *" Width="300px" runat="server" ReadOnly="true"></asp:TextBox>
                    <label for="ProbText">Type du problème *</label>
                </div>

                <span class="input-group-btn" style="width: 11px;"></span>

                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="ContaText" placeholder="Type du contacte *" Width="300px" runat="server" ReadOnly="true"></asp:TextBox>
                    <label for="ContaText">Type du contacte *</label>
                </div>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="DescText" placeholder="Description *" Width="611px" runat="server" ReadOnly="true" MaxLength="250"></asp:TextBox>
                <label for="DescText">Description *</label>
            </div>

            <div class="form-floating mb-5">
                <small>L'état du ticket *</small><br />
                <asp:DropDownList ID="EtatDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611" Height="58px" readonly="true">
                    <asp:ListItem Value="-1">-- L'état du ticket * --</asp:ListItem>
                    <asp:ListItem Value="0">Ouverte</asp:ListItem>
                    <asp:ListItem Value="1">Fermée</asp:ListItem>
                </asp:DropDownList>
            </div>
            <h6 class="mt-0">Détails du Matériel</h6>
            <hr style="width: 610px; float: left; background-color:black; height:3px" />
            <br />
            <div class="input-group">
                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="NumSerMat" placeholder="Numéro de série du matériel  *" Width="300px" MaxLength="50" runat="server" ReadOnly="true"></asp:TextBox>
                    <label for="NumSerMat">Numéro de série du matériel *</label>
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
            <hr style="width: 610px; float: left; background-color:black; height:3px" />
            <br />
            <div class="input-group">
                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="NumSerLog" placeholder="Numéro de série du logiciel  *" Width="300px" MaxLength="30" runat="server" ReadOnly="true"></asp:TextBox>
                    <label for="NumSerLog">Numéro de série du logiciel *</label>
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
            <hr style="width: 610px; float: left; background-color:black; height:2px" />
            <br />
            <div class="input-group">

                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="DrppP" placeholder="Drpp du personnel  *" Width="300px" MaxLength="10" runat="server" ReadOnly="true"></asp:TextBox>
                    <label for="DrppP">Drpp du personnel *</label>
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

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="PrenomPText" placeholder="Prénom *" Width="611px" runat="server" MaxLength="40" ReadOnly="true"></asp:TextBox>
                <label for="PrenomPText">Prénom du personnel *</label>
            </div>
            <div>
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>

            <div class="mt-4 mb-0">
                <asp:Button ID="ModifierBTN" class="btn btn-success" runat="server" Text="Modifier" OnClick="ModifierBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Modifier les données de cette Ticket')" />
                <asp:Button ID="SupprimerBTN" class="btn btn-danger" runat="server" Text="Supprimer" OnClick="SupprimerBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Supprimer cette Ticket ?')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>
    </form>
</asp:Content>

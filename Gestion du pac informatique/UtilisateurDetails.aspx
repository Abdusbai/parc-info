<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UtilisateurDetails.aspx.cs" Inherits="Gestion_du_pac_informatique.UtilisateurDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Utilisateur</h1>
    <form runat="server" method="get">
        <div class="card-body">
            <h6 class="mt-0">Détails d'Utilisateur</h6>
            <hr style="width: 610px; float: left; background-color: black; height: 2px" />
            <br />
            <div class="form-floating mb-3">
                <small>Rôle d'Utilisateur *</small><br />
                <asp:DropDownList ID="RoleDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true">
                    <asp:ListItem Value="-1">-- Rôle d'Utilisateur * --</asp:ListItem>
                    <asp:ListItem Value="0">Administrateur</asp:ListItem>
                    <asp:ListItem Value="1">Helpdesk</asp:ListItem>
                    <asp:ListItem Value="2">Technicien</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="input-group">
                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="CinText" placeholder="Cin *" Width="300px" runat="server" MaxLength="30" ReadOnly="true"></asp:TextBox>
                    <label for="CinText">Cin *</label>
                </div>

                <span class="input-group-btn" style="width: 11px;"></span>

                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="PassText" placeholder="Mot de passe *" Width="300px" runat="server" MaxLength="30"></asp:TextBox>
                    <label for="PassText">Mot de passe *</label>
                </div>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="NomText" placeholder="Nom *" Width="611px" runat="server" MaxLength="40"></asp:TextBox>
                <label for="NomText">Nom *</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="PrenomText" placeholder="Prénom *" Width="611px" runat="server" MaxLength="40"></asp:TextBox>
                <label for="PrenomText">Prénom *</label>
            </div> 

            <div class="form-floating mb-3">
                <small>Statut du compte *</small><br />
                <asp:DropDownList ID="StatutDropDownList" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true">
                    <asp:ListItem Value="-1">-- Statut du compte * --</asp:ListItem>
                    <asp:ListItem Value="0">Activé</asp:ListItem>
                    <asp:ListItem Value="1">Désactivé</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div>
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>

            <div class="mt-4 mb-0">
                <asp:Button ID="ModifierBTN" class="btn btn-success" runat="server" Text="Modifier" OnClick="ModifierBTN_Click" OnClientClick="return confirm('Voulez-vous modifier les données de cet Utilisateur ?')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>
    </form>
</asp:Content>

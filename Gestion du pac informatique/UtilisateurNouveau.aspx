<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UtilisateurNouveau.aspx.cs" Inherits="Gestion_du_pac_informatique.UtilisateurNouveau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Utilisateur</h1>
    <form runat="server" method="get">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>



        <div class="card-body">
            <h6 class="mt-0">Ajouter un Utilisateur</h6>
            <hr style="width: 610px; float: left; background-color: black; height: 2px" />
            <br />
            <div class="form-floating mb-3">
                <small>Rôle d'Utilisateur *</small><br />
                <asp:DropDownList ID="RoleDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true" AutoPostBack="True" OnSelectedIndexChanged="RoleDropDown_SelectedIndexChanged">
                    <asp:ListItem Value="-1">-- Rôle d'Utilisateur * --</asp:ListItem>
                    <asp:ListItem Value="0">Administrateur</asp:ListItem>
                    <asp:ListItem Value="1">Helpdesk</asp:ListItem>
                    <asp:ListItem Value="2">Technicien</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="form-floating mb-3">
                        <small>Cin du technicien *</small><br />
                        <asp:DropDownList ID="DropDownTech" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true" AutoPostBack="True" OnSelectedIndexChanged="TechDropDown_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="input-group">
                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="TextCin" placeholder="Cin *" Width="300px" runat="server" MaxLength="30"></asp:TextBox>
                            <label for="CinText">Cin *</label>
                        </div>

                        <span class="input-group-btn" style="width: 11px;"></span>

                        <div class="form-floating mb-3">
                            <asp:TextBox class="form-control" ID="TextPass" placeholder="Mot de passe *" Width="300px" runat="server" MaxLength="30"></asp:TextBox>
                            <label for="PassText">Mot de passe *</label>
                        </div>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="TextNom" placeholder="Nom *" Width="611px" runat="server" MaxLength="40"></asp:TextBox>
                        <label for="NomText">Nom *</label>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="TextPrenom" placeholder="Prénom *" Width="611px" runat="server" MaxLength="40"></asp:TextBox>
                        <label for="PrenomText">Prénom *</label>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>


            <div>
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>

            <div class="mt-4 mb-0">
                <asp:Button ID="AjouterBTN" class="btn btn-success" runat="server" Text="Ajouter" OnClick="AjouterBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Ajouter un Utilisateur')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>

    </form>
</asp:Content>

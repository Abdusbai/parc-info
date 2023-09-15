<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ServiceNouveau.aspx.cs" Inherits="Gestion_du_pac_informatique.ServiceNouveau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Ajouter un Service de Transfert</h1>
    <form runat="server" method="get">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card-body">
            <h6 class="mt-0">Details du Service de Transfert </h6>
            <hr style="width: 610px; float: left; background-color: black; height: 2px" />
            <br />
            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="CodeText" placeholder="Code du service *" MaxLength="20" Width="611px" runat="server"></asp:TextBox>
                <label for="CodeText">Code du service *</label>
            </div>

            <div class="form-floating mb-5">
                <asp:TextBox class="form-control" ID="NomText" placeholder="Nom du service *" Width="611px" runat="server" MaxLength="30"></asp:TextBox>
                <label for="NomText">Nom du service *</label>
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <h6 class="mt-0">Détails du Responsable</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 2px" />
            <br />
                    <div class="form-floating mb-3">
                        <small>Drpp du personnel *</small><br />
                        <asp:DropDownList ID="DrppDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true" OnSelectedIndexChanged="DrppDropDown_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="CinText" placeholder="CIN *" Width="611px" runat="server" MaxLength="20" ReadOnly="true"></asp:TextBox>
                        <label for="CinText">CIN *</label>
                    </div>


                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="NomPTesxt" placeholder="Nom *" Width="611px" runat="server" MaxLength="40" ReadOnly="true"></asp:TextBox>
                        <label for="NomPTesxt">Nom du personnel *</label>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="PrenomPText" placeholder="Prénom *" Width="611px" runat="server" MaxLength="40" ReadOnly="true"></asp:TextBox>
                        <label for="PrenomPText">Prénom du personnel *</label>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" ID="FonCText" placeholder="Prénom *" Width="611px" runat="server" MaxLength="40" ReadOnly="true"></asp:TextBox>
                        <label for="FonCText">Fonction *</label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div>
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>

            <div class="mt-4 mb-0">
                <asp:Button ID="AjouterBTN" class="btn btn-success" runat="server" Text="Ajouter" OnClick="AjouterBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Ajouter un Service de Transfert ?')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>
    </form>
</asp:Content>

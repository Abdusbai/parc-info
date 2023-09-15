<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LogicielDetails.aspx.cs" Inherits="Gestion_du_pac_informatique.LogicielDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Logiciel</h1>
    <form runat="server" method="get">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card-body">
            <h6 class="mt-0">Détails du Logiciel</h6>
            <hr style="width: 610px; float: left; background-color: black; height: 3px" />
            <br />
            <div class="input-group">
                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="NumeroText" placeholder="Numéro *" Width="300px" runat="server" MaxLength="30" ReadOnly="true"></asp:TextBox>
                    <label for="NumeroText">Numéro *</label>
                </div>

                <span class="input-group-btn" style="width: 11px;"></span>

                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="VersionText" placeholder="Version *" Width="300px" runat="server" MaxLength="20"></asp:TextBox>
                    <label for="VersionText">Version *</label>
                </div>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="NomText" placeholder="Nom *" Width="611px" runat="server" MaxLength="50"></asp:TextBox>
                <label for="NomText">Nom *</label>
            </div>

            <div class="form-floating mb-5">
                <asp:TextBox class="form-control" ID="NomEnText" placeholder="Nom de l'entreprise *" Width="611px" runat="server" MaxLength="50"></asp:TextBox>
                <label for="NomEnText">Nom de l'entreprise *</label>
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <h6 class="mt-0">Détails du Personnel</h6>
                    <hr style="width: 610px; float: left; background-color: black; height: 3px" />
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
                </ContentTemplate>
            </asp:UpdatePanel>

            <div>
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>

            <div class="mt-4 mb-0">
                <asp:Button ID="ModifierBTN" class="btn btn-success" runat="server" Text="Modifier" OnClick="ModifierBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Modifier les données de ce Logiciel')" />
                <asp:Button ID="SupprimerBTN" class="btn btn-danger" runat="server" Text="Supprimer" OnClick="SupprimerBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Supprimer ce Logiciel ?')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>

    </form>
</asp:Content>

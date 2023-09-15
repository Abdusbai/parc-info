<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MaterielDetails.aspx.cs" Inherits="Gestion_du_pac_informatique.MaterielDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Matériel</h1>

    <form runat="server" method="get">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card-body">
            <h6 class="mt-0">Détails du Matériel</h6>
            <hr style="width: 610px; float: left; background-color: black; height: 2px" />
            <br />
            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="NumSerText" placeholder="Numéro de série *" Width="611px" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                <label for="NumSerText">Numéro de série *</label>
            </div>

            <div class="input-group">
                <div class="form-floating mb-3">
                    <small>Catégorie *</small><br />
                    <asp:DropDownList ID="CatDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="300px" Height="58px" readonly="true">
                    </asp:DropDownList>
                </div>

                <span class="input-group-btn" style="width: 11px;"></span>

                <div class="form-floating mb-3">
                    <small>Marque *</small><br />
                    <asp:DropDownList ID="MarDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="300px" Height="58px" readonly="true">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="NumInvText" placeholder="Numéro d'inventaire *" Width="611px" runat="server" MaxLength="50"></asp:TextBox>
                <label for="NumInvText">Numéro d'inventaire *</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="DesiText" placeholder="Désignation *" Width="611px" runat="server" MaxLength="250"></asp:TextBox>
                <label for="DesiText">Désignation *</label>
            </div>

            <div class="form-floating mb-5">
                <asp:TextBox class="form-control" ID="RefeText" placeholder="Référence *" Width="611px" runat="server" MaxLength="250"></asp:TextBox>
                <label for="RefeText">Référence *</label>
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
                <asp:Button ID="ModifierBTN" class="btn btn-success" runat="server" Text="Modifier" OnClick="ModifierBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Modifier les données de cette Matériel')" />
                <asp:Button ID="SupprimerBTN" class="btn btn-danger" runat="server" Text="Supprimer" OnClick="SupprimerBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Supprimer cette Matériel ?')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>

    </form>
</asp:Content>

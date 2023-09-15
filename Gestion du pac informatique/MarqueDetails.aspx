<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MarqueDetails.aspx.cs" Inherits="Gestion_du_pac_informatique.MarqueDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1 class="mt-4">Marque</h1>
    <form runat="server" method="get">
        <div class="card-body">
            <h6 class="mt-0">Détails du Marque</h6>
            <hr style="width: 610px; float: left; background-color: black; height: 2px" />
            <br />
            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="CodeText" placeholder="Code *" Width="611px" runat="server" ReadOnly="true" ></asp:TextBox>
                <label for="CodeText">Code *</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="DesText" placeholder="Désignation *" Width="611px" runat="server" MaxLength="50"></asp:TextBox>
                <label for="DesText">Désignation *</label>
            </div>           
          
            <div>
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>

            <div class="mt-4 mb-0">
                <asp:Button ID="ModifierBTN" class="btn btn-success" runat="server" Text="Modifier" OnClick="ModifierBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Modifier les données de cette Marque')" />
                <asp:Button ID="SupprimerBTN" class="btn btn-danger" runat="server" Text="Supprimer" OnClick="SupprimerBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Supprimer cette Marque ?')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>
    </form>

</asp:Content>

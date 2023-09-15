<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MarqueNouveau.aspx.cs" Inherits="Gestion_du_pac_informatique.MarqueNouveau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Marque</h1>
    <form runat="server" method="get">
        <div class="card-body">
            <h6 class="mt-0">Ajouter une Marque</h6>
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
                <asp:Button ID="AjouterBTN" class="btn btn-success" runat="server" Text="Ajouter" OnClick="AjouterBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Ajouter une Marque ?')"/>
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click"/>
            </div>
        </div>
    </form>
</asp:Content>

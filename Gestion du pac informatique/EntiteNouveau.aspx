<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EntiteNouveau.aspx.cs" Inherits="Gestion_du_pac_informatique.EntiteNouveau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4"> Entité</h1>
    <form runat="server" method="get">
        <div class="card-body">
            <h6 class="mt-0">Ajouter une Entité</h6>
            <hr style="width: 610px; float: left; background-color: black; height: 2px" />
            <br />
            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="Loca" placeholder="Localisation *" runat="server" Width="611px" MaxLength="8"></asp:TextBox>
                <label for="Loca">Localisation *</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="Abre" placeholder="Abreviation" runat="server" Width="611px" MaxLength="30"></asp:TextBox>
                <label for="Abre">Abreviation</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="Dire" placeholder="Direction" runat="server" Width="611px" MaxLength="250"></asp:TextBox>
                <label for="Dire">Direction</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="Div" placeholder="Division" runat="server" Width="611px" MaxLength="250"></asp:TextBox>
                <label for="Div">Division</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="Serv" placeholder="Service" runat="server" Width="611px" MaxLength="250"></asp:TextBox>
                <label for="Serv">Service</label>
            </div>


            <div>
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>
            <div class="mt-4 mb-0">
                <asp:Button ID="AjouterBTN" class="btn btn-success" runat="server" Text="Ajouter" OnClientClick="return confirm('Voulez-vous vraiment Ajouter une entité ?')" OnClick="AjouterBTN_Click" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>
    </form>
</asp:Content>

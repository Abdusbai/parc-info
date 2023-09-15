<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EntiteDetails.aspx.cs" Inherits="Gestion_du_pac_informatique.EntiteDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Entité</h1>
    <form runat="server" method="get">
        <div class="card-body">
            <h6 class="mt-0">Détails d'Entité</h6>
            <hr style="width: 610px; float: left; background-color: black; height: 2px" />
            <br />
            <div class="input-group">
                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="Loca" placeholder="Localisation *" Width="300px" runat="server" ReadOnly="true" MaxLength="8"></asp:TextBox>
                    <label for="Loca">Localisation *</label>
                </div>

                <span class="input-group-btn" style="width: 11px;"></span>

                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="Abre" placeholder="Abreviation" Width="300px" runat="server" MaxLength="30"></asp:TextBox>
                    <label for="Abre">Abreviation</label>
                </div>
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
                <asp:Button ID="ModifierBTN" class="btn btn-success" runat="server" Text="Modifier" OnClick="ModifierBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Modifier les données de cette Entité ?')" />
                <asp:Button ID="SupprimerBTN" class="btn btn-danger" runat="server" Text="Supprimer" OnClick="SupprimerBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Supprimer cette Entité ?')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>
    </form>
</asp:Content>

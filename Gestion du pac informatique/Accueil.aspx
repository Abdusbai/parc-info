<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Accueil.aspx.cs" Inherits="Gestion_du_pac_informatique.Acceuil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .FFF {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-top: 60px
        }
    </style>
    <h1 class="mt-4">Accueil</h1>
    <form runat="server" class="FFF" method="get">
        <div>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/MAPDEF.png" Width="500px" />
        </div>
    </form>
</asp:Content>

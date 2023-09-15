<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Technicien.aspx.cs" Inherits="Gestion_du_pac_informatique.Technicien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Technicien</h1>
    <form runat="server" method="get">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="d-flex align-items-center form-inline ms-auto me-0 me-md-0 my-2 my-md-3">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox1" aria-label="Rechercher..." class="form-control" placeholder="Rechercher..." aria-describedby="btnNavbarSearch" runat="server"></asp:TextBox>
                        <asp:Button class="btn btn-primary" ID="Button1" Text="Rechercher" runat="server" OnClick="Button1_Click" />
                    </div>

                    <div class="input-group">
                        <div class="m-1">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>

                    </div>

                    <div class="mt-0 mb-0">
                        <asp:Button ID="NouveauBTN" class="btn btn-primary" OnClick="NouveauBTN_Click" runat="server" Text="Nouveau" />
                    </div>
                </div>

                <asp:GridView ID="GridView1" class="table table-bordered table-condensed table-responsive table-hover " runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="CinTech" HeaderText="Cin" />
                        <asp:BoundField DataField="NomTech" HeaderText="Nom" />
                        <asp:BoundField DataField="PrenomTech" HeaderText="Prénom" />
                        <asp:BoundField DataField="DateNeTech" HeaderText="Date de naissance" />
                        <asp:BoundField DataField="DateRecTech" HeaderText="Date de recrutement" />
                        <asp:BoundField DataField="NumBurTech" HeaderText="N° de bureau" />
                        <asp:BoundField DataField="TeleBurTech" HeaderText="Téléphone du bureau" />
                        <asp:BoundField DataField="GsmTech" HeaderText="Gsm" />
                        <asp:BoundField DataField="EmailTech" HeaderText="E-mail" />

                        <asp:CommandField DeleteText="Détails" SelectText="Détails" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>

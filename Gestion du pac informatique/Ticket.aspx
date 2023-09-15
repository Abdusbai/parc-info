<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="Gestion_du_pac_informatique.Ticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Ticket</h1>
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
                        <asp:BoundField DataField="CodeTicket" HeaderText="N° séquentiel" />
                        <asp:BoundField DataField="TypeProb" HeaderText="Type du problème" />
                        <asp:BoundField DataField="TypeCont" HeaderText="Type du contacte" />
                        <asp:BoundField DataField="DateTicket" HeaderText="Date de ticket" />
                        <asp:BoundField DataField="HeureTicket" HeaderText="Heure de ticket" />
                        <asp:BoundField DataField="DescTicket" HeaderText="Description" />
                        <asp:BoundField DataField="NumSerMat" HeaderText="Numéro de série du matériel" />
                        <asp:BoundField DataField="NumLogi" HeaderText="Numéro du logiciel" />
                        <asp:BoundField DataField="EtatTicket" HeaderText="L'état du ticket" />

                        <asp:CommandField DeleteText="Détails" SelectText="Détails" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>

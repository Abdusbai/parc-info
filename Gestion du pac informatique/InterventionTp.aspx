<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InterventionTp.aspx.cs" Inherits="Gestion_du_pac_informatique.InterventionTp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .FFF {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-top: 40px;
            margin-bottom: 40px;
        }
    </style>
    <h1 class="mt-4">Intervention par type de problème</h1>
    <form runat="server" method="get">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="d-flex align-items-center form-inline ms-auto me-0 me-md-0 my-2 my-md-3">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox1" TextMode="Date" class="form-control" placeholder="Rechercher..." aria-describedby="btnNavbarSearch" runat="server"></asp:TextBox>
                        <asp:Button class="btn btn-primary" ID="Button1" Text="Rechercher" runat="server" OnClick="Button1_Click" />
                    </div>

                    <div class="input-group">
                        <div class="m-1">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>

                    </div>
                </div>

                <div class="FFF">
                    <asp:Chart ID="Chart1" runat="server" Width="1000px" >
                        <Series>
                            <asp:Series Name="Series1"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX Title="Type de problème"></AxisX>
                                <AxisY Title="Nombre d'interventions"></AxisY>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>

                <div class="d-flex align-items-center form-inline ms-auto me-0 me-md-0 my-2 my-md-3">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox2" class="form-control" placeholder="Rechercher..." aria-describedby="btnNavbarSearch" runat="server"></asp:TextBox>
                        <asp:Button class="btn btn-primary" ID="Button2" Text="Rechercher" runat="server" OnClick="Button2_Click" />
                    </div>

                    <div class="input-group">
                        <div class="m-1">
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                    <div class="mt-0 mb-0">
                        <asp:DropDownList ID="SdDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="250px" Height="40px" readonly="true" AutoPostBack="True" OnSelectedIndexChanged="SdDropDown_SelectedIndexChanged">
                            <asp:ListItem Value="-1">-- Type de problème * --</asp:ListItem>
                            <asp:ListItem Value="0">Logiciel</asp:ListItem>
                            <asp:ListItem Value="1">Matèriel</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <asp:GridView ID="GridView1" class="table table-bordered table-condensed table-responsive table-hover " runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="NumInter" HeaderText="N° séquentiel" />
                        <asp:BoundField DataField="DateInter" HeaderText="Date d'intervention" />
                        <asp:BoundField DataField="CodeTicket" HeaderText="N° du ticket" />
                        <asp:BoundField DataField="CinTech" HeaderText="Cin du technicien affectée" />
                        <asp:BoundField DataField="DateAffectTech" HeaderText="Date d'affectation" />
                        <asp:BoundField DataField="DescSd" HeaderText="Suite à donner" />
                        <asp:BoundField DataField="DateSd" HeaderText="Date de suite à donner" />
                        <asp:BoundField DataField="CodeServ" HeaderText="Service de transfert" />
                        <asp:BoundField DataField="DateServ" HeaderText=" Date de transfert" />
                        <asp:BoundField DataField="DateRetourServ" HeaderText=" Date de retour" />
                        <asp:BoundField DataField="CinTechReaff" HeaderText="Cin du technicien réaffectée" />
                        <asp:BoundField DataField="DateReaff" HeaderText="Date de réaffectation" />
                        <asp:BoundField DataField="EtatInter" HeaderText="L'état d'intervention" />
                        <asp:BoundField DataField="DateColutre" HeaderText="Date de Clôture" />

                        <asp:CommandField DeleteText="Détails" SelectText="Détails" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>

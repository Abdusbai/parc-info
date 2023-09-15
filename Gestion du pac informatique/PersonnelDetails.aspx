<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PersonnelDetails.aspx.cs" Inherits="Gestion_du_pac_informatique.PersonnelDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Personnel</h1>
    <form runat="server" method="get">
        <div class="card-body">
            <h6 class="mt-0">Détails du Personnel</h6>
            <hr style="width: 610px; float: left; background-color: black; height: 2px" />
            <br />
            <div class="input-group">
                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="DrppText" placeholder="DRPP *" Width="300px" runat="server" MaxLength="10" ReadOnly="true"></asp:TextBox>
                    <label for="DrppText">DRPP *</label>
                </div>

                <span class="input-group-btn" style="width: 11px;"></span>

                <div class="form-floating mb-3">
                    <asp:TextBox class="form-control" ID="CinText" placeholder="CIN *" Width="300px" runat="server" MaxLength="20" ReadOnly="true"></asp:TextBox>
                    <label for="CinText">CIN *</label>
                </div>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="NomText" placeholder="Nom *" Width="611px" runat="server" MaxLength="40"></asp:TextBox>
                <label for="NomText">Nom *</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="PrenomText" placeholder="Prénom *" Width="611px" runat="server" MaxLength="40"></asp:TextBox>
                <label for="PrenomText">Prénom *</label>
            </div>

            <div class="input-group">
                <div class="form-floating mb-3">
                    <asp:TextBox ID="DateNaissText" class="form-control" placeholder="Date de naissance *" Width="300px" runat="server" TextMode="Date"></asp:TextBox>
                    <label for="DateNaissText">Date de naissance *</label>
                </div>

                <span class="input-group-btn" style="width: 11px;"></span>

                <div class="form-floating mb-3">
                    <asp:TextBox ID="DateRecrText" class="form-control" placeholder="Date de recrutemer *" Width="300px" runat="server" TextMode="Date"></asp:TextBox>
                    <label for="DateRecrText">Date de recrutement *</label>
                </div>
            </div>

            <div class="form-floating mb-3">
                <small>Fonction *</small><br />
                    <asp:DropDownList ID="FonctionDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="611px" Height="58px" readonly="true" DataTextField="DescFo" DataValueField="CodeFo">
                    </asp:DropDownList>
                </div>


                <div class="form-floating mb-3">
                    <asp:TextBox ID="NumBurText" class="form-control" placeholder=">N° de bureau *" Width="611px" runat="server" MaxLength="10"></asp:TextBox>
                    <label for="NumBurText">N° de bureau *</label>
                </div>


            <div class="input-group">
                <div class="form-floating mb-3">
                    <asp:TextBox ID="SiteText" class="form-control" placeholder=">Site *" runat="server" Width="300px" MaxLength="30"></asp:TextBox>
                    <label for="SiteText">Site *</label>
                </div>

                <span class="input-group-btn" style="width: 11px;"></span>

                <div class="form-floating mb-3">
                    <asp:TextBox ID="BatimentText" class="form-control" placeholder=">Bâtiment *" runat="server" Width="300px" MaxLength="30"></asp:TextBox>
                    <label for="BatimentText">Bâtiment *</label>
                </div>
            </div>

            <div class="input-group">
                <div class="form-floating mb-3">
                    <small>Localisation *</small><br />
                    <asp:DropDownList ID="LODropwDown" class="btn btn-light dropdown-toggle" runat="server" Width="300px" Height="58px" readonly="true" DataTextField="AbreviationEn" DataValueField="LocalisationEn">
                    </asp:DropDownList>                                
                </div>

                <span class="input-group-btn" style="width: 11px;"></span>

                <div class="form-floating mb-3">
                    <small>Personnel on fonction *</small><br />
                    <asp:DropDownList ID="ActifDropDown" class="btn btn-light dropdown-toggle" runat="server" Width="300px" Height="58px" readonly="true">
                        <asp:ListItem Value="-1">-- Actif * --</asp:ListItem>
                        <asp:ListItem Value="0">Oui</asp:ListItem>
                        <asp:ListItem Value="1">Non</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="TeleBText" placeholder="Poste de téléphone *" runat="server" Width="611px" MaxLength="20" TextMode="Phone"></asp:TextBox>
                <label for="TeleBText">Téléphone du bureau *</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="GsmText" placeholder="Gsm *" runat="server" MaxLength="20" Width="611px" TextMode="Phone"></asp:TextBox>
                <label for="GsmText">Gsm *</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox class="form-control" ID="MailText" placeholder="E-mail *" runat="server" MaxLength="30" Width="611px" TextMode="Email"></asp:TextBox>
                <label for="MailText">E-mail *</label>
            </div>

            <div>
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>

            <div class="mt-4 mb-0">
                <asp:Button ID="ModifierBTN" class="btn btn-success" runat="server" Text="Modifier" OnClick="ModifierBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Modifier les données de cet Personne ?')" />
                <asp:Button ID="SupprimerBTN" class="btn btn-danger" runat="server" Text="Supprimer" OnClick="SupprimerBTN_Click" OnClientClick="return confirm('Voulez-vous vraiment Supprimer cet Personne ?')" />
                <asp:Button ID="AnnulerBTN" class="btn btn-secondary" runat="server" Text="Annuler" OnClick="AnnulerBTN_Click" />
            </div>
        </div>
    </form>
</asp:Content>

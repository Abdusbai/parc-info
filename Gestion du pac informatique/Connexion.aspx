<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="Gestion_du_pac_informatique.Connexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Gestion du pac informatique | Connexion</title>
    <link href="css/styles.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>
</head>
<body class="bg-primary">
    <form id="form1" runat="server">
        <div id="layoutAuthentication">
            <div id="layoutAuthentication_content">
                <main>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-5">
                                <div class="card shadow-lg border-0 rounded-lg mt-5">
                                    <div class="card-header">
                                        <h3 class="text-center font-weight-light my-4">Bienvenu</h3>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-floating mb-3">
                                            <asp:TextBox class="form-control" ID="Identifiant" placeholder="Identifiant" runat="server"></asp:TextBox>
                                            <label for="Identifiant">Identifiant</label>
                                        </div>
                                        <div class="form-floating mb-3">
                                            <asp:TextBox class="form-control" TextMode="Password" ID="MotDePasse" placeholder="Mot de passe" runat="server"></asp:TextBox>
                                            <label for="MotDePasse">Mot de passe</label>
                                        </div>
                                        <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                            <div>
                                                <input class="form-check-input" id="AfficherM" onclick="ShowPass()" type="checkbox" value="" />
                                                <label class="form-check-label" for="AfficherM">Afficher le mot de passe</label>
                                            </div>
                                            <asp:Button ID="SeConnecter" class="btn btn-primary" runat="server" Text="Se Connecter" OnClick="SeConnecter_Click" />
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <div style="text-align: center; color: red;">
                                            <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
            <div id="layoutAuthentication_footer">
                <footer class="py-4 bg-light mt-auto">
                    <div class="container-fluid px-4">
                        <div class="d-flex align-items-center justify-content-between small">
                            <div class="text-muted">Ministère de l'agriculture, de la pêche maritime, du développement rural et des eaux et forêts.</div>
                            <div class="text-muted">
                                2022 © Tous droits réservés
                            </div>
                        </div>
                    </div>
                </footer>
            </div>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="js/scripts.js"></script>
    </form>
</body>
</html>

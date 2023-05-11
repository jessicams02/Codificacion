<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Codificacion.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menú</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="css/General.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-3.6.4.js"></script>
</head>
<body>
    <div class="centrar">
        <form id="form1" runat="server">
            <div class="container-fluid ">
                <div class="row">
                    <div class="col">
                        <h1>MENÚ</h1>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnVacante" runat="server" Text="Vacante" class="btn btn-primary btn-lg btn-block" OnClick="btnVacante_Click" style="width: 100%;"/>
                    </div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnProspecto" runat="server" Text="Prospecto" class="btn btn-primary btn-lg btn-block" OnClick="btnProspecto_Click" style="width: 100%;"/>
                    </div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnEntrevista" runat="server" Text="Entrevista" class="btn btn-primary btn-lg btn-block" OnClick="btnEntrevista_Click" style="width: 100%;"/>
                    </div>
                </div>
                <br />
                <br />
            </div>
        </form>
    </div>

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vacante.aspx.cs" Inherits="Codificacion.Vacante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vacante</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-3.6.4.js"></script>
    <link href="css/General.css" rel="stylesheet" />
</head>
<body>
    <div class="centrar">
        <form id="form1" runat="server">
            <div class="container-fluid justify-content-center">
                <div class="row">
                    <div class="col-1">
                        <asp:Button ID="btnRegresar" runat="server" Text="← Regresar" class="btn back" onclick="btnRegresar_Click" CausesValidation="false"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <h1>Vacante</h1>
                    </div>
                </div>
                <br />
                <asp:TextBox ID="txtId" runat="server" Visible="false" Text="0"></asp:TextBox>
                <div class="row">
                    <div class="col form-group">
                        <asp:Label ID="Label2" runat="server" Text="Área:"></asp:Label>
                        <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="txtArea" SetFocusOnError="true" ErrorMessage="Ingresa un área" CssClass="red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col form-group">
                        <asp:Label ID="Label1" runat="server" Text="Sueldo:"></asp:Label>
                        <asp:TextBox ID="txtSueldo" runat="server" CssClass="form-control money"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSueldo" runat="server" ControlToValidate="txtSueldo" SetFocusOnError="true" ErrorMessage="Ingresa un sueldo" CssClass="red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Label ID="Label3" runat="server" Text="Activo"></asp:Label>
                        <asp:CheckBox ID="chbActivo" runat="server" />
                    </div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" onclick="btnGuardar_Click"/>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <script src="Scripts/Inputmask/jquery.inputmask.js"></script>
    <script>
        $(document).ready(function () {
            $(".money").inputmask({ alias: "currency", prefix: '$ ' });
        });
    </script>
</body>
</html>

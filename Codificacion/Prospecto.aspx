<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prospecto.aspx.cs" Inherits="Codificacion.Prospecto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prospecto</title>
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
                        <asp:Button ID="btnRegresar" runat="server" Text="← Regresar" class="btn back"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <h1>Prospecto</h1>
                    </div>
                </div>
                <!--<div class="row">
                    <div class="col form-group">
                        <asp:TextBox ID="txtId" runat="server" Visible="false"></asp:TextBox>
                        <asp:Button ID="btnBuscar" runat="server" Text="Button" />
                    </div>
                </div>-->

                <div class="row">
                    <div class="col">
                        <asp:Label ID="Label1" runat="server" Text="Nombre Completo:" for="txtNombre"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Label ID="Label2" runat="server" Text="Correo:" for="txtCorreo"></asp:Label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="Fecha Registro:" for="txtFecha"></asp:Label>
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnGuardar" runat="server" Text="Button" class="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <script src="Scripts/Inputmask/jquery.inputmask.js"></script>
    <script>
        $(document).ready(function () {
            $(".mail").inputmask("email");
        });

        $('#btnGuardar').click(function (e) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!'
            });
        });
    </script>
</body>
</html>

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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.1/css/bootstrap-datepicker3.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.1/js/bootstrap-datepicker.min.js"></script>
</head>
<body>
    <div class="centrar">
        <form id="form1" runat="server">
            <div class="container-fluid justify-content-center">
                <div class="row">
                    <div class="col-1">
                        <asp:Button ID="btnRegresar" runat="server" Text="← Regresar" class="btn back" OnClick="btnRegresar_Click" CausesValidation="false" />
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <h1>Prospecto</h1>
                    </div>
                </div>
                <br />
                <asp:TextBox ID="txtId" runat="server" Visible="false" Text="0"></asp:TextBox>
                <div class="row">
                    <div class="col">
                        <asp:Label ID="Label1" runat="server" Text="Nombre Completo:" for="txtNombre"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" SetFocusOnError="true" ErrorMessage="Ingresa un nombre" CssClass="red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegExValid1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Ingresa un nombre válido" Display="Dynamic" CssClass="red" ValidationExpression="^[A-Za-z\s]+$"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Label ID="Label2" runat="server" Text="Correo:" for="txtCorreo"></asp:Label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" SetFocusOnError="true" ErrorMessage="Ingresa un correo" CssClass="red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Ingresa un correo válido" CssClass="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Label ID="Label3" runat="server" Text="Fecha Registro:" for="txtFecha"></asp:Label>
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFecha" SetFocusOnError="true" ErrorMessage="Seleccione una fecha" CssClass="red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" />
                    </div>
                </div>
            </div>
        </form>
    </div>
    <script src="Scripts/Inputmask/jquery.inputmask.js"></script>
    <script src="Scripts/AutocompletarCorreo.js"></script>
    <script>
        $(document).ready(function () {
            var date_input = $('#txtFecha'); //our date input has the name "date"
            var options = {
                format: 'yyyy-mm-dd',
                todayHighlight: true,
                autoclose: true,
            };
            date_input.datepicker(options);
            debugger;
        });


    </script>
</body>
</html>

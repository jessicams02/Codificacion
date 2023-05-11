<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrevista.aspx.cs" Inherits="Codificacion.Entrevista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entrevista</title>
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
                        <asp:Button ID="btnRegresar" runat="server" Text="← Regresar" class="btn back" OnClick="btnRegresar_Click" CausesValidation="false"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <h1>Entrevista</h1>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="txtId" runat="server" Visible="false" Text="0"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col form-group">
                        <asp:Label ID="Label1" runat="server" Text="Vacante:" for="ddlVacante"></asp:Label>
                        <asp:DropDownList ID="ddlVacante" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvVacante" runat="server" ControlToValidate="ddlVacante" SetFocusOnError="true" ErrorMessage="Seleccione una vacante" CssClass="red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col form-group">
                        <asp:Label ID="Label2" runat="server" Text="Prospecto:" for="ddlProspecto"></asp:Label>
                        <asp:DropDownList ID="ddlProspecto" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvProspecto" runat="server" ControlToValidate="ddlProspecto" SetFocusOnError="true" ErrorMessage="Seleccione un prospecto" CssClass="red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col form-group">
                        <asp:Label ID="Label3" runat="server" Text="Fecha Entrevista:" for="txtFecha"></asp:Label>
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control datepicker_input"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFecha" SetFocusOnError="true" ErrorMessage="Seleccione una fecha" CssClass="red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col form-group">
                        <asp:Label ID="Label4" runat="server" Text="Notas:" for="txtNotas"></asp:Label>
                        <asp:TextBox ID="txtNotas" runat="server" TextMode="MultiLine" CssClass="form-control textar"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col form-check">
                        <asp:Label ID="Label5" runat="server" Text="Reclutado"></asp:Label>
                        <asp:CheckBox ID="chbReclutado" runat="server" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click"/>
                    </div>
                </div>
            </div>
        </form>
    </div>

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

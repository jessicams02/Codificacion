<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntrevistaListado.aspx.cs" Inherits="Codificacion.ListadoEntrevistas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-3.6.4.js"></script>
    <link href="css/General.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
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
                        <h1>Listado de Entrevistas</h1>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nueva Entrevista" class="btn btn-primary btn-lg" OnClick="btnNuevo_Click"/>
                    </div>
                    <div class="col">
                        <asp:Button ID="btnEditar" runat="server" Text="Editar/Eliminar" class="btn btn-primary btn-lg" OnClick="btnEditar_Click"/>
                    </div>
                </div>
                <br />
                <div id="listado" runat="server" class="row" visible="false">
                    <div class="col">
                        <asp:GridView ID="gvEntrevistas" runat="server" CssClass="table table-striped">
                            <Columns>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditaEntrevista" runat="server" Text="Editar" CssClass="btn btn-primary btn-lg" CommandArgument='<%# Eval("id") %>' onclick="btnEditaEntrevista_Click"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnEliminaEntrevista" runat="server" Text="Elimnar" CssClass="btn btn-primary btn-lg" CommandArgument='<%# Eval("id") %>' onclick="btnEliminaEntrevista_Click"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>

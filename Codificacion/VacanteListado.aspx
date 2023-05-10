<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VacanteListado.aspx.cs" Inherits="Codificacion.VacanteListado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-3.6.4.js"></script>
    <link href="css/General.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid justify-content-center">
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnRegresar" runat="server" Text="← Regresar" />
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <h1>Listado Vacantes</h1>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <asp:GridView ID="gvVacantes" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" OnRowCommand="gvVacantes_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditaVacante" runat="server" Text="Editar/Elimniar" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

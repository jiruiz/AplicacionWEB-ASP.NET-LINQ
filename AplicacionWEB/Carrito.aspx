<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="AplicacionWEB.Carrito" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carrito de Servicios</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center text-primary">Carrito de Servicios</h1>
            <p class="text-center">Revise los servicios seleccionados antes de confirmar el turno.</p>

            <asp:Repeater ID="RepeaterCarrito" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead class="thead-dark">
                            <tr>
                                <th>Servicio</th>
                                <th>Precio</th>
                                <th>Acción</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("NombreServicio") %></td>
                        <td>ARS <%# Eval("Precio", "{0:N2}") %></td>
                        <td>
                            <asp:Button ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("IdTurnosServicios") %>'
                                        Text="Eliminar" CssClass="btn btn-danger btn-sm" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                    <div class="text-right">
                        <asp:Button ID="btnConfirmarTurno" runat="server" OnClick="ConfirmarTurno_Click" Text="Confirmar Turno" CssClass="btn btn-success" />
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>

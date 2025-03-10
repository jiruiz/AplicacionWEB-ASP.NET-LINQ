<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Carrito.aspx.cs" Inherits="AplicacionWEB.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center text-primary">Carrito de Servicios</h1>
            <p class="text-center">Revise los servicios seleccionados antes de confirmar el turno.</p>
            
            <!-- MensajeLabel agregado aquí -->
            <asp:Label ID="MensajeLabel" runat="server" CssClass="text-center d-block mb-3" Visible="false"></asp:Label>
            
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
</asp:Content>

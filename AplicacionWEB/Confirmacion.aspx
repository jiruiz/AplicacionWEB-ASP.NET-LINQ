<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Confirmacion.aspx.cs" Inherits="AplicacionWEB.Confirmacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center text-success">¡Turno Confirmado!</h1>
            <p class="text-center">Gracias por confirmar tu turno. Aquí tienes el resumen:</p>

            <asp:Repeater ID="RepeaterServiciosConfirmados" runat="server">
                <HeaderTemplate>
                    <table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Servicio</th>
                                <th>Precio</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("NombreServicio") %></td>
                        <td>ARS <%# Eval("Precio", "{0:N2}") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                    <div class="text-right">
                        <p class="h5"><strong>Importe Total:</strong> ARS <%# ViewState["ImporteTotal"] %></p>
                    </div>
                </FooterTemplate>
            </asp:Repeater>

            <div class="text-center mt-4">
                <a href="HomeVentas.aspx" class="btn btn-primary">Volver al Inicio</a>
            </div>
        </div>
    </form>
</asp:Content>


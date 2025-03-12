<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Carrito.aspx.cs" Inherits="AplicacionWEB.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .carrito-container {
            max-width: 700px;
            margin: auto;
            background: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }
        .total-container {
            background: #d4edda;
            padding: 10px;
            border-radius: 5px;
            text-align: right;
        }
        .error-message {
            color: red;
            font-weight: bold;
            text-align: center;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <div class="container mt-5 carrito-container">
            <h1 class="text-center text-primary">🛒 Carrito de Servicios</h1>
            <p class="text-center">Revise los servicios seleccionados antes de confirmar el turno.</p>

            <!-- Mensajes de error y confirmación -->
            <asp:UpdatePanel ID="UpdatePanelMensajes" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="MensajeLabel" runat="server" CssClass="error-message" Visible="false"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- Tabla del carrito -->
            <asp:Repeater ID="RepeaterCarrito" runat="server" OnItemCommand="RepeaterCarrito_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead class="thead-dark">
                            <tr>
                                <th>Servicio</th>
                                <th>Precio (ARS)</th>
                                <th>Cantidad</th>
                                <th>Total</th>
                                <th>Acción</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("NombreServicio") %></td>
                        <td>ARS <%# Eval("Precio", "{0:N2}") %></td>
                        <td class="text-center">
                            <asp:Button ID="btnDecrementar" runat="server" CommandName="ModificarCantidad" 
                                        CommandArgument='<%# Eval("IdServicio") + ":decrementar" %>' 
                                        Text="-" CssClass="btn btn-sm btn-outline-secondary" />
                            <span class="mx-2"><%# Eval("Cantidad") %></span>
                            <asp:Button ID="btnIncrementar" runat="server" CommandName="ModificarCantidad" 
                                        CommandArgument='<%# Eval("IdServicio") + ":incrementar" %>' 
                                        Text="+" CssClass="btn btn-sm btn-outline-secondary" />
                        </td>
                        <td>ARS <%# Eval("Total", "{0:N2}") %></td>
                        <td>
                            <asp:Button ID="btnEliminar" runat="server" CommandName="Eliminar"
                                        CommandArgument='<%# Eval("IdServicio") %>' 
                                        Text="🗑 Eliminar" CssClass="btn btn-danger btn-sm" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                    <div class="total-container">
                        <p class="h5"><strong>Total a pagar:</strong> ARS <%# ViewState["ImporteTotal"] ?? "0.00" %></p>
                    </div>
                    <div class="text-center mt-3">
                        <asp:Button ID="btnConfirmarTurno" runat="server" OnClick="ConfirmarTurno_Click"
                                    Text="✅ Confirmar Turno" CssClass="btn btn-success btn-lg" />


                         <asp:Button ID="btnVerServicios" runat="server" Text="🔍 Ver Servicios" CssClass="btn btn-primary btn-lg"
                    OnClick="VerServicios_Click" Visible="false" />
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Carrito.aspx.cs" Inherits="AplicacionWEB.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <script>
           // Espera 5 segundos y luego oculta el mensaje de error o confirmación.
           setTimeout(function () {
               var mensaje = document.getElementById('<%= MensajeLabel.ClientID %>');  // Cambiar a MensajeLabel.
        if (mensaje && mensaje.style.display !== "none") {  // Asegurarse de que el mensaje no está oculto.
            mensaje.style.transition = "opacity 0.5s ease";  // Transición de opacidad para el desvanecimiento.
            mensaje.style.opacity = "0";  // Hacerlo transparente.
            setTimeout(function () {
                mensaje.style.display = "none";  // Después de la transición, ocultarlo completamente.
            }, 500);  // Esperar medio segundo para que la transición se complete.
        }
    }, 5000);  // Esperar 5 segundos.
       </script>
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

    /* Estilo de los mensajes */
    .error-message, .success-message {
        font-weight: bold;
        font-size: 1.2rem;
        padding: 15px;
        margin: 20px auto;
        width: 80%; /* Controla el tamaño del mensaje */
        max-width: 500px; /* Tamaño máximo */
        border-radius: 5px;
        text-align: center;
        box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
        display: inline-block;
        transition: opacity 0.5s ease;
        opacity: 1;
    }

    /* Mensaje de error */
    .error-message {
        color: #721c10; /* Rojo más oscuro */
        background-color: #c3e6cb; /* Fondo rojo suave */
        border: 1px solid #03ff00; /* Borde suave */
    }

    /* Mensaje de éxito (opcional) */
    .success-message {
        color: #155724; /* Verde */
        background-color: #c3e6cb; /* Fondo verde claro */
        border: 5px solid #f2fc00; /* Borde verde claro */
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
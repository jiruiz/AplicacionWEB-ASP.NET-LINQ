<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="HomeVentas.aspx.cs" Inherits="AplicacionWEB.HomeVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Servicios Activos</title>
    <!-- Estilos personalizados -->
    <script>
        // Ocultar mensajes después de 5 segundos
        setTimeout(function () {
            var mensaje = document.getElementById('<%= LabelMensaje.ClientID %>');
        if (mensaje) {
            mensaje.style.transition = "opacity 0.5s ease";
            mensaje.style.opacity = "0";
            setTimeout(() => { mensaje.style.display = "none"; }, 500);
        }
    }, 5000);
    </script>
<style>
    .service-card {
        transition: transform 0.3s ease, box-shadow 0.3s ease;
        border-radius: 12px;
        overflow: hidden;
        box-shadow: 0 5px 12px rgba(0, 0, 0, 0.1);
        background: white;
        color: #007bff;
        padding: 20px;
        text-align: center;
    }

    .service-card:hover {
        transform: translateY(-8px);
        box-shadow: 0 10px 20px rgba(0, 0, 0, 0.15);
    }

    .service-title {
        font-size: 1.25rem;
        font-weight: bold;
        color: #0056b3;
        margin-top: 10px;
    }

    .service-description {
        font-size: 1rem;
        background: rgba(0, 123, 255, 0.08);
        padding: 12px;
        border-radius: 8px;
        color: #0056b3;
        font-weight: 500;
    }

    .service-price, .service-duration {
        font-size: 1rem;
        font-weight: bold;
        color: #007bff;
    }

    .service-icon {
        font-size: 3rem;
        color: #6610f2;
        margin-bottom: 15px;
    }

    /* Estilo para los botones */
    .btn-primary, 
    .btn-adquirir, 
    .btn-login {
        font-size: 1.1rem;
        padding: 12px 20px;
        background: linear-gradient(to right, #007bff, #6610f2);
        border-color: #0056b3; /* Azul oscuro para el borde */
        color: goldenrod; /* Naranja para el texto */
        font-weight: bold;
        border-radius: 5px;
        transition: background-color 0.3s ease, transform 0.2s ease, color 0.3s ease;
        width: 100%;
        text-transform: uppercase;
        box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    }

    .btn-primary:hover, 
    .btn-adquirir:hover, 
    .btn-login:hover {
        background-color: #0056b3; /* Azul oscuro en hover */
        color: greenyellow; /* Texto en darkorange */
        transform: translateY(-3px);
    }

    .card-footer {
        background: rgba(0, 123, 255, 0.08);
        padding: 15px;
        border-top: 1px solid rgba(0, 123, 255, 0.15);
    }

    /* Mensajes con iconos */
    .service-message-container {
        text-align: center;
        margin-top: 20px;
    }

    .service-message {
        font-size: 1.1rem;
        font-weight: 500;
        padding: 15px 20px;
        border-radius: 8px;
        display: inline-flex;
        align-items: center;
        max-width: 80%;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15);
        border-left: 5px solid;
        transition: all 0.3s ease-in-out;
        justify-content: center;
    }

    .service-message i {
        font-size: 1.5rem;
        margin-right: 10px;
    }

    /* Mensaje de Éxito */
    .service-message-success {
        background-color: #e9f7ef;
        color: #218838;
        border-color: #28a745;
    }

    /* Mensaje de Error */
    .service-message-error {
        background-color: #f8d7da;
        color: #721c24;
        border-color: #dc3545;
    }
</style>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <!-- ScriptManager agregado aquí -->
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="container mt-5">
            <h1 class="text-center text-primary">Servicios Activos</h1>
            <p class="text-center">Explora nuestros servicios disponibles para ti.</p>
            
            <!-- Contenedor de mensajes (Error o Éxito) -->
            <asp:UpdatePanel ID="UpdatePanelMensajes" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="service-message-container">
                        <asp:Label ID="LabelMensaje" runat="server" CssClass="service-message" Visible="false" />
                        <asp:Button ID="btnLoginRedirect" runat="server" Text="Iniciar sesión" CssClass="btn-login" OnClick="btnLoginRedirect_Click" Visible="false" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- Lista de servicios -->
            <div class="row mt-4">
                <asp:Repeater ID="RepeaterServicios" runat="server" OnItemCommand="RepeaterServicios_ItemCommand">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card service-card shadow-sm">
                                <div class="card-body">
                                    <!-- Icono para servicio -->
                                    <div class="service-icon">
                                        <i class="fas fa-cogs"></i> <!-- Aquí puedes usar otro icono relevante -->
                                    </div>
                                    <h5 class="service-title"><%# Eval("Nombre") %></h5>
                                    <p class="service-description"><%# Eval("Descripcion") %></p>
                                    <p class="service-price">Precio: ARS <%# string.Format("{0:N2}", Eval("Precio")) %></p>
                                    <p class="service-duration">Duración: <%# Eval("DuracionMinutos") %> minutos</p>
                                </div>
                                <div class="card-footer">
                                    <asp:Button ID="btnAdquirir" runat="server" CommandName="Adquirir" CommandArgument='<%# Eval("IdServicio") %>' 
                                                Text="Adquirir" CssClass="btn-adquirir" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</asp:Content>

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
        /* Ajustes generales */
        body {
            background: linear-gradient(to bottom, #f5f7fa, #e4eaf5);
            font-family: 'Poppins', sans-serif;
        }

        /* Contenedor principal */
        .container {
            padding: 20px 15px;
        }

        /* Título principal */
        h1 {
            font-size: 2.5rem;
            color: #007bff;
            font-weight: 700;
            text-align: center;
            margin-top: 10px; /* Reduce la separación desde la parte superior */
            margin-bottom: 5px; /* Reduce la separación con el subtítulo */
        }

        /* Subtítulo */
        p {
            font-size: 1.1rem;
            text-align: center;
            color: #6c757d;
            margin-bottom: 20px;
        }

        /* Tarjetas de servicio */
        .service-card {
            border-radius: 15px;
            background: white;
            box-shadow: 0 6px 15px rgba(0, 0, 0, 0.1);
            overflow: hidden;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
        }

        .service-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 10px 20px rgba(0, 0, 0, 0.2);
        }

        .card-body {
            padding: 20px;
            text-align: center;
        }

        .service-icon {
            font-size: 3rem;
            color: #6610f2;
            margin-bottom: 15px;
        }

        .service-title {
            font-size: 1.5rem;
            color: #0056b3;
            font-weight: 600;
            margin-bottom: 10px;
        }

        .service-description {
            font-size: 1rem;
            color: #5a6268;
            margin-bottom: 10px;
        }

        .service-price {
            font-size: 1.2rem;
            color: goldenrod;
            font-weight: 700;
            margin-bottom: 5px;
        }

        .service-duration {
            font-size: 1rem;
            color: greenyellow;
            font-weight: bold;
        }

        /* Pie de tarjeta */
        .card-footer {
            background: rgba(0, 123, 255, 0.1);
            padding: 15px;
            border-top: 1px solid rgba(0, 123, 255, 0.2);
        }

        /* Botones */
        .btn-primary,
        .btn-adquirir {
            background: linear-gradient(to right, #007bff, #6610f2);
            color: white;
            padding: 10px 15px;
            font-size: 1.1rem;
            border-radius: 8px;
            border: none;
            text-transform: uppercase;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            transition: transform 0.2s ease, box-shadow 0.3s ease;
        }

        .btn-primary:hover,
        .btn-adquirir:hover {
            transform: translateY(-2px);
            box-shadow: 0 6px 10px rgba(0, 0, 0, 0.2);
        }

        /* Mensajes */
        .service-message-container {
            margin: 20px 0;
            text-align: center;
        }

        .service-message {
            font-size: 1.1rem;
            padding: 15px;
            border-radius: 8px;
            display: inline-block;
            max-width: 80%;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            border-left: 5px solid;
            font-weight: 600;
        }

        .service-message-success {
            background-color: #d4edda;
            color: #155724;
            border-color: #28a745;
        }

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
        <div class="container ">
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
                                <div class="card-footer text-center">
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

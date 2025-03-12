<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="HomeVentas.aspx.cs" Inherits="AplicacionWEB.HomeVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Servicios Activos</title>
    <!-- Estilos personalizados -->
    <style>
        .service-card {
            transition: transform 0.3s ease, box-shadow 0.3s ease;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.15);
        }

        .service-card:hover {
            transform: translateY(-10px);
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.2);
        }

        .service-title {
            font-size: 1.4rem;
            font-weight: bold;
            color: #343a40;
            text-align: center;
            margin-bottom: 10px;
        }

        .service-price {
            font-size: 1.3rem;
            color: #28a745;
            font-weight: bold;
            text-align: center;
            margin-bottom: 15px;
        }

        .service-description {
            font-size: 1rem;
            color: #6c757d;
            text-align: center;
            margin-bottom: 20px;
            line-height: 1.6;
            padding: 10px 20px;
            background: #f8f9fa;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        .service-duration {
            font-size: 1rem;
            color: #495057;
            text-align: center;
            margin-bottom: 15px;
        }

        .service-icon {
            font-size: 3rem;
            color: #28a745;
            margin-bottom: 15px;
            text-align: center;
        }

        .btn-adquirir {
            font-size: 1.1rem;
            padding: 12px 25px;
            background-color: #007bff;
            border: none;
            color: white;
            border-radius: 5px;
            transition: background-color 0.3s ease;
            width: 100%;
            text-align: center;
        }

        .btn-adquirir:hover {
            background-color: #0056b3;
        }

        .card-body {
            padding: 30px;
            position: relative;
            text-align: center;
        }

        .card-footer {
            background-color: #f8f9fa;
            border-top: 1px solid #e9ecef;
            padding: 15px;
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
            <asp:UpdatePanel ID="UpdatePanelMensajes" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="LabelMensaje" runat="server" ForeColor="Red" Visible="false" />
                </ContentTemplate>
            </asp:UpdatePanel>

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

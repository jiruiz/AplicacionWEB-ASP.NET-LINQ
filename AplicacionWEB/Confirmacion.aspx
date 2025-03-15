<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Confirmacion.aspx.cs" Inherits="AplicacionWEB.Confirmacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Contenedor Principal */
        .confirmacion-container {
            max-width: 700px;
            margin: auto;
            background: linear-gradient(to bottom right, #e8f5e9, #c8e6c9);
            padding: 30px;
            border-radius: 12px;
            box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.2);
        }

        /* Títulos */
        h1, h2 {
            font-family: 'Arial Black', sans-serif;
            color: #388e3c; /* Verde llamativo */
            text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.3);
        }

        /* Detalles de la Fecha y Hora */
        .detalle-cita {
            font-family: 'Segoe UI', sans-serif;
            font-size: 1.3rem;
            color: #1b5e20;
            font-weight: bold;
            background: #c8e6c9;
            padding: 15px;
            border-radius: 8px;
            box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
        }

        /* Tabla de Servicios */
        .table {
            margin-top: 20px;
        }

        /* Contenedor Total */
        .total-container {
            background: #81c784;
            padding: 15px;
            border-radius: 8px;
            margin-top: 20px;
            font-family: 'Segoe UI', sans-serif;
            font-size: 1.2rem;
            color: #004d40;
            font-weight: bold;
            text-align: right;
            box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
        }

        /* Botón para volver */
        .btn-volver {
            background: #388e3c;
            color: white;
            font-weight: bold;
            padding: 15px 30px;
            border-radius: 50px;
            text-transform: uppercase;
            transition: all 0.3s ease;
            box-shadow: 0px 6px 10px rgba(0, 0, 0, 0.2);
        }

        .btn-volver:hover {
            background: #1b5e20;
            box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.3);
        }

        /* Mensaje de Error */
        .error-message {
            color: red;
            font-weight: bold;
            font-size: 1.2rem;
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5 confirmacion-container">
            <h1 class="text-center text-success">✅ ¡Turno Confirmado!</h1>
            <p class="text-center">Gracias por confirmar tu turno. Aquí tienes el resumen:</p>

            <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false"></asp:Label>

            <!-- Detalles de Fecha y Hora -->
            <div class="detalle-cita text-center mt-4">
                <p>📅 <strong>Fecha de la cita:</strong> <asp:Label ID="lblFechaCita" runat="server"></asp:Label></p>
                <p>⏰ <strong>Hora de la cita:</strong> <asp:Label ID="lblHoraCita" runat="server"></asp:Label></p>
            </div>


            <asp:Repeater ID="RepeaterServiciosConfirmados" runat="server">
                <HeaderTemplate>
                    <table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Servicio</th>
                                <th>Cantidad</th>
                                <th>Precio Unitario (ARS)</th>
                                <th>Total (ARS)</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("NombreServicio") %></td>
                        <td class="text-center"><%# Eval("Cantidad") %></td>
                        <td>ARS <%# Eval("Precio", "{0:N2}") %></td>
                        <td>ARS <%# Eval("Total", "{0:N2}") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                    <div class="total-container text-right">
                        <p class="h5"><strong>Total a pagar:</strong> ARS <%# ViewState["ImporteTotal"] ?? "0.00" %></p>
                    </div>
                </FooterTemplate>
            </asp:Repeater>


            <div class="text-center mt-4">
                <a href="HomeVentas.aspx" class="btn btn-primary">🔍 Ver Más Servicios</a>
            </div>
        </div>
    </form>
</asp:Content>

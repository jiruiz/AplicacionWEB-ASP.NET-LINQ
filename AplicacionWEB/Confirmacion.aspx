<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Confirmacion.aspx.cs" Inherits="AplicacionWEB.Confirmacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .confirmacion-container {
            max-width: 600px;
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
        <div class="container mt-5 confirmacion-container">
            <h1 class="text-center text-success">✅ ¡Turno Confirmado!</h1>
            <p class="text-center">Gracias por confirmar tu turno. Aquí tienes el resumen:</p>

            <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false"></asp:Label>

            <asp:Repeater ID="RepeaterServiciosConfirmados" runat="server">
                <HeaderTemplate>
                    <table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Servicio</th>
                                <th>Precio (ARS)</th>
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
                    <div class="total-container text-right">
                        <p class="h5"><strong>Total a pagar:</strong> ARS <%# ViewState["ImporteTotal"] ?? "0.00" %></p>
                    </div>
                </FooterTemplate>
            </asp:Repeater>

            <div class="text-center mt-4">
                <a href="HomeVentas.aspx" class="btn btn-primary">🏠 Volver al Inicio</a>
            </div>
        </div>
    </form>
</asp:Content>

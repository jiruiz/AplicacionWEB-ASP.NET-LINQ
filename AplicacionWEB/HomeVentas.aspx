<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="HomeVentas.aspx.cs" Inherits="AplicacionWEB.HomeVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Servicios Activos</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center text-primary">Servicios Activos</h1>
            <p class="text-center">Explora nuestros servicios disponibles para ti.</p>

            <div class="row mt-4">
                <asp:Repeater ID="RepeaterServicios" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <p class="card-text"><%# Eval("Descripcion") %></p>
                                    <p class="card-text text-success">Precio: ARS <%# string.Format("{0:N2}", Eval("Precio")) %></p>
                                    <p class="card-text text-muted">Duración: <%# Eval("DuracionMinutos") %> minutos</p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
</asp:Content>

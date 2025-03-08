<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Dashboard.aspx.cs" Inherits="AplicacionWEB.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard - Estadísticas</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h1 class="text-center text-primary">Estadísticas del Sistema</h1>
        <p class="text-center">Consulta los datos principales para la administración.</p>

        <!-- Tarjetas de estadísticas -->
        <div class="row mt-4">
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-primary"><strong>Usuarios Registrados</strong></div>
                    <div class="card-body">
                        <h5 class="card-title text-center">
                            <asp:Label ID="lblTotalUsuarios" runat="server" Text="0"></asp:Label>
                        </h5>
                        <p class="card-text text-center">Usuarios activos en el sistema.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-success"><strong>Servicios Activos</strong></div>
                    <div class="card-body">
                        <h5 class="card-title text-center">
                            <asp:Label ID="lblServiciosActivos" runat="server" Text="0"></asp:Label>
                        </h5>
                        <p class="card-text text-center">Servicios actualmente disponibles.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-danger"><strong>Servicios Inactivos</strong></div>
                    <div class="card-body">
                        <h5 class="card-title text-center">
                            <asp:Label ID="lblServiciosInactivos" runat="server" Text="0"></asp:Label>
                        </h5>
                        <p class="card-text text-center">Servicios no disponibles.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

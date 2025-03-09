<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Dashboard.aspx.cs" Inherits="AplicacionWEB.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard - Estadísticas</title>
    <!-- Bootstrap para estilos modernos -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" />
    <!-- Chart.js para visualizaciones dinámicas -->
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <!-- Título del Dashboard -->
        <h1 class="text-center text-primary">Dashboard - Estadísticas del Sistema</h1>
        <p class="text-center">Consulta las métricas clave de tu plataforma.</p>

        <!-- Tarjetas de estadísticas para Usuarios -->
        <div class="row mt-4">
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-primary"><strong>Usuarios Totales</strong></div>
                    <div class="card-body">
                        <h5 class="card-title text-center">
                            <!-- Label para mostrar el total de usuarios -->
                            <asp:Label ID="lblTotalUsuarios" runat="server" Text="0"></asp:Label>
                        </h5>
                        <p class="card-text text-center">Usuarios registrados en el sistema.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-success"><strong>Usuarios Activos</strong></div>
                    <div class="card-body">
                        <h5 class="card-title text-center">
                            <!-- Label para mostrar usuarios activos -->
                            <asp:Label ID="lblUsuariosActivos" runat="server" Text="0"></asp:Label>
                        </h5>
                        <p class="card-text text-center">Usuarios que han iniciado sesión recientemente.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-danger"><strong>Usuarios Inactivos</strong></div>
                    <div class="card-body">
                        <h5 class="card-title text-center">
                            <!-- Label para mostrar usuarios inactivos -->
                            <asp:Label ID="lblUsuariosInactivos" runat="server" Text="0"></asp:Label>
                        </h5>
                        <p class="card-text text-center">Usuarios no activos.</p>
                    </div>
                </div>
            </div>
        </div>

        <!-- Tarjetas de estadísticas para Servicios -->
        <div class="row mt-4">
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-primary"><strong>Servicios Totales</strong></div>
                    <div class="card-body">
                        <h5 class="card-title text-center">
                            <!-- Label para mostrar servicios totales -->
                            <asp:Label ID="lblTotalServicios" runat="server" Text="0"></asp:Label>
                        </h5>
                        <p class="card-text text-center">Servicios disponibles en la plataforma.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-success"><strong>Servicios Activos</strong></div>
                    <div class="card-body">
                        <h5 class="card-title text-center">
                            <!-- Label para mostrar servicios activos -->
                            <asp:Label ID="lblServiciosActivos" runat="server" Text="0"></asp:Label>
                        </h5>
                        <p class="card-text text-center">Servicios actualmente activos.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-danger"><strong>Servicios Inactivos</strong></div>
                    <div class="card-body">
                        <h5 class="card-title text-center">
                            <!-- Label para mostrar servicios inactivos -->
                            <asp:Label ID="lblServiciosInactivos" runat="server" Text="0"></asp:Label>
                        </h5>
                        <p class="card-text text-center">Servicios que no están disponibles.</p>
                    </div>
                </div>
            </div>
        </div>

        <!-- Gráfico de distribución de servicios -->
        <div class="container mt-5">
            <h3 class="text-center">Distribución de Servicios por Categoría</h3>
            <canvas id="chartServicios" width="400" height="200"></canvas>
        </div>
    </div>

    <!-- Script para renderizar el gráfico -->
    <script>
        window.onload = function () {
            const ctx = document.getElementById('chartServicios').getContext('2d');
            const chartServicios = new Chart(ctx, {
                type: 'pie', // Tipo de gráfico
                data: {
                    labels: <%= CategoriasNombres %>, // Nombres de las categorías
                    datasets: [{
                        label: 'Servicios por Categoría',
                        data: <%= CategoriasCantidad %>, // Datos dinámicos (número de servicios por categoría)
                        backgroundColor: ['#36a2eb', '#ff6384', '#cc65fe', '#ffce56', '#4bc0c0']
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: 'top', // Posición del gráfico
                        }
                    }
                }
            });
        };
    </script>
</asp:Content>

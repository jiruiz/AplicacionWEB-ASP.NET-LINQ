<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Dashboard.aspx.cs" Inherits="AplicacionWEB.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard - Estadísticas</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h1 class="text-center text-primary">Dashboard - Estadísticas del Sistema</h1>
        <p class="text-center">Consulta las métricas clave de tu plataforma.</p>

        <div class="row mt-4">
            <div class="col-md-3">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-primary"><strong>Usuarios Totales</strong></div>
                    <div class="card-body text-center">
                        <h5><asp:Label ID="lblTotalUsuarios" runat="server" Text="0"></asp:Label></h5>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-success"><strong>Usuarios Activos</strong></div>
                    <div class="card-body text-center">
                        <h5><asp:Label ID="lblUsuariosActivos" runat="server" Text="0"></asp:Label></h5>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-danger"><strong>Usuarios Inactivos</strong></div>
                    <div class="card-body text-center">
                        <h5><asp:Label ID="lblUsuariosInactivos" runat="server" Text="0"></asp:Label></h5>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-info"><strong>Velocidad de Respuesta</strong></div>
                    <div class="card-body text-center">
                        <h5><asp:Label ID="lblVelocidad" runat="server" Text="0 ms"></asp:Label></h5>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-primary"><strong>Servicios Totales</strong></div>
                    <div class="card-body text-center">
                        <h5><asp:Label ID="lblTotalServicios" runat="server" Text="0"></asp:Label></h5>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-success"><strong>Servicios Activos</strong></div>
                    <div class="card-body text-center">
                        <h5><asp:Label ID="lblServiciosActivos" runat="server" Text="0"></asp:Label></h5>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card bg-light mb-3">
                    <div class="card-header text-center text-danger"><strong>Servicios Inactivos</strong></div>
                    <div class="card-body text-center">
                        <h5><asp:Label ID="lblServiciosInactivos" runat="server" Text="0"></asp:Label></h5>
                    </div>
                </div>
            </div>
        </div>

        <div class="container mt-5">
            <h3 class="text-center">Distribución de Servicios por Categoría</h3>
            <canvas id="chartServicios" width="400" height="200"></canvas>
        </div>

        <div class="container mt-5">
            <h3 class="text-center">Uso del Sistema</h3>
            <canvas id="chartUsoSistema" width="400" height="200"></canvas>
        </div>
    </div>

    <script>
        window.onload = function () {
            const ctxServicios = document.getElementById('chartServicios').getContext('2d');
            new Chart(ctxServicios, {
                type: 'pie',
                data: {
                    labels: <%= CategoriasNombres %>,
                    datasets: [{
                        label: 'Servicios por Categoría',
                        data: <%= CategoriasCantidad %>,
                        backgroundColor: ['#36a2eb', '#ff6384', '#cc65fe', '#ffce56', '#4bc0c0']
                    }]
                },
                options: { responsive: true }
            });

            const ctxUso = document.getElementById('chartUsoSistema').getContext('2d');
            new Chart(ctxUso, {
                type: 'bar',
                data: {
                    labels: ['Usuarios', 'Servicios', 'Transacciones'],
                    datasets: [{
                        label: 'Cantidad',
                        data: [parseInt(document.getElementById('<%= lblTotalUsuarios.ClientID %>').innerText), parseInt(document.getElementById('<%= lblTotalServicios.ClientID %>').innerText), 500],
                        backgroundColor: ['#ff6384', '#36a2eb', '#ffce56']
                    }]
                },
                options: { responsive: true }
            });
        };
    </script>
</asp:Content>

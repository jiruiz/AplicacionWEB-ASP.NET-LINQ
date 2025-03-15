<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="MisTurnos.aspx.cs" Inherits="AplicacionWEB.MisTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
     /* Estilo para los inputs de filtro */
     .filter-input {
         margin-bottom: 20px;
         width: 100%;
         padding: 10px;
         border: 1px solid #ddd;
         border-radius: 5px;
     }
    /* Contenedor principal */
    .turnos-container {
        max-width: 800px;
        margin: auto;
        background: #f8f9fa;
        padding: 20px;
        border-radius: 10px;
        box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
    }

    /* Título principal */
    h1 {
        color: #007bff;
        text-align: center;
    }

    /* Tabla principal */
    table {
        width: 100%;
        margin-top: 20px;
        border-collapse: collapse;
    }

    /* Estilo general para encabezados y celdas */
    th, td {
        padding: 10px;
        text-align: left;
        border: 1px solid #ddd;
    }

    /* Fondo para encabezados */
    th {
        background-color: #007bff;
        color: white;
        cursor: pointer;
        position: relative;
        padding-right: 20px; /* Espacio para las flechitas */
    }

    /* Flechas visibles siempre (por defecto) */
    th::after {
        content: "▲▼"; /* Ambas flechas (ascendente y descendente) */
        position: absolute;
        right: 5px;
        font-size: 0.8rem;
    }

    /* Flecha ascendente activa */
    th.asc::after {
        content: "▲"; /* Mostrar solo flecha ascendente */
        color: #ffffff; /* Color activo */
    }

    /* Flecha descendente activa */
    th.desc::after {
        content: "▼"; /* Mostrar solo flecha descendente */
        color: #ffffff; /* Color activo */
    }

    /* Resaltar fila al pasar el ratón */
    tr:hover {
        background-color: #f1f1f1;
        transition: background-color 0.3s ease;
    }
</style>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 turnos-container">
        <h1>🗓️ Mis Turnos</h1>

         <!-- Filtro por fecha -->
    <input type="text" id="filterFecha" class="filter-input" placeholder="Filtrar por fecha (dd/MM/yyyy)" onkeyup="filtrarPorColumna(0)" />

    <!-- Filtro por servicios -->
    <input type="text" id="filterServicios" class="filter-input" placeholder="Filtrar por servicios" onkeyup="filtrarPorColumna(2)" />

        <!-- Tabla de turnos -->
        <asp:Repeater ID="RepeaterTurnos" runat="server">
            <HeaderTemplate>
                <table id="turnosTable">
                    <thead>
                        <tr>
                            <th>Fecha</th>
                            <th>Hora</th>
                            <th>Servicios</th>
                            <th>Estado</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("FechaCita", "{0:dd/MM/yyyy}") %></td>
                    <td><%# Eval("HoraCita", "{0:hh\\:mm}") %></td>
                    <td><%# Eval("Servicios") %></td>
                    <td><%# Eval("Estado") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div id="pagination-container" class="pagination"></div>

        <!-- Mensaje cuando no hay turnos -->
        <asp:Panel ID="PanelNoTurnos" runat="server" Visible="false">
            <p class="no-turnos">No tienes turnos programados.</p>
        </asp:Panel>
    </div>


<script>
    var rowsPerPage = 10; // Cantidad de filas por página

    function generarPaginacion() {
        var table = document.getElementById("turnosTable");
        var rows = table.getElementsByTagName("tr");
        var totalRows = rows.length - 1; // Descontar el encabezado
        var totalPages = Math.ceil(totalRows / rowsPerPage);

        var paginationContainer = document.getElementById("pagination-container");
        paginationContainer.innerHTML = "";

        for (var i = 1; i <= totalPages; i++) {
            var pageLink = document.createElement("a");
            pageLink.textContent = i;
            pageLink.href = "#";
            pageLink.classList.add("page-link");
            pageLink.onclick = (function (pageNumber) {
                return function () {
                    mostrarPagina(pageNumber);
                };
            })(i);
            paginationContainer.appendChild(pageLink);
        }

        // Mostrar la primera página por defecto
        mostrarPagina(1);
    }

    function mostrarPagina(pageNumber) {
        var table = document.getElementById("turnosTable");
        var rows = table.getElementsByTagName("tr");
        var start = (pageNumber - 1) * rowsPerPage + 1;
        var end = pageNumber * rowsPerPage;

        for (var i = 1; i < rows.length; i++) { // Saltar encabezado
            rows[i].style.display = i >= start && i <= end ? "" : "none";
        }

        // Resaltar el botón de la página actual
        var links = document.querySelectorAll("#pagination-container .page-link");
        links.forEach(link => link.classList.remove("active"));
        links[pageNumber - 1].classList.add("active");
    }

    // Generar paginación al cargar la página
    document.addEventListener("DOMContentLoaded", generarPaginacion);
</script>


<script>
    function filtrarPorColumna(colIndex) {
        var table = document.getElementById("turnosTable");
        var rows = table.getElementsByTagName("tr");
        var filterInput;

        // Obtener el filtro correcto basado en la columna
        if (colIndex === 0) {
            filterInput = document.getElementById("filterFecha").value.toLowerCase();
        } else if (colIndex === 2) {
            filterInput = document.getElementById("filterServicios").value.toLowerCase();
        } else if (colIndex === 3) {
            filterInput = document.getElementById("filterEstado").value.toLowerCase();
        }

        for (var i = 1; i < rows.length; i++) {
            var cell = rows[i].getElementsByTagName("td")[colIndex];
            if (cell) {
                var textValue = cell.textContent || cell.innerText;
                rows[i].style.display = textValue.toLowerCase().indexOf(filterInput) > -1 ? "" : "none";
            }
        }
    }



</script>


<script>
    function ordenarTablaPorColumna(colIndex) {
        var table = document.getElementById("turnosTable");
        var rows = Array.from(table.getElementsByTagName("tr")).slice(1); // Excluir encabezado
        var isAscending = table.getAttribute(`data-sort-col-${colIndex}`) !== "asc"; // Alternar entre ascendente y descendente

        // Ordenar las filas
        rows.sort(function (rowA, rowB) {
            var cellA = rowA.getElementsByTagName("td")[colIndex].innerText.toLowerCase();
            var cellB = rowB.getElementsByTagName("td")[colIndex].innerText.toLowerCase();

            if (!isNaN(Date.parse(cellA)) && !isNaN(Date.parse(cellB))) {
                // Comparar fechas
                return isAscending
                    ? new Date(cellA) - new Date(cellB)
                    : new Date(cellB) - new Date(cellA);
            } else if (!isNaN(cellA) && !isNaN(cellB)) {
                // Comparar números
                return isAscending ? cellA - cellB : cellB - cellA;
            } else {
                // Comparar texto
                return isAscending
                    ? cellA.localeCompare(cellB)
                    : cellB.localeCompare(cellA);
            }
        });

        // Agregar filas ordenadas nuevamente al cuerpo de la tabla
        rows.forEach(function (row) {
            table.tBodies[0].appendChild(row);
        });

        // Actualizar el atributo de orden y el estilo de las flechas
        resetFlechas();
        var headers = table.getElementsByTagName("th");
        headers[colIndex].setAttribute("data-order", isAscending ? "asc" : "desc");
        headers[colIndex].classList.add(isAscending ? "asc" : "desc");

        table.setAttribute(`data-sort-col-${colIndex}`, isAscending ? "asc" : "desc");
    }

    // Restablecer todas las flechas a su estado predeterminado
    function resetFlechas() {
        var headers = document.getElementById("turnosTable").getElementsByTagName("th");
        Array.from(headers).forEach(header => {
            header.removeAttribute("data-order");
            header.classList.remove("asc", "desc");
        });
    }

    // Agregar eventos de clic a los encabezados al cargar la página
    document.addEventListener("DOMContentLoaded", function () {
        var table = document.getElementById("turnosTable");
        var headers = table.getElementsByTagName("th");

        for (var i = 0; i < headers.length; i++) {
            (function (index) {
                headers[index].addEventListener("click", function () {
                    ordenarTablaPorColumna(index);
                });
            })(i);
        }
    });
</script>



</asp:Content>

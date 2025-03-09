using System;
using System.Data.SqlClient;
using System.Linq;


namespace AplicacionWEB
{
    public partial class Dashboard : System.Web.UI.Page
    {
        // Variables públicas para enviar datos dinámicos al gráfico
        public string CategoriasNombres { get; set; } = "[]";
        public string CategoriasCantidad { get; set; } = "[]";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo cargamos los datos si no es una solicitud de PostBack
            if (!IsPostBack)
            {
                // Establecer conexión con la base de datos
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
                conn.Open();

                // Crear el contexto de LINQ
                DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

                // Cargar estadísticas principales
                CargarEstadisticas(mapeador);

                // Cargar datos para el gráfico de servicios por categoría
                CargarGraficoServiciosPorCategoria(mapeador);

                // Cerrar la conexión
                conn.Close();
            }
        }

        private void CargarEstadisticas(DataClasses1DataContext mapeador)
        {
            // Estadísticas de usuarios
            lblTotalUsuarios.Text = mapeador.Usuarios.Count().ToString();
            lblUsuariosActivos.Text = mapeador.Usuarios.Count(u => u.Activo == true).ToString();
            lblUsuariosInactivos.Text = mapeador.Usuarios.Count(u => u.Activo == false).ToString();

            // Estadísticas de servicios
            lblTotalServicios.Text = mapeador.Servicios.Count().ToString();
            lblServiciosActivos.Text = mapeador.Servicios.Count(s => s.Estado == true).ToString();
            lblServiciosInactivos.Text = mapeador.Servicios.Count(s => s.Estado == false).ToString();
        }

        private void CargarGraficoServiciosPorCategoria(DataClasses1DataContext mapeador)
        {
            // Agrupar servicios por categoría y contar cuántos servicios hay por categoría
            var categorias = mapeador.Servicios
                .GroupBy(s => s.IdCategoria)
                .Select(g => new
                {
                    Categoria = g.Key.ToString() ?? "Sin Categoría",
                    Cantidad = g.Count()
                }).ToList();

            // Generar los datos dinámicos en formato JSON para Chart.js
            CategoriasNombres = "[" + string.Join(",", categorias.Select(c => $"'{c.Categoria}'")) + "]";
            CategoriasCantidad = "[" + string.Join(",", categorias.Select(c => c.Cantidad)) + "]";
        }
    }
}
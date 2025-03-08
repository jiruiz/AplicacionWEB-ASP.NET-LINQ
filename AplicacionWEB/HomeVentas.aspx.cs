using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWEB
{
	public partial class HomeVentas : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Solo cargar datos la primera vez
            {
                MostrarServiciosActivos();
            }
        }

        private void MostrarServiciosActivos()
        {
            // Crear conexión a la base de datos
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            try
            {
                conn.Open(); // Abrir la conexión

                // Crear una instancia del contexto de datos usando la conexión
                DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

                // Consulta LINQ para obtener servicios activos
                var serviciosActivos = mapeador.Servicios
                    .Where(s => s.Estado == true) // Filtrar servicios activos
                    .Select(s => new
                    {
                        s.Nombre,
                        s.Descripcion,
                        s.Precio,
                        s.DuracionMinutos
                    })
                    .ToList();

                // Asignar datos al Repeater
                RepeaterServicios.DataSource = serviciosActivos;
                RepeaterServicios.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar posibles errores
                Response.Write($"<p style='color:red;'>Error: {ex.Message}</p>");
            }
            finally
            {
                // Asegurar el cierre de la conexión
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
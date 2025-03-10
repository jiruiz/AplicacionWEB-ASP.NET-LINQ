using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWEB
{
	public partial class Confirmacion : System.Web.UI.Page
	{
        private SqlConnection conn; // Conexión manual
        private DataClasses1DataContext mapeador; // Contexto de datos manual

        protected void Page_Load(object sender, EventArgs e)
        {
            // Configurar conexión a la base de datos
            conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();
            mapeador = new DataClasses1DataContext(conn);

            if (!IsPostBack)
            {
                CargarDatosConfirmacion();
            }
        }

        private void CargarDatosConfirmacion()
        {
            try
            {
                // Recuperar el turno confirmado desde la sesión
                int idTurno = Session["IdTurnoConfirmado"] != null ? Convert.ToInt32(Session["IdTurnoConfirmado"]) : 0;

                // Validar que exista un turno confirmado
                if (idTurno == 0)
                {
                    Response.Write("<p style='color:red;'>No se encontró un turno confirmado.</p>");
                    return;
                }

                // Consultar los servicios confirmados asociados al turno
                var serviciosConfirmados = from ts in mapeador.TurnosServicios
                                           join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                                           where ts.IdTurno == idTurno
                                           select new
                                           {
                                               NombreServicio = s.Nombre,
                                               Precio = s.Precio
                                           };

                // Calcular el importe total
                decimal importeTotal = serviciosConfirmados.Sum(sc => sc.Precio);
                ViewState["ImporteTotal"] = importeTotal.ToString("N2");

                // Cargar los datos en el Repeater
                RepeaterServiciosConfirmados.DataSource = serviciosConfirmados.ToList();
                RepeaterServiciosConfirmados.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<p style='color:red;'>Error al cargar los datos: {ex.Message}</p>");
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Cerrar la conexión manualmente
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
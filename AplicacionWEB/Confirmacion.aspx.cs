using System;
using System.Linq;
using System.Data.SqlClient;

namespace AplicacionWEB
{
    public partial class Confirmacion : System.Web.UI.Page
    {
        private SqlConnection conn;
        private DataClasses1DataContext mapeador;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                // Recuperar el ID del turno confirmado desde la sesión
                int idTurno = Session["IdTurnoConfirmado"] != null ? Convert.ToInt32(Session["IdTurnoConfirmado"]) : 0;

                if (idTurno == 0)
                {
                    MostrarError("❌ No se encontró un turno confirmado.");
                    return;
                }

                // Obtener los datos del turno confirmado
                var turnoConfirmado = (from t in mapeador.Turnos
                                       where t.IdTurno == idTurno
                                       select new
                                       {
                                           t.FechaCita,
                                           t.HoraCita
                                       }).FirstOrDefault();

                if (turnoConfirmado == null)
                {
                    MostrarError("❌ No se pudieron recuperar los datos del turno confirmado.");
                    return;
                }

                // Mostrar la fecha y hora de la cita
                lblFechaCita.Text = turnoConfirmado.FechaCita.ToString("dd/MM/yyyy");
                lblHoraCita.Text = turnoConfirmado.HoraCita.ToString(@"hh\:mm");

                // Obtener los servicios confirmados
                var serviciosConfirmados = (from ts in mapeador.TurnosServicios
                                            join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                                            where ts.IdTurno == idTurno
                                            group ts by new { ts.IdServicio, s.Nombre, s.Precio } into g
                                            select new
                                            {
                                                IdServicio = g.Key.IdServicio,
                                                NombreServicio = g.Key.Nombre,
                                                Precio = g.Key.Precio,
                                                Cantidad = g.Count(),
                                                Total = g.Count() * g.Key.Precio
                                            }).ToList();

                // Calcular el importe total
                decimal importeTotal = serviciosConfirmados.Sum(sc => sc.Total);
                ViewState["ImporteTotal"] = importeTotal.ToString("N2");

                // Llenar el Repeater con los servicios confirmados
                RepeaterServiciosConfirmados.DataSource = serviciosConfirmados;
                RepeaterServiciosConfirmados.DataBind();
            }
            catch (Exception ex)
            {
                MostrarError($"❌ Error al cargar los datos: {ex.Message}");
            }
        }


        protected void Page_Unload(object sender, EventArgs e)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}

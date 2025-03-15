using System;
using System.Data.SqlClient;
using System.Linq;

namespace AplicacionWEB
{
    public partial class MisTurnos : System.Web.UI.Page
    {
        private SqlConnection conn; // Variable para la conexión
        private DataClasses1DataContext mapeador; // DataContext para interactuar con la base de datos

        protected void Page_Load(object sender, EventArgs e)
        {
            // Configurar e inicializar la conexión y el DataContext
            conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();
            mapeador = new DataClasses1DataContext(conn);

            if (!IsPostBack)
            {
                // Cargar los turnos sólo si no es un PostBack
                CargarTurnos();
            }
        }

        private void CargarTurnos()
        {
            try
            {
                // Validar la sesión del usuario
                string usuarioLogueado = Session["UsuarioLogueado"]?.ToString();
                if (string.IsNullOrEmpty(usuarioLogueado))
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                // Recuperar el cliente logueado
                var usuario = mapeador.Usuarios.FirstOrDefault(u => u.Usuario == usuarioLogueado);
                if (usuario == null)
                {
                    lblMensaje.Text = "❌ Usuario no encontrado.";
                    lblMensaje.Visible = true;
                    return;
                }

                // Obtener los turnos del cliente desde la base de datos
                var turnos = (from t in mapeador.Turnos
                              where t.IdUsuario == usuario.IdUsuario
                              orderby t.FechaCita descending, t.HoraCita descending // Ordenar por fecha y hora descendente
                              select new
                              {
                                  t.FechaCita,
                                  t.HoraCita,
                                  Servicios = string.Join(", ", from ts in mapeador.TurnosServicios
                                                                join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                                                                where ts.IdTurno == t.IdTurno
                                                                select s.Nombre),
                                  t.Estado
                              }).ToList();


                // Si no hay turnos, mostrar mensaje
                if (!turnos.Any())
                {
                    RepeaterTurnos.Visible = false;
                    PanelNoTurnos.Visible = true;
                    lblMensaje.Visible = false;
                    return;
                }

                // Llenar el Repeater con los turnos
                RepeaterTurnos.DataSource = turnos;
                RepeaterTurnos.DataBind();
                RepeaterTurnos.Visible = true;
                PanelNoTurnos.Visible = false;
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de excepción
                lblMensaje.Text = $"❌ Error al cargar los turnos: {ex.Message}";
                lblMensaje.Visible = true;
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}

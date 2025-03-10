using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AplicacionWEB
{
    public partial class Carrito : System.Web.UI.Page
    {
        private SqlConnection conn;
        private DataClasses1DataContext mapeador;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Configurar la conexión
            conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();
            mapeador = new DataClasses1DataContext(conn);

            if (!IsPostBack)
            {
                CargarServiciosDelCarrito();
            }
        }

        protected void CargarServiciosDelCarrito()
        {
            try
            {
                string usuarioLogueado = Session["UsuarioLogueado"]?.ToString();
                if (string.IsNullOrEmpty(usuarioLogueado))
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                var usuario = mapeador.Usuarios.FirstOrDefault(u => u.Usuario == usuarioLogueado);
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                var servicios = from ts in mapeador.TurnosServicios
                                join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                                where ts.IdUsuario == usuario.IdUsuario && ts.IdTurno == null
                                select new
                                {
                                    ts.IdTurnosServicios,
                                    NombreServicio = s.Nombre,
                                    Precio = s.Precio
                                };

                if (!servicios.Any())
                {
                    MostrarMensaje("No hay servicios en el carrito.", "Blue");
                    return;
                }

                RepeaterCarrito.DataSource = servicios.ToList();
                RepeaterCarrito.DataBind();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar el carrito: {ex.Message}", "Red");
            }
        }

        protected void RepeaterCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idTurnosServicios = Convert.ToInt32(e.CommandArgument);

                try
                {
                    var item = mapeador.TurnosServicios.FirstOrDefault(ts => ts.IdTurnosServicios == idTurnosServicios);
                    if (item != null)
                    {
                        mapeador.TurnosServicios.DeleteOnSubmit(item);
                        mapeador.SubmitChanges();
                        MostrarMensaje("Servicio eliminado con éxito.", "Green");
                    }

                    // Recargar el carrito
                    CargarServiciosDelCarrito();
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"Error al eliminar el servicio: {ex.Message}", "Red");
                }
            }
        }

        protected void ConfirmarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                string usuarioLogueado = Session["UsuarioLogueado"]?.ToString();
                if (string.IsNullOrEmpty(usuarioLogueado))
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                var usuario = mapeador.Usuarios.FirstOrDefault(u => u.Usuario == usuarioLogueado);
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                Turnos nuevoTurno = new Turnos
                {
                    IdUsuario = usuario.IdUsuario,
                    FechaTurno = DateTime.Now,
                    Estado = "Pendiente",
                    ImporteTotal = 0
                };

                mapeador.Turnos.InsertOnSubmit(nuevoTurno);
                mapeador.SubmitChanges();

                var serviciosEnCarrito = mapeador.TurnosServicios
                    .Where(ts => ts.IdUsuario == usuario.IdUsuario && ts.IdTurno == null).ToList();

                if (!serviciosEnCarrito.Any())
                {
                    MostrarMensaje("No hay servicios en el carrito para confirmar.", "Red");
                    return;
                }

                foreach (var servicio in serviciosEnCarrito)
                {
                    servicio.IdTurno = nuevoTurno.IdTurno;
                }

                mapeador.SubmitChanges();

                nuevoTurno.ImporteTotal = (from ts in mapeador.TurnosServicios
                                           join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                                           where ts.IdTurno == nuevoTurno.IdTurno
                                           select s.Precio).Sum();

                mapeador.SubmitChanges();

                Session["IdTurnoConfirmado"] = nuevoTurno.IdTurno;
                Response.Redirect("Confirmacion.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al confirmar el turno: {ex.Message}", "Red");
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        protected void MostrarMensaje(string mensaje, string color)
        {
            MensajeLabel.Text = mensaje;
            MensajeLabel.ForeColor = System.Drawing.Color.FromName(color);
            MensajeLabel.Visible = true;
        }
    }
}

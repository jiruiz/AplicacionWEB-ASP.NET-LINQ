using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AplicacionWEB
{
    public partial class Carrito : System.Web.UI.Page
    {
        private SqlConnection conn; // Conexión compartida
        private DataClasses1DataContext mapeador; // Contexto de datos compartido

        protected void Page_Load(object sender, EventArgs e)
        {
            // Configurar conexión y contexto de datos
            conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();
            mapeador = new DataClasses1DataContext(conn);

            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        protected void CargarCarrito()
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

                var carrito = from ts in mapeador.TurnosServicios
                              join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                              where ts.IdUsuario == usuario.IdUsuario && ts.IdTurno == null
                              select new
                              {
                                  ts.IdTurnosServicios,
                                  NombreServicio = s.Nombre,
                                  Precio = s.Precio
                              };

                if (!carrito.Any())
                {
                    Response.Write("<p style='color:blue;'>No hay servicios en el carrito.</p>");
                }

                RepeaterCarrito.DataSource = carrito.ToList();
                RepeaterCarrito.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<p style='color:red;'>Error al cargar el carrito: {ex.Message}</p>");
            }
        }


        protected void RepeaterCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idTurnosServicios = Convert.ToInt32(e.CommandArgument);

                try
                {
                    // Eliminar el servicio del carrito
                    var item = mapeador.TurnosServicios.FirstOrDefault(ts => ts.IdTurnosServicios == idTurnosServicios);
                    if (item != null)
                    {
                        mapeador.TurnosServicios.DeleteOnSubmit(item);
                        mapeador.SubmitChanges();
                    }

                    // Recargar el carrito
                    CargarCarrito();
                }
                catch (Exception ex)
                {
                    Response.Write($"<p style='color:red;'>Error al eliminar el servicio: {ex.Message}</p>");
                }
            }
        }

        protected void ConfirmarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar usuario logueado
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

                // Crear un nuevo turno
                Turnos nuevoTurno = new Turnos
                {
                    IdUsuario = usuario.IdUsuario,
                    FechaTurno = DateTime.Now,
                    Estado = "Pendiente",
                    ImporteTotal = 0 // Inicialmente en 0
                };

                mapeador.Turnos.InsertOnSubmit(nuevoTurno);
                mapeador.SubmitChanges();

                // Obtener servicios en el carrito
                var serviciosEnCarrito = mapeador.TurnosServicios
                    .Where(ts => ts.IdUsuario == usuario.IdUsuario && ts.IdTurno == null).ToList();

                // Verificar si hay servicios en el carrito
                if (!serviciosEnCarrito.Any())
                {
                    Response.Write("<p style='color:red;'>No hay servicios en el carrito para confirmar.</p>");
                    return;
                }

                // Asociar los servicios al turno
                foreach (var servicio in serviciosEnCarrito)
                {
                    servicio.IdTurno = nuevoTurno.IdTurno;
                }

                // Guardar los cambios antes de calcular el importe total
                mapeador.SubmitChanges();

                // Calcular el importe total
                nuevoTurno.ImporteTotal = (from ts in mapeador.TurnosServicios
                                           join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                                           where ts.IdTurno == nuevoTurno.IdTurno
                                           select s.Precio).Sum();

                // Guardar el importe total actualizado
                mapeador.SubmitChanges();

                // Confirmar el turno en la sesión
                Session["IdTurnoConfirmado"] = nuevoTurno.IdTurno;
                Response.Redirect("Confirmacion.aspx");
            }
            catch (Exception ex)
            {
                Response.Write($"<p style='color:red;'>Error al confirmar el turno: {ex.Message}</p>");
            }
        }




        protected void Page_Unload(object sender, EventArgs e)
        {
            // Cerrar la conexión explícitamente
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}

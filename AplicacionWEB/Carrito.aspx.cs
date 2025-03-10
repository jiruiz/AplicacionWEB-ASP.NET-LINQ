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

        private void CargarCarrito()
        {
            try
            {
                // Validar sesión del usuario
                string usuarioLogueado = Session["UsuarioLogueado"]?.ToString();
                if (string.IsNullOrEmpty(usuarioLogueado))
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                // Obtener el usuario logueado
                var usuario = mapeador.Usuarios.FirstOrDefault(u => u.Usuario == usuarioLogueado);
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                // DEBUG: Mostrar el IdUsuario del usuario logueado
                Response.Write($"<p style='color:green;'>IdUsuario del usuario logueado: {usuario.IdUsuario}</p>");

                // Cargar los servicios en el carrito (TurnosServicios sin confirmar)
                var carrito = from ts in mapeador.TurnosServicios
                              join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                              where ts.IdUsuario == usuario.IdUsuario && ts.IdTurno == null
                              select new
                              {
                                  ts.IdTurnosServicios,
                                  NombreServicio = s.Nombre,
                                  Precio = s.Precio
                              };

                // Validar si el carrito tiene datos
                if (!carrito.Any())
                {
                    Response.Write("<p style='color:blue;'>No hay servicios en el carrito para este usuario.</p>");
                }
                else
                {
                    // DEBUG: Mostrar los servicios del carrito en consola
                    foreach (var item in carrito)
                    {
                        Response.Write($"<p>IdTurnosServicios: {item.IdTurnosServicios}, Servicio: {item.NombreServicio}, Precio: {item.Precio}</p>");
                    }
                }

                // Asignar datos al Repeater
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
                // Validar sesión del usuario
                string usuarioLogueado = Session["UsuarioLogueado"]?.ToString();
                if (string.IsNullOrEmpty(usuarioLogueado))
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                // Obtener el usuario logueado
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
                    ImporteTotal = 0 // Se calculará posteriormente
                };
                mapeador.Turnos.InsertOnSubmit(nuevoTurno);
                mapeador.SubmitChanges();

                // Asociar los servicios del carrito al nuevo turno
                var serviciosEnCarrito = mapeador.TurnosServicios.Where(ts => ts.IdUsuario == usuario.IdUsuario && ts.IdTurno == null);
                foreach (var servicio in serviciosEnCarrito)
                {
                    servicio.IdTurno = nuevoTurno.IdTurno;
                }

                
                mapeador.SubmitChanges();

                // Redirigir a una página de confirmación
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

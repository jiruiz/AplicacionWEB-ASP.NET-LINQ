using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
                var serviciosActivos = (from s in mapeador.Servicios
                                        join c in mapeador.Categorias
                                        on s.IdCategoria equals c.IdCategoria into categorias
                                        from cat in categorias.DefaultIfEmpty() // Manejar servicios sin categoría
                                        where s.Estado == true
                                        select new
                                        {
                                            s.IdServicio, // Agregar IdServicio para referencia
                                            s.Nombre,
                                            s.Descripcion,
                                            s.Precio,
                                            s.DuracionMinutos,
                                            Categoria = cat != null ? cat.Nombre : "Sin Categoría" // Mostrar el nombre o "Sin Categoría"
                                        }).ToList();

                // Asignar datos al Repeater
                RepeaterServicios.DataSource = serviciosActivos;
                RepeaterServicios.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar posibles errores
                MostrarMensaje($"Error al cargar los servicios: {ex.Message}", false);
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

        protected void RepeaterServicios_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Adquirir")
            {
                int idServicio = Convert.ToInt32(e.CommandArgument);

                // Simular usuario logueado
                string usuarioLogueado = Session["UsuarioLogueado"]?.ToString();
                if (string.IsNullOrEmpty(usuarioLogueado))
                {
                    MostrarMensaje("Debe iniciar sesión para adquirir un servicio.", false);

                    // Hacer visible el botón de redirección a login
                    btnLoginRedirect.Visible = true;
                    return;
                }

                // Crear conexión a la base de datos
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
                try
                {
                    conn.Open(); // Abrir la conexión

                    // Crear una instancia del contexto de datos usando la conexión
                    DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

                    // Obtener el IdUsuario del usuario logueado
                    int idUsuario = mapeador.Usuarios.First(u => u.Usuario == usuarioLogueado).IdUsuario;

                    // Crear un nuevo registro en la tabla TurnosServicios
                    TurnosServicios relacion = new TurnosServicios
                    {
                        IdServicio = idServicio,    // Asociar el servicio adquirido
                        IdUsuario = idUsuario,     // Relacionarlo con el usuario logueado
                        IdTurno = null             // Este servicio aún no está confirmado en un turno
                    };

                    // Insertar el registro
                    mapeador.TurnosServicios.InsertOnSubmit(relacion);
                    mapeador.SubmitChanges();

                    // Mostrar un mensaje de éxito
                    MostrarMensaje("El servicio ha sido añadido al carrito con éxito.", true);

                    // Asegurarnos de que el botón de login no se muestre
                    btnLoginRedirect.Visible = false;
                }
                catch (Exception ex)
                {
                    // Manejar errores
                    MostrarMensaje($"Error al adquirir el servicio: {ex.Message}", false);
                }
                finally
                {
                    // Cerrar la conexión
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        // Método para mostrar mensajes
        private void MostrarMensaje(string mensaje, bool esExito)
        {
            LabelMensaje.Text = mensaje;
            LabelMensaje.CssClass = esExito ? "service-message service-message-success" : "service-message";
            LabelMensaje.Visible = true;

            // Actualizar el panel de mensajes
            UpdatePanelMensajes.Update();
        }

        // Evento para redirigir al login
        protected void btnLoginRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}

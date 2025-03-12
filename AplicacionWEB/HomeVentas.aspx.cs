using System;
using System.Collections.Generic;
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
        protected void RepeaterServicios_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Adquirir")
            {
                int idServicio = Convert.ToInt32(e.CommandArgument);

                // Simular usuario logueado
                string usuarioLogueado = Session["UsuarioLogueado"]?.ToString();
                if (string.IsNullOrEmpty(usuarioLogueado))
                {
                    LabelMensaje.Text = "Debe iniciar sesión para adquirir un servicio.";
                    LabelMensaje.ForeColor = System.Drawing.Color.Red;
                    LabelMensaje.Visible = true;
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
                    LabelMensaje.Text = "El servicio ha sido añadido al carrito con éxito.";
                    LabelMensaje.ForeColor = System.Drawing.Color.Green;
                    LabelMensaje.Visible = true;
                }
                catch (Exception ex)
                {
                    // Manejar errores
                    LabelMensaje.Text = $"Error al adquirir el servicio: {ex.Message}";
                    LabelMensaje.ForeColor = System.Drawing.Color.Red;
                    LabelMensaje.Visible = true;
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



    }
}
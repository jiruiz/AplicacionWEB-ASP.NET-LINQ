using System;
using System.Data.SqlClient;
using System.Linq;

namespace AplicacionWEB
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario está logueado
            if (Session["UsuarioLogueado"] == null)
            {
                Response.Redirect("Login.aspx"); // Redirigir al login si no está logueado
                return;
            }

            // Obtener el usuario logueado desde la sesión
            string usuarioLogueado = Session["UsuarioLogueado"].ToString();

            // Crear conexión a la base de datos
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();

            // Crear contexto LINQ to SQL
            DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

            // Verificar el rol del usuario
            var usuario = mapeador.Usuarios
                                  .Where(u => u.Usuario == usuarioLogueado)
                                  .Select(u => new { u.Rol })
                                  .FirstOrDefault();

            if (usuario == null || usuario.Rol != "Admin")
            {
                Response.Redirect("AccesoDenegado.aspx"); // Redirigir a página de acceso denegado si no es admin
                return;
            }

            // Cargar estadísticas del sistema
            CargarEstadisticas(mapeador);

            // Cerrar la conexión
            conn.Close();
        }

        private void CargarEstadisticas(DataClasses1DataContext mapeador)
        {
            // Obtener el total de usuarios
            lblTotalUsuarios.Text = mapeador.Usuarios.Count().ToString();

            // Obtener el total de servicios activos
            lblServiciosActivos.Text = mapeador.Servicios.Count(s => s.Estado == true).ToString();

            // Obtener el total de servicios inactivos
            lblServiciosInactivos.Text = mapeador.Servicios.Count(s => s.Estado == false).ToString();
        }
    }
}

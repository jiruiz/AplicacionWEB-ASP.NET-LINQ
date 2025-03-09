using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AplicacionWEB
{
    public partial class MostrarUsuarios : System.Web.UI.Page
    {
        private SqlConnection conn;
        private DataClasses1DataContext mapeador;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Configurar la conexión y el DataContext
            conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();
            mapeador = new DataClasses1DataContext(conn);

            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                // Consulta LINQ para obtener los usuarios
                var usuarios = from u in mapeador.Usuarios
                               select new
                               {
                                   u.IdUsuario,
                                   u.Nombre,
                                   u.Apellido,
                                   u.Telefono,
                                   u.Email,
                                   u.Usuario,
                                   u.FechaNacimiento,
                                   u.Rol,
                                   u.Activo,
                                   u.FechaRegistro
                               };

                // Enlazar los datos al Repeater
                repeaterUsuarios.DataSource = usuarios.ToList();
                repeaterUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Ocurrió un error al cargar los usuarios: " + ex.Message;
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
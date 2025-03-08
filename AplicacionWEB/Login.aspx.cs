using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWEB
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMensaje.Visible = false; // Ocultar el mensaje al cargar la página
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();

            DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

            try
            {
                var usuarioValido = mapeador.Usuarios
                    .Where(u => u.Usuario == usuario && u.Contrasena == password && u.Activo == true)
                    .Select(u => new { u.Usuario, u.Rol }) // Traer también el rol del usuario
                    .FirstOrDefault();

                if (usuarioValido != null)
                {
                    // Guardar en sesión
                    Session["UsuarioLogueado"] = usuarioValido.Usuario;
                    Session["RolUsuario"] = usuarioValido.Rol;

                    // Crear una cookie persistente si el usuario desea recordar la sesión
                    HttpCookie usuarioCookie = new HttpCookie("UsuarioCookie");
                    usuarioCookie["UsuarioLogueado"] = usuarioValido.Usuario;
                    usuarioCookie["RolUsuario"] = usuarioValido.Rol;
                    usuarioCookie.Expires = DateTime.Now.AddDays(7); // La cookie expira en 7 días
                    Response.Cookies.Add(usuarioCookie);

                    // Redirigir al Home
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error: " + ex.Message;
                lblMensaje.Visible = true;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
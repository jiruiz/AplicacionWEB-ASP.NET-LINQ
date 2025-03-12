using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWEB
{
    public partial class SiteHome : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Restaurar sesión desde la cookie si no está activa
            if (Session["UsuarioLogueado"] == null && Request.Cookies["UsuarioCookie"] != null)
            {
                // Leer los valores desde la cookie
                string usuario = Request.Cookies["UsuarioCookie"]["UsuarioLogueado"];
                string rol = Request.Cookies["UsuarioCookie"]["RolUsuario"];

                // Restaurar en la sesión
                Session["UsuarioLogueado"] = usuario;
                Session["RolUsuario"] = rol;
            }

            // Verificar si hay un usuario logueado
            if (Session["UsuarioLogueado"] != null)
            {
                string rolUsuario = Session["RolUsuario"]?.ToString();

                // Mostrar "Cerrar Sesión", "Carrito" y otras opciones si hay usuario logueado
                PhCerrarSesion.Visible = true;
                PhIniciarSesion.Visible = false;
                PhCarrito.Visible = true;
                PhHomeVentas.Visible = true;

                // Mostrar opciones administrativas solo si es administrador
                if (rolUsuario == "Admin")
                {
                    PhAdmin.Visible = true;
                    PhDashboard.Visible = true;
                    PhCategorias.Visible = true;
                    PhUsuarios.Visible = true;
                }
                else
                {
                    PhAdmin.Visible = false;
                    PhDashboard.Visible = false;
                    PhCategorias.Visible = false;
                    PhUsuarios.Visible = false;
                }
            }
            else
            {
                // Mostrar solo "Iniciar Sesión" si no hay usuario logueado
                PhCerrarSesion.Visible = false;
                PhIniciarSesion.Visible = true;
                PhHomeVentas.Visible = true;

                // Ocultar las opciones administrativas
                PhAdmin.Visible = false;
                PhCategorias.Visible = false;
                PhDashboard.Visible = false;
                PhUsuarios.Visible = false;
                PhCarrito.Visible = false; // Opcional: Si no hay sesión, ocultar el carrito
            }
        }
    }
}

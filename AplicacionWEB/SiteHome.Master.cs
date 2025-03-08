using System;
using System.Collections.Generic;
using System.Linq;
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

                // Mostrar "Cerrar Sesión"
                PhCerrarSesion.Visible = true;
                PhIniciarSesion.Visible = false;

                // Mostrar opciones administrativas solo si es administrador
                if (rolUsuario == "Admin")
                {
                    PhAdmin.Visible = true;
                    PhHomeVentas.Visible = true;
                    PhDashboard.Visible = true;

                }
                else
                {
                    PhAdmin.Visible = false;
                    PhHomeVentas.Visible = true;

                }
            }
            else
            {
                // Mostrar solo "Iniciar Sesión" si no hay usuario logueado
                PhHomeVentas.Visible = true;
                PhCerrarSesion.Visible = false;
                PhIniciarSesion.Visible = true;
                PhAdmin.Visible = false;
            }
        }

    }
}
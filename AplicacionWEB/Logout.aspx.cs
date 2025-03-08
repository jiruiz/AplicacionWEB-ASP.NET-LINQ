using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWEB
{
	public partial class Logout : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            // Eliminar sesión
            Session.Abandon();

            // Eliminar la cookie
            if (Request.Cookies["UsuarioCookie"] != null)
            {
                HttpCookie usuarioCookie = new HttpCookie("UsuarioCookie");
                usuarioCookie.Expires = DateTime.Now.AddDays(-1); // Expirar inmediatamente
                Response.Cookies.Add(usuarioCookie);
            }

            // Redirigir al login
            Response.Redirect("Login.aspx");
        }

    }
}
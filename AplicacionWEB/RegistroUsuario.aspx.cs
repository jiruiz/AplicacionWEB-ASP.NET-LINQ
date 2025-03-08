using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AplicacionWEB
{
	public partial class RegistroUsuario : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Conexión a la base de datos
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();

            DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

            // Validaciones: Nombre y Apellido no deben estar vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                lblMensaje.Text = "Error: Nombre y Apellido son obligatorios.";
                return;
            }

            // Validaciones: Email debe tener formato válido
            if (!txtEmail.Text.Contains("@"))
            {
                lblMensaje.Text = "Error: Ingrese un correo electrónico válido.";
                return;
            }

            // Validaciones: Contraseña no debe estar vacía
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                lblMensaje.Text = "Error: La contraseña es obligatoria.";
                return;
            }

            // Crear nuevo objeto Usuario
            Usuarios nuevoUsuario = new Usuarios
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Usuario = txtUsuario.Text.Trim(),
                Contrasena = txtContrasena.Text.Trim(), // Deberías cifrar la contraseña en producción
                FechaNacimiento = string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) ? (DateTime?)null : Convert.ToDateTime(txtFechaNacimiento.Text),
                Rol = "Usuario",
                Activo = true
            };

            // Insertar el nuevo usuario en la base de datos
            mapeador.Usuarios.InsertOnSubmit(nuevoUsuario);
            mapeador.SubmitChanges();

            // Mensaje de éxito
            lblMensaje.Text = "Usuario registrado con éxito.";
            lblMensaje.CssClass = "text-success";
            lblMensaje.Visible = true;

            // Redireccionar a otra página si lo deseas
            Response.Redirect("Login.aspx");
        }
    }
}
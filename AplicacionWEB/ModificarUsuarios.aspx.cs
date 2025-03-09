using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace AplicacionWEB
{
    public partial class ModificarUsuarios : System.Web.UI.Page
    {
        private SqlConnection conn;
        private DataClasses1DataContext mapeador;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                var usuarios = from u in mapeador.Usuarios
                               select new
                               {
                                   u.IdUsuario,
                                   u.Nombre,
                                   u.Apellido,
                                   u.Email,
                                   u.Rol,
                                   u.Usuario,
                                   u.Activo,
                                   u.Contrasena // Solo para actualizar internamente
                               };

                grillaUsuarios.DataSource = usuarios.ToList();
                grillaUsuarios.DataBind();

            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Error al cargar los usuarios: " + ex.Message;
            }
        }

        protected void grillaUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grillaUsuarios.EditIndex = e.NewEditIndex;
            CargarUsuarios();
        }

        protected void grillaUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grillaUsuarios.EditIndex = -1;
            CargarUsuarios();
        }

        protected void grillaUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int idUsuario = Convert.ToInt32(grillaUsuarios.DataKeys[e.RowIndex]?.Value);
                string nombre = (grillaUsuarios.Rows[e.RowIndex].FindControl("txtNombre") as TextBox)?.Text;
                string apellido = (grillaUsuarios.Rows[e.RowIndex].FindControl("txtApellido") as TextBox)?.Text;
                string email = (grillaUsuarios.Rows[e.RowIndex].FindControl("txtEmail") as TextBox)?.Text;
                DropDownList ddlRol = (grillaUsuarios.Rows[e.RowIndex].FindControl("ddlRol") as DropDownList);
                bool activo = (grillaUsuarios.Rows[e.RowIndex].FindControl("chkActivo") as CheckBox)?.Checked ?? false;
                string nuevaContrasena = (grillaUsuarios.Rows[e.RowIndex].FindControl("txtContrasena") as TextBox)?.Text;

                // Validar el rol
                if (ddlRol.SelectedValue == "")
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "Por favor, seleccione un rol válido.";
                    return;
                }

                // Actualizar el usuario
                var usuario = mapeador.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
                if (usuario != null)
                {
                    usuario.Nombre = nombre;
                    usuario.Apellido = apellido;
                    usuario.Email = email;
                    usuario.Rol = ddlRol.SelectedValue;
                    usuario.Activo = activo;

                    // Si se proporciona una nueva contraseña, actualizarla
                    if (!string.IsNullOrWhiteSpace(nuevaContrasena))
                    {
                        usuario.Contrasena = nuevaContrasena; // En un caso real, considera encriptar las contraseñas
                    }

                    mapeador.SubmitChanges();
                    lblMensaje.CssClass = "text-success";
                    lblMensaje.Text = "Usuario actualizado correctamente.";
                }

                grillaUsuarios.EditIndex = -1;
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Error al actualizar el usuario: " + ex.Message;
            }
        }



        protected void grillaUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idUsuario = Convert.ToInt32(grillaUsuarios.DataKeys[e.RowIndex]?.Value);
                var usuario = mapeador.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
                if (usuario != null)
                {
                    mapeador.Usuarios.DeleteOnSubmit(usuario);
                    mapeador.SubmitChanges();
                    lblMensaje.CssClass = "text-success";
                    lblMensaje.Text = "Usuario eliminado correctamente.";
                }

                CargarUsuarios();
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Error al eliminar el usuario: " + ex.Message;
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
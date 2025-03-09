using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWEB
{
    public partial class IngresoCategorias : System.Web.UI.Page
    {
        private SqlConnection conn;
        private DataClasses1DataContext mapeador;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Configurar la conexión y el DataContext una sola vez
            conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();
            mapeador = new DataClasses1DataContext(conn);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar entrada del usuario
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "El nombre de la categoría es obligatorio.";
                    return;
                }

                // Crear el objeto categoría
                Categorias nuevaCategoria = new Categorias
                {
                    Nombre = txtNombre.Text,
                    Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text
                };

                // Insertar la categoría utilizando LINQ to SQL
                mapeador.Categorias.InsertOnSubmit(nuevaCategoria);
                mapeador.SubmitChanges();

                // Mostrar mensaje de éxito
                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Categoría guardada con éxito.";
                txtNombre.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Ocurrió un error al guardar la categoría: " + ex.Message;
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
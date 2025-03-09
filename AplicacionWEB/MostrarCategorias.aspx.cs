using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace AplicacionWEB
{
    public partial class MostrarCategorias : System.Web.UI.Page
    {
        private SqlConnection conn;
        private DataClasses1DataContext mapeador;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Configurar conexión y contexto de datos
            conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();
            mapeador = new DataClasses1DataContext(conn);

            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        private void CargarCategorias()
        {
            try
            {
                // Consulta LINQ para obtener las categorías
                var categorias = from c in mapeador.Categorias
                                 select new
                                 {
                                     c.IdCategoria,
                                     c.Nombre,
                                     c.Descripcion
                                 };

                // Enlazar los datos al Repeater
                repeaterCategorias.DataSource = categorias.ToList();
                repeaterCategorias.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Ocurrió un error al cargar las categorías: " + ex.Message;
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
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AplicacionWEB
{
    public partial class ModificarServicios : System.Web.UI.Page
    {
        private string conexionString = "Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarServicios();
            }
        }
        protected void grillaServicios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idServicio = Convert.ToInt32(grillaServicios.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Integrated Security=True;"))
            {
                conn.Open();
                string query = "DELETE FROM Servicios WHERE IdServicio = @IdServicio";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdServicio", idServicio);
                    cmd.ExecuteNonQuery();
                }
            }

            CargarServicios(); // Vuelve a cargar la grilla después de eliminar
        }

        private void CargarServicios()
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                conn.Open();
                DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

                var servicios1 = from i in mapeador.Servicios
                                 select i;

                grillaServicios.DataSource = servicios1;
                grillaServicios.DataBind();
            }
        }

        protected void grillaServicios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grillaServicios.EditIndex = e.NewEditIndex;
            CargarServicios();
        }

        protected void grillaServicios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grillaServicios.EditIndex = -1;
            CargarServicios();
        }

        protected void grillaServicios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idServicio = Convert.ToInt32(grillaServicios.DataKeys[e.RowIndex]?.Value ?? 0);
            string nombre = (grillaServicios.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text;
            string descripcion = (grillaServicios.Rows[e.RowIndex].FindControl("txtDescripcion") as TextBox).Text;
            decimal precio = Convert.ToDecimal((grillaServicios.Rows[e.RowIndex].FindControl("txtPrecio") as TextBox).Text);
            int duracion = Convert.ToInt32((grillaServicios.Rows[e.RowIndex].FindControl("txtDuracion") as TextBox).Text);
            bool estado = (grillaServicios.Rows[e.RowIndex].FindControl("chkEstado") as CheckBox).Checked;

            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                conn.Open();
                DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

                var servicio = mapeador.Servicios.FirstOrDefault(s => s.IdServicio == idServicio);
                if (servicio != null)
                {
                    servicio.Nombre = nombre;
                    servicio.Descripcion = descripcion;
                    servicio.Precio = precio;
                    servicio.DuracionMinutos = duracion;
                    servicio.Estado = estado;
                    mapeador.SubmitChanges();
                }
            }

            grillaServicios.EditIndex = -1;
            CargarServicios();
        }
    }
}

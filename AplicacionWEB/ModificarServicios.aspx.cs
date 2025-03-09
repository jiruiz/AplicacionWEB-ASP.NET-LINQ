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

            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                conn.Open();
                string query = "DELETE FROM Servicios WHERE IdServicio = @IdServicio";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdServicio", idServicio);
                    cmd.ExecuteNonQuery();
                }
            }

            // Recargar los datos en la grilla después de eliminar
            CargarServicios();
        }

        private void CargarServicios()
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                conn.Open();
                DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

                var servicios1 = from s in mapeador.Servicios
                                 join c in mapeador.Categorias on s.IdCategoria equals c.IdCategoria into categorias
                                 from cat in categorias.DefaultIfEmpty()
                                 select new
                                 {
                                     s.IdServicio,
                                     s.Nombre,
                                     s.Descripcion,
                                     s.Precio,
                                     s.DuracionMinutos,
                                     s.Estado,
                                     CategoriaNombre = cat != null ? cat.Nombre : "Sin Categoría"
                                 };

                grillaServicios.DataSource = servicios1.ToList();
                grillaServicios.DataBind();
            }
        }

        protected void grillaServicios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grillaServicios.EditIndex = e.NewEditIndex;

            // Recargar la lista de servicios
            CargarServicios();

            // Obtener la fila en edición
            GridViewRow row = grillaServicios.Rows[e.NewEditIndex];
            DropDownList ddlCategoria = row.FindControl("ddlCategoria") as DropDownList;

            if (ddlCategoria != null) // Validar que el control DropDownList no sea null
            {
                using (SqlConnection conn = new SqlConnection(conexionString))
                {
                    conn.Open();
                    DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

                    var categorias = from c in mapeador.Categorias
                                     select new { c.IdCategoria, c.Nombre };

                    ddlCategoria.DataSource = categorias.ToList();
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataBind();

                    // Seleccionar la categoría actual del servicio
                    Label lblCategoria = row.FindControl("labelCategoria") as Label;
                    if (lblCategoria != null)
                    {
                        ddlCategoria.SelectedValue = categorias.FirstOrDefault(c => c.Nombre == lblCategoria.Text)?.IdCategoria.ToString();
                    }
                }
            }
            else
            {
                lblMensaje.Text = "Error: No se pudo encontrar el DropDownList.";
            }
        }

        protected void grillaServicios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grillaServicios.EditIndex = -1;
            CargarServicios();
        }

        protected void grillaServicios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idServicio = Convert.ToInt32(grillaServicios.DataKeys[e.RowIndex]?.Value ?? 0);
            string nombre = (grillaServicios.Rows[e.RowIndex].FindControl("txtNombre") as TextBox)?.Text;
            string descripcion = (grillaServicios.Rows[e.RowIndex].FindControl("txtDescripcion") as TextBox)?.Text;
            decimal precio = Convert.ToDecimal((grillaServicios.Rows[e.RowIndex].FindControl("txtPrecio") as TextBox)?.Text ?? "0");
            int duracion = Convert.ToInt32((grillaServicios.Rows[e.RowIndex].FindControl("txtDuracion") as TextBox)?.Text ?? "0");
            bool estado = (grillaServicios.Rows[e.RowIndex].FindControl("chkEstado") as CheckBox)?.Checked ?? false;
            int idCategoria = Convert.ToInt32((grillaServicios.Rows[e.RowIndex].FindControl("ddlCategoria") as DropDownList)?.SelectedValue ?? "0");

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
                    servicio.IdCategoria = idCategoria;
                    mapeador.SubmitChanges();
                }
            }

            grillaServicios.EditIndex = -1;
            CargarServicios();
        }
    }
}

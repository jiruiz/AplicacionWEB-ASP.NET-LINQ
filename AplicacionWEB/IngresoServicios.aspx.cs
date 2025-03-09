using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AplicacionWEB
{
    public partial class IngresoServicios : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Conexión a la base de datos
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
                conn.Open();

                DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

                try
                {
                    // Obtener categorías desde la base de datos
                    var categorias = from c in mapeador.Categorias
                                     select new { c.IdCategoria, c.Nombre };

                    // Llenar el DropDownList
                    ddlCategoria.DataSource = categorias;
                    ddlCategoria.DataTextField = "Nombre"; // Nombre de la categoría visible
                    ddlCategoria.DataValueField = "IdCategoria"; // ID de la categoría como valor
                    ddlCategoria.DataBind();

                    // Agregar una opción por defecto
                    ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoría", "0"));
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al cargar las categorías: " + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();

            DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

            try
            {
                // Validar la selección de categoría
                if (ddlCategoria.SelectedValue == "0")
                {
                    lblMensaje.Text = "Por favor, seleccione una categoría.";
                    return;
                }

                // Verificar si el campo de precio está vacío o tiene valores inválidos
                decimal precio;
                if (!decimal.TryParse(txtPrecio.Text, out precio))
                {
                    lblMensaje.Text = "Error: Ingrese un precio válido.";
                    return;
                }

                // Verificar si la duración es un número entero válido
                int duracion;
                if (!int.TryParse(txtDuracion.Text, out duracion))
                {
                    lblMensaje.Text = "Error: Ingrese una duración válida.";
                    return;
                }

                // Crear el objeto servicio
                Servicios servicio = new Servicios
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio,
                    DuracionMinutos = duracion,
                    Estado = CheckBox1.Checked,
                    IdCategoria = Convert.ToInt32(ddlCategoria.SelectedValue) // Asignar categoría
                };

                // Guardar en la base de datos
                mapeador.Servicios.InsertOnSubmit(servicio);
                mapeador.SubmitChanges();

                // Mensaje de éxito
                lblMensaje.Text = "Servicio guardado con éxito.";
                Response.Redirect("MostrarServicios.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error al guardar el servicio: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

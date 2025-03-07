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

		}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();

            DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

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


            Servicios servicio = new Servicios {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text),
                DuracionMinutos = Convert.ToInt32(txtDuracion.Text),
                Estado = CheckBox1.Checked
            };

            mapeador.Servicios.InsertOnSubmit(servicio);
            mapeador.SubmitChanges();


            // Mensaje de éxito
            lblMensaje.Text = "Servicio guardado con éxito.";
            Response.Redirect("MostrarServicios.aspx");

        }
    }
}
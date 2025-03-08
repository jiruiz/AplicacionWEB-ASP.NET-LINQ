using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace AplicacionWEB
{
    public partial class ResultadosBusqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Crear conexión a la base de datos
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();

            // Instanciar el contexto DataClasses1DataContext
            DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);
            // Obtener el término de búsqueda desde la URL
            string query = Request.QueryString["q"];

            if (!string.IsNullOrEmpty(query))
            {
                lblQuery.Text = $"Resultados para: \"{query}\""; // Mostrar el término de búsqueda

                // Consulta LINQ para buscar en múltiples columnas
                var resultados = mapeador.Servicios
                    .Where(s => s.Nombre.Contains(query) ||
                                s.Descripcion.Contains(query) ||
                                s.Precio.ToString().Contains(query) ||
                                s.DuracionMinutos.ToString().Contains(query))
                    .Select(s => new
                    {
                        Resultado = $"Nombre: {s.Nombre}, Descripción: {s.Descripcion}"
                    })
                    .ToList();

                // Asignar resultados al Repeater
                RepeaterResultados.DataSource = resultados;
                RepeaterResultados.DataBind();
            }
            else
            {
                lblQuery.Text = "Por favor ingrese un término de búsqueda.";
            }
        }
    }
}

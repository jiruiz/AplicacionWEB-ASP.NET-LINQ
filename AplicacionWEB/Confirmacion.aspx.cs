﻿using System;
using System.Linq;
using System.Data.SqlClient;

namespace AplicacionWEB
{
    public partial class Confirmacion : System.Web.UI.Page
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
                CargarDatosConfirmacion();
            }
        }

        private void CargarDatosConfirmacion()
        {
            try
            {
                int idTurno = Session["IdTurnoConfirmado"] != null ? Convert.ToInt32(Session["IdTurnoConfirmado"]) : 0;

                if (idTurno == 0)
                {
                    MostrarError("❌ No se encontró un turno confirmado.");
                    return;
                }

                var serviciosConfirmados = (from ts in mapeador.TurnosServicios
                                            join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                                            where ts.IdTurno == idTurno
                                            group ts by new { ts.IdServicio, s.Nombre, s.Precio } into g
                                            select new
                                            {
                                                IdServicio = g.Key.IdServicio,
                                                NombreServicio = g.Key.Nombre,
                                                Precio = g.Key.Precio,
                                                Cantidad = g.Count(),
                                                Total = g.Count() * g.Key.Precio
                                            }).ToList();

                // Calcular el importe total
                decimal importeTotal = serviciosConfirmados.Sum(sc => sc.Total);
                ViewState["ImporteTotal"] = importeTotal.ToString("N2");

                RepeaterServiciosConfirmados.DataSource = serviciosConfirmados;
                RepeaterServiciosConfirmados.DataBind();
            }
            catch (Exception ex)
            {
                MostrarError($"❌ Error al cargar los datos: {ex.Message}");
            }
        }


        protected void Page_Unload(object sender, EventArgs e)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}

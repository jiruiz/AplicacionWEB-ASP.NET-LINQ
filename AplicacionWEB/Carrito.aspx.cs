﻿using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;

namespace AplicacionWEB
{
    public partial class Carrito : System.Web.UI.Page
    {
        private SqlConnection conn;
        private DataClasses1DataContext mapeador;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Configurar la conexión
            conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();
            mapeador = new DataClasses1DataContext(conn);

            if (!IsPostBack)
            {
                CargarServiciosDelCarrito();
            }
        }

        protected void CargarServiciosDelCarrito()
        {
            try
            {
                string usuarioLogueado = Session["UsuarioLogueado"]?.ToString();
                if (string.IsNullOrEmpty(usuarioLogueado))
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                var usuario = mapeador.Usuarios.FirstOrDefault(u => u.Usuario == usuarioLogueado);
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                var servicios = (from ts in mapeador.TurnosServicios
                                 join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                                 where ts.IdUsuario == usuario.IdUsuario && ts.IdTurno == null
                                 group ts by new { ts.IdServicio, s.Nombre, s.Precio } into g
                                 select new
                                 {
                                     IdServicio = g.Key.IdServicio,
                                     NombreServicio = g.Key.Nombre,
                                     Precio = g.Key.Precio,
                                     Cantidad = g.Count(),
                                     Total = g.Count() * g.Key.Precio
                                 }).ToList();

                // Sumar el total de los servicios y guardarlo en ViewState
                decimal importeTotal = servicios.Sum(s => s.Total);
                ViewState["ImporteTotal"] = importeTotal.ToString("N2");


                RepeaterCarrito.DataSource = servicios;
                RepeaterCarrito.DataBind();

                // Buscar los botones dentro del FooterTemplate del Repeater
                if (RepeaterCarrito.Controls.Count > 0)
                {
                    Control footer = RepeaterCarrito.Controls[RepeaterCarrito.Controls.Count - 1]; // Último control es el Footer
                    Button btnConfirmarTurno = footer.FindControl("btnConfirmarTurno") as Button;
                    Button btnVerServicios = footer.FindControl("btnVerServicios") as Button;

                    if (btnConfirmarTurno != null)
                    {
                        btnConfirmarTurno.Visible = servicios.Any();
                    }
                    if (btnVerServicios != null)
                    {
                        btnVerServicios.Visible = !servicios.Any(); // Se muestra solo si el carrito está vacío
                    }
                }


                if (!servicios.Any())
                {
                    MostrarMensaje("No hay servicios en el carrito.", "Blue");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar el carrito: {ex.Message}", "Red");
            }
        }

        protected void VerServicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeVentas.aspx");
        }


        protected void RepeaterCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string usuarioLogueado = Session["UsuarioLogueado"]?.ToString();
            if (string.IsNullOrEmpty(usuarioLogueado))
            {
                Response.Redirect("Login.aspx");
                return;
            }

            var usuario = mapeador.Usuarios.FirstOrDefault(u => u.Usuario == usuarioLogueado);
            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int idServicio;
            if (!int.TryParse(e.CommandArgument.ToString().Split(':')[0], out idServicio))
            {
                MostrarMensaje("⚠️ El ID del servicio no es válido.", "Red");
                return;
            }

            if (e.CommandName == "Eliminar")
            {
                var serviciosAEliminar = mapeador.TurnosServicios
                    .Where(ts => ts.IdUsuario == usuario.IdUsuario && ts.IdServicio == idServicio && ts.IdTurno == null)
                    .ToList();

                if (serviciosAEliminar.Any())
                {
                    mapeador.TurnosServicios.DeleteAllOnSubmit(serviciosAEliminar);
                    mapeador.SubmitChanges();
                    MostrarMensaje("✅ Servicio eliminado del carrito.", "Green");
                }
                else
                {
                    MostrarMensaje("⚠️ No se encontró el servicio en el carrito.", "Red");
                }
            }
            else if (e.CommandName == "ModificarCantidad")
            {
                string accion = e.CommandArgument.ToString().Split(':')[1];

                if (accion == "incrementar")
                {
                    TurnosServicios nuevo = new TurnosServicios
                    {
                        IdUsuario = usuario.IdUsuario,
                        IdServicio = idServicio,
                        IdTurno = null
                    };

                    mapeador.TurnosServicios.InsertOnSubmit(nuevo);
                    mapeador.SubmitChanges();
                    MostrarMensaje("✅ Cantidad incrementada.", "Green");
                }
                else if (accion == "decrementar")
                {
                    var servicio = mapeador.TurnosServicios
                        .Where(ts => ts.IdUsuario == usuario.IdUsuario && ts.IdServicio == idServicio && ts.IdTurno == null)
                        .FirstOrDefault();

                    if (servicio != null)
                    {
                        mapeador.TurnosServicios.DeleteOnSubmit(servicio);
                        mapeador.SubmitChanges();
                        MostrarMensaje("✅ Cantidad decrementada.", "Green");
                    }
                    else
                    {
                        MostrarMensaje("⚠️ No se encontró un servicio para eliminar.", "Red");
                    }
                }
            }

            CargarServiciosDelCarrito();
        }

        protected void ConfirmarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                string usuarioLogueado = Session["UsuarioLogueado"]?.ToString();
                if (string.IsNullOrEmpty(usuarioLogueado))
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                var usuario = mapeador.Usuarios.FirstOrDefault(u => u.Usuario == usuarioLogueado);
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                var serviciosEnCarrito = mapeador.TurnosServicios
                    .Where(ts => ts.IdUsuario == usuario.IdUsuario && ts.IdTurno == null).ToList();

                if (!serviciosEnCarrito.Any())
                {
                    MostrarMensaje("No hay servicios en el carrito para confirmar.", "Red");
                    return;
                }

                Turnos nuevoTurno = new Turnos
                {
                    IdUsuario = usuario.IdUsuario,
                    FechaTurno = DateTime.Now,
                    Estado = "Pendiente"
                };

                mapeador.Turnos.InsertOnSubmit(nuevoTurno);
                mapeador.SubmitChanges();

                foreach (var servicio in serviciosEnCarrito)
                {
                    servicio.IdTurno = nuevoTurno.IdTurno;
                }

                mapeador.SubmitChanges();

                nuevoTurno.ImporteTotal = (from ts in mapeador.TurnosServicios
                                           join s in mapeador.Servicios on ts.IdServicio equals s.IdServicio
                                           where ts.IdTurno == nuevoTurno.IdTurno
                                           select s.Precio).Sum();

                mapeador.SubmitChanges();

                Session["IdTurnoConfirmado"] = nuevoTurno.IdTurno;
                Response.Redirect("Confirmacion.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al confirmar el turno: {ex.Message}", "Red");
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        protected void MostrarMensaje(string mensaje, string color)
        {
            MensajeLabel.Text = mensaje;
            MensajeLabel.ForeColor = System.Drawing.Color.FromName(color);
            MensajeLabel.Visible = true;
            UpdatePanelMensajes.Update();
        }
    }
}

﻿using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWEB
{
    public partial class MostrarServicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario está logueado
            if (Session["UsuarioLogueado"] == null)
            {
                // Si no está logueado, redirigir al login
                Response.Redirect("Login.aspx");
                return;
            }

            // Obtener el usuario logueado desde la sesión
            string usuarioLogueado = Session["UsuarioLogueado"].ToString();

            // Crear conexión a la base de datos
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C9H0QQO\\SQLEXPRESS;Initial Catalog=templateDB;Integrated Security=True;");
            conn.Open();

            DataClasses1DataContext mapeador = new DataClasses1DataContext(conn);

            // Consulta LINQ para verificar el rol del usuario
            var usuario = mapeador.Usuarios
                                  .Where(u => u.Usuario == usuarioLogueado)
                                  .Select(u => new { u.Rol })
                                  .FirstOrDefault();

            if (usuario == null || usuario.Rol != "Admin")
            {
                // Si el usuario no es administrador, redirigir o mostrar un mensaje
                Response.Redirect("AccesoDenegado.aspx");
                return;
            }
            else
            {
                // Continuar con la carga de los datos
                var servicios = from s in mapeador.Servicios
                                join c in mapeador.Categorias on s.IdCategoria equals c.IdCategoria into categorias
                                from cat in categorias.DefaultIfEmpty() // Maneja casos sin categoría
                                select new
                                {
                                    s.Nombre,
                                    s.Descripcion,
                                    s.Precio,
                                    s.DuracionMinutos,
                                    s.Estado,
                                    Categoria = cat != null ? cat.Nombre : "Sin Categoría" // Muestra "Sin Categoría" si no hay relación
                                };

                // Asignamos los datos al GridView
                GridView1.DataSource = servicios.ToList(); // Convertir a lista para asignar al GridView
                GridView1.DataBind();

                // Asignamos los datos al Repeater
                Repeater1.DataSource = servicios.ToList(); // Convertir a lista para asignar al Repeater
                Repeater1.DataBind();

                // Asignamos los datos al ListView
                ListView1.DataSource = servicios.ToList();
                ListView1.DataBind();

                //// DROPDOWNLIST ////
                // Crea la consulta LINQ para obtener los servicios
                ddlServicios.DataSource = from p in mapeador.Servicios // Consulta LINQ a la tabla "Servicios" en el contexto LINQ
                                          where p.Estado == true // Filtra solo los servicios activos
                                          select new
                                          {
                                              p.Nombre,          // Incluimos el campo "Nombre" para mostrarlo en el DropDownList
                                              IdServicio = 0    // Establecemos un valor "dummy" (0) para "IdServicio" solo como prueba
                                          };

                // Configuramos el campo que se mostrará en el DropDownList
                ddlServicios.DataTextField = "Nombre"; // Indicamos que el campo "Nombre" será el texto visible en las opciones

                // Configuramos el valor asociado a cada opción del DropDownList
                ddlServicios.DataValueField = "IdServicio"; // Indicamos que "IdServicio" será el valor interno que identificará cada opción

                // Enlazamos los datos al control DropDownList para que procese la fuente de datos y genere las opciones
                ddlServicios.DataBind();

                // Agregamos manualmente una opción al inicio del DropDownList
                ddlServicios.Items.Insert(0, new ListItem("Seleccione un servicio", ""));
                // Esta opción tiene como texto "Seleccione un servicio" y un valor vacío ("")
                // Es útil para guiar al usuario o como opción predeterminada
                //// FIN DEL DROPDOWNLIST ////

                // Obtenemos los datos de la tabla Servicios
                var listaServicios = mapeador.Servicios
                    .Select(p => new
                    {
                        p.Nombre,
                        p.Descripcion,
                        p.Precio,
                        p.DuracionMinutos,
                        Estado = p.Estado ? "Activo" : "Inactivo"
                    }).ToList();

                // Creamos una fila de encabezado para la tabla
                TableHeaderRow encabezado = new TableHeaderRow();

                encabezado.Cells.Add(new TableHeaderCell { Text = "Nombre" });
                encabezado.Cells.Add(new TableHeaderCell { Text = "Descripción" });
                encabezado.Cells.Add(new TableHeaderCell { Text = "Precio" });
                encabezado.Cells.Add(new TableHeaderCell { Text = "Duración" });
                encabezado.Cells.Add(new TableHeaderCell { Text = "Estado" });

                // Agregamos la fila de encabezado al control asp:Table
                ServiciosTable.Rows.Add(encabezado);

                // Recorremos los servicios y creamos una fila para cada servicio
                foreach (var servicio in listaServicios)
                {
                    TableRow fila = new TableRow();

                    // Crear celdas dinámicamente y agregar datos
                    fila.Cells.Add(new TableCell { Text = servicio.Nombre });
                    fila.Cells.Add(new TableCell { Text = servicio.Descripcion });
                    fila.Cells.Add(new TableCell { Text = servicio.Precio.ToString("C") }); // Formato de moneda
                    fila.Cells.Add(new TableCell { Text = servicio.DuracionMinutos + " minutos" });
                    fila.Cells.Add(new TableCell { Text = servicio.Estado });

                    // Agregar la fila al asp:Table
                    ServiciosTable.Rows.Add(fila);
                }

                //// LISTBOX ////
                // Obtenemos los datos de la tabla Servicios
                var serviciosListBox = mapeador.Servicios
                    .Select(p => new
                    {
                        IdServicio = 0, // Valor temporal para depurar
                        p.Nombre
                    }).ToList();

                // Vinculamos los datos al ListBox
                ServiciosListBox.DataSource = serviciosListBox;
                ServiciosListBox.DataTextField = "Nombre"; // Campo que se muestra
                ServiciosListBox.DataValueField = "IdServicio"; // Valor interno asociado
                ServiciosListBox.DataBind();
                //// FIN LISTBOX ////

                // Mostrar un servicio destacado en los labels
                var servicioEnLabel = (from a in mapeador.Servicios
                                       select new
                                       {
                                           a.Nombre,
                                           a.Descripcion,
                                           a.Precio,
                                           a.DuracionMinutos,
                                           a.Estado
                                       }).FirstOrDefault();

                if (servicioEnLabel != null)
                {
                    labelNombre.Text = servicioEnLabel.Nombre;
                    labelDescripcion.Text = servicioEnLabel.Descripcion;
                    labelPrecio.Text = servicioEnLabel.Precio.ToString("C");
                    labelDuracion.Text = servicioEnLabel.DuracionMinutos + " minutos";
                    labelEstado.Text = servicioEnLabel.Estado ? "Activo" : "Inactivo";
                }

                // Mostrar datos como tabla HTML
                string html = "<table border='1'><tr><th>Nombre</th><th>Descripción</th><th>Precio</th><th>Duración</th><th>Estado</th></tr>";

                foreach (var servicio in servicios)
                {
                    html += "<tr><td>" + servicio.Nombre + "</td><td>" + servicio.Descripcion + "</td><td>" + servicio.Precio.ToString("C") + "</td><td>" + servicio.DuracionMinutos + "</td><td>" + (servicio.Estado ? "Activo" : "Inactivo") + "</td></tr>";
                }

                html += "</table>";
                tableContainer.InnerHtml = html;

                // Cerrar conexión
                conn.Close();

            }

                
        }
    }
}

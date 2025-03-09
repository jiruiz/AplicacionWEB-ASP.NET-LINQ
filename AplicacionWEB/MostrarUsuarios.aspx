<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="MostrarUsuarios.aspx.cs" Inherits="AplicacionWEB.MostrarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mostrar Usuarios</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Listado de Usuarios</h2>

        <!-- Mensaje de error o éxito -->
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-success"></asp:Label>

        <!-- Repeater para mostrar usuarios -->
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="repeaterUsuarios" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <div class="card-body">
                                <h5 class="card-title"><strong>Usuario:</strong> <%# Eval("Usuario") %></h5>
                                <h6 class="card-subtitle mb-2 text-muted">
                                    <strong>ID:</strong> <%# Eval("IdUsuario") %><br />
                                    <strong>Nombre:</strong> <%# Eval("Nombre") %> <%# Eval("Apellido") %>
                                </h6>
                                <p class="card-text"><strong>Email:</strong> <%# Eval("Email") %></p>
                                <p class="card-text"><strong>Rol:</strong> <%# Eval("Rol") %></p>
                                <p class="card-text">
                                    <strong>Activo:</strong> <%# Convert.ToBoolean(Eval("Activo")) ? "Sí" : "No" %>
                                </p>
                            </div>
                            <div class="card-footer">
                                <small class="text-muted">Registrado el <%# string.Format("{0:dd/MM/yyyy}", Eval("FechaRegistro")) %></small>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
</asp:Repeater>

        </div>
    </div>
</asp:Content>

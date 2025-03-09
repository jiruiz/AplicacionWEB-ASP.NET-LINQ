<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="MostrarCategorias.aspx.cs" Inherits="AplicacionWEB.MostrarCategorias" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mostrar Categorías</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="mb-4">Listado de Categorías</h2>

            <!-- Mensaje de éxito o error -->
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-success"></asp:Label>

            <!-- Repeater para mostrar las categorías -->
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater ID="repeaterCategorias" runat="server">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card h-100">
                                <div class="card-body">
                                    <h5 class="card-title">ID: <%# Eval("IdCategoria") %></h5>
                                    <h6 class="card-subtitle mb-2 text-primary">Nombre: <%# Eval("Nombre") %></h6>
                                    <p class="card-text">Descripción: <%# Eval("Descripcion") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</asp:Content>
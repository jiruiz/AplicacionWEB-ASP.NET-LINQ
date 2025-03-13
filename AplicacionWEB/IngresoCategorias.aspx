<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="IngresoCategorias.aspx.cs" Inherits="AplicacionWEB.IngresoCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ingreso de Categorías</title>
    <!-- Agregar jQuery para evitar errores de validación unobtrusive -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <!-- Agregar Bootstrap para estilos mejorados -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <form id="form1" runat="server">
    
    <div class="container mt-5">
        <div class="card shadow-lg">
            <div class="card-header bg-primary text-white text-center">
                <h2>Ingreso de Categorías</h2>
            </div>
            <div class="card-body">
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-success d-block mb-3"></asp:Label>

                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre de la Categoría</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Ingrese el nombre"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción de la Categoría</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Ingrese la descripción"></asp:TextBox>
                </div>

                <div class="text-center">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary px-4" Text="Guardar" OnClick="btnGuardar_Click" />
                    <asp:HyperLink NavigateUrl="MostrarCategorias.aspx" Text="Volver" runat="server" CssClass="btn btn-secondary ms-3" />
                </div>
            </div>
        </div>
    </div>
                </form>
</asp:Content>

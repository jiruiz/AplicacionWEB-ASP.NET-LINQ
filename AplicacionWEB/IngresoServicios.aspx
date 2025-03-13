<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoServicios.aspx.cs" Inherits="AplicacionWEB.IngresoServicios" MasterPageFile="~/SiteHome.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <h2>Ingreso de Servicios</h2>
            </div>
            <div class="card-body">
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger d-block mb-3"></asp:Label>

                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Ingrese el nombre"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Ingrese la descripción"></asp:TextBox>
                </div>

                <div class="mb-3 row">
                    <div class="col-md-6">
                        <label for="txtPrecio" class="form-label">Precio</label>
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Placeholder="Ingrese el precio"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label for="txtDuracion" class="form-label">Duración (minutos)</label>
                        <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control" Placeholder="Ingrese la duración"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="ddlCategoria" class="form-label">Categoría</label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </div>

                <div class="mb-3 form-check">
                    <asp:CheckBox ID="CheckBox1" runat="server" CssClass="form-check-input" />
                    <label for="CheckBox1" class="form-check-label">Estado Activo</label>
                </div>

                <div class="text-center">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success px-4" Text="Guardar" />
                    <asp:HyperLink NavigateUrl="MostrarServicios.aspx" Text="Volver" runat="server" CssClass="btn btn-secondary ms-3" />
                </div>
            </div>
        </div>
    </div>
            </form>
</asp:Content>


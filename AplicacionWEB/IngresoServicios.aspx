<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoServicios.aspx.cs" Inherits="AplicacionWEB.IngresoServicios" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar contenido para el encabezado, si lo necesitas -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="form1" runat="server">

    <div class="container mt-4">
        <h2 class="mb-4">Ingreso de Servicios</h2>

        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>

        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Ingrese el nombre"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtDescripcion" class="form-label">Descripción</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Ingrese la descripción"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtPrecio" class="form-label">Precio</label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Placeholder="Ingrese el precio"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtDuracion" class="form-label">Duración</label>
            <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control" Placeholder="Ingrese la duración"></asp:TextBox>
        </div>

        <div class="mb-3 form-check">
            <asp:CheckBox ID="CheckBox1" runat="server" CssClass="form-check-input" />
            <label for="CheckBox1" class="form-check-label">Estado</label>
        </div>

        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
    </div>
            </form>
</asp:Content>

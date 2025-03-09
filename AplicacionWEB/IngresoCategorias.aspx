<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/SiteHome.Master"  CodeBehind="IngresoCategorias.aspx.cs" Inherits="AplicacionWEB.IngresoCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ingreso de Categorías</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="mb-4">Ingreso de Categorías</h2>

            <!-- Mensaje de error o éxito -->
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-success"></asp:Label>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre de la Categoría</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Ingrese el nombre"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción de la Categoría</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Ingrese la descripción"></asp:TextBox>
            </div>

            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </form>
</asp:Content>
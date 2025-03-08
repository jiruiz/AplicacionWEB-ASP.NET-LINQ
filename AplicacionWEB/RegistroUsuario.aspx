<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="RegistroUsuario.aspx.cs" Inherits="AplicacionWEB.RegistroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro de Usuario</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center">Registro de Usuario</h2>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtNombre" Text="Nombre:" runat="server"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtApellido" Text="Apellido:" runat="server"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtTelefono" Text="Teléfono:" runat="server"></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtEmail" Text="Correo Electrónico:" runat="server"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtUsuario" Text="Nombre de Usuario:" runat="server"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtContrasena" Text="Contraseña:" runat="server"></asp:Label>
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtFechaNacimiento" Text="Fecha de Nacimiento (opcional):" runat="server"></asp:Label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="text-center">
                <asp:Button ID="btnGuardar" runat="server" Text="Registrar Usuario" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </form>
</asp:Content>

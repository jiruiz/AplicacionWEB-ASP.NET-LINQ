<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Login.aspx.cs" Inherits="AplicacionWEB.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilo para el botón de iniciar sesión */
        .btn-primary {
            background: linear-gradient(to right, #007bff, #6610f2);
            border-color: #0056b3; /* Azul oscuro para el borde */
            color: indianred; /* Naranja para el texto */
            font-weight: bold;
            padding: 12px 20px;
            border-radius: 5px;
            transition: background-color 0.3s ease;
            width: 100%; /* Hacer que el botón ocupe el 100% del ancho */
        }

        .btn-primary:hover {
            background-color: #0056b3; /* Azul oscuro cuando pasa el ratón */
            color: darkorange; /* Cambiar el color del texto a blanco al pasar el ratón */
        }

    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <h2 class="text-center">Iniciar Sesión</h2>
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                <form runat="server">
                    <div class="mb-3">
                        <asp:Label AssociatedControlID="txtUsuario" Text="Usuario:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label AssociatedControlID="txtPassword" Text="Contraseña:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                    </div>
                </form>

                <!-- Redirigir a Registro -->
                <div class="text-center mt-3">
                    <p>¿No tienes cuenta? 
                        <a href="RegistroUsuario.aspx" class="text-primary">Regístrate aquí</a>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

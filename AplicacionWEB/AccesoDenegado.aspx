<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="AccesoDenegado.aspx.cs" Inherits="AplicacionWEB.AccesoDenegado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center mt-5">
        <h1 class="text-danger">Acceso Denegado</h1>
        <p class="lead">No tienes permiso para acceder a esta página.</p>
        <a href="Home.aspx" class="btn btn-primary mt-3">Volver al Inicio</a>
    </div>
</asp:Content>

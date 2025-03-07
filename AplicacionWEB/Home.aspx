<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Home.aspx.cs" Inherits="AplicacionWEB.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <section class="text-center">
            <h1>Bienvenido a Aplicación Web</h1>
            <p class="lead">Gestiona tus servicios de manera rápida y eficiente.</p>
            <a href="MostrarServicios.aspx" class="btn btn-primary">Ver Servicios</a>
        </section>

        <section class="row mt-5 text-center">
            <div class="col-md-4">
                <h3>Interfaz Intuitiva</h3>
                <p>Todo al alcance de tu mano con facilidad.</p>
            </div>
            <div class="col-md-4">
                <h3>Información Segura</h3>
                <p>Tu tranquilidad es nuestra prioridad.</p>
            </div>
            <div class="col-md-4">
                <h3>Soporte Técnico</h3>
                <p>Siempre disponibles para resolver tus dudas.</p>
            </div>
        </section>
    </div>
</asp:Content>

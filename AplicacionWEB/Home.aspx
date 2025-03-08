<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Home.aspx.cs" Inherits="AplicacionWEB.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <!-- Sección Principal -->
        <section class="text-center mb-5">
            <h1 class="display-4 text-primary">Bienvenido a JR ADMIN</h1>
            <p class="lead">Gestiona tus servicios de manera rápida y eficiente con herramientas diseñadas para ti.</p>
            <a href="HomeVentas.aspx" class="btn btn-outline-primary btn-lg mt-3">Ver Servicios</a>
        </section>

        <!-- Sección de Ventajas -->
        <section class="row text-center">
            <div class="col-md-4">
                <div class="p-4 bg-light shadow-sm rounded">
                    <i class="bi bi-laptop text-primary" style="font-size: 3rem;"></i>
                    <h3 class="mt-3">Interfaz Intuitiva</h3>
                    <p>Todo al alcance de tu mano con facilidad y rapidez.</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="p-4 bg-light shadow-sm rounded">
                    <i class="bi bi-shield-lock text-success" style="font-size: 3rem;"></i>
                    <h3 class="mt-3">Información Segura</h3>
                    <p>Tu tranquilidad y privacidad son nuestra prioridad.</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="p-4 bg-light shadow-sm rounded">
                    <i class="bi bi-headset text-warning" style="font-size: 3rem;"></i>
                    <h3 class="mt-3">Soporte Técnico</h3>
                    <p>Estamos siempre disponibles para resolver tus dudas.</p>
                </div>
            </div>
        </section>
    </div>
</asp:Content>


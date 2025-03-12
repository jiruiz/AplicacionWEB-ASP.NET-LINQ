<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="Home.aspx.cs" Inherits="AplicacionWEB.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hero-section {
            background: linear-gradient(to right, #007bff, #6610f2);
            color: white;
            padding: 80px 20px;
            border-radius: 10px;
            box-shadow: 0px 5px 15px rgba(0, 0, 0, 0.2);
            margin-bottom: 60px;
        }

        .feature-card {
            transition: transform 0.3s ease, box-shadow 0.3s ease;
            padding: 30px;
        }

        .feature-card:hover {
            transform: translateY(-5px);
            box-shadow: 0px 10px 20px rgba(0, 0, 0, 0.2);
        }

        .benefits-section {
            background: #007bff;
            color: white;
            padding: 50px;
            border-radius: 10px;
            box-shadow: 0px 5px 15px rgba(0, 0, 0, 0.2);
            margin-top: 60px;
        }

        .icon-lg {
            font-size: 3rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        
        <!-- Sección Principal (Hero) -->
        <section class="hero-section text-center">
            <h1 class="display-4 fw-bold">Bienvenido a <span class="text-warning">JR ADMIN</span></h1>
            <p class="lead">Gestiona tus servicios de manera rápida y eficiente con herramientas diseñadas para ti.</p>
            <a href="HomeVentas.aspx" class="btn btn-light btn-lg mt-3 shadow">🔍 Explorar Servicios</a>
        </section>

        <!-- Sección de Ventajas -->
        <section class="row text-center">
            <div class="col-md-4 mb-4">
                <div class="p-4 bg-light shadow-sm rounded feature-card">
                    <i class="bi bi-laptop text-primary icon-lg"></i>
                    <h3 class="mt-3">Interfaz Intuitiva</h3>
                    <p>Todo al alcance de tu mano con facilidad y rapidez.</p>
                </div>
            </div>
            <div class="col-md-4 mb-4">
                <div class="p-4 bg-light shadow-sm rounded feature-card">
                    <i class="bi bi-shield-lock text-success icon-lg"></i>
                    <h3 class="mt-3">Información Segura</h3>
                    <p>Tu tranquilidad y privacidad son nuestra prioridad.</p>
                </div>
            </div>
            <div class="col-md-4 mb-4">
                <div class="p-4 bg-light shadow-sm rounded feature-card">
                    <i class="bi bi-headset text-warning icon-lg"></i>
                    <h3 class="mt-3">Soporte Técnico</h3>
                    <p>Estamos siempre disponibles para resolver tus dudas.</p>
                </div>
            </div>
        </section>

        <!-- Nueva Sección de Beneficios -->
        <section class="benefits-section text-center">
            <h2 class="fw-bold">¿Por qué elegir JR ADMIN?</h2>
            <div class="row mt-4">
                <div class="col-md-4">
                    <h3>📈 +500</h3>
                    <p>Clientes satisfechos</p>
                </div>
                <div class="col-md-4">
                    <h3>⏳ 24/7</h3>
                    <p>Soporte siempre disponible</p>
                </div>
                <div class="col-md-4">
                    <h3>🔒 100%</h3>
                    <p>Seguridad garantizada</p>
                </div>
            </div>
        </section>
        
    </div>
</asp:Content>

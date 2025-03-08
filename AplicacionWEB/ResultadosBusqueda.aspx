
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="ResultadosBusqueda.aspx.cs" Inherits="AplicacionWEB.ResultadosBusqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Resultados de Búsqueda</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h1 class="text-center text-primary">Resultados de la Búsqueda</h1>
        <p class="text-center">Resultados para: <strong><asp:Label ID="lblQuery" runat="server"></asp:Label></strong></p>

        <div class="list-group mt-4">
            <asp:Repeater ID="RepeaterResultados" runat="server">
                <ItemTemplate>
                    <a href="#" class="list-group-item list-group-item-action">
                        <%# Eval("Resultado") %>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>


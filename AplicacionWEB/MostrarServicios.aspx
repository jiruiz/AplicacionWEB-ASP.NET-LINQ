<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.Master" CodeBehind="MostrarServicios.aspx.cs" Inherits="AplicacionWEB.MostrarServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <form id="form1" runat="server">

        <div>
            <asp:ListBox ID="ServiciosListBox" runat="server"></asp:ListBox>
           <asp:DropDownList ID="ddlServicios" runat="server" CssClass="form-control"></asp:DropDownList>

            <asp:Table ID="ServiciosTable" runat="server"></asp:Table>



            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div>
                        <strong>Nombre:</strong> <%# Eval("Nombre") %><br />
                        <strong>Descripción:</strong> <%# Eval("Descripcion") %><br />
                        <strong>Precio:</strong> <%# Eval("Precio", "{0:C}") %><br />
                        <strong>Duración:</strong> <%# Eval("DuracionMinutos") %> minutos<br />
                        <strong>Estado:</strong> <%# Eval("Estado") %><br /><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            <asp:ListView ID="ListView1" runat="server">

                <ItemTemplate>
                    <div>
                        <strong>Nombre:</strong> <%# Eval("Nombre") %><br />
                        <strong>Descripción:</strong> <%# Eval("Descripcion") %><br />
                        <strong>Precio:</strong> <%# Eval("Precio", "{0:C}") %><br />
                        <strong>Duración:</strong> <%# Eval("DuracionMinutos") %> minutos<br />
                        <strong>Estado:</strong> <%# Eval("Estado") %><br /><br />
                    </div>
                </ItemTemplate>
                <LayoutTemplate>
                    <div>
                        <h2>Servicios</h2>
                        <hr />
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </div>
                </LayoutTemplate>

            </asp:ListView>

            <asp:Label ID="labelNombre" runat="server" Text="Nombre:"></asp:Label><br />
            <asp:Label ID="labelDescripcion" runat="server" Text="Descripción:"></asp:Label><br />
            <asp:Label ID="labelPrecio" runat="server" Text="Precio:"></asp:Label><br />
            <asp:Label ID="labelDuracion" runat="server" Text="Duración:"></asp:Label><br />
            <asp:Label ID="labelEstado" runat="server" Text="Estado:"></asp:Label><br />

            <div id="tableContainer" runat="server"></div>


        </div>
                </form>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="ModificarUsuarios.aspx.cs" Inherits="AplicacionWEB.ModificarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Modificar Usuarios</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <h1>Listado de Usuarios</h1>

            <!-- GridView para editar y eliminar usuarios -->
            <asp:GridView CssClass="table table-striped" ID="grillaUsuarios" runat="server" 
                AutoGenerateColumns="False" DataKeyNames="IdUsuario"
                OnRowEditing="grillaUsuarios_RowEditing"
                OnRowUpdating="grillaUsuarios_RowUpdating"
                OnRowCancelingEdit="grillaUsuarios_RowCancelingEdit"
                OnRowDeleting="grillaUsuarios_RowDeleting">

                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="labelID" runat="server" Text='<%# Bind("IdUsuario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Usuario">
                        <ItemTemplate>
                            <asp:Label ID="labelUsuario" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>




                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="labelNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellido">
                        <ItemTemplate>
                            <asp:Label ID="labelApellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="labelEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Rol">
                        <ItemTemplate>
                            <asp:Label ID="labelRol" runat="server" Text='<%# Bind("Rol") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlRol" runat="server">
                                <asp:ListItem Value="" Text="Seleccione un rol"></asp:ListItem>
                                <asp:ListItem Value="Admin" Text="Admin"></asp:ListItem>
                                <asp:ListItem Value="Usuario" Text="Usuario"></asp:ListItem>
                                <asp:ListItem Value="Supervisor" Text="Supervisor"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Contraseña">
                        <ItemTemplate>
                            <asp:Label ID="labelContrasena" runat="server" Text="********"></asp:Label> <!-- Siempre muestra asteriscos -->
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" Placeholder="Nueva contraseña"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Activo">
                        <ItemTemplate>
                            <asp:Label ID="labelActivo" runat="server" Text='<%# (Convert.ToBoolean(Eval("Activo")) ? "Sí" : "No") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkActivo" runat="server" Checked='<%# Bind("Activo") %>'></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ButtonType="Link" ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
        </div>
    </form>
</asp:Content>

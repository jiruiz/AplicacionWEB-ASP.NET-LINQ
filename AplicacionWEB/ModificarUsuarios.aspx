<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="ModificarUsuarios.aspx.cs" Inherits="AplicacionWEB.ModificarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Modificar Usuarios</title>
    <style>
     .container {
         max-width: 900px;
         margin-top: 40px;
     }
     h1 {
         color: #007bff;
         text-align: center;
         margin-bottom: 20px;
     }
     .table {
         border: 1px solid #dee2e6; /* Borde exterior */
         border-radius: 10px; /* Bordes redondeados, opcional */
         overflow: hidden; /* Evita que elementos sobresalgan */
         box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1); /* Sombra para destacar */
     }

     .table-responsive {
         overflow-x: auto;
     }
     .btn-primary {
         background-color: #007bff;
         border: none;
     }
     .btn-primary:hover {
         background-color: #0056b3;
     }
     .btn-danger {
         background-color: #dc3545;
         border: none;
     }
     .btn-danger:hover {
         background-color: #a71d2a;
     }
     .form-control {
         border-radius: 5px;
     }
 </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

    <div class="container">
        <h1>Gestión de Usuarios</h1>
        <div class="table-responsive">
            <asp:GridView CssClass="table table-hover table-bordered" ID="grillaUsuarios" runat="server"
                AutoGenerateColumns="False" DataKeyNames="IdUsuario"
                OnRowEditing="grillaUsuarios_RowEditing"
                OnRowUpdating="grillaUsuarios_RowUpdating"
                OnRowCancelingEdit="grillaUsuarios_RowCancelingEdit"
                OnRowDeleting="grillaUsuarios_RowDeleting">
                
                <Columns>
                    <asp:BoundField DataField="IdUsuario" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" ReadOnly="True" />
                    
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="labelNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Apellido">
                        <ItemTemplate>
                            <asp:Label ID="labelApellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="labelEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Text='<%# Bind("Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Rol">
                        <ItemTemplate>
                            <asp:Label ID="labelRol" runat="server" Text='<%# Bind("Rol") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                                <asp:ListItem Value="Admin" Text="Admin"></asp:ListItem>
                                <asp:ListItem Value="Usuario" Text="Usuario"></asp:ListItem>
                                <asp:ListItem Value="Supervisor" Text="Supervisor"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Activo">
                        <ItemTemplate>
                            <asp:Label ID="labelActivo" runat="server" Text='<%# (Convert.ToBoolean(Eval("Activo")) ? "Sí" : "No") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkActivo" runat="server" Checked='<%# Bind("Activo") %>' CssClass="form-check-input"></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <div class="btn-group" role="group">
                                <asp:LinkButton ID="btnEditar" runat="server" CommandName="Edit" CssClass="btn btn-primary btn-sm">
                                    ✏️ Editar
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Delete" CssClass="btn btn-danger btn-sm">
                                    ❌ Eliminar
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div class="btn-group" role="group">
                                <asp:LinkButton ID="btnGuardar" runat="server" CommandName="Update" CssClass="btn btn-success btn-sm">
                                    ✅ Guardar
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancelar" runat="server" CommandName="Cancel" CssClass="btn btn-secondary btn-sm">
                                    ❌ Cancelar
                                </asp:LinkButton>
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
    </div>
        </form>
</asp:Content>

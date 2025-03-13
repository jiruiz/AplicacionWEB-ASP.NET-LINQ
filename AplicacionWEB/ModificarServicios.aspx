<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="ModificarServicios.aspx.cs" Inherits="AplicacionWEB.ModificarServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
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
    <div class="container">
        <h1>Listado de Servicios</h1>
        <form id="form1" runat="server">
            <div class="table-responsive">
                <asp:GridView CssClass="table table-hover table-bordered" ID="grillaServicios" runat="server"  
                    AutoGenerateColumns="False" DataKeyNames="IdServicio"
                    OnRowEditing="grillaServicios_RowEditing"
                    OnRowUpdating="grillaServicios_RowUpdating"
                    OnRowCancelingEdit="grillaServicios_RowCancelingEdit"
                    OnRowDeleting="grillaServicios_RowDeleting">
                    
                    <Columns>
                        <asp:BoundField DataField="IdServicio" HeaderText="ID" ReadOnly="True" />

                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="labelNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Descripción">
                            <ItemTemplate>
                                <asp:Label ID="labelDescripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label ID="labelPrecio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Text='<%# Bind("Precio") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Duración (Min)">
                            <ItemTemplate>
                                <asp:Label ID="labelDuracionMinutos" runat="server" Text='<%# Bind("DuracionMinutos") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control" Text='<%# Bind("DuracionMinutos") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Label ID="labelEstado" runat="server" 
                                    Text='<%# (Convert.ToBoolean(Eval("Estado")) ? "Activo" : "Inactivo") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkEstado" runat="server" CssClass="form-check-input" Checked='<%# Bind("Estado") %>'></asp:CheckBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Categoría">
                            <ItemTemplate>
                                <asp:Label ID="labelCategoria" runat="server" Text='<%# Bind("CategoriaNombre") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <div class="btn-group">
                                    <asp:LinkButton ID="btnEditar" runat="server" CommandName="Edit" CssClass="btn btn-primary btn-sm">
                                        ✏️ Editar
                                    </asp:LinkButton>
                                    
                                    <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Delete" CssClass="btn btn-danger btn-sm">
                                        ❌ Eliminar
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <div class="btn-group">
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

            <div class="mt-3">
                <asp:HyperLink NavigateUrl="MostrarServicios.aspx" CssClass="btn btn-outline-primary" Text="🔙 Volver a Servicios" runat="server" />
            </div>

        </form>
    </div>
</asp:Content>

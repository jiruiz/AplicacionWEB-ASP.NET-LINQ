<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeBehind="ModificarServicios.aspx.cs" Inherits="AplicacionWEB.ModificarServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div class="container">
            <h1>Listado de Servicios</h1>
            <asp:GridView CssClass="table table-striped" ID="grillaServicios" runat="server"  
                AutoGenerateColumns="False" DataKeyNames="IdServicio"
                OnRowEditing="grillaServicios_RowEditing"
                OnRowUpdating="grillaServicios_RowUpdating"
                OnRowCancelingEdit="grillaServicios_RowCancelingEdit"
                OnRowDeleting="grillaServicios_RowDeleting">

                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="labelID" runat="server" Text='<%# Bind("IdServicio") %>'></asp:Label>
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

                    <asp:TemplateField HeaderText="Descripción">
                        <ItemTemplate>
                            <asp:Label ID="labelDescripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:Label ID="labelPrecio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("Precio") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Duracion Minutos">
                          <ItemTemplate>
                              <asp:Label ID="labelDuracionMinutos" runat="server" Text='<%# Bind("DuracionMinutos") %>'></asp:Label>
                          </ItemTemplate>
                          <EditItemTemplate>
                              <asp:TextBox ID="txtDuracion" runat="server" Text='<%# Bind("DuracionMinutos") %>'></asp:TextBox>
                          </EditItemTemplate>
                      </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Label ID="labelEstado" runat="server" 
                                    Text='<%# (Convert.ToBoolean(Eval("Estado")) ? "Activo" : "Inactivo") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# Bind("Estado") %>'></asp:CheckBox>
                            </EditItemTemplate>
                        </asp:TemplateField>


                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>

            <asp:HyperLink NavigateUrl="MostrarServicios.aspx" Text="Volver a Servicios" runat="server" />
        </div>
    </form>
</asp:Content>

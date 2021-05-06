<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Presentacion.GestionUsuarios.ListaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
    <div class="container">
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
            <ol class="breadcrumb bg-white">
                <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                <li class="breadcrumb-item active" aria-current="page">Administrar Usuarios</li>
            </ol>
        </nav>
        <br />
    </div>
    <asp:SqlDataSource ID="Usuarios" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConexionBD %>"
        SelectCommand="SELECT [IdUsuario],[NombreUsuario], [EmailUsuario] FROM [Usuarios]"></asp:SqlDataSource>
    <div class="container">
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Tipo Usuario</label>
            <label class="col-sm-2 col-form-label ">Buscar Usuario</label>
            <div class="col-sm-10">
                <asp:DropDownList runat="server" ID="ddlTest">
                    <asp:ListItem Text="Docente" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Coordinador" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Sub Director" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Director" Value="4"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button CssClass="btn btn-primary mb-2 boton2" Text="Crea Usuario" runat="server" />
                <asp:TextBox class="form-control box2" ID="TextBox2" runat="server"></asp:TextBox>
            </div>

        </div>
        <br />

        <asp:GridView ID="GvUsuarios" runat="server" AutoGenerateColumns="False" DataSourceID="Usuarios" DataKeyNames="IdUsuario" OnSelectedIndexChanged="GvUsuarios_SelectedIndexChanged" OnRowCommand="GvUsuarios_RowCommand">
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="ID" SortExpression="IdUsuario" Visible="false"/>
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre" SortExpression="NombreUsuario" />
                <asp:BoundField DataField="EmailUsuario" HeaderText="Correo" SortExpression="EmailUsuario" />
                <asp:ButtonField ButtonType="button" HeaderText="Acciones" Text="Editar" CommandName="Details" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnBorrar" CssClass="btn btn-outline-danger" CommandArgument="<%# Container.DataItemIndex%>" CommandName="Borrar" runat="server" Text="Borrar" Width="100" />
                        <asp:Button ID="btnModificar" CssClass="btn btn-outline-warning" CommandName="Modificar" CommandArgument="<%# Container.DataItemIndex%>" runat="server" Text="Modificar" Width="100" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


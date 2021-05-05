<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Presentacion.GestionUsuarios.ListaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
<<<<<<< Updated upstream
    <br />
    <div class="container">
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
            <ol class="breadcrumb bg-white">
                <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                <li class="breadcrumb-item active" aria-current="page">Administrar Usuarios</li>
            </ol>
        </nav>
        <div>
            <asp:TextBox class="form-control box" ID="TextBox1" runat="server"></asp:TextBox>

        </div>
        <br />
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th scope="col">Nombre</th>
                    <th scope="col">Carrera</th>
                    <th scope="col">Accion</th>
                </tr>
            </thead>
        </table>
    </div>

=======

    <asp:SqlDataSource ID="Usuarios" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConexionBD %>"
        SelectCommand="SELECT [IdUsuario],[NombreUsuario], [EmailUsuario] FROM [Usuarios]">
    </asp:SqlDataSource>
<br />
     <div class="form-group row">
       <label class="col-sm-2 col-form-label">Tipo Usuario</label>
       <label class="col-sm-2 col-form-label ">Buscar Usuario</label>
    <div class="col-sm-10" >
            <asp:dropdownlist runat="server" id="ddlTest">
                <asp:listitem text="Docente" value="1"></asp:listitem>
                <asp:listitem text="Coordinador" value="2"></asp:listitem>
                <asp:listitem text="Sub Director" value="3"></asp:listitem>
                <asp:listitem text="Director" value="4"></asp:listitem>
            </asp:dropdownlist> 
        <asp:Button CssClass="btn btn-primary mb-2 boton2" Text="Crea Usuario" runat="server" />
            <asp:TextBox class="form-control box2" ID="TextBox2" runat="server"></asp:TextBox>
    </div>
        
   </div>
    <br />
    <
    <asp:GridView ID="GvUsuarios" runat="server" AutoGenerateColumns="False" DataSourceID="Usuarios" OnSelectedIndexChanged="GvUsuarios_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre" SortExpression="NombreUsuario" />
            <asp:BoundField DataField="EmailUsuario" HeaderText="Correo" SortExpression="EmailUsuario" />
            <asp:buttonfield  buttontype="button" HeaderText="Acciones" Text="Editar" commandname="Details"  />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnBorrar" CssClass="btn btn-outline-danger" CommandArgument="<%# Container.DataItemIndex%>"  CommandName="Borrar" runat="server" Text="Borrar" Width="100"/>
                    <asp:Button ID="btnModificar" CssClass="btn btn-outline-warning"  CommandName="Modificar" CommandArgument="<%# Container.DataItemIndex%>" runat="server" Text="Modificar" Width="100"/>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>
>>>>>>> Stashed changes
</asp:Content>


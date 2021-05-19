<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Presentacion.GestionUsuarios.ListaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <link href="../CSS/CrearUsuarios.css" rel="stylesheet">
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
    <br />
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
                <asp:Button CssClass="btn btn-primary mb-2 boton2" Text="Crea Usuario" runat="server" OnClick="Unnamed1_Click" />
                <asp:TextBox class="form-control box2" ID="TextBox2" runat="server"></asp:TextBox>
            </div>

        </div>
        <br />

        <asp:GridView ID="GvUsuarios" runat="server" CssClass="GridViewStyle"  HeaderStyle-CssClass="HeaderStyle"  AutoGenerateColumns="False" DataSourceID="Usuarios" DataKeyNames="IdUsuario" OnSelectedIndexChanged="GvUsuarios_SelectedIndexChanged" OnRowCommand="GvUsuarios_RowCommand" Width="1245px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre" SortExpression="NombreUsuario" ItemStyle-Width="400px"  >
<ItemStyle Width="400px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="EmailUsuario" HeaderText="Correo" SortExpression="EmailUsuario" ItemStyle-Width="300px" >
<ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="200px" >
                    <ItemTemplate >
                        <asp:LinkButton ID="btnModificar" CssClass="btn LinkButton2 btn-outline-warning"  CommandName="Modificar" CommandArgument="<%# Container.DataItemIndex%>" runat="server" Width="50"  Height="45"></asp:LinkButton>
                        <asp:LinkButton ID="btnBorrar"  CssClass="btn LinkButton btn-outline-danger"   CommandArgument="<%# Container.DataItemIndex%>" CommandName="Borrar" runat="server" Width="50" Height="45"></asp:LinkButton>
                    </ItemTemplate>

<ItemStyle Width="200px"></ItemStyle>
                </asp:TemplateField>
                
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
</asp:Content>
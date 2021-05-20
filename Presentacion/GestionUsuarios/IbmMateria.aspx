<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="IbmMateria.aspx.cs" Inherits="Presentacion.GestionUsuarios.AgregaMateria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
    <div class="container">
         <div class="form-group row">
            <label class="col-sm-2 col-form-label">Nombre de la Materia</label>
            <div class="col-sm-10">
                <asp:Textbox runat="server" ID="tbNombreM" />
            </div>
        </div>
        <br />
        <div>
            <label class="col-sm-2 col-form-label">Clave</label>
            <div class="col-sm-10">
                <asp:Textbox runat="server" ID="tbClave" />
            </div>
        </div>
        <br />
        <div>
            <label class="col-sm-2 col-form-label">Docente(s)</label>
            <div class="col-sm-10">
                <asp:DropDownList runat="server" ID="dlDocentes" DataSourceID="SED" DataTextField="NombreUsuario" DataValueField="NombreUsuario">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SED" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionBD %>" SelectCommand="SELECT [NombreUsuario], [IdUsuario] FROM [Usuarios]"></asp:SqlDataSource>
            </div>
        </div>
        <br />
        <div>
            <label class="col-sm-2 col-form-label">Docente(s)</label>
            <div class="col-sm-10">
                <asp:DropDownList runat="server" ID="dlSemestre">
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
</asp:Content>

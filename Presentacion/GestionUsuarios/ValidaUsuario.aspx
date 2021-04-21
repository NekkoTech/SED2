<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/UsuariosSinLogeo.master" AutoEventWireup="true" CodeBehind="ValidaUsuario.aspx.cs" Inherits="Presentacion.GestionUsuarios.ValidaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CphMainLogin" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Label1" runat="server" Text="Inicio de Sesion"></asp:Label>
        </div>
        <div class="row">
            <asp:TextBox ID="tbEmailUsuario" runat="server" CssClass="input-group-text"></asp:TextBox>
            <br />
            <asp:TextBox ID="tbPassWord" runat="server" CssClass="input-group-text"></asp:TextBox>
            <br />
            <asp:Button ID="BtnLogin" runat="server" CssClass="btn-success rounded" OnClick="Button1_Click" Text="Iniciar Sesión" />
        </div>

        

        <br />
        <asp:LinkButton ID="LBForgot" runat="server" OnClick="LBForgot_Click">Olvidaste tu contraseña?</asp:LinkButton>
        <br />
    </div>
    

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/UsuariosSinLogeo.master" AutoEventWireup="true" CodeBehind="ValidaUsuario.aspx.cs" Inherits="Presentacion.GestionUsuarios.ValidaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CphMainLogin" runat="server">

    <asp:TextBox ID="tbEmailUsuario" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="tbPassWord" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="BtnLogin" runat="server" OnClick="Button1_Click" Text="Button" />

</asp:Content>

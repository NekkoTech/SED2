<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterCoordinadorMenu.Master" AutoEventWireup="true" CodeBehind="InicioCoordinador.aspx.cs" Inherits="Presentacion.GestionUsuarios.InicioCoordinador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
    <br />
    <div class="container">
        <div class="row align-content-center">
            <asp:Label ID="LblMensajeInicio" runat="server" Text="" CssClass="text-center fs-2"></asp:Label>
            <asp:Label ID="LblNombre" runat="server" Text="" CssClass="text-center fs-2"></asp:Label>
        </div>
        
    </div>
</asp:Content>

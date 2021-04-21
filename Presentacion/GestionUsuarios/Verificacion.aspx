<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/UsuariosSinLogeo.master" AutoEventWireup="true" CodeBehind="Verificacion.aspx.cs" Inherits="Presentacion.GestionUsuarios.OlvidaContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CphMainLogin" runat="server">
    <div class="container-sm w-50 card rounded-3 text-center">
        <div class="card-body">
            <div class="card-title">
                <asp:Label ID="LblTitulo" runat="server" Text="Se le envio un codigo de verificacion a su correo"></asp:Label>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Label ID="LblMensaje" runat="server" Text="Ingrese el codigo de verificacion"></asp:Label>
                    <asp:TextBox ID="tbCodigo" placeholder="Codigo" runat="server" CssClass="input-group-text" Width="500px"></asp:TextBox>
                    <br />
                    <asp:Button ID="BtnIngresar" runat="server" CssClass="btn-success rounded" Text="Ingresar" Width="150px" />
                </div>

            </div>
        </div>
</asp:Content>

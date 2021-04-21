<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/UsuariosSinLogeo.master" AutoEventWireup="true" CodeBehind="OlvidaContraseña.aspx.cs" Inherits="Presentacion.GestionUsuarios.OlvidaContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CphMainLogin" runat="server">
    <div class="container-sm w-50 card rounded-3 text-center">
        <div class="card-body">
            <div class="card-title">
                <asp:Label ID="Label1" runat="server" Text="Recuperar Contraseña"></asp:Label>
            </div>
            <div class="row">
                <div class="col">
                    
                    <asp:TextBox ID="tbEmailUsuario" placeholder="Correo" runat="server" CssClass="input-group-text" Width="500px"></asp:TextBox>
                    <br />
                    <asp:Button ID="BtnSolicitar" runat="server" CssClass="btn-success rounded" Text="Solicitar" Width="150px" />
                </div>

            </div>
        </div>
</asp:Content>

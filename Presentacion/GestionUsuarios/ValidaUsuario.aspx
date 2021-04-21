<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/UsuariosSinLogeo.master" AutoEventWireup="true" CodeBehind="ValidaUsuario.aspx.cs" Inherits="Presentacion.GestionUsuarios.ValidaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphMainLogin" runat="server">
    <br />
    <br />
    <div class="container-sm w-50 card rounded-3 text-center">
        <div class="card-body">
            <div class="card-title">
                <asp:Label ID="Label1" runat="server" Text="Inicio de Sesion"></asp:Label>
            </div>
            <div class="row">
                <div class="col">
                    
                    <asp:TextBox ID="tbEmailUsuario" placeholder="Correo" runat="server" CssClass="input-group-text" Width="500px"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="tbPassWord" placeholder="Contraseña" runat="server" CssClass="input-group-text" Width="500px"></asp:TextBox>
                    <br />
                    <asp:Button ID="BtnLogin" runat="server" CssClass="btn-success rounded" OnClick="Button1_Click" Text="Iniciar Sesión" Width="150px" />
                </div>

            </div>

            <br />
            <asp:LinkButton ID="LBForgot" runat="server" OnClick="LBForgot_Click">Olvidaste tu contraseña?</asp:LinkButton>
            <br />
        </div>

    </div>


</asp:Content>

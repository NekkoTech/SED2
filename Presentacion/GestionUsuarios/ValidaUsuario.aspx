<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/UsuariosSinLogeo.master" AutoEventWireup="true" CodeBehind="ValidaUsuario.aspx.cs" Inherits="Presentacion.GestionUsuarios.ValidaUsuario" %>

<%@ Register Src="~/Controles/wuc_Email.ascx" TagPrefix="uc1" TagName="wuc_Email" %>
<%@ Register Src="~/Controles/wuc_PassWord.ascx" TagPrefix="uc1" TagName="wuc_PassWord" %>



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
                    <uc1:wuc_Email runat="server" id="tbEmailUsuario" />
                    <br />
                    <uc1:wuc_PassWord runat="server" id="tbPassWord" />
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

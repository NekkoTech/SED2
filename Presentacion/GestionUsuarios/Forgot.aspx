<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/UsuariosSinLogeo.master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="Presentacion.GestionUsuarios.Forgot" %>

<%@ Register Src="~/Controles/wuc_Email.ascx" TagPrefix="uc1" TagName="wuc_Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphMainLogin" runat="server">
    <br />
    <br />
    <div class="container-sm w-50 card rounded-3 text-center">
        <div class="card-body">
            <div class="card-title">
                <asp:Label ID="Label1" runat="server" Text="Recuperar Contraseña"></asp:Label>
            </div>
            <div class="row">
                <div class="col">
                    <uc1:wuc_Email runat="server" id="tbEmailUsuario" />
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="BtnSolicitar" runat="server" CssClass="btn-success rounded" Text="Solicitar" Width="150px" OnClick="BtnSolicitar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

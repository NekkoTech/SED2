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
                    <uc1:wuc_Email runat="server" CssClas="form-control" id="tbEmailUsuario" />
                    <br />
                    <uc1:wuc_PassWord runat="server" CssClas="form-control" id="tbPassWord" />
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label> <br /><br />
                    <asp:Button ID="BtnLogin" runat="server" CssClass="btn-success rounded" OnClick="Button1_Click" Text="Iniciar Sesión" Width="150px" />
                </div>

            </div>

            <br />
            <asp:LinkButton ID="LBForgot" runat="server" CausesValidation="false" OnClick="LBForgot_Click">Olvidaste tu contraseña?</asp:LinkButton>
            <br />
             <asp:LinkButton ID="LBAlumno" runat="server" CausesValidation="false" OnClick="LBAlumno_Click">Acceso a Alumnos</asp:LinkButton>
            <br />
        </div>

    </div>


</asp:Content>

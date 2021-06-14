<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/UsuariosSinLogeo.master" AutoEventWireup="true" CodeBehind="AccesoAlumnos.aspx.cs" Inherits="Presentacion.GestionUsuarios.AccesoAlumnos" %>
<%@ Register Src="~/Controles/wuc_CodVerificacion.ascx" TagPrefix="uc1" TagName="wuc_CodVerificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CphMainLogin" runat="server">
     <br />
    <br />
    <div class="container-sm w-50 card rounded-3 text-center">
        <div class="card-body">
            <div class="card-title">
                <asp:Label ID="LblTitulo" runat="server" Text="Se le envio un codigo de verificacion a su correo"></asp:Label>
            </div>
            <div class="row">
                <div class="col">
                    <uc1:wuc_CodVerificacion runat="server" id="tbCodigo" /> <br />
                    <asp:Label ID="LblMsg" runat="server" CssClass="text-danger"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="BtnIngresar" runat="server" CssClass="btn-success rounded" Text="Ingresar" Width="150px" OnClick="BtnIngresar_Click" />
                </div>

            </div>
        </div>
</asp:Content>

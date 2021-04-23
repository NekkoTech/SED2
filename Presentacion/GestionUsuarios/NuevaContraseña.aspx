<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/UsuariosSinLogeo.master" AutoEventWireup="true" CodeBehind="NuevaContraseña.aspx.cs" Inherits="Presentacion.GestionUsuarios.NuevaContraseña" %>

<%@ Register Src="~/Controles/wuc_RepPassWord.ascx" TagPrefix="uc1" TagName="wuc_RepPassWord" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CphMainLogin" runat="server">
    <br />
    <br />
    <div class="container-sm w-50 card rounded-3 text-center">
        <div class="card-body">
            <div class="card-title">
                <asp:Label ID="Label1" runat="server" Text="Ingrese su Nueva Contraseña"></asp:Label>
            </div>
            <div class="row">
                <div class="col">
                    <uc1:wuc_RepPassWord runat="server" id="tbNuevaContraseña" />
                    <br />
                    <asp:Button ID="BtnCambiarContra" runat="server" CssClass="btn-success rounded" Text="Cambiar" Width="150px" OnClick="BtnCambiarContra_Click" />
                </div>

            </div>

            <br />
            <br />
        </div>

    </div>


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="ListaPlanEstudio.aspx.cs" Inherits="Presentacion.GestionUsuarios.ListaPlanEstudio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <div class="container">
        <div class="row">
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb bg-white">
                    <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                    <li class="breadcrumb-item">Planes de Estudio</li>
                </ol>
            </nav>
        </div>
        <div class="row text-center align-middle">
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" CssClass="col-form-label" Text="Agregar Plan de Estudio"></asp:Label>
            </div>
            <div class="col-2">
                <asp:Button ID="BtnAgregar"  runat="server" CssClass="btn btn-success m-2 form-control" Text="Agregar" OnClick="BtnAgregar_Click" />
            </div>
            <div class="col-2">
                <asp:Label ID="Label2" runat="server" CssClass="col-form-label" Text="Buscar Plan"></asp:Label>
            </div>
            <div class="col-4">
                <asp:TextBox ID="TbSearch" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="text-center">
                <asp:GridView ID="GrvPlanes" CssClass="form-control" runat="server"></asp:GridView>
            </div>
            
        </div>
    </div>
</asp:Content>

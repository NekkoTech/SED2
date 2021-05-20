<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterCoordinadorMenu.Master" AutoEventWireup="true" CodeBehind="IbmMateria.aspx.cs" Inherits="Presentacion.GestionUsuarios.IbmMateria" %>

<%@ Register Src="~/Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>
<%@ MasterType VirtualPath="../PaginasMaestras/MasterCoordinadorMenu.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
    <!--div class="container">
         <div class="form-group row">
            <label class="col-sm-2 col-form-label">Nombre de la Materia</label>
            <div class="col-sm-10">
                <asp:Textbox runat="server" ID="tbNombreM" />
            </div>
        </div>
        <br />
        <div>
            <label class="col-sm-2 col-form-label">Clave</label>
            <div class="col-sm-10">
                <asp:Textbox runat="server" ID="tbClave" />
            </div>
        </div>
        <br />
        <div>
            <label class="col-sm-2 col-form-label">Docente(s)</label>
            <div class="col-sm-10">
                <asp:DropDownList runat="server" ID="dlDocentes" DataSourceID="SED" DataTextField="NombreUsuario" DataValueField="NombreUsuario">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SED" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionBD %>" SelectCommand="SELECT [NombreUsuario], [IdUsuario] FROM [Usuarios]"></asp:SqlDataSource>
            </div>
        </div>
        <br />
        <div>
            <label class="col-sm-2 col-form-label">Docente(s)</label>
            <div class="col-sm-10">
                <asp:DropDownList runat="server" ID="dlSemestre">
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </!--div-->
    <div class="container">
        <br />
        <div class="row">
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb bg-white">
                    <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                    <li class="breadcrumb-item"><a href="ListaPlanEstudio.aspx">Planes de Estudio</a></li>
                    <li class="breadcrumb-item active">Formulario Plan de Estudio</li>
                </ol>
            </nav>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:Label ID="LblHeader" CssClass="form-control" runat="server" Text="ELEGIR CAMPO A MODIFICAR"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <asp:Label ID="LblNombre" CssClass="col-form-label" runat="server" Text="Nombre"></asp:Label>
            </div>
            <div class="col">
                <uc1:wuc_Text runat="server" ID="wuc_Text" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <asp:Label ID="Label2" runat="server" Text="Asignar Coordinador"></asp:Label>
            </div>
            <div class="col">
                <asp:DropDownList ID="DdlCoordinadores" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" Text="Atributos de Egreso"></asp:Label>
            </div>
            <div class="col">
                <asp:Table ID="tbAtributos" runat="server" CssClass="table">
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero1">1</asp:TableCell>
                        <asp:TableCell>
                            <uc1:wuc_Text runat="server" ID="wuc_Text1" />
                            <asp:CheckBox ID="CbAtributo" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero2">2</asp:TableCell>
                        <asp:TableCell>
                            <uc1:wuc_Text runat="server" ID="wuc_Text2" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero3">3</asp:TableCell>
                        <asp:TableCell>
                            <uc1:wuc_Text runat="server" ID="wuc_Text3" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero4">4</asp:TableCell>
                        <asp:TableCell>
                            <uc1:wuc_Text runat="server" ID="wuc_Text4" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero5">5</asp:TableCell>
                        <asp:TableCell>
                            <uc1:wuc_Text runat="server" ID="wuc_Text5" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero6">6</asp:TableCell>
                        <asp:TableCell>
                            <uc1:wuc_Text runat="server" ID="wuc_Text6" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero7">7</asp:TableCell>
                        <asp:TableCell>
                            <uc1:wuc_Text runat="server" ID="wuc_Text7" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <div class="row align-middle text-center">
                <div class="col-6">
                    <asp:Button ID="BtnRegresar" CssClass="btn btn-success box w-25" runat="server" Text="Regresar" OnClick="BtnRegresar_Click" />
                </div>
                <div class="col-6">
                    <asp:Button ID="BtnGuardar" CssClass="btn btn-success box w-25" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
                    <asp:Button ID="BtnModificar" CssClass="btn btn-success box w-25" runat="server" Text="Modificar" OnClick="BtnModificar_Click" />
                </div>
            </div>
        </div>
        <br />
        <br />
    </div>
</asp:Content>

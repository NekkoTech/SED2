<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterDocenteMenu.Master" AutoEventWireup="true" CodeBehind="EncuadreDocente.aspx.cs" Inherits="Presentacion.GestionUsuarios.EncuadreDocente" %>

<%@ Register Src="~/Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>
<%@ Register Src="~/Controles/wuc_RepPassWord.ascx" TagPrefix="uc1" TagName="wuc_RepPassWord" %>
<%@ Register Src="~/Controles/wuc_PassWord.ascx" TagPrefix="uc1" TagName="wuc_PassWord" %>
<%@ Register Src="~/Controles/wuc_Email.ascx" TagPrefix="uc1" TagName="wuc_Email" %>
<%@ Register Src="~/Controles/wuc_NumeroEmpleado.ascx" TagPrefix="uc1" TagName="wuc_NumeroEmpleado" %>
<%@ Register Src="~/Controles/wuc_CrearUsuarioPassWord.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioPassWord" %>
<%@ Register Src="~/Controles/wuc_CrearUsuarioCorreo.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioCorreo" %>
<%@ Register Src="~/Controles/wuc_Text_SR.ascx" TagPrefix="uc1" TagName="wuc_Text_SR" %>

<%@ MasterType VirtualPath="../PaginasMaestras/MasterDocenteMenu.Master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <div class="container">
        <br />
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
            <ol class="breadcrumb bg-white">
                <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                <li class="breadcrumb-item active" aria-current="page">Encuadre</li>
            </ol>
        </nav>
        <div class="row">
            <div class="col-8">
                <div class="container">
                    <div class="row">
                        <div class="col text-center">
                            <asp:Label ID="LblHeader" CssClass="form-control" runat="server" Text="Informacion de Materia"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-2">
                            <asp:Label ID="LblNombre" CssClass="col-form-label" runat="server" Text="Nombre Materia"></asp:Label>
                        </div>
                        <div class="col">
                            <uc1:wuc_Text runat="server" ID="tbNombre" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-2">
                            <asp:Label ID="Label3" CssClass="col-form-label" runat="server" Text="Clave"></asp:Label>
                        </div>
                        <div class="col">

                            <uc1:wuc_NumeroEmpleado runat="server" ID="tbClave" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-2">
                            <asp:Label ID="Label2" runat="server" Text="Docente"></asp:Label>
                        </div>
                        <div class="col">
                            <asp:DropDownList ID="DdlDocentes" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-2">
                            <asp:Label ID="Label4" CssClass="col-form-label" runat="server" Text="Semestre"></asp:Label>
                        </div>
                        <div class="col">
                            <asp:DropDownList CssClass="form-control" ID="DdlSemestre" runat="server">
                                <asp:ListItem Text="1" Value="1" Selected="True"></asp:ListItem>
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
                                        <div class="col-sm w-100">
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text1" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm">
                                            <asp:DropDownList CssClass="form-control" ID="DdlAtrib1" runat="server">
                                                <asp:ListItem Text="Introductorio" Value="I" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Medio" Value="M"></asp:ListItem>
                                                <asp:ListItem Text="Avanzado" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="No Aplica" Value="NA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell ID="TcNumero2">2</asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm w-100">
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text2" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm">
                                            <asp:DropDownList CssClass="form-control" ID="DdlAtrib2" runat="server">
                                                <asp:ListItem Text="Introductorio" Value="I" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Medio" Value="M"></asp:ListItem>
                                                <asp:ListItem Text="Avanzado" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="No Aplica" Value="NA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell ID="TcNumero3">3</asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm w-100">
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text3" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm">
                                            <asp:DropDownList CssClass="form-control" ID="DdlAtrib3" runat="server">
                                                <asp:ListItem Text="Introductorio" Value="I" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Medio" Value="M"></asp:ListItem>
                                                <asp:ListItem Text="Avanzado" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="No Aplica" Value="NA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell ID="TcNumero4">4</asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm w-100">
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text4" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm">
                                            <asp:DropDownList CssClass="form-control" ID="DdlAtrib4" runat="server">
                                                <asp:ListItem Text="Introductorio" Value="I" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Medio" Value="M"></asp:ListItem>
                                                <asp:ListItem Text="Avanzado" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="No Aplica" Value="NA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell ID="TcNumero5">5</asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm w-100">
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text5" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm">
                                            <asp:DropDownList CssClass="form-control" ID="DdlAtrib5" runat="server">
                                                <asp:ListItem Text="Introductorio" Value="I" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Medio" Value="M"></asp:ListItem>
                                                <asp:ListItem Text="Avanzado" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="No Aplica" Value="NA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell ID="TcNumero6">6</asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm w-100">
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text6" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm">
                                            <asp:DropDownList CssClass="form-control" ID="DdlAtrib6" runat="server">
                                                <asp:ListItem Text="Introductorio" Value="I" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Medio" Value="M"></asp:ListItem>
                                                <asp:ListItem Text="Avanzado" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="No Aplica" Value="NA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell ID="TcNumero7">7</asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm w-100">
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text7" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <div class="col-sm">
                                            <asp:DropDownList CssClass="form-control" ID="DdlAtrib7" runat="server">
                                                <asp:ListItem Text="Introductorio" Value="I" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Medio" Value="M"></asp:ListItem>
                                                <asp:ListItem Text="Avanzado" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="No Aplica" Value="NA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </div>
                        <div class="row align-middle text-center">
                            <div class="col-6">
                                <asp:Button ID="BtnRegresar" CssClass="btn btn-success box w-50" runat="server" Text="Regresar" OnClick="BtnRegresar_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="BtnSubirEncuadre" CssClass="btn btn-success box w-50" runat="server" Text="Subir Encuadre" OnClick="BtnSubirEncuadre_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
            </div>
            <div class="col-4">
                <br />
                <br />
                <div class="card" style="width: 20rem; top: 0px; left: 0px;">
                    <asp:Image ID="ImgEncuadre" runat="server" Width="300px" Height="250px" CssClass="card-img" />
                    <div class="card-body">
                        <div class="col-2 w-50">
                            <asp:Button ID="BtnVer" CssClass="btn btn-success" Width="60px" runat="server" Text="Ver" OnClick="BtnVer_Click" CausesValidation="false" />
                        </div>
                        <div class="col-2 w-50">
                            <asp:Button ID="BtnDescargar" CssClass="btn btn-success" Width="100px" runat="server" Text="Descargar" OnClick="BtnDescargar_Click" CausesValidation="false" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <!--Modal De Funcionamiento de peticiones-->
    <div id="master-modal-peticiones" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-notify modal-info" role="document">
            <div class="modal-content">
                <div id="EModalHeader" runat="server">
                    <p class="heading lead text-center"><span id="EModalTitulo" runat="server"></span></p>
                </div>
                <div class="modal-body">
                    <span id="EModalBody" runat="server"></span>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="BtnCancelar" type="button" CssClass="btn btn-danger" runat="server" data-dismiss="modal" Text="Cancelar" />
                    <asp:Button ID="BtnConfirmar" type="button" CssClass="btn btn-success" runat="server" OnClick="BtnConfirmar_Click" Text="Guardar" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>
    <script>

        function openMasterModalPeticion() {
            $('#master-modal-peticiones').modal('show');
        }

    </script>

</asp:Content>

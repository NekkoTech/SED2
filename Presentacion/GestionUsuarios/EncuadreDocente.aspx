<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterDocenteMenu.Master" AutoEventWireup="true" CodeBehind="EncuadreDocente.aspx.cs" Inherits="Presentacion.GestionUsuarios.EncuadreDocente" %>


<%@ MasterType VirtualPath="../PaginasMaestras/MasterDocenteMenu.Master" %>
<%@ Register Src="~/Controles/wuc_Text_SR.ascx" TagPrefix="uc1" TagName="wuc_Text_SR" %>
<%@ Register Src="~/Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>
<%@ Register Src="~/Controles/wuc_NumeroEmpleado.ascx" TagPrefix="uc1" TagName="wuc_NumeroEmpleado" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="//mozilla.github.io/pdf.js/build/pdf.js"></script>
    <script type="text/javascript"> var url = '//cdn.mozilla.net/pdfjs/helloworld.pdf';
        PDFJS.workerSrc = '//mozilla.github.io/pdf.js/build/pdf.worker.js';

        // Asynchronous download of PDF
        var loadingTask = PDFJS.getDocument(url);
        loadingTask.promise.then(function (pdf) {
            console.log('PDF loaded');

            // Fetch the first page
            var pageNumber = 1;
            pdf.getPage(pageNumber).then(function (page) {
                console.log('Page loaded');

                var scale = 1.5;
                var viewport = page.getViewport(scale);

                // Prepare canvas using PDF page dimensions
                var canvas = document.getElementById('the-canvas');
                var context = canvas.getContext('2d');
                canvas.height = viewport.height;
                canvas.width = viewport.width;

                // Render PDF page into canvas context
                var renderContext = {
                    canvasContext: context,
                    viewport: viewport
                };
                var renderTask = page.render(renderContext);
                renderTask.then(function () {
                    console.log('Page rendered');
                });
            });
        }, function (reason) {
            // PDF loading error
            console.error(reason);
        });
    </script>

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
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text1" Enabled="false" />
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
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text2" Enabled="false" />
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
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text3" Enabled="false" />
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
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text4" Enabled="false" />
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
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text5" Enabled="false" />
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
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text6" Enabled="false" />
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
                                            <uc1:wuc_Text_SR runat="server" ID="wuc_Text7" Enabled="false" />

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
                <div class="col text-center">
                    <asp:Label ID="LblIntento" CssClass="form-control" runat="server"></asp:Label>
                </div>
                <br />
                <br />
                <div class="card">
                    <iframe id="Encuadre" style="width: 355px" runat="server" />
                    <div class="card-body row">
                        <div class="col-6">
                            <asp:Button ID="BtnVer" CssClass="btn btn-success" Width="60px" runat="server" Text="Ver" OnClick="BtnVer_Click" CausesValidation="false" />
                        </div>
                        <div class="col6">
                            <asp:Button ID="Button2" CssClass="btn btn-success" Width="90px" runat="server" Text="Descargar" OnClick="BtnDescargar_Click" CausesValidation="false" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="col">
                    <asp:Label ID="LblCalificacion" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col">
                    <asp:Label ID="LblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                    <asp:TextBox ID="tbObservaciones" CssClass="form-control" runat="server"></asp:TextBox>
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
    <!--Modal De FilePicker-->
    <div id="master-modalFU" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-notify modal-info" role="document">
            <div class="modal-content">
                <div id="ModalHeaderFU" runat="server">
                    <p class="heading lead text-center"><span id="MHeaderFU" runat="server">Seleccionar Archivo</span></p>
                </div>
                <div class="modal-body">
                    <asp:FileUpload ID="FUModal" accept="application/pdf" CssClass="form-control-file" runat="server" />
                    <asp:RegularExpressionValidator ID="rexp" runat="server" ControlToValidate="FUModal"
                        ErrorMessage="Solo archivos PDF"
                        ValidationExpression="^.*\.(doc|DOC|docx|DOCX|pdf|PDF)$"></asp:RegularExpressionValidator>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button1" type="button" CssClass="btn btn-success" runat="server" data-dismiss="modal" CausesValidation="false" Text="Cancelar" />
                    <asp:Button ID="btnSubirModal" type="button" CssClass="btn btn-success" runat="server" OnClick="BtnGuardarModal_Click" CausesValidation="false" Text="Subir Encuadre" />
                </div>
            </div>
        </div>
    </div>
    <script>

        function openMasterModalPeticion() {
            $('#master-modal-peticiones').modal('show');
        }
        function openMasterModalFU() {
            $('#master-modalFU').modal('show');
        }

    </script>
</asp:Content>

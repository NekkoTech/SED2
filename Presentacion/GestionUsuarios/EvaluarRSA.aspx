<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterCoordinadorMenu.Master" AutoEventWireup="true" CodeBehind="EvaluarRSA.aspx.cs" Inherits="Presentacion.GestionUsuarios.EvaluarRSA" %>

<%@ MasterType VirtualPath="../PaginasMaestras/MasterCoordinadorMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
    <div class="container">
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
            <ol class="breadcrumb bg-white">
                <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                <li class="breadcrumb-item"><a href="ListaEncuadres.aspx">Encuadre</a></li>
                <li class="breadcrumb-item active" aria-current="page">Evaluar Encuadre</li>
            </ol>
        </nav>
        <div class="row-cols-2">
            <div class="col-sm-4 align-items-start">
                <asp:Button ID="btnRegresar" CssClass="btn btn-success box w-25" runat="server" Text="Regresar" OnClick="BtnRegresar_Click" />
            </div>
            <div class="col-sm text-center">
                <iframe id="Documento" style="width: 800px" height="500" runat="server" />
            </div>
        </div>
        <div class="row text-center">
            <div class="col-6">
                    <asp:Button ID="BtnRechazar" CssClass="btn btn-danger box w-25" runat="server" Text="Rechazar" OnClick="BtnRechazar_Click" />
                </div>
                <div class="col-6">
                    <asp:Button ID="BtnAceptar" CssClass="btn btn-success box w-25" runat="server" Text="Aceptar" OnClick="BtnAceptar_Click" />
                </div>
        </div>
        <br />
        <br />
    </div>
     <!--Modal De Funcionamiento de peticiones-->
    <div id="master-modal-Observaciones" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-notify modal-info" role="document">
            <div class="modal-content">
                <div id="EModalHeader" runat="server">
                    <p class="heading lead text-center">Favor de ingresar las observaciones sobre el rechazo del encuadre</p>
                </div>
                <div class="modal-body">
                    <asp:Label ID="LblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                    <asp:TextBox ID="tbObservaciones" Width="200" Height="200" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="BtnCancelar" type="button" CssClass="btn btn-danger" runat="server" data-dismiss="modal" Text="Regresar" />
                    <asp:Button ID="BtnConfirmar" type="button" CssClass="btn btn-success" runat="server" OnClick="BtnEnviarRechazado_Click" Text="Enviar" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>
    <!--Modal De Funcionamiento de peticiones-->
    <div id="master-modal-Calif" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-notify modal-info" role="document">
            <div class="modal-content">
                <div id="Div1" runat="server">
                    <p class="heading lead text-center">Favor de ingresar la calificacion de este encuadre (0-100)</p>
                </div>
                <div class="modal-body text-center">
                    <asp:TextBox ID="TbCalificacion" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button1" type="button" CssClass="btn btn-danger" runat="server" data-dismiss="modal" Text="Regresarr" />
                    <asp:Button ID="Button2" type="button" CssClass="btn btn-success" runat="server" OnClick="BtnEnviarAceptado_Click" Text="Enviar" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>
    <!--Modal De Funcionamiento de peticiones-->
    <div id="master-modal-accept" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-notify modal-info" role="document">
            <div class="modal-content">
                <div id="Div2" runat="server">
                    <p class="heading lead text-center">Comprobación</p>
                </div>
                <div class="modal-body text-center">
                    <asp:Label ID="Label1" runat="server" Text="¿Seguro que desea Aceptar este encuadre?"></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button3" type="button" CssClass="btn btn-danger" runat="server" data-dismiss="modal" Text="Regresar" />
                    <asp:Button ID="Button4" type="button" CssClass="btn btn-success" runat="server" OnClick="BtnAceptado_Click" Text="Enviar" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>
    <script>

        function openMasterModalObservaciones() {
            $('#master-modal-Observaciones').modal('show');
        }
        function openMasterModalCalif() {
            $('#master-modal-Calif').modal('show');
        }
        function openMasterModalAccept() {
            $('#master-modal-accept').modal('show');
        }
       
    </script>
</asp:Content>

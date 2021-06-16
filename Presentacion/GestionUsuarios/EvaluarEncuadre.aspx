<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterCoordinadorMenu.Master" AutoEventWireup="true" CodeBehind="EvaluarEncuadre.aspx.cs" Inherits="Presentacion.GestionUsuarios.EvaluarEncuadre" %>

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
                <asp:Button ID="btnRegresar" CssClass="btn btn-success box w-25" runat="server" CausesValidation="false" Text="Regresar" OnClick="BtnRegresar_Click" />
            </div>
            <div class="col-sm text-center">
                <iframe id="Encuadre" style="width: 800px" height="500" runat="server" />
            </div>
        </div>
        <div class="row text-center">
            <div class="col-6">
                    <asp:Button ID="BtnRechazar" CssClass="btn btn-danger box w-25" runat="server" CausesValidation="false" Text="Rechazar" OnClick="BtnRechazar_Click" />
                </div>
                <div class="col-6">
                    <asp:Button ID="BtnAceptar" CssClass="btn btn-success box w-25" runat="server" CausesValidation="false" Text="Aceptar" OnClick="BtnAceptar_Click" />
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
                    <asp:TextBox ID="tbObservaciones" Width="200" Height="400" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:requiredfieldvalidator ID="rfvtbObservaciones" runat="server" ValidationGroup="Observaciones" errormessage="RequiredFieldValidator" ControlToValidate="tbObservaciones" CssClass="text-danger" Display="Dynamic">Llene el campo de observaciones</asp:requiredfieldvalidator>
                    <asp:Button ID="BtnCancelar" type="button" CssClass="btn btn-danger" runat="server" CausesValidation="false" data-dismiss="modal" Text="Regresar" />
                    <asp:Button ID="BtnConfirmar" type="button" CssClass="btn btn-success" runat="server" ValidationGroup="Observaciones" OnClick="BtnEnviarRechazado_Click" Text="Enviar" />
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
                    <asp:TextBox ID="TbCalificacion" CssClass="form-control" runat="server"></asp:TextBox> <br />
                    <asp:regularexpressionvalidator runat="server" ValidationGroup="Calificacion" ControlToValidate="TbCalificacion" errormessage="RegularExpressionValidator" ValidationExpression="^[6-9][0-9]?$|^100$">60-100</asp:regularexpressionvalidator>
                </div>
                <div class="modal-footer">
                    <asp:requiredfieldvalidator ID="Requiredfieldvalidator1" runat="server" ValidationGroup="Calificacion" errormessage="RequiredFieldValidator" ControlToValidate="TbCalificacion" CssClass="text-danger" Display="Dynamic">Asigne la calificacion</asp:requiredfieldvalidator>
                    <asp:Button ID="Button1" type="button" CssClass="btn btn-danger" runat="server" CausesValidation="false" data-dismiss="modal" Text="Regresarr" />
                    <asp:Button ID="Button2" type="button" CssClass="btn btn-success" runat="server" ValidationGroup="Calificacion" OnClick="BtnEnviarAceptado_Click" Text="Enviar"/><br/>
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
                    <asp:Button ID="Button3" type="button" CssClass="btn btn-danger" runat="server" data-dismiss="modal" Text="Regresar" CausesValidation="false" />
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

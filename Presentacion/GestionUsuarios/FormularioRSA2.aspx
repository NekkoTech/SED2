<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterDocenteMenu.Master" AutoEventWireup="true" CodeBehind="FormularioRSA2.aspx.cs" Inherits="Presentacion.GestionUsuarios.FormularioRSA2" %>

<%@ Register Src="~/Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>
<%@ Register Src="~/Controles/wuc_NumeroEmpleado.ascx" TagPrefix="uc1" TagName="wuc_NumeroEmpleado" %>
<%@ Register Src="~/Controles/wuc_Text_SR.ascx" TagPrefix="uc1" TagName="wuc_Text_SR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
     <div class="row">
            <div class="col-2">
                
            </div>
            <div class="col">
                <asp:Label ID="Label1" runat="server" Text="Atributos de Egreso"></asp:Label>
                <asp:Table ID="tbAtributos" runat="server" CssClass="table">
                    <asp:TableRow>
                        
                       
                        <asp:TableCell ID="TcNumero1">1</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text1" Enabled="false"/>
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero2">2</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text2" Enabled="false"/>
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero3">3</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text3" Enabled="false"/>
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                       <asp:TableCell ID="TcNumero4">4</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text4" Enabled="false"/>
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero5">5</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text5" Enabled="false"/>
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero6">6</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text6" Enabled="false"/>
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero7">7</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text7" Enabled="false"/>
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
         </div>
         <br />
    <div class="row">
         <div class="col">
              <table class="center" style="width:70%">
                  <tr>
                      <td>Indique el porcentaje de alumnos en cada nivel (4 es sobresaliente)</td>
                  </tr>
              </table>
         </div>
    </div>
     <br />
         <div class="row">
           
             <div class="col">
              
              <table class="center" style="width:70%">
              <tr>
                <td>Atributo(s) de Egreso</td>
                <td >Técnica de Evaluación</td>
                  <td>4</td>
                  <td>3</td>
                  <td>2</td>
                  <td>1</td>
              </tr>
              <tr>
                <td>1</td>
                <td><asp:TextBox ID="TbTecnica1" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb14" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb13" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb12" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb11" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>2</td>
                <td><asp:TextBox ID="TbTecnica2" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb24" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb23" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb22" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb21" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>3</td>
                <td><asp:TextBox ID="TbTecnica3" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb34" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb33" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb32" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb31" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>4</td>
                <td><asp:TextBox ID="TbTecnica4" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb44" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb43" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb42" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb41" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>5</td>
                <td><asp:TextBox ID="TbTecnica5" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb54" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb53" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb52" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb51" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>6</td>
                <td><asp:TextBox ID="TbTecnica6" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb64" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb63" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb62" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb61" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>7</td>
                <td><asp:TextBox ID="TbTecnica7" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb74" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb73" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb72" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb71" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
            </table>
         </div>
             <br />
             
        </div>
     <div class="form-row align-content-center text-center">
              <div class="col">
                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-light boton mb-2 box margen"  Text="Regresar"></asp:Button>

            </div>
            <div class="col">
                 <asp:Button runat="server" ID="Button1" CssClass="btn btn-warning box mb-2 margen" Font-Size="Large"   Text="Guardar Informacion" OnClick="btnGuardar_Click"></asp:Button>
            </div>
             <div class="col">
                 <asp:Button runat="server" ID="btnModal" CssClass="btn btn-warning mb-2 box margen" Font-Size="Large"  Text="Ver Retroalimentacion" OnClick="btnObservaciones_Click" Visible="false"></asp:Button>
            </div>
            <div class="col">
                 <asp:Button runat="server" ID="btnEnviar" CssClass="btn btn-light boton mb-2 box margen"   Text="Siguiente Pagina" OnClick="btnEnviar_Click"></asp:Button>
            </div>
         </div>
     <!--Modal De Funcionamiento de peticiones-->
    <div id="master-modal-Observaciones" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-notify modal-info" role="document">
            <div class="modal-content">
                <div id="Div1" runat="server">
                    <p class="heading lead text-center">Retroalimentacion:</p>
                </div>
                <div class="modal-body">
                    <asp:Label ID="LblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                    <asp:TextBox ID="tbObservaciones" Width="200" Height="200" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnObservaciones" type="button" CssClass="btn btn-danger" runat="server" data-dismiss="modal" Text="Cerrar" CausesValidation="false"/>
                </div>
            </div>
        </div>
    </div>
    <script>

        function openMasterModalPeticion() {
            $('#master-modal-peticiones').modal('show');
        }
        function openMasterModalObservaciones() {
            $('#master-modal-Observaciones').modal('show');
        }
    </script>
</asp:Content>
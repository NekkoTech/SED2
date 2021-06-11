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
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text1" />
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero2">2</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text2" />
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero3">3</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text3" />
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                       <asp:TableCell ID="TcNumero4">4</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text4" />
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero5">5</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text5" />
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero6">6</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text6" />
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="TcNumero7">7</asp:TableCell>
                        <asp:TableCell>
                            <div class="col-sm w-75">
                                <uc1:wuc_Text_SR runat="server" ID="wuc_Text7" />
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
                <td><asp:TextBox ID="tbtecnica" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                <td><asp:TextBox ID="Tb4" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb3" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb2" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="Tb1" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>2</td>
                <td><asp:TextBox ID="TextBox1" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                <td><asp:TextBox ID="TextBox2" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox3" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox4" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox5" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>3</td>
                <td><asp:TextBox ID="TextBox6" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                <td><asp:TextBox ID="TextBox7" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox8" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox9" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox10" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>4</td>
                <td><asp:TextBox ID="TextBox11" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                <td><asp:TextBox ID="TextBox12" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox13" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox14" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox15" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>5</td>
                <td><asp:TextBox ID="TextBox16" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                <td><asp:TextBox ID="TextBox17" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox18" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox19" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox20" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>6</td>
                <td><asp:TextBox ID="TextBox21" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                <td><asp:TextBox ID="TextBox22" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox23" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox24" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox25" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
              </tr>
                  <tr>
                <td>7</td>
                <td><asp:TextBox ID="TextBox26" runat="server"  CssClass="form-control box w-100" Width="700px"></asp:TextBox></td>
                <td><asp:TextBox ID="TextBox27" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox28" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox29" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
                  <td><asp:TextBox ID="TextBox30" runat="server"  CssClass="form-control box w-100" Width="50px"></asp:TextBox></td>
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
                 <asp:Button runat="server" ID="btnEnviar" CssClass="btn btn-light boton mb-2 box margen"   Text="Siguiente Pagina"></asp:Button>
            </div>
         </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MP_BaseMaster.Master" AutoEventWireup="true" CodeBehind="AgregaUsuario.aspx.cs" Inherits="Presentacion.GestionUsuarios.AgregaUsuario" %>

<%@ Register Src="~/Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <%--<link href="../CSS/Login.css" rel="stylesheet">--%>
    
  <br />
       <div class="form-group row">
       <label class="col-sm-2 col-form-label">Nombre(s)</label>
    <div class="col-sm-10">
            <uc1:wuc_Text runat="server" id="tbNombre" />
      
    </div>
   </div>
    <br />
    <div class="form-group row">
       <label class="col-sm-2 col-form-label">Apellido Paterno</label>
    <div class="col-sm-10">
      <input type="text" class="form-control box" id="inputAppat" style="border-radius: 30px">
    </div>
   </div>
    <br />
    <div class="form-group row">
       <label class="col-sm-2 col-form-label">Apellido Materno</label>
    <div class="col-sm-10">
      <input type="text" class="form-control box" id="inputApmat" style="border-radius: 30px">
    </div>
   </div>
    <br />
    <div class="form-group row">
       <label class="col-sm-2 col-form-label">Numero Empleado</label>
    <div class="col-sm-10">
      <input type="text" class="form-control box" id="inputNumEmpleado" style="border-radius: 30px">
    </div>
   </div>
    <br />
    <div class="form-group row">
       <label class="col-sm-2 col-form-label">Correo Institucional</label>
    <div class="col-sm-10">
      <input type="text" class="form-control box" id="inputEmail" style="border-radius: 30px">
    </div>
   </div>
    <br />
    <div class="form-group row">
       <label class="col-sm-2 col-form-label">Contraseña</label>
    <div class="col-sm-10">
      <input type="text" class="form-control box" id="inputPass" style="border-radius: 30px">
    </div>
   </div>
  <br />
    <div class="form-row text-center">
      
           <button type="button" class="btn btn-light btn-outline-dark mb-2 box margen" >SUBDIRECTOR</button>
   
    
           <button type="button" class="btn btn-light btn-outline-dark mb-2 box margen" >COORDINADOR</button>
    
  
           <button type="button" class="btn btn-light btn-outline-dark mb-2 box margen" >DOCENTE</button>
   
      
  </div>
  <br />
     <div class="form-row text-center">
      
           <button type="button" class="btn btn-primary mb-2 boton" >Guardar</button>
   </div>
</asp:Content>

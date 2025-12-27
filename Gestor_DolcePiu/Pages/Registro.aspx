<%@ Page Title="" Language="C#" MasterPageFile="~/Site.login.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Gestor_DolcePiu.Pages.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="formcontent">
           
                <div class="control">
                    <div class="row">
                        <asp:Label class="titulo" ID="lblRegistro" runat="server" Text="Registrarse en el Sistema"></asp:Label>
                    </div>
                    <div class="inputs">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" placeholder="Ingrese su nombre"></asp:TextBox>
                    </div>
                    <div class="inputs">
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
                        <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" placeholder="Ingrese su apellido"></asp:TextBox>
                    </div>
                    <div class="inputs">
                        <asp:Label ID="lblDocumento" runat="server" Text="Documento:"></asp:Label>
                        <asp:TextBox ID="txtDocumento" CssClass="form-control" runat="server" placeholder="Ingrese su documento"></asp:TextBox>
                    </div>
                    <div class="inputs">
                        <asp:Label ID="lblTeleono" runat="server" Text="Telefono:"></asp:Label>
                        <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server" placeholder="Ingrese su telefono"></asp:TextBox>
                    </div>
                    <div class="inputs">
                        <asp:Label ID="lblEmail" runat="server" Text="Correo electronico:"></asp:Label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Ingrese su correo electronico"></asp:TextBox>
                    </div>
                    <div class="inputs">
                        <asp:Label ID="lblDireccion" runat="server" Text="Direccion:"></asp:Label>
                        <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" placeholder="Ingrese su direccion"></asp:TextBox>
                    </div>
                    <br />
                    <div class="inputs">
                        <asp:Label ID="lblZonas" runat="server" Text="Zona"></asp:Label>
                        <asp:ListBox ID="lstZonas" runat="server" Rows="1"></asp:ListBox>
                    </div>
                    <div class="inputs">
                        <asp:Label ID="lblContrasenia" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="txtContrasenia" CssClass="form-control" TextMode="Password" runat="server" placeholder="Ingrese su contraseña"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="error">
                        <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                    </div>
                    <div class="error">
                        <asp:Label runat="server" CssClass="alert-danger" ID="lblRegistrado"></asp:Label>
                    </div>
                    <br />
                    <div class="row-btn">
                         <asp:Button ID="btnCerrar"  CssClass="btn btn-primary btn-dark"  runat="server" Text="Cerrar" OnClick="btnCerrar_Click"/>  
                         <asp:Button ID="btnRegistrar" CssClass="btn btn-primary btn-dark" runat="server" Text="Aceptar" OnClick="btnRegistrar_Click" />
                    </div>
                </div>
            
        </div>
    </div>
</asp:Content>

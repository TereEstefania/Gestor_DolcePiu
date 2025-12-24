<%@ Page Title="" Language="C#" MasterPageFile="~/Site.login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Gestor_DolcePiu.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6">
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox runat="server" ID="txtEmail" placeholder="example@email.com" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password" />
        </div>
        <div >  
            <asp:Label runat="server" ID="lblMensaje" CssClass="text-danger" Visible="false"></asp:Label>
        </div>
        <asp:Button Text="Ingresar" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" cssclass="btn btn-primary" />
    </div>
</asp:Content>

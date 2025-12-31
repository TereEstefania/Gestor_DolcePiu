<%@ Page Title="" Language="C#" MasterPageFile="~/Site.login.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Gestor_DolcePiu.Pages.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Estas en PEDIDOS</h1>
    <asp:Label ID="lblBienvenida" runat="server"></asp:Label>
    <div class="navegador">
        <%--<uc:NavigationBar ID="NavigationBar" runat="server" />--%>
</div>
    <div >
        <div >
            <asp:Label ID="lblSeleccionarProductos" class="titulo" runat="server" Text="Seleccionar productos"></asp:Label>
         <div >                
            <asp:Label ID="lblSabor" runat="server" Text="Sabor"></asp:Label>
            <asp:ListBox ID="lstSabores" runat="server" Rows="1"></asp:ListBox>
            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
         </div>
        <div >
            <asp:Button ID="btnAgregarProducto" CssClass="btn btn-primary btn-dark" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" />
        </div>
        <div >
            <asp:Label ID="lblZona" runat="server" Text="Zona"></asp:Label>
            <asp:ListBox ID="lstZonas" runat="server" Rows="1"></asp:ListBox>
            <asp:Label ID="lblMetodoPago" runat="server" Text="Metodo de Pago"></asp:Label>
            <asp:RadioButtonList ID="rblFormaPago" runat="server"></asp:RadioButtonList>
        </div>
        <div>
          <asp:Label runat="server" CssClass="alert-danger" ID="lblRegistrado"></asp:Label>
        </div>
        <div class="lbtn">
          <asp:Button ID="BtnRegistrar" CssClass="btn btn-primary btn-dark" runat="server" Text="Registrar Pedido" OnClick="BtnRegistrar_Click" />
        </div>
        </div>
        <div class="spacing grids-form">
             <div  style="overflow: auto; height: 500px;">
                <asp:GridView ID="gvMostrarProductos" runat="server"></asp:GridView>
            </div >
            <asp:Label ID="lblTotal" runat="server" Text="Total: $0.00" Font-Bold="True" />
        </div>
</div>
        
</asp:Content>

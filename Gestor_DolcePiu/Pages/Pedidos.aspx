<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Pedidos.master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Gestor_DolcePiu.Pages.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Estas en PEDIDOS</h1>
    <asp:Label ID="lblBienvenida" runat="server"></asp:Label>
        <div>
            <asp:Label ID="lblSeleccionarProductos" class="titulo" runat="server" Text="Seleccionar productos"></asp:Label>
            <div>
                <asp:Label ID="lblSabor" runat="server" Text="Sabor"></asp:Label>
                <asp:ListBox ID="lstSabores" runat="server" Rows="1"></asp:ListBox>
                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnAgregarProducto" CssClass="btn btn-primary btn-dark" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" />

                <asp:Label ID="lblZona" runat="server" Text="Zona"></asp:Label>
                <asp:ListBox ID="lstZonas" runat="server" Rows="1"></asp:ListBox>
                <asp:Label ID="lblMetodoPago" runat="server" Text="Metodo de Pago"></asp:Label>
                <asp:RadioButtonList ID="rblFormaPago" runat="server"></asp:RadioButtonList>
            </div>
            <div>
                <asp:Label runat="server"  ID="lblRegistrado"></asp:Label>
            </div>
            <div>
                <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar Pedido" CssClass="btn btn-primary" OnClick="BtnRegistrar_Click" />
            </div>
        </div>
        <div>
            <asp:GridView ID="gvMostrarProductos" runat="server" CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false"
                OnSelectedIndexChanged="gvMostrarProductos_SelectedIndexChanged" AllowPaging="True" PageSize="5">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Codigo" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:CommandField HeaderText="Eliminar Seleccion" ShowSelectButton="true" SelectText="❌"/>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblTotal" runat="server" Text="Total: $0.00" Font-Bold="True" />
        </div>

        <%if (clickeado)
            {%>
        <div class="alert alert-success" role="alert">
            <asp:Label ID="lblAlerta" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnCerrarAlerta" CssClass="btn-close" runat="server" OnClick="btnCerrarAlerta_Click" aria-label="Close"></asp:Button>
        </div>
        <%} %>
</asp:Content>

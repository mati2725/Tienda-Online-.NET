<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Tp_Integrador___Grupo3.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 [IdProducto_P], [Nombre_P], [IdCategoria_P], [PrecioUnitario_P], [Imagen_P] FROM [Productos] WHERE [IdCategoria_P]=1"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 [IdProducto_P], [Nombre_P], [IdCategoria_P], [PrecioUnitario_P], [Imagen_P] FROM [Productos] WHERE [IdCategoria_P]=2"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 [IdProducto_P], [Nombre_P], [IdCategoria_P], [PrecioUnitario_P], [Imagen_P] FROM [Productos] WHERE [IdCategoria_P]=3"></asp:SqlDataSource>
        <br />
        <br />
        <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    <asp:Button ID="Button3" runat="server" Height="26px" OnClick="Button3_Click" Text="Todos los productos" Width="182px" />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Todas las categorias" OnClick="Button1_Click" Height="26px" Width="182px" />
                </td>
                <td style="width:65%">
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" Width="80%"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registrarse.aspx">Registrarse</asp:HyperLink>
                    <br />
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/IniciarSesion.aspx">Iniciar Sesión</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Usuario/Carrito.aspx">Carrito</asp:HyperLink>
                </td>
            </tr>
        </table>
            <h1 style="text-align: center; background-color: #00CC99; height: 35px; font-size: xx-large; color: #000000;">
                <asp:Label ID="Label1" runat="server" Text="Notebooks"></asp:Label>
&nbsp;<asp:HyperLink ID="HyperLink3" runat="server" ForeColor="#0066FF" CssClass="auto-style1" NavigateUrl="~/MostrarProductos.aspx">ver más</asp:HyperLink>
            </h1>
        <br />
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
            <EmptyDataTemplate>
                <table style="">
                    <tr>
                        <td>No se han devuelto datos.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <td runat="server" style="width:20%;text-align:center">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("Imagen_P") %>' style="max-width:40%" CommandArgument='<%# Eval("Nombre_P")+";"+Eval("Imagen_P")+";"+Eval("Detalle_P")+";"+Eval("IdMarca_P")+";"+Eval("PrecioUnitario_P")+";"+Eval("Stock_P") %>' CommandName="EventoSeleccionarImagen_InicioNotebook" OnCommand="ImageButton1_Command"/>
                    <br />
                    <br />
                    <asp:Label ID="Nombre_PLabel" runat="server" Text='<%# Eval("Nombre_P") %>' />
                    &nbsp;
                    <asp:Label ID="PrecioUnitario_PLabel" runat="server" Text='<%# Eval("PrecioUnitario_P") %>' />
                    <br />
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" border="0" style="">
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </table>
                <div style="">
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <br />
            <h1 style="text-align: center; background-color: #00CC99; height: 35px; font-size: xx-large; color: #000000;">
                <asp:Label ID="Label2" runat="server" Text="Celulares"></asp:Label>
&nbsp;<asp:HyperLink ID="HyperLink4" runat="server" ForeColor="#0066FF" CssClass="auto-style1" NavigateUrl="~/MostrarProductos.aspx">ver más</asp:HyperLink>
            </h1>
        <br />
        <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource2">
            <EmptyDataTemplate>
                <table style="">
                    <tr>
                        <td>No se han devuelto datos.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <td runat="server" style="width:20%;text-align:center">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("Imagen_P") %>' style="max-width:40%" CommandArgument='<%# Eval("Nombre_P")+";"+Eval("Imagen_P")+";"+Eval("Detalle_P")+";"+Eval("IdMarca_P")+";"+Eval("PrecioUnitario_P")+";"+Eval("Stock_P") %>' CommandName="EventoSeleccionarImagen_InicioCelular" OnCommand="ImageButton1_Command1"/>
                    <br />
                    <br />
                    <asp:Label ID="Nombre_PLabel" runat="server" Text='<%# Eval("Nombre_P") %>' />
                    &nbsp;
                    <asp:Label ID="PrecioUnitario_PLabel" runat="server" Text='<%# Eval("PrecioUnitario_P") %>' />
                    <br />
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" border="0" style="">
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </table>
                <div style="">
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <br />
            <h1 style="text-align: center; background-color: #00CC99; height: 35px; font-size: xx-large; color: #000000;">
                <asp:Label ID="Label3" runat="server" Text="Auriculares"></asp:Label>
&nbsp;<asp:HyperLink ID="HyperLink5" runat="server" ForeColor="#0066FF" CssClass="auto-style1" NavigateUrl="~/MostrarProductos.aspx">ver más</asp:HyperLink>
            </h1>
        <br />
        <asp:ListView ID="ListView3" runat="server" DataSourceID="SqlDataSource3">
            <EmptyDataTemplate>
                <table style="">
                    <tr>
                        <td>No se han devuelto datos.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <td runat="server" style="width:20%;text-align:center">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("Imagen_P") %>' style="max-width:40%" CommandArgument='<%# Eval("Nombre_P")+";"+Eval("Imagen_P")+";"+Eval("Detalle_P")+";"+Eval("IdMarca_P")+";"+Eval("PrecioUnitario_P")+";"+Eval("Stock_P") %>' CommandName="EventoSeleccionarImagen_InicioAuri" OnCommand="ImageButton1_Command2" />
                    <br />
                    <br />
                    <asp:Label ID="Nombre_PLabel" runat="server" Text='<%# Eval("Nombre_P") %>' />
                    &nbsp;
                    <asp:Label ID="PrecioUnitario_PLabel" runat="server" Text='<%# Eval("PrecioUnitario_P") %>' />
                    <br />
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" border="0" style="">
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </table>
                <div style="">
                </div>
            </LayoutTemplate>
        </asp:ListView>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarProductos.aspx.cs" Inherits="Tp_Integrador___Grupo3.Buscar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    

    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Productos] WHERE ([Estado_P] = @Estado_P)">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="Estado_P" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Marcas]"></asp:SqlDataSource>
        <br />
        <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    <asp:Button ID="ButtonProductos" runat="server" Height="26px" OnClick="ButtonProductos_Click" Text="Todos los productos" Width="182px" />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Todas las categorias" OnClick="Button1_Click" Height="26px" Width="182px" />
                </td>
                <td style="width:65%">
                    <asp:TextBox ID="TextBox1" runat="server" Width="80%"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" />
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registrarse.aspx">Registrarse</asp:HyperLink>
                    <br />
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/IniciarSesion.aspx">Iniciar Sesión</asp:HyperLink>
                    <br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Usuario/Carrito.aspx">Carrito</asp:HyperLink>
                </td>
            </tr>
        </table>
        <div>
            <h1 style="text-align: center; background-color: #00CC99; height: 35px; font-size: xx-large; color: #000000;">
                BÚSQUEDA DE PRODUCTOS
            </h1>
            <br />
            <br />
            <table style="width:100%">
                <tr>
                    <td style="vertical-align:top; width:15%"> 
                        <div class="auto-style1">
                            <br />
                        <br />
                        </div>
                        &nbsp;
                        <br />
                        <br />
                        <h1 style="text-align: center; background-color: #00CC99; height: 35px; font-size: xx-large; color: #000000;">
                        <span style="font-size:24px;"><strong>FILTROS</strong></span><br />
            </h1>
                        <span style="font-size:20px">MARCA</span><br />
                        <asp:DataList ID="dlMarcas" runat="server" DataSourceID="SqlDataSource2" Width="108px">
                            <ItemTemplate>
                                <asp:Button ID="btnMarca" runat="server" Text='<%# Eval("Nombre_M") %>' Width="80%" CommandArgument='<%# Eval("IdMarca_M") %>' CommandName="EventoSeleccionarMarca" OnCommand="btnMarca_Command"/>
                            </ItemTemplate>
                        </asp:DataList>
                        <br />
                        <br />
                        <span style="font-size:20px">PRECIO</span><br />
                        <asp:TextBox ID="TextBox2" runat="server" style="Width:100px"></asp:TextBox>
&nbsp;hasta
                        <asp:TextBox ID="TextBox3" runat="server" style="Width:100px"></asp:TextBox>
                        <br />
                        <asp:Button ID="Button3" runat="server" Text="Aplicar" OnClick="Button3_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Deshacer filtros" />
                        <br />
                    </td>
                    <td style="text-align:center">
                        <asp:ListView ID="ListView1" runat="server" DataKeyNames="IdProducto_P" DataSourceID="SqlDataSource1" GroupItemCount="3" >
                            <EmptyDataTemplate>
                                <table runat="server" style="">
                                    <tr>
                                        <td>No se han devuelto datos.</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <EmptyItemTemplate>
<td runat="server" />
                            </EmptyItemTemplate>
                            <GroupTemplate>
                                <tr id="itemPlaceholderContainer" runat="server">
                                    <td id="itemPlaceholder" runat="server"></td>
                                </tr>
                            </GroupTemplate>
                            <ItemTemplate >
                                <td runat="server" >
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("Imagen_P") %>' style="max-width:75%" CommandArgument='<%# Eval("Nombre_P")+";"+Eval("Imagen_P")+";"+Eval("Detalle_P")+";"+Eval("IdMarca_P")+";"+Eval("PrecioUnitario_P")+";"+Eval("Stock_P") %>' CommandName="SeleccionarProductoImagen" Height="150px" OnCommand="ImageButton1_Command" />
                                    <br />
                                    <asp:Label ID="Nombre_PLabel" runat="server" Text='<%# Eval("Nombre_P") %>'  />
                                    <br />
                                    <asp:Label ID="PrecioUnitario_PLabel" runat="server" Text='<%# Eval("PrecioUnitario_P") %>' />
                                    <br /></td>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <table runat="server">
                                    <tr runat="server">
                                        <td runat="server">
                                            <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                                <tr id="groupPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server" style="">
                                            <asp:DataPager ID="DataPager1" runat="server" PageSize="15">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                    <asp:NumericPagerField />
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                </Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

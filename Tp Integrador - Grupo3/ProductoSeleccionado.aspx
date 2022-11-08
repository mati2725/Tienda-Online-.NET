<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductoSeleccionado.aspx.cs" Inherits="Tp_Integrador___Grupo3.MostrarProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style3 {
            font-size: xx-large;
            color: #000000;
            height: 35px;
            text-align: center;
            background-color: #00CC99;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            width: 100%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">

         &nbsp;&nbsp;&nbsp;

         <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    <asp:Button ID="Button3" runat="server" Height="26px" OnClick="Button3_Click" Text="Todos los productos" Width="182px" />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Todas las categorias" OnClick="Button1_Click" Height="26px" Width="182px" />
                </td>
                <td style="width:65%">
                    <asp:TextBox ID="TextBox1" runat="server" Width="80%"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Usuario/Carrito.aspx">Carrito</asp:HyperLink>
                    <br />
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Registrarse.aspx">Registrarse</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/IniciarSesion.aspx">Iniciar Sesion</asp:HyperLink>
                </td>
            </tr>

         </table>
                <h1 class="auto-style3">PRODUCTO SELECCIONADO</h1>
            <div class="auto-style5">
                <br />
                <br />
                <table class="auto-style6">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="width: 20%; text-align: center">
                <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="ListView1_ItemDataBound">
<%--                    <AlternatingItemTemplate>
                        <td runat="server" style="background-color: #FAFAD2;color: #284775;">Nombre_P:
                            <asp:Label ID="Nombre_PLabel" runat="server" Text='<%# Eval("Nombre_P") %>' />
                            <br />
                            Detalle_P:
                            <asp:Label ID="Detalle_PLabel" runat="server" Text='<%# Eval("Detalle_P") %>' />
                            <br />
                            Imagen_P:
                            <asp:Label ID="Imagen_PLabel" runat="server" Text='<%# Eval("Imagen_P") %>' />
                            <br />
                            IdMarca_P:
                            <asp:Label ID="IdMarca_PLabel" runat="server" Text='<%# Eval("IdMarca_P") %>' />
                            <br />
                            PrecioUnitario_P:
                            <asp:Label ID="PrecioUnitario_PLabel" runat="server" Text='<%# Eval("PrecioUnitario_P") %>' />
                            <br />
                            Stock_P:
                            <asp:Label ID="Stock_PLabel" runat="server" Text='<%# Eval("Stock_P") %>' />
                            <br />
                        </td>
                    </AlternatingItemTemplate> --%>
                    <EditItemTemplate>
                        <td runat="server" style="background-color: #FFCC66;color: #000080;">Nombre_P:
                            <asp:TextBox ID="Nombre_PTextBox" runat="server" Text='<%# Bind("Nombre_P") %>' />
                            <br />
                            Detalle_P:
                            <asp:TextBox ID="Detalle_PTextBox" runat="server" Text='<%# Bind("Detalle_P") %>' />
                            <br />
                            Imagen_P:
                            <asp:TextBox ID="Imagen_PTextBox" runat="server" Text='<%# Bind("Imagen_P") %>' />
                            <br />
                            IdMarca_P:
                            <asp:TextBox ID="IdMarca_PTextBox" runat="server" Text='<%# Bind("IdMarca_P") %>' />
                            <br />
                            PrecioUnitario_P:
                            <asp:TextBox ID="PrecioUnitario_PTextBox" runat="server" Text='<%# Bind("PrecioUnitario_P") %>' />
                            <br />
                            Stock_P:
                            <asp:TextBox ID="Stock_PTextBox" runat="server" Text='<%# Bind("Stock_P") %>' />
                            <br />
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                        </td>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                            <tr>
                                <td>No se han devuelto datos.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <td runat="server" style="">Nombre_P:
                            <asp:TextBox ID="Nombre_PTextBox" runat="server" Text='<%# Bind("Nombre_P") %>' />
                            <br />Detalle_P:
                            <asp:TextBox ID="Detalle_PTextBox" runat="server" Text='<%# Bind("Detalle_P") %>' />
                            <br />Imagen_P:
                            <asp:TextBox ID="Imagen_PTextBox" runat="server" Text='<%# Bind("Imagen_P") %>' />
                            <br />IdMarca_P:
                            <asp:TextBox ID="IdMarca_PTextBox" runat="server" Text='<%# Bind("IdMarca_P") %>' />
                            <br />PrecioUnitario_P:
                            <asp:TextBox ID="PrecioUnitario_PTextBox" runat="server" Text='<%# Bind("PrecioUnitario_P") %>' />
                            <br />Stock_P:
                            <asp:TextBox ID="Stock_PTextBox" runat="server" Text='<%# Bind("Stock_P") %>' />
                            <br />
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                        </td>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <td runat="server" style="background-color: #FFFBD6;color: #333333;">
                            <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl='<%# Eval("Imagen_P") %>' />
                            <br />
                            <asp:Label ID="Nombre_PLabel" runat="server" Text='<%# Eval("Nombre_P") %>' />
                            <br />
                            <asp:Label ID="Descripcion_PLabel" runat="server" Text='<%# Eval("Detalle_P") %>'></asp:Label>
                            &nbsp;<br />
                            <asp:Label ID="IdMarca_PLabel" runat="server" Text='<%# Eval("Nombre_M") %>' />
                            <br />
                            <asp:Label ID="PrecioUnitario_PLabel" runat="server" Text='<%# Eval("PrecioUnitario_P") %>' />
                            <br />
                            <asp:Label ID="Stock_PLabel" runat="server" Text='<%# Eval("Stock_P") %>' />
                            <br />
                            Cantidad:
                            <asp:DropDownList ID="ddlCantidad" runat="server" Width="61px">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Button ID="btnAgregar" runat="server" CommandArgument='<%# Eval("Nombre_P")+";"+Eval("PrecioUnitario_P") %>' OnCommand="btnAgregar_Command" Text="Agregar al carrito" />
                            <br />
                        </td>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server"></td>
                            </tr>
                        </table>
                        <div style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
                        </div>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <td runat="server" style="background-color: #FFCC66;font-weight: bold;color: #000080;">Nombre_P:
                            <asp:Label ID="Nombre_PLabel" runat="server" Text='<%# Eval("Nombre_P") %>' />
                            <br />
                            Detalle_P:
                            <asp:Label ID="Detalle_PLabel" runat="server" Text='<%# Eval("Detalle_P") %>' />
                            <br />
                            Imagen_P:
                            <asp:Label ID="Imagen_PLabel" runat="server" Text='<%# Eval("Imagen_P") %>' />
                            <br />
                            IdMarca_P:
                            <asp:Label ID="IdMarca_PLabel" runat="server" Text='<%# Eval("IdMarca_P") %>' />
                            <br />
                            PrecioUnitario_P:
                            <asp:Label ID="PrecioUnitario_PLabel" runat="server" Text='<%# Eval("PrecioUnitario_P") %>' />
                            <br />
                            Stock_P:
                            <asp:Label ID="Stock_PLabel" runat="server" Text='<%# Eval("Stock_P") %>' />
                            <br />
                        </td>
                    </SelectedItemTemplate>
                </asp:ListView>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="width: 20%; text-align: center">
                            <asp:Label ID="lblNoStock" runat="server" ForeColor="Red"></asp:Label>
                            <br />
                            <asp:Label ID="lblNoIniciaSesion" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <br />
                <asp:Label ID="lblstock" runat="server" ForeColor="White"></asp:Label>
&nbsp;
                &nbsp;
                </div>
    <p>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TpIntegradorGrupo3ConnectionString %>" SelectCommand="SELECT [Nombre_P], [Detalle_P], [Imagen_P], [IdMarca_P], [PrecioUnitario_P], [Stock_P], [Estado_P] FROM [Productos] WHERE ([Estado_P] = @Estado_P)">
             <SelectParameters>
                 <asp:Parameter DefaultValue="True" Name="Estado_P" Type="Boolean" />
             </SelectParameters>
         </asp:SqlDataSource>
    </form>
    </body>
</html>

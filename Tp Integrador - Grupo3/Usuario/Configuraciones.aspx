<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configuraciones.aspx.cs" Inherits="Tp_Integrador___Grupo3.Configuraciones" %>

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
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            width: 409px;
            text-align: right;
        }
        .auto-style6 {
            width: 375px;
        }
        .auto-style8 {
            width: 238px;
            text-align: right;
        }
        .auto-style23 {
            margin-left: 5px;
        }
        .auto-style21 {
            margin-left: 3px;
            margin-top: 3px;
        }
        .auto-style30 {
            text-align: center;
        }
        .auto-style31 {
            width: 382px;
        }
        .auto-style32 {
            width: 409px;
            text-align: right;
            height: 30px;
        }
        .auto-style33 {
            width: 375px;
            height: 30px;
        }
        .auto-style34 {
            width: 238px;
            text-align: right;
            height: 30px;
        }
        .auto-style35 {
            width: 382px;
            height: 30px;
            text-align: left;
        }
        .auto-style36 {
            width: 409px;
            text-align: right;
            height: 31px;
        }
        .auto-style37 {
            width: 375px;
            height: 31px;
        }
        .auto-style38 {
            width: 238px;
            text-align: right;
            height: 31px;
        }
        .auto-style39 {
            width: 382px;
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    &nbsp;</td>
                <td style="width:65%" class="auto-style30">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Usuario/Carrito.aspx">Carrito</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Usuario/MiCuenta.aspx">Mi Cuenta</asp:HyperLink>
                </td>
            </tr>
        <div>
        </div>
 
        </table>
                <h1 class="auto-style3">CONFIGURACIONES</h1>
        <table class="auto-style4">
            <tr>
                <td class="auto-style36"><strong>&nbsp;Usuario:</strong></td>
                <td class="auto-style37">
                        <asp:TextBox ID="txtId" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Height="17px" Width="285px" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style38"><strong>Dirección:</strong></td>
                <td class="auto-style39">
                        <asp:TextBox ID="txtDireccion" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" CssClass="auto-style23" Height="16px" Width="285px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style5"><strong>Nombre:</strong></td>
                <td class="auto-style6">
                        <asp:TextBox ID="txtNombre" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Height="16px" Width="285px"></asp:TextBox>
                    </td>
                <td class="auto-style8"><strong>&nbsp;Email:</strong></td>
                <td class="auto-style31">
                        <asp:TextBox ID="txtEmail" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" CssClass="auto-style21" Height="16px" Width="285px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style32"><strong>Apellido:</strong></td>
                <td class="auto-style33">
                        <asp:TextBox ID="xtApellido" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Height="16px" Width="285px"></asp:TextBox>
                    </td>
                <td class="auto-style34">&nbsp;</td>
                <td class="auto-style35">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
            </tr>
            <tr>
                <td class="auto-style5"><strong>Fecha de nacimiento:</strong></td>
                <td class="auto-style6">Dia:&nbsp;<asp:DropDownList ID="ddlDia" runat="server" Height="17px" Width="61px">
                        </asp:DropDownList>
&nbsp;&nbsp;Mes:<asp:DropDownList ID="ddlMes" runat="server" Height="16px" Width="60px">
                        </asp:DropDownList>
&nbsp;&nbsp;&nbsp; Año:
                        <asp:DropDownList ID="ddlAño" runat="server" Height="21px" Width="60px">
                        </asp:DropDownList>
                        </td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style31">
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"><strong>Telefono:</strong></td>
                <td class="auto-style6">
                        <asp:TextBox ID="txtTel" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Height="16px" Width="285px"></asp:TextBox>
                    </td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style31">&nbsp;</td>
            </tr>
        </table>
        <p class="auto-style30">
            <strong>Introduzca contraseña para validar modificacion</strong></p>
        <p class="auto-style30">
            <asp:TextBox ID="txtContraseñaVal" runat="server" TextMode="Password" Width="169px"></asp:TextBox>
        </p>
        <p class="auto-style30">
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnModificar" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Text="Guardar Cambios" OnClick="btnModificar_Click" />
            &nbsp;&nbsp;
            <asp:Label ID="lblCambiarPass" runat="server"></asp:Label>
            </strong>
        </p>
        <p class="auto-style30">
            <asp:Label ID="lblConfiguracion" runat="server"></asp:Label>
        </p>
        <p class="auto-style30">
            &nbsp;</p>
    </form>
</body>
</html>

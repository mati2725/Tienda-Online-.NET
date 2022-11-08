<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Tp_Integrador___Grupo3.IniciarSesion" %>

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
            width: 622px;
            text-align: right;
            font-size: large;
        }
        .auto-style29 {
            margin-left: 7px;
            margin-bottom: 0px;
        }
        .auto-style30 {
            text-align: center;
        }
        .auto-style31 {
            font-weight: bold;
            margin-right: 0px;
        }
        .auto-style32 {
            text-align: left;
        }
        .auto-style33 {
            margin-left: 0px;
        }
        .auto-style34 {
            width: 68%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <br />
            <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    <asp:Button ID="Button3" runat="server" Height="26px" OnClick="Button3_Click" Text="Todos los productos" Width="182px" />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Todas las categorias" OnClick="Button1_Click" Height="26px" Width="182px" />
                </td>
                <td class="auto-style34">
                    <asp:TextBox ID="TextBox1" runat="server" Width="70%"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registrarse.aspx">Registrarse</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/IniciarSesion.aspx">Iniciar Sesión</asp:HyperLink>
                </td>
            </tr>
        </table>
                <h1 class="auto-style3">INICIAR SESIÓN</h1>
        <div>
            <table class="auto-style4">
                <tr>
                    <td class="auto-style5"><strong>&nbsp;Usuario:</strong></td>
                    <td class="auto-style32">&nbsp;
                        <asp:TextBox ID="txtId" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Height="16px" Width="277px" CssClass="auto-style33"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>Contraseña:</strong></td>
                    <td class="auto-style32">
                        <asp:TextBox ID="txtContraseña" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" CssClass="auto-style29" Height="17px" TextMode="Password" Width="278px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
            <p class="auto-style30">
                <strong>
                <asp:Button ID="btnIniciarSesion" runat="server" BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style31" ForeColor="Black" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" />
                </strong>
            </p>
            <p class="auto-style30">
                <asp:Label ID="lblLogin" runat="server"></asp:Label>
            </p>
            <p class="auto-style30">
                &nbsp;</p>
    </form>
    <p class="auto-style30">
&nbsp;</p>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Tp_Integrador___Grupo3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
            background-color: #00CC99;
        }
        .auto-style3 {
            font-size: xx-large;
            color: #000000;
            height: 35px;
        }
        .auto-style21 {
            margin-left: 3px;
            margin-top: 3px;
        }
        .auto-style22 {
            margin-left: 4px;
        }
        .auto-style23 {
            margin-left: 5px;
        }
        .auto-style25 {
            width: 100%;
        }
        .auto-style26 {
            width: 444px;
            text-align: right;
            font-size: x-large;
        }
        .auto-style27 {
            width: 577px;
            text-align: left;
        }
        .auto-style28 {
            width: 229px;
            text-align: right;
            font-size: x-large;
        }
        .auto-style29 {
            margin-left: 4px;
            margin-bottom: 0px;
        }
        .auto-style30 {
            font-weight: bold;
            font-size: small;
            margin-bottom: 0px;
        }
        .auto-style31 {
            text-align: center;
        }
        .auto-style32 {
            text-align: left;
            width: 521px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">

            <br />

            <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    &nbsp;</td>
                <td style="width:65%">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/IniciarSesion.aspx">Iniciar Sesión</asp:HyperLink>
                </td>
            </tr>
        </table>

        <div class="auto-style31">
            <div class="auto-style2">
                <h1 class="auto-style3"><strong>REGISTRARSE</strong></h1>
            </div>
            <table class="auto-style25">
                <tr>

                    <td class="auto-style26"><strong>&nbsp;Usuario:</strong></td>
                    <td class="auto-style27">
                        <asp:TextBox ID="txtId" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Height="28px" Width="304px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtId" ErrorMessage="Ingrese Usuario">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style28"><strong>Dirección:</strong></td>
                    <td class="auto-style32">
                        <asp:TextBox ID="txtDireccion" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" CssClass="auto-style23" Height="28px" Width="304px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Ingrese Direccion">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style26"><strong>Nombre:</strong></td>
                    <td class="auto-style27">
                        <asp:TextBox ID="txtNombre" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Height="28px" Width="304px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Solo letras" ValidationExpression="[A-Za-z ]*">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvNombres" runat="server" ControlToValidate="txtNombre" ErrorMessage="Ingrese Nombre">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style28"><strong>Contraseña:</strong></td>
                    <td class="auto-style32">
                        <asp:TextBox ID="txtContraseña" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" CssClass="auto-style29" Height="28px" TextMode="Password" Width="304px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="Ingrese Contraseña">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style26"><strong>Apellido:</strong></td>
                    <td class="auto-style27">
                        <asp:TextBox ID="txtApellido" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Height="28px" Width="304px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtApellido" ErrorMessage="Solo letras" ValidationExpression="[A-Za-z ]*">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvApellidos" runat="server" ControlToValidate="txtApellido" ErrorMessage="Ingrese Apellido">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style28"><strong>Repetir contraseña:</strong></td>
                    <td class="auto-style32">
                        <asp:TextBox ID="txtRepContraseña" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" CssClass="auto-style22" Height="28px" TextMode="Password" Width="304px"></asp:TextBox>
                        <asp:CompareValidator ID="cvRepContraseña" runat="server" ControlToCompare="txtContraseña" ControlToValidate="txtRepContraseña" ErrorMessage="No coincide contraseña">*</asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="rfvRepContraseña" runat="server" ControlToValidate="txtRepContraseña" ErrorMessage="Repita Contraseña">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style26"><strong>Fecha de nacimiento:</strong></td>
                    <td class="auto-style27">Dia:&nbsp;
                        <asp:DropDownList ID="ddlDia" runat="server" Height="17px" Width="61px">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
&nbsp;Mes:
                        <asp:DropDownList ID="ddlMes" runat="server" Height="16px" Width="60px">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
&nbsp;&nbsp; Año:
                        <asp:DropDownList ID="ddlAño" runat="server" Height="21px" Width="66px">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvNacimiento" runat="server" ControlToValidate="ddlDia" ErrorMessage="Ingrese Dia">*</asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvMes" runat="server" ControlToValidate="ddlMes" ErrorMessage="Ingrese Mes">*</asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvAnio" runat="server" ControlToValidate="ddlAño" ErrorMessage="Ingrese Año">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style28"><strong>Email:</strong></td>
                    <td class="auto-style32">
                        <asp:TextBox ID="txtEmail" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" CssClass="auto-style21" Height="28px" Width="304px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Ingrese mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Llene el campo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style26"><strong>Telefono:</strong></td>
                    <td class="auto-style27">
                        <asp:TextBox ID="txtTel" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Height="28px" Width="304px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTel" ErrorMessage="Solo Numeros" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTel" ErrorMessage="Ingrese Telefono">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style28"><strong>DNI:</strong></td>
                    <td class="auto-style32">
                        <asp:TextBox ID="txtDni" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" CssClass="auto-style22" Height="28px" Width="304px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="refDni" runat="server" ControlToValidate="txtDni" ErrorMessage="Solo Numeros" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni" ErrorMessage="Ingrese DNI">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
        <p>
            </p>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
        <p class="auto-style31">
            <strong>
            <asp:Button ID="btnRegistrar" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" CssClass="auto-style30" Height="36px" Text="Registrarse" Width="106px" OnClick="btnRegistrar_Click" />
            </strong>
        </p>
            <p class="auto-style31">
                <asp:Label ID="lblRegistro" runat="server"></asp:Label>
        </p>
            <p class="auto-style31">
                &nbsp;</p>
            <p class="auto-style31">
                &nbsp;</p>
            <p class="auto-style31">
                &nbsp;</p>
            <p class="auto-style31">
                &nbsp;</p>
            <p class="auto-style31">
                &nbsp;</p>
            <p class="auto-style31">
                &nbsp;</p>
    </form>
</body>
</html>

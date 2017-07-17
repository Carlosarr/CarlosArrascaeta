<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmClientes.aspx.cs" Inherits="FrmClientes" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 600px; height: 63px">
        <tr>
            <td style="width: 394267px">
            </td>
            <td style="width: 5119px">
                ABM Clientes<br />
            </td>
            <td style="width: 744169px">
            </td>
            <td style="width: 957038px">
            </td>
        </tr>
        <tr>
            <td style="width: 394267px; height: 34px;">
                </td>
            <td style="width: 5119px; height: 34px;">
                <asp:Label ID="lblCedula" runat="server" Text="Cedula"></asp:Label></td>
            <td style="width: 744169px; height: 34px;">
                <asp:TextBox ID="txtCi" runat="server" OnTextChanged="txtCi_TextChanged" AutoPostBack="True"></asp:TextBox></td>
            <td style="width: 957038px; height: 34px;">
            </td>
        </tr>
        <tr>
            <td style="width: 394267px; height: 30px">
                </td>
            <td style="width: 5119px; height: 30px">
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" Width="36px"></asp:Label></td>
            <td style="width: 744169px; height: 30px">
                <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox></td>
            <td style="width: 957038px; height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 394267px; height: 33px">
                </td>
            <td style="width: 5119px; height: 33px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label></td>
            <td style="width: 744169px; height: 33px">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
            <td style="width: 957038px; height: 33px">
            </td>
        </tr>
        <tr>
            <td style="width: 394267px; height: 41px;">
                </td>
            <td style="width: 5119px; height: 41px;">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label></td>
            <td style="width: 744169px; height: 41px;">
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td>
            <td style="width: 957038px; height: 41px;">
            </td>
        </tr>
        <tr>
            <td style="width: 394267px">
                </td>
            <td style="width: 5119px">
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label></td>
            <td style="width: 744169px">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox></td>
            <td style="width: 957038px">
            </td>
        </tr>
        <tr>
            <td style="width: 394267px; height: 38px;">
                </td>
            <td style="width: 5119px; height: 38px;">
                <asp:Label ID="lblCi_Admini" runat="server" Text="Ci Administrativo"></asp:Label></td>
            <td style="width: 744169px; height: 38px;">
                <asp:Label ID="lblAdministrativo" runat="server"></asp:Label></td>
            <td style="width: 957038px; height: 38px;">
            </td>
        </tr>
        <tr>
            <td style="width: 394267px; height: 42px">
                </td>
            <td style="width: 5119px; height: 42px">
                <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label></td>
            <td style="width: 744169px; height: 42px">
                <asp:TextBox ID="txtTel" runat="server"></asp:TextBox></td>
            <td style="width: 957038px; height: 42px">
                <br />
                </td>
        </tr>
        <tr>
            <td style="width: 394267px; height: 3px">
                </td>
            <td style="width: 5119px; height: 3px">
                <asp:Label ID="lblVehiculos" runat="server" Text="Vehiculo Matricula" Width="124px"></asp:Label></td>
            <td style="width: 744169px; height: 3px" align="left" valign="top">
                <br />
                <asp:DropDownList ID="drpVehiculos" runat="server" Width="159px">
                </asp:DropDownList><br />
                <asp:Label ID="lblVehiculos2" runat="server"></asp:Label></td>
            <td style="width: 957038px; height: 3px">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FrmVehiculo.aspx">Para agregar un nuevo Vehiculo, haga click aqui.</asp:HyperLink><br />
                </td>
        </tr>
        <tr>
            <td style="width: 394267px; height: 26px">
                </td>
            <td style="width: 5119px; height: 26px">
                </td>
            <td style="width: 744169px; height: 26px">
            </td>
            <td style="width: 957038px; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 394267px; height: 26px">
                </td>
            <td align="center" colspan="2" style="height: 26px">
                <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar"
                    Width="70px" />
                <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar"
                    Width="70px" />
                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar"
                    Width="67px" /></td>
            <td style="width: 957038px; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 394267px; height: 26px">
                </td>
            <td style="width: 5119px; height: 26px">
                </td>
            <td style="width: 744169px; height: 26px">
            </td>
            <td style="width: 957038px; height: 26px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 21px">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


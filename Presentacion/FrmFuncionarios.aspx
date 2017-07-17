<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmFuncionarios.aspx.cs" Inherits="FrmFuncionarios" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 699px; height: 115px">
        <tr>
            <td style="width: 243px; height: 33px">
            </td>
            <td style="width: 194px; height: 33px">
            </td>
            <td style="width: 194px; height: 33px">
            </td>
            <td style="width: 340px; height: 33px">
            </td>
            <td style="width: 278px; height: 33px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 47px;">
            </td>
            <td style="width: 194px; height: 47px;">
                <asp:Label ID="Label2" runat="server" Text="Tipo de Funcionario"></asp:Label></td>
            <td style="width: 194px; height: 47px;" align="center" valign="middle">
                <asp:RadioButtonList ID="rbdTipoDeFuncionario" runat="server" AppendDataBoundItems="True"
                    AutoPostBack="True" Height="31px" RepeatDirection="Horizontal" Width="160px" OnSelectedIndexChanged="rbdTipoDeFuncionario_SelectedIndexChanged">
                    <asp:ListItem>Administrativo</asp:ListItem>
                    <asp:ListItem>Mecanico</asp:ListItem>
                </asp:RadioButtonList></td>
            <td style="width: 340px; height: 47px;">
            </td>
            <td style="width: 278px; height: 47px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px">
            </td>
            <td style="width: 194px">
            </td>
            <td style="width: 194px">
            </td>
            <td style="width: 340px">
            </td>
            <td style="width: 278px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 22px">
            </td>
            <td style="width: 194px; height: 22px">
                <asp:Label ID="Label1" runat="server" Text="Cedula"></asp:Label>
            </td>
            <td style="width: 194px; height: 22px" align="center">
                <asp:TextBox ID="txtCedula" runat="server" AutoPostBack="True" OnTextChanged="txtCedula_TextChanged"></asp:TextBox></td>
            <td style="width: 340px; height: 22px">
            </td>
            <td style="width: 278px; height: 22px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 29px">
            </td>
            <td style="width: 194px; height: 29px">
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label></td>
            <td style="width: 194px; height: 29px" align="center">
                <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox></td>
            <td style="width: 340px; height: 29px">
            </td>
            <td style="width: 278px; height: 29px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 29px">
            </td>
            <td style="width: 194px; height: 29px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label></td>
            <td style="width: 194px; height: 29px" align="center">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
            <td style="width: 340px; height: 29px">
            </td>
            <td style="width: 278px; height: 29px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 25px">
            </td>
            <td style="width: 194px; height: 25px">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label></td>
            <td style="width: 194px; height: 25px" align="center">
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td>
            <td style="width: 340px; height: 25px">
            </td>
            <td style="width: 278px; height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 25px">
            </td>
            <td style="width: 194px; height: 25px">
                &nbsp;<asp:Label ID="lblSueldo" runat="server" Text="Sueldo"></asp:Label></td>
            <td style="width: 194px; height: 25px" align="center">
                <asp:TextBox ID="txtSueldo" runat="server"></asp:TextBox></td>
            <td style="width: 340px; height: 25px">
            </td>
            <td style="width: 278px; height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 19px">
            </td>
            <td style="width: 194px; height: 19px">
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
            </td>
            <td style="width: 194px; height: 19px" align="center">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox></td>
            <td style="width: 340px; height: 19px">
            </td>
            <td style="width: 278px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 45px">
            </td>
            <td style="width: 194px; height: 45px">
                <asp:Label ID="lblNivelDeInstruccion" runat="server" Text="NivelDeInstruccion"></asp:Label></td>
            <td style="width: 194px; height: 45px" align="center">
                <asp:TextBox ID="txtNivelDeInstruccion" runat="server"></asp:TextBox></td>
            <td style="width: 340px; height: 45px">
                </td>
            <td style="width: 278px; height: 45px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 33px">
            </td>
            <td style="width: 194px; height: 33px">
                <asp:Label ID="Label3" runat="server" Text="Telefono"></asp:Label></td>
            <td align="center" style="width: 194px; height: 33px">
                <asp:TextBox ID="txtNumeroTelefono" runat="server" Width="140px"></asp:TextBox>&nbsp;
            </td>
            <td style="width: 340px; height: 33px">
            </td>
            <td style="width: 278px; height: 33px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 32px">
            </td>
            <td style="width: 194px; height: 32px">
                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad"></asp:Label></td>
            <td align="center" style="width: 194px; height: 32px">
                <asp:TextBox ID="txtEspecialidad" runat="server"></asp:TextBox></td>
            <td style="width: 340px; height: 32px">
            </td>
            <td style="width: 278px; height: 32px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 32px">
            </td>
            <td style="width: 194px; height: 32px">
                <asp:Label ID="lblSustituto" runat="server" Text="Sustituto"></asp:Label></td>
            <td colspan="2" style="height: 32px">
                <asp:DropDownList ID="drpSustituto" runat="server" Width="317px" OnSelectedIndexChanged="drpSustituto_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 278px; height: 32px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 22px">
            </td>
            <td style="width: 194px; height: 22px">
            </td>
            <td align="center" style="width: 194px; height: 22px">
            </td>
            <td style="width: 340px; height: 22px">
            </td>
            <td style="width: 278px; height: 22px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 24px">
            </td>
            <td align="center" colspan="2" style="height: 24px">
                <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />&nbsp;<asp:Button
                    ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" /></td>
            <td style="width: 340px; height: 24px">
            </td>
            <td style="width: 278px; height: 24px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 32px">
                <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label></td>
            <td align="center" colspan="1" style="width: 278px; height: 32px">
            </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmVehiculo.aspx.cs" Inherits="FrmVehiculo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 669px; height: 168px">
        <tr>
            <td style="width: 81px">
            </td>
            <td style="width: 97px">
            </td>
            <td style="width: 424px">
            </td>
        </tr>
        <tr>
            <td style="width: 81px">
            </td>
            <td style="width: 97px">
                <asp:Label ID="lblMatricula" runat="server" Text="Matricula"></asp:Label></td>
            <td style="width: 424px">
                <asp:TextBox ID="txtMatricula" runat="server" OnTextChanged="txtMatricula_TextChanged" AutoPostBack="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 81px">
            </td>
            <td style="width: 97px">
                <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label></td>
            <td style="width: 424px">
                <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 81px; height: 24px;">
            </td>
            <td style="width: 97px; height: 24px">
                <asp:Label ID="lblcliente" runat="server" Text="Cliente"></asp:Label></td>
            <td style="width: 424px; height: 24px;">
                <asp:DropDownList ID="drpClientes" runat="server" Width="156px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 81px">
            </td>
            <td style="width: 97px">
                <asp:Label ID="Modelo" runat="server" Text="Modelo"></asp:Label></td>
            <td style="width: 424px">
                <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 81px; height: 26px;">
            </td>
            <td style="width: 97px; height: 26px">
                <asp:Label ID="lblAño" runat="server" Text="Año"></asp:Label></td>
            <td style="width: 424px; height: 26px;">
                <asp:TextBox ID="txtAño" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 81px; height: 24px">
            </td>
            <td style="height: 24px; width: 97px;">
                <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" /></td>
            <td style="width: 424px; height: 24px">
                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
                <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" /></td>
        </tr>
        <tr>
            <td style="width: 81px">
            </td>
            <td colspan="2">
                &nbsp;
                <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 81px">
            </td>
            <td style="width: 97px">
                <asp:Label ID="lblFotos" runat="server" Text="Fotos"></asp:Label></td>
            <td style="width: 424px">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="189px" />
                <asp:Button ID="btnAgrgarFoto" runat="server" OnClick="btnAgrgarFoto_Click" Text="Subir" />
                <asp:Button ID="btnAgregarNuevaFoto" runat="server" OnClick="btnAgregarNuevaFoto_Click"
                    Text="Agregar foto nueva" Width="126px" /></td>
        </tr>
        <tr>
            <td style="width: 81px; height: 32px;">
            </td>
            <td style="height: 32px; width: 97px;">
            </td>
            <td style="width: 424px; height: 32px;">
                &nbsp;
               
                <asp:GridView ID="grdFotos" runat="server" AutoGenerateColumns="False" Height="56px"
                     Width="59px" OnSelectedIndexChanged="grdFotos_SelectedIndexChanged" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="IdFoto" HeaderText="Id" />
                        <asp:ImageField DataImageUrlField="DireccionFotos" HeaderText="FOTOS">
                        </asp:ImageField>
                        <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
                        <asp:CommandField SelectText="Modificar" ShowSelectButton="True" />
                    </Columns>
                    <RowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td style="width: 81px; height: 32px">
            </td>
            <td colspan="2" style="height: 32px">
                Para volver a Consulta Clientes haga click
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FrmConsultaCliente.aspx">Aqui</asp:HyperLink></td>
        </tr>
    </table>
</asp:Content>


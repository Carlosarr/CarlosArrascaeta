<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmConsultaCliente.aspx.cs" Inherits="FrmConsultaCliente" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 581px; height: 355px">
        <tr>
            <td style="width: 3px">
                </td>
            <td style="width: 2px">
                Consulta de Servicios Por Rango de Fechas</td>
            <td style="width: 3px">
                </td>
        </tr>
        <tr>
            <td style="width: 3px">
                &nbsp; &nbsp; &nbsp; &nbsp; FECHA1:</td>
            <td style="width: 2px">
                <asp:TextBox ID="txtFecha1" runat="server" Width="108px"></asp:TextBox></td>
            <td style="width: 3px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
                &nbsp; &nbsp; &nbsp;&nbsp; FECHA2:</td>
            <td style="width: 2px">
                <asp:TextBox ID="txtFecha2" runat="server" Width="107px"></asp:TextBox></td>
            <td style="width: 3px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td style="width: 2px">
                <asp:GridView ID="grdServicios" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="190px" Width="250px">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
            <td style="width: 3px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td style="width: 2px">
                <asp:Label ID="lblMensaje" runat="server" Text="Mensaje"></asp:Label></td>
            <td style="width: 3px">
                <asp:Button ID="btnListar" runat="server" OnClick="btnListar_Click" Text="Button" /></td>
        </tr>
    </table>
</asp:Content>


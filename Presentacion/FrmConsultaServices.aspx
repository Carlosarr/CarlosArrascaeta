<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmConsultaServices.aspx.cs" Inherits="FrmConsultaServices" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 638px; height: 76px">
        <tr>
            <td style="width: 46px; height: 21px">
            </td>
            <td style="width: 1px; height: 21px">
                SERVICES</td>
            <td style="width: 1px; height: 21px">
                TRABAJOS</td>
        </tr>
        <tr>
            <td style="width: 46px; height: 21px">
            </td>
            <td rowspan="2" style="width: 1px">
                <asp:GridView ID="grdService" runat="server" OnSelectedIndexChanged="grdService_SelectedIndexChanged" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="164px" Width="394px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:BoundField DataField="Numero" HeaderText="num" />
                        <asp:BoundField DataField="Estado" HeaderText="estado" />
                        <asp:BoundField DataField="Fecha" HeaderText="fecha" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
            <td style="width: 1px; height: 21px">
                <asp:Label ID="lblNumService" runat="server" Font-Bold="True" Font-Italic="True"
                    Font-Size="Large"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 46px">
            </td>
            <td style="width: 1px">
                <asp:GridView ID="grdTrabajos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="182px" Width="355px">
                    <RowStyle ForeColor="#000066" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 46px">
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 1px">
            </td>
        </tr>
        <tr>
            <td style="width: 46px">
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 1px">
            </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmIngresoServicio.aspx.cs" Inherits="FrmIngresoServicio" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 600px; height: 63px">
        <tr>
            <td style="width: 5134px">
            </td>
            <td style="width: 1138px">
                Ingreso de Servicios<br />
            </td>
            <td style="width: 8222px">
            </td>
            <td style="width: 957038px">
                Services del Cliente</td>
        </tr>
        <tr>
            <td style="width: 5134px">
                <asp:Label ID="lblCedula" runat="server" Text="Ingrese aqui el documento del Cliente"></asp:Label></td>
            <td style="width: 1138px">
                <asp:TextBox ID="txtCi" runat="server" OnTextChanged="txtCi_TextChanged" AutoPostBack="True"></asp:TextBox></td>
            <td style="width: 8222px">
                <asp:Label ID="lblMensajeCliente" runat="server" Text="Mensaje" Width="36px"></asp:Label></td>
            <td style="width: 8222px">
                <asp:ListBox ID="lstServices" runat="server"></asp:ListBox></td>
           
        </tr>
        <tr>
            <td style="width: 5134px; height: 21px">
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" Width="36px"></asp:Label></td>
            <td style="width: 1138px; height: 21px">
                <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox></td>
            <td style="width: 8222px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 5134px; height: 26px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label></td>
            <td style="width: 1138px; height: 26px">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
            <td style="width: 8222px; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 5134px">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label></td>
            <td style="width: 1138px">
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td>
            <td style="width: 8222px">
            </td>
        </tr>
        <tr>
            <td style="width: 5134px">
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label></td>
            <td style="width: 1138px">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox></td>
            <td style="width: 8222px">
            </td>
        </tr>
        <tr>
            <td style="width: 5134px">
                <asp:Label ID="lblCi_Admini" runat="server" Text="Ci Administrativo"></asp:Label></td>
            <td style="width: 1138px">
                <asp:TextBox ID="txtCiAdmin" runat="server"></asp:TextBox></td>
            <td style="width: 8222px">
            </td>
            <td style="width: 957038px">
            </td>
        </tr>
        <tr>
            <td style="width: 5134px; height: 26px">
                <asp:Label ID="Label7" runat="server" Text="Tels"></asp:Label></td>
            <td style="width: 1138px; height: 26px">
                <asp:TextBox ID="txtTel" runat="server"></asp:TextBox></td>
            <td style="width: 8222px; height: 26px">
                </td>
            <td style="width: 957038px; height: 26px">
                <br />
                </td>
        </tr>
        <tr>
            <td style="width: 5134px; height: 26px">
                <asp:Label ID="lblVehiculos" runat="server" Text="Vehiculo Matricula"></asp:Label></td>
            <td style="width: 1138px; height: 26px">
                <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox></td>
            
            <td style="width: 957038px; height: 26px">
                <asp:ListBox ID="lstVehiculos" runat="server"></asp:ListBox><br />
                </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 26px">
                Si es correcto, complete los datos a a rellenar para el Servicio</td>
            <td style="width: 957038px; height: 26px">
                Elija una opcion:
                <br />
                <asp:Button ID="btnAgregarServicio" runat="server" OnClick="btnAgregar_Click" Text="Agregar Servicio"
                    Width="155px" /><br />
                <br />
                </td>
        </tr>
        <tr>
            <td style="width: 5134px; height: 26px">
                </td>
            <td style="width: 1138px; height: 26px">
                </td>
            <td style="width: 8222px; height: 26px">
                </td>
            <td style="width: 957038px; height: 26px">
                <asp:Label ID="lblMensajeServ" runat="server" Text="Mensaje" Width="36px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 5134px; height: 26px">
                Estado</td>
            <td style="width: 1138px; height: 26px">
                <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox></td>
            <td style="width: 8222px; height: 26px">
            </td>
            <td style="width: 957038px; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 5134px; height: 26px">
                Fecha</td>
            <td style="width: 1138px; height: 26px">
                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox></td>
            <td style="width: 8222px; height: 26px">
            </td>
            
        </tr>
        <tr>
            <td style="width: 5134px; height: 26px">
                Lista De Trabajos Disponibles<br />
                para Altas</td>
            <td style="width: 1138px; height: 26px">
                <asp:DropDownList ID="DrpTrabajos" runat="server" Width="174px">
                </asp:DropDownList></td>
            <td style="width: 8222px; height: 26px">
                <asp:TextBox ID="txtCodigo" runat="server">Su codigo de trabajo aparecer&#225; aqui</asp:TextBox></td>
            <td style="width: 957038px; height: 26px"></td>
        </tr>
        <tr>
            <td style="width: 5134px; height: 45px;">
                Matricula Para Servicio<br />
                </td>
            <td style="width: 1138px; height: 45px;">
                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DrpMatriculas"
                    runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 8222px; height: 45px;">
                </td>
            <td style="width: 957038px; height: 45px;">
                <asp:Button ID="btnConfAlta" runat="server" OnClick="btnConfAlta_Click" Text="Confirmar Alta"
                    Width="138px" /></td>
        </tr>
        <tr>
            <td style="width: 5134px; height: 21px">
            </td>
            <td style="width: 1138px; height: 21px">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label></td>
            <td style="width: 8222px; height: 21px">
            </td>
            <td style="width: 957038px; height: 21px">
                </td>
        </tr>
        <tr>
            <td style="width: 5134px; height: 21px">
            </td>
            <td style="width: 1138px; height: 21px">
            </td>
            <td style="width: 8222px; height: 21px">
            </td>
            <td style="width: 957038px; height: 21px">
                </td>
        </tr>
    </table>
</asp:Content>


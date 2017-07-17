using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Logica;
using EntidadesCompartidas;

public partial class MasterPageTallermaster : System.Web.UI.MasterPage
{
    protected void MostrarDatosADMIN()
    {
        Administrativo Nuevo_Adm = (Administrativo)Session["AdministrativoMaster"];
        lblCedula.Text = "ADMINISTRATIVO: ";
        lblContraseña.Text = Nuevo_Adm.Nombre.ToString() + " " + Nuevo_Adm.Apellido.ToString();
        CambiarBotones();
    }
    protected void MostrarDatosMECA()
    {
        Mecanico Nuevo_Meca = (Mecanico)Session["MecanicoMaster"];
        lblCedula.Text = "MECANICO: ";
        lblContraseña.Text = Nuevo_Meca.Nombre.ToString() + " " + Nuevo_Meca.Apellido.ToString();
        CambiarBotones();
    }
    protected void MostrarDatosCLI()
    {
        Cliente Nuevo_cli = (Cliente)Session["ClienteMaster"];
        lblCedula.Text = "CLIENTE: ";
        lblContraseña.Text = Nuevo_cli.Nombre.ToString() + " " + Nuevo_cli.Apellido.ToString();
        CambiarBotones();
    }

    protected void CambiarBotones()
    {
        btnIniciarSession.Visible = false;
        btnIniciarSession.Enabled = false;

        btnCerrarSession.Visible = true;
        btnCerrarSession.Enabled = true;

        //OCULTAR CAJAS DE TEXTO y radiobtn
        txtCedula.Visible = false;
        txtCedula.Enabled = false;
        txtContraseña.Visible = false;
        txtContraseña.Enabled = false;

        rbdTipoDePersona.Enabled = false;
        rbdTipoDePersona.Visible = false;
    }

    protected void ReiniciarBtns()
    {
        btnIniciarSession.Visible = true;
        btnIniciarSession.Enabled = true;

        btnCerrarSession.Visible = false;
        btnCerrarSession.Enabled = false;

        //OCULTAR CAJAS DE TEXTO y radiobtn
        txtCedula.Visible = true;
        txtCedula.Enabled = true;
        txtCedula.Text = "";

        txtContraseña.Visible = true;
        txtContraseña.Enabled = true;
        txtContraseña.Text = "";

        rbdTipoDePersona.Enabled = true;
        rbdTipoDePersona.Visible = true;
        rbdTipoDePersona.SelectedIndex = -1;

        lblCedula.Text = "Cedula";
        lblContraseña.Text = "Contraseña";
        lblError.Text = "";
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            MenuAdmin.Enabled = false;
            MenuAdmin.Visible = false;
            MenuConsulta.Visible = false;
            MenuConsulta.Enabled = false;
            MenuCliente.Visible = false;
            MenuCliente.Enabled = false;

            if (Session["AdministrativoMaster"] != null)
            {
                MostrarDatosADMIN();
                MenuAdmin.Enabled = true;
                MenuAdmin.Visible = true;
            }
            else
            if (Session["MecanicoMaster"] != null)
            {
                MostrarDatosMECA();
                MenuConsulta.Visible = true;
                MenuConsulta.Enabled = true;
            }
            else
            if (Session["ClienteMaster"] != null)
            {
                MostrarDatosCLI();
                MenuCliente.Visible = true;
                MenuCliente.Enabled = true;
                
            }
            
        }
        catch 
        {
            lblError.Text = "Error al cargar la pagina";
        }
    }
    protected void tnInicio_Click(object sender, EventArgs e)
    {
        string Contraseña;
        int Cedula;
        string TipoDePersona;

        try
        {
            Contraseña = txtContraseña.Text;
            Cedula = Convert.ToInt32(txtCedula.Text);
            TipoDePersona = Convert.ToString(rbdTipoDePersona.SelectedValue);

            if (TipoDePersona == "Administrativo")
            {
                Administrativo Nuevo_Adm = LogicaAdministrativo.LogueoAdministrativo(Cedula, Contraseña);

                Session["AdministrativoMaster"] = new Administrativo();
                Session["AdministrativoMaster"] = Nuevo_Adm;

                if (Nuevo_Adm == null)
                {
                    lblError.Text = "Cedula y/o Contraseña Incorrecta";
                }
                else
                {
                    //mostrar datos
                    MostrarDatosADMIN();

                    MenuAdmin.Visible = true;
                    MenuAdmin.Enabled = true;

                    lblError.Text = "";
                    Response.Redirect("FrmHome.aspx");
                }
            }
            else if (TipoDePersona == "Mecanico")
            {
                Mecanico Nuevo_Meca = LogicaMecanico.LogueoMecanico(Cedula, Contraseña);

                Session["MecanicoMaster"] = new Mecanico();
                Session["MecanicoMaster"]=Nuevo_Meca;

                if (Nuevo_Meca == null)
                {
                    lblError.Text = "Cedula y/o Contraseña Incorrecta";
                }
                else
                {
                    //mostrar datos
                    MostrarDatosMECA();
                    lblError.Text="";
                    MenuConsulta.Visible = true;
                    MenuConsulta.Enabled = true;
                    Response.Redirect("FrmHome.aspx");

                }
            }
            else if (TipoDePersona == "Cliente")
            {
                Cliente Nuevo_Cliente = LogicaCliente1.LogueoCliente(Cedula, Contraseña);

                Session["ClienteMaster"] = new Cliente();
                Session["ClienteMaster"] = Nuevo_Cliente;

                if (Nuevo_Cliente == null)
                {
                    lblError.Text = "Cedula y/o Contraseña Incorrecta";
                }
                else
                {
                    //mostrar datos
                    MostrarDatosCLI();
                    MenuCliente.Enabled = true;
                    MenuCliente.Visible = true;
                    lblError.Text="";
                    Response.Redirect("FrmHome.aspx");
                }
            }
            else
            {
                lblError.Text = "Debe identificarse como Admin..,Mecanico o Cliente";

            }
        }
        catch
        {
            lblError.Text = "Debe Ingresar Cedula y/o Contraseña";
        }
    }


    protected void btnCerrarSession_Click(object sender, EventArgs e)
    {
        try
        {
            MenuAdmin.Visible = false;
            MenuAdmin.Enabled = false;
            ReiniciarBtns();

            //borrar session
            Session["AdministrativoMaster"] = null;
            Session["MecanicoMaster"] = null;
            Session["ClienteMaster"] = null;

            Response.Redirect("FrmHome.aspx");
        }
        catch
        {
            lblError.Text = "No se puede cerrar session";
        }
    }
}

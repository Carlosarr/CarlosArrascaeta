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

using System.Collections.Generic;
using Logica;
using EntidadesCompartidas;

public partial class FrmIngresoServicio : System.Web.UI.Page
{
    public void LimpiarCuadros()
    {
        txtCi.Text = "";
        txtApellido.Text = "";
        txtContraseña.Text = "";
        txtNombre.Text = "";
        txtDireccion.Text = "";
        txtCiAdmin.Text = "";
        txtTel.Text = "";
        txtMatricula.Text = "";
        lstVehiculos.Items.Clear();
       
        
        txtFecha.Text = "";
        txtEstado.Text = "";
        DrpTrabajos.Items.Clear();
        

    }
   
    public void CasoAgregar()
    {
        txtCi.Enabled = false;
        txtApellido.Enabled = false;
        txtContraseña.Enabled = false;
        txtNombre.Enabled = false;
        txtDireccion.Enabled = false;
        txtCiAdmin.Enabled = false;
        txtTel.Enabled = false;
       
        lstVehiculos.Enabled = false;
        //trabajo
        
        txtEstado.Enabled = true;
        txtFecha.Enabled = true;
        DrpTrabajos.Enabled = true;
       // btnEliminar.Visible = false;
        //btnModificar.Visible = false;
    }

 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DrpTrabajos.DataSource = LogicaTrabajo.ListarTrabajosDisponibles();
            DrpTrabajos.DataTextField = "Descripcion";
            DrpTrabajos.DataValueField = "Codigo";
            DrpTrabajos.DataBind();



            txtCi.Enabled = true;
            txtApellido.Enabled = false;
            txtContraseña.Enabled = false;
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtCiAdmin.Enabled = false;
            txtTel.Enabled = false;
            
            lstVehiculos.Enabled = false;
            //trabajo
            
            txtEstado.Enabled = false;
            txtFecha.Enabled = false;
            DrpTrabajos.Enabled = false;
        }
    }

    protected void txtCi_TextChanged(object sender, EventArgs e)
    {
       

        try
        {

            Administrativo Admin_Logueado = (Administrativo)Session["AdministrativoMaster"];
            int oCedulaAdm = Admin_Logueado.Cedula;


           Cliente oResultado = LogicaCliente1.BuscarCliente(Convert.ToInt32(txtCi.Text), oCedulaAdm);
            if (oResultado==null)
            {
                lblError.Text = "No existe";
            }
            else
            {


                DrpMatriculas.DataSource = oResultado.Vehiculo;
                DrpMatriculas.DataTextField = "Matricula";
                DrpMatriculas.DataValueField = "Matricula";
                DrpMatriculas.DataBind();

                txtCi.Text = oResultado.Cedula.ToString();
                txtContraseña.Text = oResultado.Contraseña;
                txtNombre.Text = oResultado.Nombre;
                txtApellido.Text = oResultado.Apellido;
                txtDireccion.Text = oResultado.Direccion;
                txtTel.Text = oResultado.Telefono.ToString();

                lstVehiculos.DataSource = oResultado.Vehiculo;
                lstVehiculos.DataBind();
                 List<Service> ListaDeServices= LogicaService.ListarServicesDeClientes(oResultado.Cedula);

                 lstServices.DataSource = ListaDeServices;
                lstServices.DataBind();
               

                Session["Cliente"] = oResultado;
            }
        }
        catch (Exception oEx)
        {

            lblError.Text = "Problemas con cliente" + oEx.Message;
        }
    }
   
    
  


    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        CasoAgregar();
    }
   
    
    protected void btnConfAlta_Click(object sender, EventArgs e)
    {
        Cliente oCliente = (Cliente)Session["Cliente"];
        Administrativo Admin_Logueado = (Administrativo)Session["AdministrativoMaster"];
        
       
        List<Trabajo> oTRabxnull = null;
      string oEstado = txtEstado.Text;
        DateTime oFecha = Convert.ToDateTime(txtFecha.Text);
        Service oService = new Service(0, oEstado, oFecha, oCliente, Admin_Logueado, oTRabxnull);
        string oMat = DrpTrabajos.SelectedValue;
        int oCod = Convert.ToInt32(DrpTrabajos.SelectedValue); 
        try
        {
           int oResultado = LogicaService.AgregarService(oMat,oCod,oService);
           if (oResultado==1)
           {
               lblError.Text = "Alta con exito";
           }
           else
           {
               lblError.Text = "problemas con la transaccion 'Alta',intente mas tarde";
           }

        }
        catch (Exception oEx)
        {
            lblError.Text = "Problemas con la aplicacion al agregar service " + oEx.Message;
        }
    }
   
}

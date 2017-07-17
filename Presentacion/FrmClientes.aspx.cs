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

public partial class FrmClientes : System.Web.UI.Page
{
    public void DeshabilitarBnts()
    {
        btnModificar.Enabled = false;
        btnModificar.Visible = false;
        btnEliminar.Enabled = false;
        btnEliminar.Visible = false;
        btnAgregar.Visible= false;
        btnAgregar.Enabled = false;
    }
    public void LimpiarCuadros()
    {
        txtCi.Text = "";
        txtApellido.Text = "";
        txtContraseña.Text = "";
        txtNombre.Text = "";
        txtDireccion.Text = "";
        lblAdministrativo.Visible = false;
        txtTel.Text = "";
        txtNombre.Text = "";
        

    }

    public void LimpiarCuadrosCaso2()
    {
        txtApellido.Text = "";
        txtContraseña.Text = "";
        txtNombre.Text = "";
        txtDireccion.Text = "";
        lblAdministrativo.Visible = false;
        txtTel.Text = "";
        txtNombre.Text = "";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DeshabilitarBnts();

            //Administrativo Administrativo_Logueado = (Administrativo)Session["Administrativo"];
            //lblAdministrativo = Administrativo_Logueado.Cedula.ToString();
            Session["Cliente"] = new Cliente();
            

            //listar mecanicos
           // List<Vehiculo> listaDeVehiculos=LogicaVehiculo.ListarVehiculos();
            //drpVehiculos.DataSource = listaDeVehiculos;
           // drpVehiculos.DataBind();

            LimpiarCuadros();

          }

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {

            //atributos cliente
            int oCedula = 0;
            string oContraseña = "";
            string oNombre = "";
            string oApellido = "";
            string oDireccion = "";
            int oTelefono= 0000;
            List<Vehiculo> oVehiculos = null;//(List<Vehiculo>)Session["ListaVehiculos"];
            Administrativo oAdmin = null;
            string oerror = "";

            Cliente oCliente;
            try
            {
                oAdmin = (Administrativo)Session["AdministrativoMaster"];
               
                
            }
            catch
            {
                oerror += "problemas para reconocer la cedula, ";
            }

           
            
            
                oApellido = txtApellido.Text;
            if(oApellido=="")
            {
                oerror += "Debe ingresar un apellido, ";
            }
            
                oDireccion = txtDireccion.Text;

            if(oDireccion=="")
            {
                oerror += "Debe ingresar una direccion, ";
            }
            
                oContraseña = txtContraseña.Text;

            if(oContraseña=="")
            {
                oerror += "Debe ingresar una contraseña, ";
            }
             oNombre = txtNombre.Text;
            
            if(oNombre=="")
            {
                oerror += "Debe ingresar un nombre valido, ";
            }
            try
            {
                oTelefono = Convert.ToInt32(txtTel.Text);
            }
            catch
            {
                oerror += "No hay telefono valido, ";
            }
            try
            {
                oCedula = Convert.ToInt32(txtCi.Text);
            }
            catch
            {

                oerror += "La cedula no es un numero, ";
            }
            if (oerror != "")
            {
                lblError.Text = oerror;
            }
            else
            {
                try
                {
                    //construyo el nuevo objeto cliente
                    oCliente = new Cliente(oCedula, oContraseña, oNombre, oApellido, oDireccion, oAdmin, oVehiculos, oTelefono);

                    //agrego el cliente a la base de datos
                    int oResultado = LogicaCliente1.AgregarCliente(oCliente);

                    if ((oResultado == -4))
                    {
                        lblError.Text = "Cliente ya existe";
                    }
                    else if (oResultado == -3)
                    {
                        lblError.Text = "Cliente agregado con exito";
                    }
                }
                catch (Exception oEx)
                {
                    lblError.Text = "No se pudo agregar cliente" + oEx.Message;
                }
            }
        }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        
        try
        {
         int oResultado = LogicaCliente1.EliminarCliente(Convert.ToInt32(txtCi.Text));
           if (oResultado == -6)
           {
               lblError.Text = "El cliente no existe en la base de datos";
           }
           if (oResultado == -5)
           {
               lblError.Text = "Cliente con servicios 'en curso',baja no permitida ";
           }
           if(oResultado==1)
           {
               lblError.Text = "Eliminacion correcta";
               LimpiarCuadros();
               DeshabilitarBnts();
           }
           else
           {
               lblError.Text = "Problemas con la transaccion, intente mas tarde";
           }
        }
        catch (Exception oex)
        {

            lblError.Text = "Problemas con baja cliente" + oex.Message;
        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        Cliente oClienteMod = new Cliente();
        try
        {
            
            
            oClienteMod.Cedula = Convert.ToInt32(txtCi.Text);
            oClienteMod.Nombre = txtNombre.Text;
            oClienteMod.Contraseña = txtContraseña.Text;
            oClienteMod.Apellido = txtApellido.Text;
            oClienteMod.Direccion = txtDireccion.Text;
            
            oClienteMod.Telefono =Convert.ToInt32(txtTel.Text);
           
        }
        catch(Exception oEx)
        {
            lblError.Text = "Falta ingresar algun dato" + oEx.Message;
        }
       


        try
        {
            int oResultado = LogicaCliente1.ModificarCliente(oClienteMod);
            if (oResultado == -4)
            {
                lblError.Text = "El cliente no existe en la base de datos";
            }
            if (oResultado == 1)
            {
                lblError.Text = "Cliente Modificado correctamente ";
                LimpiarCuadros();
                DeshabilitarBnts();
            }
           
            else
            {
                lblError.Text = "Problemas con la transaccion modificar, intente mas tarde";
            }
        }
        catch (Exception oex)
        {

            lblError.Text = "Problemas con modifcacion cliente" + oex.Message;
        }
    }
    
    
    
    protected void txtCi_TextChanged(object sender, EventArgs e)
    {
        

        try
        {
            lblError.Text = "";
            Administrativo oAdmin = (Administrativo)Session["AdministrativoMaster"];
            lblAdministrativo.Text =  oAdmin.Cedula.ToString();

           Cliente oResultado = LogicaCliente1.BuscarCliente(Convert.ToInt32(txtCi.Text), oAdmin.Cedula);

            if (oResultado==null)
            {
                
                DeshabilitarBnts();
                btnAgregar.Enabled = true;
                btnAgregar.Visible = true;
                LimpiarCuadrosCaso2();
                drpVehiculos.Visible = false;
                lblVehiculos2.Text = "Ciente nuevo,No presenta Vehiculos";
                lblAdministrativo.Visible = true;


            }
            else
            {
                Session["Cliente"] = new Cliente();
                Session["Cliente"] = oResultado;
                txtCi.Text = oResultado.Cedula.ToString();
                txtContraseña.Text = oResultado.Contraseña;
                txtNombre.Text = oResultado.Nombre;
                txtApellido.Text = oResultado.Apellido;
                txtDireccion.Text = oResultado.Direccion;
                txtTel.Text = oResultado.Telefono.ToString();
                lblAdministrativo.Text = oAdmin.Nombre.ToString() + " " + oAdmin.Cedula.ToString();
                lblAdministrativo.Visible = true;
                drpVehiculos.DataSource = oResultado.Vehiculo;
                drpVehiculos.DataTextField = "Matricula";
                drpVehiculos.DataValueField = "Matricula";
                drpVehiculos.DataBind();

                btnEliminar.Enabled = true;
                btnEliminar.Visible = true;
                btnModificar.Enabled = true;
                btnModificar.Visible = true;
               

            }
        }
        catch (Exception oEx)
        {

            lblError.Text = "Problemas con cliente" + oEx.Message;
        }
    }
}


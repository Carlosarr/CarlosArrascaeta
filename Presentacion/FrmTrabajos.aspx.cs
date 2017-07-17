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
using System.Collections.Generic;

public partial class FrmTrabajos : System.Web.UI.Page
{

    protected void DeshabilitarBtns()
    {
        //deshabilitar botones
        btnAgregar.Enabled = false;
        btnEliminar.Enabled = false;
        btnMofdificar.Enabled = false;
        btnAgregar.Visible = false;
        btnEliminar.Visible = false;
        btnMofdificar.Visible = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DeshabilitarBtns();
        }
    }

    protected void txtCodigo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            DeshabilitarBtns();

            //Buscar si existe un trabajo con el codigo ingresado
            Trabajo Nuevo_Trabajo = LogicaTrabajo.BuscarTrabajo(Convert.ToInt32(txtCodigo.Text));

            //LISTAR MECANICOS EN EL DROP

                List<Mecanico> ListaDeMecanicos = LogicaMecanico.ListarMecanicos();
                drpMecanico.DataSource = ListaDeMecanicos;
                drpMecanico.DataTextField = "Etiqueta";
                drpMecanico.DataValueField = "Cedula";
                drpMecanico.DataBind();

                if (Nuevo_Trabajo != null)
                {
                    //mostar datos en el formulario
                    txtDescripcion.Text = Nuevo_Trabajo.Descripcion;
                  

                    

                    Session["Trabajo"] = Nuevo_Trabajo;

                    //mostrar datos
                    txtCodigo.Text = Nuevo_Trabajo.Codigo.ToString();
                    txtDescripcion.Text = Nuevo_Trabajo.Descripcion.ToString();

                   drpMecanico.SelectedValue = Convert.ToString(Nuevo_Trabajo.Mecanico.Cedula);

                    btnEliminar.Enabled = true;
                    btnEliminar.Visible = true;
                    btnMofdificar.Enabled = true;
                    btnMofdificar.Visible = true;
                }
                else
                {
                    btnEliminar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnMofdificar.Enabled = false;
                    btnMofdificar.Visible = false;
                    btnAgregar.Enabled = true;
                    btnAgregar.Visible = true;
                    txtDescripcion.Text = "";
                }
           
                 
        }
        catch
        {
            lblError.Text = "ERROR AL BUSCAR EL TRABAJO";
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        int Codigo=0;
        string Descripcion="";
        
        Mecanico mecanico = new Mecanico(); ;
        string Mensaje="Debe Ingresar: ";
        Trabajo Nuevo_Trabajo=null;
        

        Descripcion = txtDescripcion.Text;

        try
        {
            Codigo=Convert.ToInt32(txtCodigo.Text);
        }
        catch
        {
        }
        if (Descripcion == "")
        {
            Mensaje = Mensaje + "Descripcion, ";
        }

        try
        {
            mecanico.Cedula = Convert.ToInt32(drpMecanico.SelectedValue);
           
        }
        catch
        {
            Mensaje = Mensaje + "Mecanico, ";
        }

        if (Mensaje != "Debe Ingresar: ")
        {
            lblError.Text = Mensaje;
        }
        else
        {
            try
            {
                Nuevo_Trabajo = new Trabajo(Codigo, Descripcion, mecanico);
              
                    //agrego el trabajo a la base de datos
                    int respuesta = LogicaTrabajo.AgregarTrabajo(Nuevo_Trabajo);

                    if (respuesta == -1)
                    {
                        lblError.Text = "Trabajo ya existente en la BD";
                    }
                    else
                    {
                        lblError.Text = "Trabajo dado de alta correctamente";
                        txtDescripcion.Text = "";
                        txtCodigo.Text = "";
                    }
            }
                
            catch (Exception ex)
            {
                lblError.Text= "Problemas en el alta del Trabajo: " + ex.Message;
            
            }
            
        }

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Trabajo Nuevo_Trabajo = (Trabajo)Session["Trabajo"]; 
            int respuesta = LogicaTrabajo.EliminarTrabajo(Nuevo_Trabajo);

            if (respuesta == -1)
            {
                lblError.Text = "No existe el trabajo en la base de datos";
            }
            else
            {
                lblError.Text = "Trabajo dado de baja correctamente";
                txtDescripcion.Text = "";
                txtCodigo.Text = "";
            }
        }
        catch(Exception ex)
        {
            throw new Exception("PROLEMAS PARA ELIMINAR EL TRABAJO DE LA BD: " + ex.Message);
        }
    }

    protected void btnMofdificar_Click(object sender, EventArgs e)
    {
        int Codigo = 0;
        string Descripcion = "";
        
        Mecanico mecanico = new Mecanico(); ;
        string Mensaje = "Debe Ingresar: ";
        Trabajo Nuevo_Trabajo = null;


        Descripcion = txtDescripcion.Text;

        try
        {
            Codigo = Convert.ToInt32(txtCodigo.Text);
        }
        catch
        {
        }
        if (Descripcion == "")
        {
            Mensaje = Mensaje + "Descripcion, ";
        }

        try
        {
            mecanico.Cedula = Convert.ToInt32(drpMecanico.SelectedValue);
            
        }
        catch
        {
            Mensaje = Mensaje + "Mecanico, ";
        }

        if (Mensaje != "Debe Ingresar: ")
        {
            lblError.Text = Mensaje;
        }
        else
        {
            try
            {
                Nuevo_Trabajo = new Trabajo(Codigo, Descripcion, mecanico);

                //modifico el trabajo a la base de datos
                int respuesta = LogicaTrabajo.ModificarTrabajo(Nuevo_Trabajo);

                if (respuesta == -1)
                {
                    lblError.Text = "Trabajo encontrado en la BD";
                }
                else
                {
                    lblError.Text = "Trabajo Modificado correctamente";
                    txtDescripcion.Text = "";
                    txtCodigo.Text = "";
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Problemas en la modificacion del Trabajo: " + ex.Message);

            }

        }
    }
}

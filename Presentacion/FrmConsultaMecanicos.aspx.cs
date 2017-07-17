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

public partial class FrmConsultaMecanicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnConsultar_Click(object sender, EventArgs e)
    {

        string Fecha1="";
        string Fecha2="";

        Mecanico Mecanico_Logueado = (Mecanico)Session["MecanicoLogueado"];

        string mensaje="Debe ingresar: ";
        
        Fecha1= txtFecha1.Text;
        if(Fecha1=="")
        {
            mensaje=mensaje+"Fecha1, ";
        }
         
        Fecha2= txtFecha2.Text;
        if(Fecha2=="")
        {
            mensaje=mensaje+"Fecha2, ";
        }
        if(mensaje!="Debe ingresar: ")
        {
            lblError.Text=mensaje;
        }
        else
        {
            try
            {
                //buscar lista de trabajos por rango de fechas
                 List<Trabajo> ListaDeTrabajos = LogicaTrabajo.BuscarTrabajosPorRangoDeFechas(Convert.ToDateTime(Fecha1),Convert.ToDateTime(Fecha2),Mecanico_Logueado.Cedula);

                 if (ListaDeTrabajos != null)
                 {
                     //mostrar en la grilla
                     grdTrabajos.DataSource = ListaDeTrabajos;
                     grdTrabajos.DataBind();
                 }
                 else
                 {
                     lblError.Text = "No se han encontrado trabajos";
                 }
            }
            catch
            {
                lblError.Text = "PROBLEMAS PARA BUSCAR TRABAJOS EN LA BD";
            }
        }
        
           
        
    }
}

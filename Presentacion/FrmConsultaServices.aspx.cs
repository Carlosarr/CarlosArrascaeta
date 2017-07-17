using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntidadesCompartidas;
using Logica;

public partial class FrmConsultaServices : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Cliente Cliente_Logueado = (Cliente)Session["ClienteMaster"];

            List<Service> ListaDeServices = LogicaService.ListarServicesEnCurso(Cliente_Logueado.Cedula);

            Session["ListaDeServices"]=new List<Service>();
            Session["ListaDeServices"] = ListaDeServices;

            grdService.DataSource = ListaDeServices;
            grdService.DataBind();
        }
        catch
        {

        }
    }
    protected void grdService_SelectedIndexChanged(object sender, EventArgs e)
    {
       try{
         
           int num=Convert.ToInt32(grdService.SelectedRow.Cells[0].Text);
           lblNumService.Text = "Service numero: " + num;
           if (Session["ListaDeServices"] !=null)
           {
             List<Service>  ListaDeServices= (List<Service>)Session["ListaDeServices"] ;

             foreach (Service serv in ListaDeServices)
             {
                 if (serv.Numero == num)
                 {
                     grdTrabajos.DataSource = serv.Trabajos;
                     grdTrabajos.DataBind();
                 }
             }

            
           }
       }    
       catch
       {
       }
    }
}

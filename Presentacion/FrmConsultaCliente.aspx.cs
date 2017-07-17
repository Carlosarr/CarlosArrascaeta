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

public partial class FrmConsultaCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Cliente oCliente = (Cliente)Session["Cliente"];
       
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        Cliente oCliente = (Cliente)Session["ClienteMaster"];
        try
        {
            if (txtFecha1.Text== ""||txtFecha2.Text == "")
            {
                lblMensaje.Text = "Debe llenar las fechas";
            }
            List<Service> oLista = LogicaService.ListarServiciosDeClienteporRangoDeFechas(txtFecha1.Text, txtFecha2.Text, oCliente.Cedula);
            if (oLista == null)
            {
                lblMensaje.Text = "No hay servicios entre tales fechas";
            }
            else
            {
                grdServicios.DataSource = oLista;
                grdServicios.DataBind();
            }
        }
        catch (Exception oEx)
        {
            lblMensaje.Text = "Problemas al listar, intente mas tarde" + oEx.Message;
        }
    }
}

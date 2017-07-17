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

public partial class FrmConsultaVehiculos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                List<Vehiculo> ListaDeVehiculos = Logica.LogicaVehiculo.ListarVehiculos2();
                Session["ListaDeVehiculos"] = new List<Vehiculo>();
                Session["ListaDeVehiculos"] = ListaDeVehiculos;
                drpVehiculo.DataSource = ListaDeVehiculos;
                drpVehiculo.DataValueField = "Matricula";
                drpVehiculo.DataBind();
            }
        }
        catch
        {
        }
    }
    protected void drpVehiculo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string Matricula = drpVehiculo.SelectedValue;
            List<Vehiculo> ListaDeVehiculos = (List<Vehiculo>)Session["ListaDeVehiculos"];
            foreach (Vehiculo vehiculo in ListaDeVehiculos)
            {
                if (vehiculo.Matricula==Matricula)
                {
                    UserControlVehiculos1.MostrarVehiculo(vehiculo);
                }
            }
        }
        catch
        {
            
        }
    }
}

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
using EntidadesCompartidas;


public partial class UserControlVehiculos : System.Web.UI.UserControl
{
    public void MostrarVehiculo(Vehiculo vehiculo)
    {
        txtMatricula.Text = vehiculo.Matricula.ToString();
        txtModelo.Text = vehiculo.Modelo.ToString();
        txtMarca.Text = vehiculo.Marca.ToString();
        txtAño.Text = vehiculo.Ano.ToString();
        grdFotos.DataSource = vehiculo.Fotos;
        grdFotos.DataBind();
    }

    public void LimpiarUserControl()
    {
        txtMatricula.Text = "";
        txtModelo.Text = "";
        txtMarca.Text = "";
        txtAño.Text = "";
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtMatricula_TextChanged(object sender, EventArgs e)
    {

    }
}

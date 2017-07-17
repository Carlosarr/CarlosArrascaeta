using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

using EntidadesCompartidas;
using Logica;

public partial class FrmCupones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["Cupon"] = new Cupon();

                List<Cliente> ListaDeClientes = LogicaCliente1.ListarClientes();
                drpCiCliente.DataSource = ListaDeClientes;
                drpCiCliente.DataTextField = "Etiqueta";
                drpCiCliente.DataValueField = "Cedula";
                drpCiCliente.DataBind();
            }
        }
        catch
        {
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string mensaje="Debe ingresar: ";
        int Numero = 0;
        int Ci_Cliente = 0;
        DateTime Fecha = DateTime.Now;
        int Valor = 0;
        Cliente _cliente=new Cliente();

        try 
        {
            Numero = Convert.ToInt32(txtNumero.Text);
        }
        catch
        {
            mensaje = mensaje + "Numero, ";
        }
        try
        {
           Ci_Cliente = Convert.ToInt32(drpCiCliente.SelectedValue);
            _cliente.Cedula=Ci_Cliente;
        }
        catch
        {
            mensaje = mensaje + "Cedula del Cliente, ";
        }
        try
        {
            Fecha = Convert.ToDateTime(txtFecha.Text);
        }
        catch
        {
            mensaje = mensaje + "Fecha, ";
        }
        try
        {
            Valor = Convert.ToInt32(txtValor.Text);
        }
        catch
        {
            mensaje = mensaje + "Valor, ";
        }
        if (mensaje != "Debe ingresar: ")
        {
            lblerror.Text = mensaje;
        }
        else
        {
            try
            {
                Cupon Nuevo_Cupon = new Cupon(Numero, Fecha, Valor, _cliente);
            }
            catch
            {
                lblerror.Text = "No se pudo agregar el cupon";
            }
        }
    }
    protected void txtNumero_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Cupon Cupon_encontrado= LogicaCupon.BuscarCupon(Convert.ToInt32(txtNumero.Text));

            if (Cupon_encontrado == null)
            {

            }
            else
            {
                //subir cupon a session
                Session["Cupon"] = Cupon_encontrado;

                //mostrar datos en los txts
                txtNumero.Text =Cupon_encontrado.Numero.ToString();
                drpCiCliente.SelectedValue = Cupon_encontrado.Cliente.Cedula.ToString();
                txtFecha.Text = Cupon_encontrado.Fecha.ToString();
                txtValor.Text = Cupon_encontrado.Valor.ToString();
            }
        }
        catch
        {
            lblerror.Text = "No se pudo encontrar un cupon con ese numero";
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Cupon Cupon_Seleccionado = (Cupon)Session["Cupon"];

            int respuesta = LogicaCupon.EliminarCupon(Cupon_Seleccionado);

            if (respuesta == -1)
            {

            }
        }
        catch
        {

        }
    }

   
    protected void BtnXml_Click(object sender, EventArgs e)
    {
        int numero = 0;
        int ci_Cliente = 0;
        DateTime fecha = DateTime.Now;
        int valor = 0;
        bool bandera=false;
        try
        {
            numero = Convert.ToInt32(txtNumero.Text);
            ci_Cliente = Convert.ToInt32(drpCiCliente.SelectedValue);
            fecha = Convert.ToDateTime(txtFecha.Text);
            valor = Convert.ToInt32(txtValor.Text);
            bandera = true;
        }
        catch
        {
            lblerror.Text = "No se ha ingresado uno o varios datos";
        }
        if (bandera == true)
        {
            try
            {
                XmlDocument Nuevo_XML = new XmlDocument();
                Nuevo_XML.Load(Server.MapPath("Cupones.xml"));

                XmlNode raizCupon = Nuevo_XML.DocumentElement;

                XmlElement _Cupon = Nuevo_XML.CreateElement("Cupon");

                //Atributos
                XmlAttribute _numero = Nuevo_XML.CreateAttribute("Numero");
                _numero.Value = Convert.ToString(numero);
                _Cupon.Attributes.Append(_numero);

                XmlAttribute _ci_cliente = Nuevo_XML.CreateAttribute("Cliente");
                _ci_cliente.Value = Convert.ToString(ci_Cliente);
                _Cupon.Attributes.Append(_ci_cliente);

                XmlAttribute _fecha = Nuevo_XML.CreateAttribute("Fecha");
                _fecha.Value = Convert.ToString(fecha);
                _Cupon.Attributes.Append(_fecha);

                XmlAttribute _valor = Nuevo_XML.CreateAttribute("Valor");
                _valor.Value = Convert.ToString(valor);
                _Cupon.Attributes.Append(_valor);

                raizCupon.AppendChild(_Cupon);
                Nuevo_XML.Save(Server.MapPath("Cupones.xml"));

                lblerror.Text = "Datos exportados correctamente";

            }
            catch
            {
                lblerror.Text = "Problemas para crear los elementos xml";
            }
        }
    }
}

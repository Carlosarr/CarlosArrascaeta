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
using Logica;
using System.IO;

using System.Collections.Generic;

public partial class FrmVehiculo : System.Web.UI.Page
{
    protected void Deshabilitarbtns()
    {
        //deshabilitar botones
        btnAgregar.Enabled = false;
        btnAgregar.Visible = false;
        btnEliminar.Enabled = false;
        btnEliminar.Visible = false;
        btnModificar.Enabled = false;
        btnModificar.Visible = false;
        btnAgregarNuevaFoto.Visible = false;
        btnAgregarNuevaFoto.Enabled = false;
        btnAgrgarFoto.Enabled = false;
        btnAgrgarFoto.Visible = false;
        FileUpload1.Enabled = false;
        FileUpload1.Visible=false;
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        

            if (!IsPostBack)
            {
                
                btnAgregarNuevaFoto.Enabled = false;
                btnAgregarNuevaFoto.Visible = false;

                Session["encontrado"] = new int();
                Session["encontrado"] = 0;

                Deshabilitarbtns();
                
                Session["ListaDeFotos"] = new List<Foto>();

                if (Session["Vehiculo"] == null)
                {
                    Session["Vehiculo"] = new Vehiculo();
                }

                List<Cliente> ListaDeClientes = LogicaCliente1.ListarClientes();
                drpClientes.DataSource = ListaDeClientes;
                drpClientes.DataTextField = "Etiqueta";
                drpClientes.DataValueField = "Cedula";
                drpClientes.DataBind();

                txtModelo.Text = "";
                txtMarca.Text = "";
                txtAño.Text = "";
                txtMatricula.Text = "";
                grdFotos.Visible = false;
            }

            //if (Session["volver"] != null)
            //{
            //    int volver = (int)Session["volver"];

            //    if (volver == 1)
            //    {
            //        Vehiculo Vehiculo_Encontrado = (Vehiculo)Session["Vehiculo"];

            //        if (Vehiculo_Encontrado != null)
            //        {
            //            btnAgregarNuevaFoto.Enabled = true;
            //            btnAgregarNuevaFoto.Visible = true;

            //            //mostar fotos en grid
            //            grdFotos.Visible = true;

            //            Session["ListaDeFotos"] = LogicaVehiculo.ListarFotos(Vehiculo_Encontrado.Matricula);
            //            List<Foto> ListaDeFotos = (List<Foto>)Session["ListaDeFotos"];
            //            grdFotos.DataSource = ListaDeFotos;
            //            grdFotos.DataBind();

            //            //cambiar columna eliminar por modificar (de la grilla)
            //            grdFotos.Columns[2].Visible = false;
            //            grdFotos.Columns[3].Visible = true;


            //            //mostrar datos del vehiculo encontrado
            //            txtMatricula.Text = Vehiculo_Encontrado.Matricula.ToString();
            //            txtModelo.Text = Vehiculo_Encontrado.Modelo.ToString();
            //            txtMarca.Text = Vehiculo_Encontrado.Marca.ToString();
            //            txtAño.Text = Vehiculo_Encontrado.Ano.ToString();

            //            //habiliat botones de eliminar y modificar
            //            btnModificar.Enabled = true;
            //            btnModificar.Visible = true;
            //            btnEliminar.Enabled = true;
            //            btnEliminar.Visible = true;
            //        }
            //    }
            //}
    }
    protected void btnAgrgarFoto_Click(object sender, EventArgs e)
    {
      
        string Ruta = "";
        string NombreArchivoFoto = "";
        string RutaCompletaFoto = "";
        
       
        try
        {
            //Obtenemos la ruta donde el archivo se va a guardar en el servidor
            NombreArchivoFoto = Path.GetFileName(FileUpload1.PostedFile.FileName);

            RutaCompletaFoto = Server.MapPath("") + "/Imagenes/" + NombreArchivoFoto;

            //guardar imagen en mi carpeta
            FileUpload1.PostedFile.SaveAs(RutaCompletaFoto);
            
            Ruta = "~/Imagenes/" + NombreArchivoFoto;
            

            
            if (NombreArchivoFoto == "")
            {
                lblError.Text = "no ha ingresado ninguna foto";
            }
            else
            {
                List<Foto> ListaDeFotos=null;

                if(Session["ListaDeFotos"]==null)
                {
                   ListaDeFotos=new List<Foto>();
                
                }
                else
                {
                    ListaDeFotos=(List<Foto>)Session["ListaDeFotos"];
                }
                    Foto Nueva_foto = new Foto(Ruta);

                    ListaDeFotos.Add(Nueva_foto);
                    //subo a session
                    Session["ListaDeFotos"] = ListaDeFotos;

                    //muestro en grid
                    grdFotos.DataSource = ListaDeFotos;

                    grdFotos.DataBind();

                    grdFotos.Visible = true;
                
            }


        }
        catch
        {
            lblError.Text = "No ha ingresado  ninguna foto";
        }

       
    
    

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Vehiculo"] != null)
            {
                Vehiculo Vehiculo_Encontrado = (Vehiculo)Session["Vehiculo"];

                int respuesta = LogicaVehiculo.EliminarVehiculo(Vehiculo_Encontrado.Matricula);

                if (respuesta == -4)
                {
                    lblError.Text = "No existe el vehiculo";
                }
                else if (respuesta == -1 || (respuesta == -2) || (respuesta == -3))
                {
                    lblError.Text= "Error al eliminar el vehiculo";
                }
                else if (respuesta == 1)
                {
                    lblError.Text = "Vehiculo eliminado correctamente";

                    Deshabilitarbtns();
                    txtAño.Text = "";
                    txtModelo.Text = "";
                    txtMarca.Text = "";
                    Session["ListaDeFotos"] = null;
                    grdFotos.Visible = false;
                }
            }
                
        }
        catch
        {
            lblError.Text = "ERROR AL ALIMINAR EL VEHICULO DE LA BASE DE DATOS";
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        int Ci_Cliente = 000;
        string Matricula = "";
        string Modelo = "";
        string Marca = "";
        List<Foto> ListaDeFotos = null;
            
        string mensaje = "Debe ingresar: ";
        int año=000;
        try
        {
            Ci_Cliente =Convert.ToInt32(drpClientes.SelectedValue.ToString());
        }
        catch
        {
            mensaje = "problemas para reconocer el cliente, ";
        }
        try
        {
            ListaDeFotos = (List<Foto>)Session["ListaDeFotos"];

            
        }
        catch
        {
            mensaje = "problemas para encontrar la lista de fotos, ";
        }

        if(ListaDeFotos!=null)
        {
            if (ListaDeFotos.Count < 1)
            {
                mensaje = mensaje + "Fotos, ";
            }
        }

        if(ListaDeFotos == null)
        {
             mensaje = mensaje + "Fotos, ";
        }    
        
        
        try
        {
            año=Convert.ToInt32(txtAño.Text);
        }
        catch
        {
            mensaje = mensaje + "Año, ";
        }
        Matricula = txtMatricula.Text;
        if (Matricula == "")
        {
            mensaje = mensaje + "Matricula, ";
        }
        Modelo = txtModelo.Text;
        if (Modelo == "")
        {
            mensaje = mensaje + "Modelo, ";
        }
        Marca = txtMarca.Text;
        if (Marca == "")
        {
            mensaje = mensaje + "Marca, ";
        }
        if (mensaje == "Debe ingresar: ")
        {
            try
            {
                Vehiculo Nuevo_Vehiculo = new Vehiculo(Matricula, Marca, Modelo, año, ListaDeFotos);
                int respuesta=LogicaVehiculo.AgregarVehiculo(Nuevo_Vehiculo,Ci_Cliente);

                if (respuesta == 1)
                {
                    
                    //agregar fotos
                    if (Session["ListaDeFotos"] != null)
                    {
                        foreach (Foto foto in Nuevo_Vehiculo.Fotos)
                        {
                            int respid = LogicaVehiculo.AgregarFoto(Nuevo_Vehiculo.Matricula, foto.DireccionFotos);

                        }
                    }

                        lblError.Text = "Vehiculo Agregado Correctamente";
                        Session["ListaDeFotos"] = null;

                        txtAño.Text = "";
                        txtMarca.Text = "";
                        txtMatricula.Text = "";
                        txtModelo.Text = "";
                        Deshabilitarbtns();
                        grdFotos.Visible = false;
                    
                }
                else if (respuesta == -4)
                {
                    lblError.Text = "ya existe la matricula ingresada";
                }
                else if ((respuesta == -3) || (respuesta == -2))
                {
                    lblError.Text = "error al agregar el vehiculo";
                }
            }
            catch
            {
                lblError.Text = "No se pudo agregar el vehiculo";
            }
        }
        else
        {
            lblError.Text = mensaje;
        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        int Ci_Cliente = 000;
        string Matricula = "";
        string Modelo = "";
        string Marca = "";
        List<Foto> ListaDeFotos = null;
        string mensaje = "Debe ingresar: ";
        int año = 000;
        try
        {

            Ci_Cliente = Convert.ToInt32(drpClientes.SelectedValue);
        }
        catch
        {
            mensaje = "problemas para reconocer el cliente, ";
        }
        
        
        try
        {
            año = Convert.ToInt32(txtAño.Text);
        }
        catch
        {
            mensaje = mensaje + "Año, ";
        }
        //try
        //{
        //    ListaDeFotos = (List<Foto>)Session["ListaDeFotos"];
        //}
        //catch
        //{
        //    lblError.Text = "problemas para reconocer lista de fotos";
        //}
        Matricula = txtMatricula.Text;
        if (Matricula == "")
        {
            mensaje = mensaje + "Matricula, ";
        }
        Modelo = txtModelo.Text;
        if (Modelo == "")
        {
            mensaje = mensaje + "Modelo, ";
        }
        Marca = txtMarca.Text;
        if (Marca == "")
        {
            mensaje = mensaje + "Marca, ";
        }
        if (mensaje == "Debe ingresar: ")
        {
            try
            {
                Vehiculo Nuevo_Vehiculo = new Vehiculo(Matricula, Marca, Modelo, año, ListaDeFotos);
                int respuesta = LogicaVehiculo.ModificarVehiculo(Nuevo_Vehiculo, Ci_Cliente);

                if (respuesta !=-4)
                {
                    lblError.Text = "Vehiculo Modificado Correctamente";

                    //foreach (Foto foto in Nuevo_Vehiculo.Fotos)
                    //{
                    //    int respid = LogicaVehiculo.AgregarFoto(Nuevo_Vehiculo.Matricula, foto.DireccionFotos);


                    //}

                    Session["ListaDeFotos"] = null;


                    txtAño.Text = "";
                    txtMarca.Text = "";
                    txtMatricula.Text = "";
                    txtModelo.Text = "";
                    Deshabilitarbtns();
                    grdFotos.Visible = false;
                    
                }
                else 
                {
                    lblError.Text = "No existe el vehiculo";
                }
            }
            catch
            {
                lblError.Text = "No se pudo modificar el vehiculo";
            }
        }
        else
        {
            lblError.Text = mensaje;
        }
    }
    protected void txtMatricula_TextChanged(object sender, EventArgs e)
    {
        
        try
        {
            
            string matricula = txtMatricula.Text;

            if (txtMatricula.Text != "")
            {
                Vehiculo Vehiculo_Encontrado = LogicaVehiculo.BuscarVehiculo(matricula);

                //para saber si se debe modificar una imagen o agregar una nueva
                Session["ParaModificar"] = new bool();

                if (Vehiculo_Encontrado != null)
                {
                    //si se encuentra el objeto no se va a utilizar este fileupload
                    FileUpload1.Visible = false;
                    FileUpload1.Enabled = false;
                    btnAgrgarFoto.Enabled = false;
                    btnAgrgarFoto.Visible = false;
                    btnAgregarNuevaFoto.Enabled = true;
                    btnAgregarNuevaFoto.Visible = true;

                    Session["Vehiculo"] = Vehiculo_Encontrado;
                    Session["ListaDeFotos"] = Vehiculo_Encontrado.Fotos;
                    //mostar fotos en grid
                    grdFotos.Visible = true;

                    grdFotos.DataSource = Vehiculo_Encontrado.Fotos; 
                    grdFotos.DataBind();

                   // cambiar columnas del grid para modificar las fotos
                    //y el comportamiento del selectindexchange
                    grdFotos.Columns[2].Visible = false;
                    grdFotos.Columns[3].Visible = true;
                    Session["encontrado"] = -2;
                   
                    Session["ParaModificar"] = true;
                    //mostrar datos del vehiculo encontrado

                    txtModelo.Text = Vehiculo_Encontrado.Modelo.ToString();
                    txtMarca.Text = Vehiculo_Encontrado.Marca.ToString();
                    txtAño.Text = Vehiculo_Encontrado.Ano.ToString();
                    lblError.Text = "";

                    //habiliat botones de eliminar y modificar
                    btnModificar.Enabled = true;
                    btnModificar.Visible = true;
                    btnEliminar.Enabled = true;
                    btnEliminar.Visible = true;
                }
                else
                {
                    grdFotos.Columns[2].Visible = true;
                    grdFotos.Columns[3].Visible =  false;
                    Deshabilitarbtns();
                    txtModelo.Text = "";
                    txtAño.Text = "";
                    txtMarca.Text = "";
                    btnAgregar.Enabled = true;
                    btnAgregar.Visible = true;
                    grdFotos.Visible = false;
                    Session["encontrado"] = -1;
                    Session["ListaDeFotos"] = null;
                    Session["ParaModificar"] = false;
                    FileUpload1.Visible = true;
                    FileUpload1.Enabled = true;
                    btnAgrgarFoto.Enabled = true;
                    btnAgrgarFoto.Visible = true;
                    btnAgregarNuevaFoto.Enabled = false;
                    btnAgregarNuevaFoto.Visible = false;
                }

            }
        }
        catch
        {
            lblError.Text = "ERROR AL BUSCAR VEHICULO";
        }
    }

    protected void grdFotos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = (int)Session["encontrado"];
             
            
            if (id==-1)
            {
                List<Foto> ListaDeFotos = (List<Foto>)Session["ListaDeFotos"];

                ListaDeFotos.RemoveAt(grdFotos.SelectedIndex);

                grdFotos.DataSource = ListaDeFotos;

                grdFotos.DataBind();

            }
            else if (id !=-1)
            {
                Session["ParaModificar"] = true;
                Session["encontrado"] = Convert.ToInt32(grdFotos.SelectedRow.Cells[0].Text);
                Response.Redirect("FrmModificarImagen.aspx");
            }
        }
        catch(Exception es)
        {
            lblError.Text = es.ToString();
        }
    }




    protected void btnAgregarNuevaFoto_Click(object sender, EventArgs e)
    {

        
        
        Session["ParaModificar"] = false; //para agregar nueva
        Response.Redirect("FrmModificarImagen.aspx");
        
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try 
        {
            Session["volver"] = 0;
            txtMatricula.Enabled = true;
            
        }

        catch
        {
        }
    }
}

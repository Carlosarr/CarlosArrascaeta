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

public partial class FrmModificarImagen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //deshabilito btns
            btnEliminarFoto.Enabled = false;
            btnEliminarFoto.Visible = false;
            btnAgregarfoto.Enabled = false;
            btnAgregarfoto.Visible = false;
            btnCambiarFoto.Enabled = false;
            btnCambiarFoto.Visible = false;

            bool Paramodificar = (bool)Session["ParaModificar"];

            if (Paramodificar)
            {
                btnCambiarFoto.Enabled = true;
                btnCambiarFoto.Visible = true;
                btnEliminarFoto.Enabled = true;
                btnEliminarFoto.Visible = true;

                //obtener el id de la foto seleccionada para modificarla o eliminarla
                int id = (int)Session["encontrado"];

                //bajo las fotos y muestro la seleccionada
                List<Foto> ListaDeFotos = (List<Foto>)Session["ListaDeFotos"];
                foreach (Foto foto in ListaDeFotos)
                {
                    if (foto.IdFoto == id)
                    {
                        Label1.Text = "ID: " + id;
                        imgfoto.ImageUrl = foto.DireccionFotos;
                    }
                }

                //si la lista de fotos tiene solo una no esta permitido eliminarla
                //debe tener por lo menos una foto en la coleccion
                if (ListaDeFotos.Count == 1)
                {
                    btnEliminarFoto.Enabled = false;
                    btnEliminarFoto.Visible = false;
                }
                else
                {
                    btnEliminarFoto.Enabled = true;
                    btnEliminarFoto.Visible = true;
                }

                //esto avisa que se debe seguir trabajando con el vehiculo
                Session["volver"] = new int();
                Session["volver"] = 0;

            }
            else
            {
                btnCambiarFoto.Enabled = false;
                btnCambiarFoto.Visible = false;
                btnEliminarFoto.Enabled = false;
                btnEliminarFoto.Visible = false;
                btnAgregarfoto.Enabled = true;
                btnAgregarfoto.Visible = true;


            }
        }
        catch
        {

        }
    }
    
    protected void btnCambiarFoto_Click(object sender, EventArgs e)
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
                int id = (int)Session["encontrado"];

                Foto Nueva_foto = new Foto(Ruta);

                imgfoto.ImageUrl = Nueva_foto.DireccionFotos;

                Logica.LogicaVehiculo.ModificarFoto(id, Nueva_foto);
                Vehiculo vehiculo = (Vehiculo)Session["Vehiculo"];
                vehiculo.Fotos = LogicaVehiculo.ListarFotos(vehiculo.Matricula);
                Session["ListaDeFotos"] = vehiculo.Fotos;

            }
        }
        catch(Exception es)
        {
            lblError.Text = es.Message;
        }
    }
    protected void btnEliminarFoto_Click(object sender, EventArgs e)
    {
        try
        {

                int id = (int)Session["encontrado"];
                Logica.LogicaVehiculo.EliminarFoto(id);
                imgfoto.ImageUrl = "";
                lblSinFoto.Text = "Sin Imagen par mostrar";

                //listar nuevamente fotos
                Vehiculo vehiculo = (Vehiculo)Session["Vehiculo"];
                vehiculo.Fotos = LogicaVehiculo.ListarFotos(vehiculo.Matricula);
                Session["ListaDeFotos"] = vehiculo.Fotos;
                Session["volver"] = 1;
                    Response.Redirect("FrmVehiculo.aspx");
              


            
            
        }
        catch (Exception es)
        {
            lblError.Text = es.Message;
        }
    }
    protected void btnAgregarfoto_Click(object sender, EventArgs e)
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

                Vehiculo vehiculo = (Vehiculo)Session["Vehiculo"];

                Foto Nueva_foto = new Foto(Ruta);



                int Respid = Logica.LogicaVehiculo.AgregarFoto(vehiculo.Matricula, Ruta);

                if (Respid != -1)
                {
                    imgfoto.ImageUrl = Nueva_foto.DireccionFotos;

                    imgfoto.ImageUrl = Ruta;

                    Label1.Text = "ID: " + Respid;

                    Session["encontrado"] = Respid;

                    lblSinFoto.Text = "";

                    

                    //Session["volver"] = 1;
                    
                    Response.Redirect("FrmVehiculo.aspx");
                }
            }
        }
        catch (Exception es)
        {
            lblError.Text = es.Message;
        }
    }
    protected void btnvolver_Click(object sender, EventArgs e)
    {
        try
        {
            //Session["volver"] = 1;
            Response.Redirect("FrmVehiculo.aspx");
        }
        catch
        {
            lblError.Text = "problemas para volver";
        }
    }
}

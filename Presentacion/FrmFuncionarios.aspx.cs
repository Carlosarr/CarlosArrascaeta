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

public partial class FrmFuncionarios : System.Web.UI.Page
{

    protected void DeshabilitarBnts()
    {
        //deshabilitar botones
        btnEliminar.Enabled = false;
        btnEliminar.Visible = false;
        btnModificar.Enabled = false;
        btnModificar.Visible = false;
        btnAgregar.Visible = false;
        btnAgregar.Enabled = false;
    }

    protected void LimpiarCuadros()
    {
        
        txtContraseña.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtDireccion.Text = "";
        txtNivelDeInstruccion.Text = "";
        txtEspecialidad.Text = "";
        txtNumeroTelefono.Text = "";
        txtSueldo.Text = "";
       
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["Mecanico"] = new Mecanico();
                Session["Administrativo"] = new Administrativo();

                LimpiarCuadros();
                txtCedula.Enabled = false;
                txtContraseña.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtSueldo.Enabled = false;
                txtDireccion.Enabled = false;
                txtNumeroTelefono.Enabled = false;


                DeshabilitarBnts();
            }

         

            if (rbdTipoDeFuncionario.SelectedValue == "Administrativo")
            {
                
                //deshabilito opciones de mecanico
                lblEspecialidad.Enabled = false;
                lblSustituto.Enabled = false;

                txtEspecialidad.Enabled=false;
                drpSustituto.Enabled=false;

                //habilito opciones de administrativo
                lblNivelDeInstruccion.Enabled = true;

                txtNivelDeInstruccion.Enabled = true;
            }
            else if (rbdTipoDeFuncionario.SelectedValue == "Mecanico")
            {
                //listar mecanicos
                List<Mecanico> ListaDeMecanicos = LogicaMecanico.ListarMecanicos();

                drpSustituto.DataSource = ListaDeMecanicos;
                drpSustituto.DataTextField = "Etiqueta";
                drpSustituto.DataValueField = "Cedula";
                drpSustituto.DataBind();

                //deshabilito opciones de administrativo
                
                lblNivelDeInstruccion.Enabled = false;

                txtNivelDeInstruccion.Enabled = false;

                //habilito opciones de mecanico
                //deshabilito opciones de mecanico
                lblEspecialidad.Enabled = true;
                lblSustituto.Enabled = true;

                txtEspecialidad.Enabled = true;
                drpSustituto.Enabled = true;
            }
        }
        catch
        {
            lblError.Text = "Seleccione el tipo de funcionario";
        }
    }
    
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        //********************  AGREGAR ADMINISTRATIVO ***************************************
        
            if (rbdTipoDeFuncionario.SelectedValue == "Administrativo")
            {
                int Cedula=0;
                string Contraseña="";
                string Nombre="";
                string Apellido="";
                string Direccion="";
                int Telefono=0;
                int Sueldo;
                string NivelDeInstruccion="";
                string Mensaje = "Debe Ingresar: " ;

                Administrativo Nuevo_Administrativo;

                
                Contraseña = txtContraseña.Text;
                Nombre = txtNombre.Text;
                Apellido = txtApellido.Text;
                Direccion = txtDireccion.Text;
                
                Sueldo = Convert.ToInt32(txtSueldo.Text);
                NivelDeInstruccion = txtNivelDeInstruccion.Text;

                try
                {
                    Cedula = Convert.ToInt32(txtCedula.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Cedula, ";
                }
                if (Contraseña == "")
                {
                    Mensaje = Mensaje + "Contraseña, ";
                }
                if (Nombre == "")
                {
                    Mensaje = Mensaje + "Nombre, ";
                }
                if (Apellido == "")
                {
                    Mensaje = Mensaje + "Apellido, ";
                }
                if (Direccion == "")
                {
                    Mensaje = Mensaje + "Direccion, ";
                }
                try
                {
                    Telefono = Convert.ToInt32(txtNumeroTelefono.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Telefono, ";
                }
                try
                {
                    Sueldo = Convert.ToInt32(txtSueldo.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Sueldo, ";
                }
                if (NivelDeInstruccion == "")
                {
                    Mensaje = Mensaje + "NivelDeInstruccion, ";
                }

                if (Mensaje == "Debe Ingresar: ")
                {
                    try
                    {
                        //construyo el nuevo objeto administrativo
                        Nuevo_Administrativo = new Administrativo(Cedula, Contraseña, Nombre, Apellido, Sueldo, Direccion, NivelDeInstruccion,Telefono);

                        //agrego el administrativo a la base de datos
                        int respuesta = LogicaFuncionario.AgregarFuncionario(Nuevo_Administrativo);


                        if ((respuesta == -1) || (respuesta == -2))
                        {
                            lblError.Text = "No se Puedo agregar el Administrativo";
                        }
                        else if (respuesta == -4)
                        {
                            lblError.Text = "Administrativo ya existente en la BD";
                        }
                        else
                        {
                            //string mensajeTelefonos = "";
                            //if (Session["ListaDeTelefonos"] != null)
                            //{
                            //    //Agregar telefonos a la BD
                            //    //descargo la lista de la session con los telefonos ingresados
                            //    List<int> ListaDeTelefonos = (List<int>)Session["ListaDeTelefonos"];

                            //    //recorro la lista y agrego los telefonos uno por uno
                            //    foreach (int numero in ListaDeTelefonos)
                            //    {
                            //        int respuestaTelefonos = LogicaAdministrativo.AgregarTelefonoAdministrativo(Cedula, numero);

                            //        if (respuestaTelefonos == -1)
                            //        {
                            //            mensajeTelefonos = mensajeTelefonos + ", " + Convert.ToString(numero);
                            //        }
                            //    }


                            //}
                            //if (mensajeTelefonos != "")
                            //{
                            //    lblError.Text = "Administrativo dado de alta correctamente, " + "los numeros de telefono: " + mensajeTelefonos + "ya fueron ingresados";
                            //}
                            //else
                            //{
                                LimpiarCuadros();
                                txtCedula.Text = "";
                                lblError.Text = "Administrativo dado de alta correctamente";
                        //    }
                        //}
                      
                    }
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Problemas en el alta del Administrativo: "+ ex.Message);
                    }
                }
                else
                {
                    lblError.Text = Mensaje;
                }
                
                
               //********************  AGREGAR MECANICO ***************************************
            }
            else if (rbdTipoDeFuncionario.SelectedValue == "Mecanico")
            {
                int Cedula=0;
                string Contraseña = "";
                string Nombre = "";
                string Apellido = "";
                string Direccion = "";
                int Telefono=00;
                int Sueldo=0;
                string Especialidad = "";
                Mecanico Sustituto = null;
                string Mensaje = "Debe Ingresar: ";

                Mecanico Nuevo_Mecanico;


                Contraseña = txtContraseña.Text;
                Nombre = txtNombre.Text;
                Apellido = txtApellido.Text;
                Direccion = txtDireccion.Text;
                
              
                Especialidad=txtEspecialidad.Text;

                try
                {
                    Cedula = Convert.ToInt32(txtCedula.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Cedula, ";
                }
                try 
                {
                    int CedulaSustituto = Convert.ToInt32(drpSustituto.SelectedValue); // cedula seleccionada en el drop

                    Sustituto = new Mecanico(Convert.ToInt32(CedulaSustituto));
                    
                }
                catch
                {
                    Mensaje = Mensaje + "Sustituto, ";
                }
                if (Contraseña == "")
                {
                    Mensaje = Mensaje + "Contraseña, ";
                }
                if (Nombre == "")
                {
                    Mensaje = Mensaje + "Nombre, ";
                }
                if (Apellido == "")
                {
                    Mensaje = Mensaje + "Apellido, ";
                }
                if (Direccion == "")
                {
                    Mensaje = Mensaje + "Direccion, ";
                }
                try
                {
                    Telefono = Convert.ToInt32(txtNumeroTelefono.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Telefono, ";
                }
                try
                {
                    Sueldo = Convert.ToInt32(txtSueldo.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Sueldo, ";
                }
                if (Especialidad == "")
                {
                    Mensaje = Mensaje + "Especialidad, ";
                }
                

                if (Mensaje == "Debe Ingresar: ")
                {
                    try
                    {
                        //construyo el nuevo objeto mecanico
                        Nuevo_Mecanico = new Mecanico(Cedula, Contraseña, Nombre, Apellido, Sueldo, Direccion, Sustituto, Especialidad, Telefono);

                        //agrego el mecanico a la base de datos
                        int respuesta = LogicaFuncionario.AgregarFuncionario(Nuevo_Mecanico);

                        if ((respuesta == -1)||(respuesta==-2))
                        {
                            lblError.Text = "No se Puedo agregar el Mecanico";
                        }
                        else if (respuesta == -4)
                        {
                            lblError.Text = "Mecanico ya existente en la BD";
                        }
                        else
                        {
                            //string mensajeTelefonos = "";
                            //if (Session["ListaDeTelefonos"] != null)
                            //{
                            //    //Agregar telefonos a la BD
                            //    //descargo la lista de la session con los telefonos ingresados
                            //    List<int> ListaDeTelefonos = (List<int>)Session["ListaDeTelefonos"];

                            //    //recorro la lista y agrego los telefonos uno por uno
                            //    foreach (int numero in ListaDeTelefonos)
                            //    {
                            //        int respuestaTelefonos = LogicaMecanico.AgregarTelefonoMecanico(Cedula, numero);
                            //        if (respuestaTelefonos == -1)
                            //        {
                            //            mensajeTelefonos = mensajeTelefonos + ", " + Convert.ToString(numero);
                            //        }
                            //    }


                            //}
                            //if (mensajeTelefonos != "")
                            //{
                            //    lblError.Text = "Mecanico dado de alta correctamente, " + "los numeros de telefono: " + mensajeTelefonos + "ya fueron ingresados";
                            //}
                            //else
                            //{
                                LimpiarCuadros();
                                txtCedula.Text = "";
                                lblError.Text = "Mecanico dado de alta correctamente";
                        //    }
                        //}
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Problemas en el alta del Mecanico: " + ex.Message);
                    }
                }
                else
                {
                    lblError.Text = Mensaje;
                }
            
            }
        }
    


    protected void txtCedula_TextChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
        Session["ListaDeTelefonos"] =null;

        LimpiarCuadros();
        try
        {
           

            if (rbdTipoDeFuncionario.SelectedValue == "Administrativo")
            {
                //Buscar funcionario en la base de datos
                Administrativo Nuevo_Adm = LogicaAdministrativo.BuscarAdministrativo(Convert.ToInt32(txtCedula.Text));
                
                if (Nuevo_Adm != null)
                {

                    

                    //subo el funcionario a la session 
                    Session["Administrativo"] = Nuevo_Adm;

                    //Mostrar datos del funcioario encontrado
                    txtCedula.Text = Nuevo_Adm.Cedula.ToString();
                    txtContraseña.Text = Nuevo_Adm.Contraseña.ToString();
                    txtNombre.Text = Nuevo_Adm.Nombre.ToString();
                    txtApellido.Text = Nuevo_Adm.Apellido.ToString();
                    txtContraseña.Text = Nuevo_Adm.Contraseña.ToString();
                    txtDireccion.Text = Nuevo_Adm.Direccion.ToString();
                    txtSueldo.Text = Nuevo_Adm.Sueldo.ToString();
                    txtNumeroTelefono.Text = Nuevo_Adm.Telefono.ToString();
                    txtNivelDeInstruccion.Text = Nuevo_Adm.NivelDeInstruccion.ToString();

                    DeshabilitarBnts();

                    //habilitar botones de borrar y modificar
                    btnModificar.Enabled = true;
                    btnModificar.Visible = true;


                    //Comprobar que este objeto no este presente en otras tablas para saber si lo podemos eliminar o no
                    int respuestac = LogicaAdministrativo.ComprobarRelacionAdministrativo(Nuevo_Adm.Cedula);
                    if ((respuestac == -2) || (respuestac == -3))
                    {
                        btnEliminar.Enabled = false;
                        btnEliminar.Visible = false;
                    }
                    else if(respuestac==-1)
                    {
                        btnEliminar.Enabled = true;
                        btnEliminar.Visible = true;
                    }
            }
            else
            {
                btnAgregar.Visible = true;
                btnAgregar.Enabled = true;
                btnEliminar.Enabled = false;
                btnEliminar.Visible = false;
                btnModificar.Enabled = false;
                btnModificar.Visible = false;
                
            }
            }
            else if (rbdTipoDeFuncionario.SelectedValue == "Mecanico")
            {
                //buscar funcionario en la base de datos
                Mecanico Nuevo_Mec = LogicaMecanico.BuscarMecanico(Convert.ToInt32(txtCedula.Text));
               

                if (Nuevo_Mec != null)
                {

                    ////subo los telefonos a la session
                    //if (Session["ListaDeTelefonos"] == null)
                    //{
                    //    Session["ListaDeTelefonos"] = new List<int>();
                    //    Session["ListaDeTelefonos"] = Nuevo_Mec.Telefonos;
                    //}

                    //subo el funcionario a la session
                    Session["Mecanico"] = Nuevo_Mec;


                    //Mostrar daotos del funcioario encontrado
                    txtCedula.Text = Nuevo_Mec.Cedula.ToString();
                    txtContraseña.Text = Nuevo_Mec.Contraseña.ToString();
                    txtNombre.Text = Nuevo_Mec.Nombre.ToString();
                    txtApellido.Text = Nuevo_Mec.Apellido.ToString();

                    txtDireccion.Text = Nuevo_Mec.Direccion.ToString();
                    txtSueldo.Text = Nuevo_Mec.Sueldo.ToString();

                    txtNumeroTelefono.Text = Nuevo_Mec.Telefono.ToString();
                    txtEspecialidad.Text = Nuevo_Mec.Especialidad.ToString();

                    drpSustituto.SelectedValue = Convert.ToString(Nuevo_Mec.Sustituto.Cedula);

                    DeshabilitarBnts();

                    //habilitar botones de borrar y modificar
                    
                    btnModificar.Enabled = true;
                    btnModificar.Visible = true;

                    //comprobar que el mecanico no este presente en la tabla service para poder eliminarlo
                    int respuestac = LogicaMecanico.ComprobarRelacionMecanico(Nuevo_Mec.Cedula);
                    if((respuestac==-2)||(respuestac==-3))
                    {
                        btnEliminar.Enabled =false;
                        btnEliminar.Visible = false;
                    }
                    else if(respuestac==-1)
                    {
                         btnEliminar.Enabled =true;
                        btnEliminar.Visible = true;
                    }
                }
                else
                {
                    btnAgregar.Visible = true;
                    btnAgregar.Enabled = true;
                    btnEliminar.Enabled = false;
                    btnEliminar.Visible = false;
                    btnModificar.Enabled = false;
                    btnModificar.Visible = false;
                 
                }
            }
        }
        catch
        {
            lblError.Text = "ERROR AL BUSCAR EL FUNCIONARIO";
        }
    }

    protected void btnAgregarTel_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNumeroTelefono.Text != "")
            {
                if (Session["ListaDeTelefonos"] == null)
                {

                    List<int> ListaDeTelefonos = new List<int>();
                    Session["ListaDeTelefonos"] = ListaDeTelefonos;
                    ListaDeTelefonos.Add(Convert.ToInt32(txtNumeroTelefono.Text));
                  
                   
                    txtNumeroTelefono.Text = "";
                }
                else
                {

                    List<int> ListaDeTelefonos = (List<int>)Session["ListaDeTelefonos"];
                    ListaDeTelefonos.Add(Convert.ToInt32(txtNumeroTelefono.Text));
                  
                    txtNumeroTelefono.Text = "";
                }
                lblError.Text = "";
            }
        }
        catch
        {
            lblError.Text = "Error al agregar telefonos, intente nuevamente";
        }                                 
    }
   
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
 
    }
   
    protected void btnEliminarTel_Click(object sender, EventArgs e)
    {
        if (txtNumeroTelefono.Text != "")
        {
            //borrar telefono de la session, (seleccionado del listbox)
            List<int> ListaDeTelefonos = (List<int>)Session["ListaDeTelefonos"];
            ListaDeTelefonos.Remove(Convert.ToInt32(txtNumeroTelefono.Text));

          
            txtNumeroTelefono.Text = "";
        }
    }
   
    protected void drpSustituto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            
            int respuestaEliminarFunc = 0;
            //string mensajeTel="";
            //int respuestaEliminarTel = 0;

            if (rbdTipoDeFuncionario.SelectedValue == "Administrativo")
            {
                Administrativo Nuevo_Adm = (Administrativo)Session["Administrativo"];


                ////eliminar telefonos
                //foreach (int numero in Nuevo_Adm.Telefono)
                //{
                //    respuestaEliminarTel = LogicaAdministrativo.EliminarTelefonoAdministrativo(Nuevo_Adm.Cedula, numero);
                //    if (respuestaEliminarTel == -1)
                //    {
                //        mensajeTel = mensajeTel + Convert.ToString(numero);
                //    }
                //}
                //if (mensajeTel == "")
                //{
                    respuestaEliminarFunc = LogicaFuncionario.EliminarFuncioario(Nuevo_Adm);

                    if (respuestaEliminarFunc == -2)
                    {
                        lblError.Text = "Administrativo dado de baja correctamente";

                        LimpiarCuadros();
                    }
                    else 
                    {
                        lblError.Text = "No se ha podido dar de baja el administrativo";

                        LimpiarCuadros();
                    }
                }
            
            else if (rbdTipoDeFuncionario.SelectedValue == "Mecanico")
            {

                Mecanico Nuevo_Meca = (Mecanico)Session["Mecanico"];


                ////eliminar telefonos
                //foreach (int numero in Nuevo_Meca.Telefonos)
                //{
                //    respuestaEliminarTel = LogicaMecanico.EliminarTelefonoMecanico(Nuevo_Meca.Cedula, numero);
                    
                //    if (respuestaEliminarTel == -1)
                //    {
                //        mensajeTel = mensajeTel + Convert.ToString(numero);
                //    }
                //}
                //if (mensajeTel == "")
                //{
                  respuestaEliminarFunc = LogicaFuncionario.EliminarFuncioario(Nuevo_Meca);

                    if ((respuestaEliminarFunc == -2) || (respuestaEliminarFunc == -3))
                    {
                        lblError.Text = "No se ha podido dar de baja el Mecanico";
                    }
                    else if (respuestaEliminarFunc == -1)
                    {
                        lblError.Text = "No se encuentra el Mecanico en la BD";
                    }
                    else if(respuestaEliminarFunc == -4)
                    {
                        lblError.Text="Mecanico dado de baja correctamente";

                        LimpiarCuadros();
                    }

             
            }
        }
        catch(Exception ex)
        {
            throw new Exception("Problemas para eliminar el funcionario: " + ex.Message); 
        }
     }
    

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        //********************  MODIFICAR ADMINISTRATIVO ***************************************
        
            if (rbdTipoDeFuncionario.SelectedValue == "Administrativo")
            {
                int Cedula=0;
                string Contraseña="";
                string Nombre="";
                string Apellido="";
                string Direccion="";
                int Telefono=000;
                int Sueldo;
                string NivelDeInstruccion="";
                string Mensaje = "Debe Ingresar: " ;

                Administrativo Nuevo_Administrativo;

                
                Contraseña = txtContraseña.Text;
                Nombre = txtNombre.Text;
                Apellido = txtApellido.Text;
                Direccion = txtDireccion.Text;
                

                Sueldo = Convert.ToInt32(txtSueldo.Text);
                NivelDeInstruccion = txtNivelDeInstruccion.Text;

                try
                {
                    Cedula = Convert.ToInt32(txtCedula.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Cedula, ";
                }
                if (Contraseña == "")
                {
                    Mensaje = Mensaje + "Contraseña, ";
                }
                if (Nombre == "")
                {
                    Mensaje = Mensaje + "Nombre, ";
                }
                if (Apellido == "")
                {
                    Mensaje = Mensaje + "Apellido, ";
                }
                if (Direccion == "")
                {
                    Mensaje = Mensaje + "Direccion, ";
                }
                
                try
                {
                    Sueldo = Convert.ToInt32(txtSueldo.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Sueldo, ";
                }
                try
                {
                    Telefono = Convert.ToInt32(txtNumeroTelefono.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Telefono, ";
                }
                if (NivelDeInstruccion == "")
                {
                    Mensaje = Mensaje + "NivelDeInstruccion, ";
                }

                if (Mensaje == "Debe Ingresar: ")
                {
                    try
                    {
                        //construyo el nuevo objeto administrativo
                        Nuevo_Administrativo = new Administrativo(Cedula, Contraseña, Nombre, Apellido, Sueldo, Direccion, NivelDeInstruccion, Telefono);

                        //modifico el administrativo en la base de datos
                        int respuesta = LogicaFuncionario.ModificarFuncionario(Nuevo_Administrativo);


                        
                      if (respuesta != -1)
                        {
                            lblError.Text = "No se pudo modificar el ADMINISTRATIVO";
                        }
                        else
                        {
                            LimpiarCuadros();
                            txtCedula.Text = "";
                            lblError.Text = "Administrativo modificado correctamente";
                        }
                        
                      
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Problemas en la modificacion del Administrativo: "+ ex.Message);
                    }
                }
                else
                {
                    lblError.Text = Mensaje;
                }
                
                
               //********************  MODIFICAR MECANICO ***************************************
            }
            else if (rbdTipoDeFuncionario.SelectedValue == "Mecanico")
            {
                int Cedula=0;
                string Contraseña = "";
                string Nombre = "";
                string Apellido = "";
                string Direccion = "";
                int Telefono =000;
                int Sueldo=0;
                string Especialidad = "";
                Mecanico Sustituto = null;
                string Mensaje = "Debe Ingresar: ";

                Mecanico Nuevo_Mecanico;


                Contraseña = txtContraseña.Text;
                Nombre = txtNombre.Text;
                Apellido = txtApellido.Text;
                Direccion = txtDireccion.Text;
                
              
                Especialidad=txtEspecialidad.Text;

                try
                {
                    Cedula = Convert.ToInt32(txtCedula.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Cedula, ";
                }
                try 
                {
                    int CedulaSustituto = Convert.ToInt32(drpSustituto.SelectedValue); // cedula seleccionada en el drop

                    Sustituto = new Mecanico(Convert.ToInt32(CedulaSustituto));
                    
                }
                catch
                {
                    Mensaje = Mensaje + "Sustituto, ";
                }
                if (Contraseña == "")
                {
                    Mensaje = Mensaje + "Contraseña, ";
                }
                if (Nombre == "")
                {
                    Mensaje = Mensaje + "Nombre, ";
                }
                if (Apellido == "")
                {
                    Mensaje = Mensaje + "Apellido, ";
                }
                if (Direccion == "")
                {
                    Mensaje = Mensaje + "Direccion, ";
                }
                try
                {
                    Telefono = Convert.ToInt32(txtNumeroTelefono.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Telefono, ";
                }
                try
                {
                    Sueldo = Convert.ToInt32(txtSueldo.Text);
                }
                catch
                {
                    Mensaje = Mensaje + "Sueldo, ";
                }
                if (Especialidad == "")
                {
                    Mensaje = Mensaje + "Especialidad, ";
                }
                

                if (Mensaje == "Debe Ingresar: ")
                {
                    try
                    {
                        //construyo el nuevo objeto mecanico
                        Nuevo_Mecanico = new Mecanico(Cedula, Contraseña, Nombre, Apellido, Sueldo, Direccion, Sustituto, Especialidad, Telefono);

                        //agrego el mecanico a la base de datos
                        int respuesta = LogicaFuncionario.ModificarFuncionario(Nuevo_Mecanico);

                        
                        if ((respuesta == -1)||(respuesta==-2))
                        {
                            lblError.Text = "No se pudo modificar el Mecanico";
                        }
                        else if(respuesta==-3)
                        {
                        LimpiarCuadros();
                        txtCedula.Text = "";
                        lblError.Text = "Mecanico modificado correctamente";    
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Problemas en el alta del Mecanico: " + ex.Message);
                    }
                }
                else
                {
                    lblError.Text = Mensaje;
                }
            }
        
    
    }
    protected void rbdTipoDeFuncionario_SelectedIndexChanged(object sender, EventArgs e)
    {
        //habilitar cuadros
        txtCedula.Text = "";
        lblError.Text = "";
        LimpiarCuadros();
        txtCedula.Enabled = true;
        txtContraseña.Enabled = true;
        txtNombre.Enabled = true;
        txtApellido.Enabled = true;
        txtDireccion.Enabled = true;
        txtNumeroTelefono.Enabled = true;
        txtSueldo.Enabled = true;
        DeshabilitarBnts();
    }
}

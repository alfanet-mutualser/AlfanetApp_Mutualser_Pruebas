
using System;
using ASP;
using Microsoft;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSRadicadoTableAdapters;
using DSGrupoSQLTableAdapters;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Text;

public partial class _DocRecibidoReporte : System.Web.UI.Page 
{
    //string GrpDocRad = "1";
    

    protected void Page_Load(object sender, EventArgs e)
    {  
    try
    {     

        if (!IsPostBack)
            {
                string Admon = Request["Admon"];
                if (Admon == "S")
                {
                    ((MainMaster)this.Master).hidemenu();
                }
                else
                {
                    ((MainMaster)this.Master).showmenu();
                }

                //this.DateFechaRad.Text = DateTime.Now.ToLongDateString() +" " + DateTime.Now.ToLongTimeString();
                //this.TxtSerieD.Enabled = true;
               // this.TxtAccion.Enabled = true;
               // this.cmdActualizar.Enabled = false;
                //this.cmdAceptar.Enabled = true;
                //this.RangeVFecVen.MinimumValue = (DateTime.Today.Day)+"/"+DateTime.Today.Month+"/"+DateTime.Today.Year;

                String codImagen = Request["RadicadoCodigo"];
                HFGrupo.Value = Request["GrupoCodigo"];
                HFTipoDB.Value = Request["TipoCodigo"];
                HFControlDias.Value = Request["ControlDias"];
                HFDepenOrig.Value = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                HFWFMovFecha.Value = Convert.ToString(DateTime.Now);
                string senrodoc;
                if (codImagen != null)
                {
                    senrodoc = codImagen;
                    Session["NroDoc"] = codImagen;
                }

                senrodoc = (string)(Session["NroDoc"]);
                if (Session["NroDoc"] != null)
                {
                    senrodoc = Session["NroDoc"].ToString();
                    string Tipo = senrodoc.Substring(0, 1);
                    string nrodoc = senrodoc.Substring(1);
                    if (Tipo == "1")
                    {
                        RadicadoBLL ObjRad = new RadicadoBLL();
                        DSRadicado.Radicado_ReadRadDataTable radicados = new DSRadicado.Radicado_ReadRadDataTable();
                        radicados = ObjRad.GetDataBy(nrodoc, HFGrupo.Value);
                        DataRow[] rows = radicados.Select();
                       // this.DateFechaRad.Text = rows[0].ItemArray[2].ToString().Trim();
                        //this.SelDateFechaProcedencia.Text = rows[0].ItemArray[3].ToString().Trim();
                       // this.SelDateFechaVencimiento.Text = rows[0].ItemArray[9].ToString().Trim();
                       // this.TxtNumeroExterno.Text = rows[0].ItemArray[5].ToString().Trim();
                       // this.TxtProcedencia.Text = rows[0].ItemArray[4].ToString().Trim() + " | " + rows[0].ItemArray[15].ToString().Trim() + " | " + rows[0].ItemArray[19].ToString().Trim();
                       // this.TxtDetalle.Text = rows[0].ItemArray[8].ToString();
                       // this.TxtAnexo.Text = rows[0].ItemArray[20].ToString();  
                      //  this.TxtNaturaleza.Text = rows[0].ItemArray[6].ToString() + " | " + rows[0].ItemArray[16].ToString().Trim();
                      //  this.TxtMedioRecibo.Text = rows[0].ItemArray[11].ToString() + " | " + rows[0].ItemArray[17].ToString().Trim();
                      //  this.TxtExpediente.Text = rows[0].ItemArray[10].ToString() + " | " + rows[0].ItemArray[18].ToString().Trim();

                        //this.cmdActualizar.Enabled = true;
                        // this.cmdAceptar.Enabled = false;
                       // this.TxtSerieD.Visible = true;
                       // this.TxtAccion.Visible = true;
                        //this.ImgFindCargar.Visible = false;
                        //this.ImgFindAccion.Visible = false;
                        //this.LblSearchCargar.Visible = false;
                        //this.LblSearchAccion.Visible = false;
                      //  this.LblCargarA.Visible = true;
                      //  this.LblAccion.Visible = true;
                      //  this.Label22.Text = "Radicado Nro" + " " + nrodoc;

                        Session["NroDoc"] = "1" + nrodoc;
                        this.HFNroRad.Value = nrodoc; 
                       
                    }
                    else
                    {
                        this.Session.Clear();
                        //this.Session.Remove(Session["NroDoc"].ToString());
                        //this.Label22.Text = "";
                    }
                }        
            }
            else
            { 
             
            }
        }
        catch (Exception Error)
        {
         this.ExceptionDetails.Text = "Problema" + Error;
        }
    }   
    
    
    
    
   
   
    
    //protected void cmdAceptar_Click(object sender, EventArgs e)
    //{  
    //    //IDbConnection ObjConn = null;
    //    //IDbTransaction ObjTran = null;
    //    //ObjConn = new SqlConnection(@"server=JUANRG-PC\SQLEXPRESS;Trusted_Connection=true;DATABASE=AlfaNet");
    //    //ObjConn.Open();
    //    try
    //    {
    //        string RadicadoCodigo;
    //        RadicadoBLL Obj = new RadicadoBLL();


    //        //ObjTran = ObjConn.BeginTransaction();

    //        if (this.LblSearchCargar.Text == "Archivar En")
    //            {
    //               RadicadoCodigo = Obj.AddRadicado(GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToDateTime(SelDateFechaProcedencia.Text.ToString()), TxtProcedencia.Text.ToString(), null, TxtNumeroExterno.Text.ToString(), TxtNaturaleza.Text.ToString().Trim(), Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), TxtDetalle.Text.ToString(), TxtAnexo.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(),this.TxtSerieD.Text.ToString(), TxtAccion.Text.ToString(), "0", "1", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 3, TxtDetalle.Text.ToString(), this.TxtSerieD.Text.ToString(), "0");
    //        //DSRadicadoTableAdapters.Radicado1TableAdapter TARadicado = new Radicado1TableAdapter();
    //            if (RBEnterarA.SelectedValue == "T")
    //                    {
    //                        string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[0].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 4, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), "0");

    //                    }    
    //            else
    //                {
    //                for (int i=0; i< ListBoxEnterar.Items.Count; i++)
    //                 {
                        
    //                    string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[i].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()),2, TxtDetalle.Text.ToString(), null,RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()),"0");
    //                 }
    //                }
    //            }
    //            else if ( this.LblSearchCargar.Text == "Proceso")
    //            {
    //                RadicadoCodigo = Obj.AddRadicado(GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToDateTime(SelDateFechaProcedencia.Text.ToString()), TxtProcedencia.Text.ToString(),this.TxtSerieD.Text.ToString(), TxtNumeroExterno.Text.ToString(), TxtNaturaleza.Text.ToString().Trim(), Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), TxtDetalle.Text.ToString(), TxtAnexo.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), this.TxtSerieD.Text.ToString(), TxtAccion.Text.ToString(), "1", "0", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 3, TxtDetalle.Text.ToString(), null, "0");
    //                //DSRadicadoTableAdapters.Radicado1TableAdapter TARadicado = new Radicado1TableAdapter();
    //                if (RBEnterarA.SelectedValue == "T")
    //                    {
    //                        string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[0].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 4, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), "0");

    //                    }    
    //            else
    //                {
    //                for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
    //                {

    //                    string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[i].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 2, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), "0");
    //                }
    //                }
    //            }
    //            else
    //            {
    //                RadicadoCodigo = Obj.AddRadicado(GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToDateTime(SelDateFechaProcedencia.Text.ToString()), TxtProcedencia.Text.ToString(),null, TxtNumeroExterno.Text.ToString(), TxtNaturaleza.Text.ToString().Trim(), Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), TxtDetalle.Text.ToString(), TxtAnexo.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), this.TxtSerieD.Text.ToString(), TxtAccion.Text.ToString(),"1","0", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 1, TxtDetalle.Text.ToString(),null, "0");
    //                //DSRadicadoTableAdapters.Radicado1TableAdapter TARadicado = new Radicado1TableAdapter();
    //                 if (RBEnterarA.SelectedValue == "T")
    //                    {
    //                        string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[0].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 4, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), "0");

    //                    }    
    //            else
    //                {
    //                for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
    //                {

    //                    string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[i].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 2, TxtDetalle.Text.ToString(),null, RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), "0");
    //                }
    //                }
    //            }
    //        //ObjTran.Commit();
    //        //ObjTran = null;
            
    //        this.Label22.Text = "Radicado Nro" + " " + RadicadoCodigo;
    //        Session["NroDoc"] = "1" + RadicadoCodigo;
    //        //this.Label14.Text = "1" + RadicadoCodigo;
    //        this.LblMessageBox.Text = "Radicado Nro" + " " + RadicadoCodigo;     
    //        this.ModalPopupExtender1.Show();
    //        MailBLL Correo = new MailBLL();
    //        MembershipUser usuario;
    //        usuario = Membership.GetUser(Profile.GetProfile(User.Identity.Name.ToString()).UserName.ToString());
    //        string Body = "Tiene un nuevo Radicado Nro " + RadicadoCodigo + "<BR>" + " Fecha de Radicacion: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "<BR>" + "Procedencia: " + TxtProcedencia.Text.ToString() + "<BR>" + "Naturaleza: " + TxtNaturaleza.Text.ToString().Trim() + "<BR>";
    //        Correo.EnvioCorreo("soporte.archivar@gmail.com", usuario.Email, "Radicado Nro" + " " + RadicadoCodigo, Body, true, "1");
            
    //    }
    //    catch (Exception Error)
    //    {
    //        //ObjTran.Rollback();
    //        //ObjTran = null;
    //        this.ExceptionDetails.Text = "Problema" + Error;
    //    }

    //  }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        try
        {
            this.Session.Clear();
           // this.Session.Remove(Session.Keys["NroDoc"].ToString());
            Response.Redirect("~");
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
   protected void BtnNuevoRad_Click(object sender, EventArgs e)
    {
          try
            {
                this.Session.Clear();
                //this.Session.Remove(Session["NroDoc"].ToString());
                //this.ExceptionDetails.Text = "";
                //this.TxtBuscarRadicado.Text = "";
                //this.SelDateFechaProcedencia.Text = "";
                //this.TxtNumeroExterno.Text = "";
                //this.SelDateFechaVencimiento.Text = "";
                //this.TxtProcedencia.Text = "";
                //this.TxtDetalle.Text = "";
                //this.TxtNaturaleza.Text = "";
                //this.TxtMedioRecibo.Text = "";
                //this.TxtExpediente.Text = "";
                //this.TxtSerieD.Text = "";
                //this.TxtAccion.Text = "";
                //this.TxtSerieD.Visible = true;
                //this.TxtAccion.Visible = true;
                //this.LblSearchAccion.Text = "";
                //this.LblSearchCargar.Text = "";
                //this.LblSearchExpediente.Text = "";
                //this.LblSearchMedio.Text = "";
                //this.LblSearchNaturaleza.Text = "";
                //this.LblSearchProcedencia.Text = "";
                //this.ImgFindCargar.Visible = true;
                //this.ImgFindAccion.Visible = true;
                //this.LblSearchCargar.Visible = true;
                //this.LblSearchAccion.Visible = true;
                //this.LblCargarA.Visible = true;
                //this.LblAccion.Visible = true;
                //this.cmdAceptar.Enabled = true;
                //this.cmdActualizar.Enabled = false;
                //this.Label22.Text = "";
                //this.TxtAnexo.Text = "";
                //this.TxtDependencia1.Text = "";
                //this.Label5.Text = "";
                //this.ListBoxEnterar.Items.Clear();
                Response.Redirect("~/AlfaNetDocumentos/DocRecibido/NuevoDocRecibido1.aspx");
        
            }
    catch (SqlException err)
    {
        //cnn.rol
       this.ExceptionDetails.Text = "Error: " + err.Message.ToString();

    }
}   
    
}
        
           
      

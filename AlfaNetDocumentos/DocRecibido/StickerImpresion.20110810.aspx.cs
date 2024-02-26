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

public partial class AlfaNetDocumentos_DocRecibido_StickerImpresion : System.Web.UI.Page
{
    StickerBLL Sticker = new StickerBLL();
    DateTime Fecha;
    DateTime Hora;
    //string TramiteDependencia = new string[64];
    //string TramiteProcedencia = new string[64];

    protected void Page_Load(object sender, EventArgs e)
    {
        string nrodoc = Request["RadicadoCodigo"];
        string Grupo = Request["GrupoCodigo"];
        String CodBar = Request["CodBar"];
        string GrupoPadre = Request["GrupoPadreCodigo"];

        if (CodBar == "1")
        {
            this.LblCodigoBarras.Visible = true;
        }
        else
        {
            this.LblCodigoBarras.Visible = false;
        }      
        
        if (nrodoc != null)
        {           
            this.HFSticker.Value = nrodoc;
            this.LblCodigoBarras.Text = HFSticker.Value.ToUpper();
            this.LblCodigoBarras.Text = HFSticker.Value.ToUpper();

            if (GrupoPadre == "1")
            {
                DataTable DTRadSticker;
                DTRadSticker = Sticker.GetRadicadoSticker(Grupo, Convert.ToInt32(nrodoc));
                Fecha = Convert.ToDateTime(DTRadSticker.Rows[0]["WFMovimientoFecha"]);
                this.LblCliente.Text = DTRadSticker.Rows[0]["Empresa"].ToString().ToUpper();
                this.LblStickercargarA.Text = "  " + DTRadSticker.Rows[0]["DependenciaNombre"].ToString().ToUpper();
                //this.LblStickerFecRad.Text = " " + DTRadSticker.Rows[0]["WFMovimientoFecha"].ToString().ToUpper();
                this.LblStickerFecRad.Text = " " + Fecha.Day + "/" + Fecha.Month + "/" + Fecha.Year;
                this.Label17.Text = " " + Fecha.TimeOfDay;
                //TramiteDependencia = "  " + DTRadSticker.Rows[0]["DependenciaNombre"].ToString().ToUpper();
                //TramiteProcedencia = " " + DTRadSticker.Rows[0]["ProcedenciaNombre"].ToString().ToUpper();
                //this.LblStickercargarA.Text = TramiteDependencia;
                //this.LabelProcedencia.Text = TramiteProcedencia;
                this.Label18.Text = " " + DTRadSticker.Rows[0]["ProcedenciaNombre"].ToString().ToUpper();
                this.LblStickerNroRad.Text = DTRadSticker.Rows[0]["RadicadoCodigo"].ToString().ToUpper();
                this.LblStickerUsr.Text = DTRadSticker.Rows[0]["NombresUsuario"].ToString().ToUpper();
                this.Label19.Text = " " + DTRadSticker.Rows[0]["RadicadoAnexo"].ToString().ToUpper(); 
                this.Label2.Visible = false;
                this.Label4.Visible = false;
                this.Label5.Visible = false;
                this.LblDireccion.Visible = false;
                this.Label8.Text = "Radicado No: ".ToUpper();
                this.Label1.Text = "Fecha: ".ToUpper();
                this.Label6.Text = "Hora: ".ToUpper();
                this.LabelProcedencia.Text = "Procedencia: ".ToUpper();
               
            }
            else if (GrupoPadre == "2")
            {
                DataTable DTRegSticker;
                DTRegSticker = Sticker.GetRegistroSticker(Grupo, Convert.ToInt32(nrodoc));
                            
                this.Label8.Text = "Registro No: ".ToUpper();
                this.Label1.Text = "Fecha: ".ToUpper();
                this.Label6.Text = "Hora: ".ToUpper();
                this.LabelProcedencia.Visible = false;
                this.Label18.Visible = false;

                if (DTRegSticker.Rows.Count!=0)
                {
                    if (DTRegSticker.Rows[0]["RegistroTipo"].ToString() == "0")
                    {
                        this.LblStickercargarA.Text = DTRegSticker.Rows[0]["ProcedenciaNombre"].ToString().ToUpper();
                        this.LblDireccion.Text = DTRegSticker.Rows[0]["ProcedenciaDireccion"].ToString().ToUpper();
                        this.Label5.Text = DTRegSticker.Rows[0]["CiudadNombre"].ToString().ToUpper() + "-" + DTRegSticker.Rows[0]["DepartamentoNombre"].ToString().ToUpper();
                        // 
                    }
                    else if (DTRegSticker.Rows[0]["RegistroTipo"].ToString() == "1")
                    {
                        this.Label2.Visible = false;
                        this.LblDireccion.Visible = false;
                        this.Label4.Visible = false;
                        this.Label5.Visible = false;
                        this.LblStickercargarA.Text = DTRegSticker.Rows[0]["DependenciaNombre"].ToString().ToUpper();

                    }
                    this.LblCliente.Text = DTRegSticker.Rows[0]["Empresa"].ToString().ToUpper();
                    this.Label19.Text = " " + DTRegSticker.Rows[0]["AnexoExtRegistro"].ToString().ToUpper();
                    Fecha = Convert.ToDateTime(DTRegSticker.Rows[0]["WFMovimientoFecha"].ToString().ToUpper());
                    //this.LblStickerFecRad.Text =" " + DTRegSticker.Rows[0]["WFMovimientoFecha"].ToString().ToUpper();
                    this.LblStickerFecRad.Text = " " + Fecha.Day + "/" + Fecha.Month + "/" + Fecha.Year;
                    this.Label17.Text = " " + Fecha.TimeOfDay;
                    this.LblStickerNroRad.Text = DTRegSticker.Rows[0]["RegistroCodigo"].ToString().ToUpper();

                    this.LblStickerUsr.Text = DTRegSticker.Rows[0]["NombresUsuario"].ToString().ToUpper();
                    if (this.LblStickerUsr.Text == "")
                    {
                        this.LblStickerUsr.Text = User.Identity.Name.ToUpper();
                    }
                }
                else
                {

                }
            }
        }
    }
}

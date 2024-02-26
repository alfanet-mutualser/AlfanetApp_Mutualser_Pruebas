using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;
using ASP;
using Microsoft;
using Infragistics.Shared;
using Infragistics.WebUI.UltraWebGrid;


public partial class _ReArchviar : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
           
        }
        else
        {

        }
    }
    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        this.CiudadByIdDataSource.SelectParameters["GrupoCodigo"].DefaultValue = this.RadBtnLstFindby.SelectedValue;
        if (TxtDocumento.Text != "")
        {
            if (TxtDocumento.Text.Contains(" | "))
            {
                TxtDocumento.Text = TxtDocumento.Text.Remove(TxtDocumento.Text.IndexOf(" | "));
            }
        }
        else
        {
            TxtDocumento.Text = null;
        }
        this.CiudadByIdDataSource.SelectParameters["NumeroDocumento"].DefaultValue = this.TxtDocumento.Text;
        this.DVDocumento.ChangeMode(DetailsViewMode.ReadOnly);
        this.Label3.Visible = true;
        this.TextBox3.Visible = true;
        this.LinkButton1.Visible = true;
        this.DVDocumento.DataBind();

        
    }
    protected void ImgBtnInsert_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void DVDocumento_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {

    }
    protected void DVDocumento_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {

    }
    protected void DVDocumento_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {

    }
    protected void DVDocumento_DataBound(object sender, EventArgs e)
    {

    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
        {
            this.DVDocumento.Visible = false;
            this.Label3.Visible = false;
            this.TextBox3.Visible = false;
            this.LinkButton1.Visible = false;
            this.ACDocumento.ServiceMethod = "GetDocArchivadosRecibidos";
        }
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
        {
            this.DVDocumento.Visible = false;
            this.Label3.Visible = false;
            this.TextBox3.Visible = false;
            this.LinkButton1.Visible = false;
            this.ACDocumento.ServiceMethod = "GetDocArchivadosEnviados";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if(RadBtnLstFindby.SelectedValue=="1")
        {
        int mNumeroDocumento = Convert.ToInt32(this.DVDocumento.DataKey[0].ToString());
        int mWFMovimientoPaso = Convert.ToInt32(this.DVDocumento.DataKey[1].ToString());
        String mDependenciaCodDestino = this.DVDocumento.DataKey[2].ToString();
        String mDependenciaCodOrigen = this.DVDocumento.DataKey[2].ToString();

        String mWFMovimientoMultitarea = "0";

        int mWFMovimientoTipoini = Convert.ToInt32(this.DVDocumento.DataKey[3].ToString());
        int mWFMovimientoTipo = 7;

        DateTime mWFFechaMovimientoFin= DateTime.Now;
        String mWFMovimientoNotas = this.DVDocumento.DataKey[5].ToString();
        if (mWFMovimientoNotas == "")
            mWFMovimientoNotas = null;
        String mGrupoCodigo = this.DVDocumento.DataKey[4].ToString();
        String mWFProcesoCodigo = null;
        String mWFAccionCodigo = "1";
        DateTime mWFMovimientoFecha = DateTime.Now;
        DateTime mWFMovimientoFechaEst = DateTime.Now;
        String mSerieCodigo = null;
        mSerieCodigo = this.TextBox3.Text;
        if (mSerieCodigo != "")
        {
            if (mSerieCodigo.Contains(" | "))
            {
                mSerieCodigo = mSerieCodigo.Remove(mSerieCodigo.IndexOf(" | "));
            }
            else
            {
                mSerieCodigo = null;
            }
        }
        else
        {
            mSerieCodigo = null;
        }
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////
        DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
        Object ErrorMessage = TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                           mDependenciaCodDestino,
                                                           mWFMovimientoPaso,
                                                           0,
                                                           1,
                                                           mWFFechaMovimientoFin,
                                                           mWFMovimientoTipo,
                                                           mWFMovimientoTipoini,
                                                           mWFMovimientoNotas,
                                                           mGrupoCodigo,
                                                           mDependenciaCodOrigen,
                                                           mWFProcesoCodigo,
                                                           mWFAccionCodigo,
                                                           mWFMovimientoFecha,
                                                           mWFMovimientoFechaEst,
                                                           mSerieCodigo,
                                                           mWFMovimientoMultitarea,
                                                           UserId);

  this.TxtDocumento.Text = null;
  string MensajeError = Convert.ToString(ErrorMessage);
  if (MensajeError == "")
  {
      this.LblMessageBox.Text = "Documento Nro. " + mNumeroDocumento + " Archivado en Serie " + this.TextBox3.Text;
  }
  else
  {
          this.SetFocus(this.TxtDocumento);
          //Display a user-friendly message
          this.LblMessageBox.Text = "Ocurrio un problema al tratar de archivar el Documento. ";
          Exception inner = new Exception(MensajeError);           
          this.LblMessageBox.Text += ErrorHandled.FindError(inner);
          this.MPEMensaje.Show();
          
  }
  
  //throw new Exception(MensajeError);
        }   
    }
}
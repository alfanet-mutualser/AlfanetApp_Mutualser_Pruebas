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
using ASP;
using Microsoft;
using DSRadicadoTableAdapters;
using DSGrupoSQLTableAdapters;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Text;
using System.IO;

public partial class PQR : System.Web.UI.Page
{
    string GrpDocRad = "1";

    protected void Page_Load(object sender, EventArgs e)
    {
        String Fecha = DateTime.Today.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        String Mayuscula = Fecha.Substring(0, 1).ToUpper();
        string minuscula = Fecha.Substring(1);
        this.DateFechaRad.Text = Mayuscula + minuscula;
        try
        {


            if (!IsPostBack)
            {
                //User.ToString();
                //bool Anonimo = Profile.IsAnonymous;

                //Profile.GetProfile(Profile.UserName).NombreDepUsuario.ToString() + " | ";                                 

                DSRadicadoTableAdapters.PlantillaPQRTableAdapter DSPQR = new PlantillaPQRTableAdapter();
                DSRadicado.PlantillaPQRDataTable DTPQR = new DSRadicado.PlantillaPQRDataTable();
                DTPQR = DSPQR.GetPlantillaPQR();
                if (DTPQR.Count > 0)
                {
                    this.TxtMedioRecibo.Text = DTPQR.Rows[0].ItemArray[0].ToString() + " | " + DTPQR.Rows[0].ItemArray[4].ToString();
                    this.TxtExpediente.Text = DTPQR.Rows[0].ItemArray[1].ToString() + " | " + DTPQR.Rows[0].ItemArray[5].ToString();
                    this.TxtSerieD.Text = DTPQR.Rows[0].ItemArray[2].ToString() + " | " + DTPQR.Rows[0].ItemArray[6].ToString();
                    this.TxtAccion.Text = DTPQR.Rows[0].ItemArray[3].ToString() + " | " + DTPQR.Rows[0].ItemArray[7].ToString();
                }
                if (!Profile.IsAnonymous)
                {
                    UpdatePanel4.Visible = true;
                    UpdatePanel5.Visible = true;
                    UpdatePanel6.Visible = true;
                    UpdatePanel7.Visible = true;
                    this.cmdActualizar.Visible = true;
                }
                else
                {
                    UpdatePanel4.Visible = false;
                    UpdatePanel5.Visible = false;
                    UpdatePanel6.Visible = false;
                    UpdatePanel7.Visible = false;
                    //DDLNaturalezaDependenciaPQR.Visible = false;
                    this.cmdActualizar.Visible = false;
                }
                // }        
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
    protected void cmdAceptar_Click(object sender, EventArgs e)
    {
        DataTable tabla = new DataTable();
        rutinas ejecutar = new rutinas();
        string codigodelgruporadicados = "";
        tabla = ejecutar.rtn_traer_tbtablas_por_Id("GRUPORAD");
        codigodelgruporadicados = tabla.Rows[0][0].ToString().Trim();

        try
        {
            // insercion de la procedencia
            if (UpdatePanel9.Visible == true)
            {
                ProcedenciaBLL ProceBLL = new ProcedenciaBLL();
                bool confir;
                confir = ProceBLL.AddProcedencia(this.TxtAddNUI.Text, this.TxtAddNUI.Text, this.TxtAddNombre.Text, "0", this.TxtDireccion.Text, this.TxtAddTel1.Text, null, null, this.TxtEmail1.Text, null, null, this.DropDownList1.SelectedValue, "1", "1");
                this.TxtProcedencia.Text = this.TxtAddNUI.Text;
            }

            if (this.TxtAddNUI.Text == "")
            {

                this.TxtProcedencia.Text = DropDownList2.Items[0].Text;
            }

            string RadicadoCodigo = "1";
            RadicadoBLL Obj = new RadicadoBLL();

            String Cargar;
            String Radicador;

            Cargar = this.DDLNaturalezaDependenciaPQR.SelectedValue;
            Radicador = this.TxtSerieD.Text;

            if (this.HFCargar.Value == "Dependencia" || this.HFCargar.Value == "")
            {
                RadicadoCodigo = Obj.AddRadicado(GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), DateTime.Now, TxtProcedencia.Text.ToString(), null, "777", this.DDLNaturaleza.SelectedValue.ToString(), Radicador, TxtDetalle.Text.ToString(), null, DateTime.Now, TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), Cargar, TxtAccion.Text.ToString(), "1", "0", DateTime.Now, DateTime.Now, 1, TxtDetalle.Text.ToString(), null, "0", null);

            }
            else if (this.HFCargar.Value == "Serie")
            {
                RadicadoCodigo = Obj.AddRadicado(GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), DateTime.Now, TxtProcedencia.Text.ToString(), this.TxtSerieD.Text.ToString(), "777", this.DDLNaturaleza.SelectedValue.ToString(), Radicador, TxtDetalle.Text.ToString(), null, DateTime.Now, TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), Cargar, TxtAccion.Text.ToString(), "1", "0", DateTime.Now, DateTime.Now, 3, TxtDetalle.Text.ToString(), null, "0", null);
            }
            else if (this.HFCargar.Value == "Procesos")
            {
                if (this.TxtSerieD.Text != null)
                {
                    if (TxtSerieD.Text.Contains(" | "))
                    {
                        TxtSerieD.Text = TxtSerieD.Text.Remove(TxtSerieD.Text.IndexOf(" | "));
                    }
                }
                if (this.TxtProcedencia.Text != null)
                {
                    if (TxtProcedencia.Text.Contains(" | "))
                    {
                        TxtProcedencia.Text = TxtProcedencia.Text.Remove(TxtProcedencia.Text.IndexOf(" | "));
                    }
                }
                if (this.TxtNaturaleza.Text != null)
                {
                    if (TxtNaturaleza.Text.Contains(" | "))
                    {
                        TxtNaturaleza.Text = TxtNaturaleza.Text.Remove(TxtNaturaleza.Text.IndexOf(" | "));
                    }
                }
                if (this.TxtExpediente.Text != null)
                {
                    if (TxtExpediente.Text.Contains(" | "))
                    {
                        TxtExpediente.Text = TxtExpediente.Text.Remove(TxtExpediente.Text.IndexOf(" | "));
                    }
                }
                if (this.TxtMedioRecibo.Text != null)
                {
                    if (TxtMedioRecibo.Text.Contains(" | "))
                    {
                        TxtMedioRecibo.Text = TxtMedioRecibo.Text.Remove(TxtMedioRecibo.Text.IndexOf(" | "));
                    }
                }

                int? Result = 1;
                DSRadicadoTableAdapters.Radicado_CreateRadicadoProcesosTableAdapter OBJTAProcesos = new Radicado_CreateRadicadoProcesosTableAdapter();
                //OBJTAProcesos.CreateRadicadoProcesos(GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), DateTime.Now, TxtProcedencia.Text.ToString(), this.TxtSerieD.Text, "777", this.DDLNaturaleza.SelectedValue.ToString(), Radicador, TxtDetalle.Text.ToString(), null, DateTime.Now, TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), "1", "0", DateTime.Now, DateTime.Now, 4, null, ref Result, "0");
                RadicadoCodigo = Convert.ToString(Result);
            }
            this.Label14.Text = "Tramite Nro: " + " " + RadicadoCodigo;
            this.LblMessageBox.Text = "Su Solicitud ha sido registrada correctamente " + "<BR>" + "Nro " + RadicadoCodigo + "<BR>" + "Conserve este numero para consultar el estado de la solicitud";
            this.HFNroDoc.Value = RadicadoCodigo;
            //this.LblDocumentoNro.Text = RadicadoCodigo;
            //this.Adjuntar.Enabled = true;
            //this.FileUpload1.Enabled = true;
            this.ModalPopupExtender1.Show();
            this.LblRpta.Enabled = false;


            MailBLL Correo = new MailBLL();
            MembershipUser usuario;
            DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
            DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();

            DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(DDLNaturalezaDependenciaPQR.SelectedValue);
            if (DTUsuariosxDependencia.Count > 0)
            {
                DataRow[] rows = DTUsuariosxDependencia.Select();
                System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
                usuario = Membership.GetUser(a);
                string Body = "Tiene un nuevo Radicado Nro " + RadicadoCodigo + "<BR>" + " Fecha de Radicacion: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "<BR>" + "Procedencia: " + TxtProcedencia.Text.ToString() + "<BR>" + "Naturaleza: " + TxtNaturaleza.Text.ToString().Trim() + "<BR>";
                Correo.EnvioCorreo("alfanet@mutualser.org", usuario.Email, "Radicado Nro" + " " + RadicadoCodigo, Body, true, "1");
            }


            try
            {
                for (int i = 0; i < this.ASPxUploadControl1.FileInputCount; i++)
                {

                    if (this.ASPxUploadControl1.UploadedFiles[i].FileName != "")
                    {
                        //Radicado
                        if (RadicadoCodigo != "")
                        {

                            DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
                            DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                            DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

                            Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                            int codigoR = Convert.ToInt32(CodigoRuta);
                            String Grupo = "Radicados";
                            String Ano = DateTime.Today.Year.ToString();
                            String Mes = DateTime.Today.Month.ToString();

                            String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");

                            if (CodigoRuta == null)
                            {
                                TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 1, PathVirtual);
                                CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                                codigoR = Convert.ToInt32(CodigoRuta);
                                if (Directory.Exists(PathVirtual))
                                {
                                    TARadicadoImagen.InsertRadicadoImagen(codigodelgruporadicados, Convert.ToInt32(this.HFNroDoc.Value), this.ASPxUploadControl1.UploadedFiles[i].FileName, codigoR);
                                    this.ASPxUploadControl1.UploadedFiles[i].SaveAs(PathVirtual + this.ASPxUploadControl1.UploadedFiles[i].FileName);
                                }
                                else
                                {
                                    Directory.CreateDirectory(PathVirtual);
                                    TARadicadoImagen.InsertRadicadoImagen(codigodelgruporadicados, Convert.ToInt32(this.HFNroDoc.Value), this.ASPxUploadControl1.UploadedFiles[i].FileName, codigoR);
                                    this.ASPxUploadControl1.UploadedFiles[i].SaveAs(PathVirtual + this.ASPxUploadControl1.UploadedFiles[i].FileName);
                                }
                            }
                            else
                            {
                                if (Directory.Exists(PathVirtual))
                                {
                                    TARadicadoImagen.InsertRadicadoImagen(codigodelgruporadicados, Convert.ToInt32(this.HFNroDoc.Value), this.ASPxUploadControl1.UploadedFiles[i].FileName, codigoR);
                                    this.ASPxUploadControl1.UploadedFiles[i].SaveAs(PathVirtual + this.ASPxUploadControl1.UploadedFiles[i].FileName);
                                }
                                else
                                {
                                    Directory.CreateDirectory(PathVirtual);
                                    TARadicadoImagen.InsertRadicadoImagen(codigodelgruporadicados, Convert.ToInt32(this.HFNroDoc.Value), this.ASPxUploadControl1.UploadedFiles[i].FileName, codigoR);
                                    this.ASPxUploadControl1.UploadedFiles[i].SaveAs(PathVirtual + this.ASPxUploadControl1.UploadedFiles[i].FileName);

                                }
                            }
                            //                            this.LblUploadDetails.Visible = true;
                            //                            this.LblUploadDetails.Text = string.Format(
                            //                            @"Nombre: {0}<br />
                            //                                        Tamaño (en bytes): {1:N0}<br />
                            //                                        Tipo: {2}",
                            //this.ASPxUploadControl1.UploadedFiles[i].FileName,
                            //this.ASPxUploadControl1.UploadedFiles[i].FileBytes.Length,
                            //this.ASPxUploadControl1.UploadedFiles[i].PostedFile.ContentType);
                            //this.PlaceHolder1.Controls.Clear();
                            //Page_Load(null, null);

                            //this.LblMessageBox.Text = "Imagen Adicionada";
                            //this.ModalPopupExtender1.Show();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.LblMessageBox.Text = "Error: " + ex.Message.ToString();
                this.ModalPopupExtender1.Show();
            }

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Ocurrio un problema al tratar de Realizar el Tramite verifique su NIT o CC. ";
            this.ExceptionDetails.Text += ErrorHandled.FindError(Error);
        }

    }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        try
        {
            //this.Session.Clear();
            // this.Session.Remove(Session.Keys["NroDoc"].ToString());
            Response.Redirect("~");
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    protected void cmdActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            //if ()
            RadicadoBLL PlaPQR = new RadicadoBLL();

            if (PlaPQR.GetPlantillaPQR().Count != 0)
            {

                PlaPQR.Update_Plantilla(this.TxtSerieD.Text, this.TxtExpediente.Text, this.TxtMedioRecibo.Text, this.TxtAccion.Text);
            }
            else
            {
                PlaPQR.Create_Plantilla(this.TxtSerieD.Text, this.TxtExpediente.Text, this.TxtMedioRecibo.Text, this.TxtAccion.Text);
            }
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

            Response.Redirect("~/PQR.aspx");

        }
        catch (SqlException err)
        {
            //cnn.rol
            this.LblAccion.Text = "Error: " + err.Message.ToString();

        }
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/AlfaNetAdministracion/AdminMaestros/MaestroNaturaleza.aspx");

    }
    private void PopulateSubLevel(int parentid, TreeNode parentNode)
    {
        DSDependenciaSQLTableAdapters.DependenciaByTextTableAdapter TADSD = new DSDependenciaSQLTableAdapters.DependenciaByTextTableAdapter();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = TADSD.GettreedependenciaDataBy(Convert.ToString(parentid));
        PopulateNodes(DTDependencia, parentNode.ChildNodes);
    }
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeView1.SelectedNode == null)
            PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr["DependenciaCodigo"].ToString() + " | " + dr["DependenciaNombre"].ToString();
            tn.Value = dr["DependenciaCodigo"].ToString();
            nodes.Add(tn);
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeView1.SelectedNode.Text)) == false)
        {
            this.TxtSerieD.Text = TreeView1.SelectedNode.Text.ToString();
            this.TreeView1.CollapseAll();
            this.TreeView1.Dispose();
            this.HFCargar.Value = "Dependencia";
        }

    }
    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevelSerie((e.Node.Value), e.Node);
    }
    protected void TreeVSerie_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVSerie.SelectedNode.Text)) == false)
        {
            this.TxtSerieD.Text = this.TreeVSerie.SelectedNode.Text;
            this.TreeVSerie.CollapseAll();
            this.HFCargar.Value = "Serie";
        }
    }
    private void PopulateSubLevelSerie(String parentid, TreeNode parentNode)
    {
        DSSerieSQLTableAdapters.SerieByTextTableAdapter TADSS = new DSSerieSQLTableAdapters.SerieByTextTableAdapter();
        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();

        DTSerie = TADSS.GetSerieTreeDataBy(Convert.ToString(parentid));

        PopulateNodesSerie(DTSerie, parentNode.ChildNodes);
    }
    private void PopulateNodesSerie(DataTable dt, TreeNodeCollection nodes)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();

            tn.Text = dr["SerieCodigo"].ToString() + " | " + dr["SerieNombre"].ToString();
            tn.Value = dr["SerieCodigo"].ToString();
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    private void PopulateSubLevelProceso(int parentid, TreeNode parentNode)
    {
        ProcesoTableAdapters.WFProcesoTableAdapter TAPRO = new ProcesoTableAdapters.WFProcesoTableAdapter();
        Proceso.WFProcesoDataTable DTProceso = new Proceso.WFProcesoDataTable();
        DTProceso = TAPRO.GetProcesoTreeVDataBy(Convert.ToString(parentid));

        PopulateNodesProceso(DTProceso, parentNode.ChildNodes);
    }
    private void PopulateNodesProceso(DataTable dt, TreeNodeCollection nodes)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();

            tn.Text = dr["WFProcesoCodigo"].ToString() + " | " + dr["WFProcesoDescripcion"].ToString();
            tn.Value = dr["WFProcesoCodigo"].ToString();
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    protected void TreeVProceso_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVProceso.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            this.TxtSerieD.Text = this.TreeVProceso.SelectedNode.Text;
            this.TreeVProceso.CollapseAll();
            this.HFCargar.Value = "Procesos";
        }
    }
    protected void TreeVProceso_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevelProceso(Int32.Parse(e.Node.Value), e.Node);
    }
    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        // scriptManager.
        scriptManager.SetFocus(TxtNaturaleza);
    }
    protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.SetFocus(this.TxtMedioRecibo);
    }
    protected void ImageButton4_Click1(object sender, ImageClickEventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.SetFocus(this.TxtExpediente);
    }
    protected void ImageButton5_Click1(object sender, ImageClickEventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.SetFocus(this.TxtAccion);
    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadBtnLstFindby.SelectedValue == "1")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetProcedenciaByTextNombre";
        }
        else if (RadBtnLstFindby.SelectedValue == "2")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetProcedenciaByTextId";
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.SetFocus(TxtAddNombre);
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/AlfaNetAdministracion/AdminMaestros/MaestroProcedencia.aspx");
        //Response.Redirect("");
    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/AlfaNetAdministracion/AdminMaestros/MaestroMedio.aspx");
    }
    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/AlfaNetAdministracion/AdminMaestros/MaestroExpediente.aspx");
    }
    protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/AlfaNetAdministracion/AdminMaestros/MaestroWorkFlowAccion.aspx");
    }
    protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/AlfaNetAdministracion/AdminMaestros/MaestroDependenciaJuan.aspx");
    }
    protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/AlfaNetAdministracion/AdminMaestros/MaestroSerie.aspx");
    }
    protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/AlfaNetAdministracion/AdminMaestros/MaestroWorkFlowProceso.aspx");
    }
    protected void BtnAdicionar_Click(object sender, EventArgs e)
    {
        try
        {
            //ProcedenciaBLL ObjProcedencia = new ProcedenciaBLL();
            //ObjProcedencia.AddProcedencia(
            //    this.TxtAddNUI.Text,
            //    this.TxtAddNUI.Text,
            //    this.TxtAddNombre.Text,
            //    null,
            //    this.TxtAddDireccion.Text,
            //    this.TxtAddTel1.Text,
            //    //this.TxtAddTel2.Text,
            //    this.TxtAddFax.Text,
            //    this.TxtAddEmail1.Text,
            //    this.TxtAddEmail2.Text,
            //    this.TxtAddWeb.Text,
            //    this.TxtCiudad.Text,
            //    "1",
            //    "1"
            //);

            this.LblMessageBox.Text = " ! Se ha registrado correctamente en el sistema ! ";
            this.ModalPopupExtender1.Show();
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "! No se pudo registrar en el Sistema ! " + Error.Message;
            this.ModalPopupExtender1.Show();
        }
    }
    protected void ImgBtnFindRad_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            String NroRad = TxtBuscarRadicado.Text;

            if (NroRad != null)
            {
                if (NroRad.Contains(" | "))
                {
                    NroRad = NroRad.Remove(NroRad.IndexOf(" | "));
                }
            }
            DSWorkFlowTableAdapters.WFMovimiento_ReadMaxWFMovimientoPasoTableAdapter TAMAX = new DSWorkFlowTableAdapters.WFMovimiento_ReadMaxWFMovimientoPasoTableAdapter();
            DSWorkFlow.WFMovimiento_ReadMaxWFMovimientoPasoDataTable DTMax = new DSWorkFlow.WFMovimiento_ReadMaxWFMovimientoPasoDataTable();
            DTMax = TAMAX.GetWFMovimientoMaxPaso(NroRad);
            HFRpta.Value = NroRad;
            //DSWorkFlow.WFMovimiento_ReadMaxWFMovimientoPasoRow DRMax= DTMax[0]..Rows[0];
            foreach (DSWorkFlow.WFMovimiento_ReadMaxWFMovimientoPasoRow Rowmax in DTMax.Rows)
            {
                if (DTMax[0].ProcedenciaCodigo == "ANONIMO")
                {
                    Documentoencontrado(DTMax, NroRad);
                }
                else if (DTMax[0].ProcedenciaCodigo == TxtNuiCon.Text)
                {
                    Documentoencontrado(DTMax, NroRad);
                }
                else
                {
                    this.LblMessageBox.Text = "Numero de Tramite o Identificacion Incorrecto verifique por favor: <br />";

                    this.ModalPopupExtender1.Show();
                }
            }
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "! No se pudo registrar en el Sistema ! " + Error.Message;
            this.ModalPopupExtender1.Show();
        }
    }
    protected void cmdConsultar_Click(object sender, EventArgs e)
    {
        this.UpdatePanel8.Visible = true;
        this.UpdatePanel100.Visible = false;
        this.UpdatePanel3.Visible = false;
        this.UpdatePanel2.Visible = false;
        this.UpdatePanel10.Visible = false;
        this.Panel1.Visible = false;
        this.cmdAceptar.Enabled = false;

    }

    protected void TxtAddNUI_TextChanged(object sender, EventArgs e)
    {
        ProcedenciaBLL ProcedenciaBLL = new ProcedenciaBLL();
        DSProcedenciaSQL.ProcedenciaDataTable DTProcedencia = new DSProcedenciaSQL.ProcedenciaDataTable();
        DTProcedencia = ProcedenciaBLL.GetProcedenciaByID(this.TxtAddNUI.Text);

        foreach (DSProcedenciaSQL.ProcedenciaRow Row in DTProcedencia.Rows)
        {
            this.TxtAddNombre.Text = Row.ProcedenciaNombre;
            this.DDLPais.Visible = false;
            this.DDLDepartamento.Visible = false;
            this.CascadingDropDown1.Enabled = false;
            this.CascadingDropDown2.Enabled = false;
            this.CascadingDropDown5.Enabled = false;
            this.Label11.Visible = false;
            this.Label12.Visible = false;

            ListItem itm = new ListItem();
            itm.Text = Row.CiudadNombre;
            itm.Value = Row.CiudadCodigo;
            itm.Selected = true;

            this.DropDownList1.Items.Clear();
            this.DropDownList1.Items.Add(itm);
            this.TxtAddDireccion.Text = Row.ProcedenciaDireccion;
            this.TxtAddTel1.Text = Row.ProcedenciaTelefono1;
            this.TxtAddEmail1.Text = Row.ProcedenciaMail1;
            this.TxtProcedencia.Text = this.TxtAddNUI.Text;
            this.UpdatePanel9.Visible = false;
            this.TxtDetalle.Focus();
        }
        if (DTProcedencia.Rows.Count == 0)
        {
            this.UpdatePanel9.Visible = true;
            this.TxtAddNombre.Text = null;
            this.DDLPais.Visible = true;
            this.DDLDepartamento.Visible = true;
            this.CascadingDropDown1.Enabled = true;
            this.CascadingDropDown2.Enabled = true;
            this.CascadingDropDown5.Enabled = true;
            this.Label11.Visible = true;
            this.Label12.Visible = true;
            this.DropDownList1.Items.Clear();
            this.TxtAddDireccion.Text = null;
            this.TxtAddTel1.Text = null;
            this.TxtAddEmail1.Text = null;
            this.TxtAddNombre.Focus();
        }
    }
    protected void RBLAddNUI_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBLAddNUI.SelectedValue == "0")
        {
            this.RFVAddNUI.Enabled = false;
            this.UpdatePanel9.Visible = false;
            this.TxtAddNUI.Enabled = false;
        }
        else if (RBLAddNUI.SelectedValue == "1")
        {
            this.RFVAddNUI.Enabled = true;
            this.UpdatePanel9.Visible = true;
            this.TxtAddNUI.Enabled = true;
        }
    }
    protected void RBLSearchNUI_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBLSearchNUI.SelectedValue == "0")
        {
            this.RFVSearchNUI.Enabled = false;
        }
        else if (RBLSearchNUI.SelectedValue == "1")
        {
            this.RFVSearchNUI.Enabled = true;
        }
    }
    protected void Documentoencontrado(DSWorkFlow.WFMovimiento_ReadMaxWFMovimientoPasoDataTable DTMax, String NroRad)
    {
        try
        {
            if (DTMax[0].WFMovimientoPasoFinal == "1")
            {
                this.LblMessageBox.Text = "Documento con Tramite Finalizado: <br />";
                //this.LblMessageBox.Text += "A cargo de la Dependencia: <br />" + DTMax[0].DependenciaNombre;
                this.ModalPopupExtender1.Show();

                if (DTMax[0].Respuesta != "0")
                {

                    LblRpta.Enabled = true;
                    //Panel PnlRpta = ((Panel)GVR.Row.FindControl("PnlRpta"));
                    DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
                    DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
                    DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(NroRad), "1");

                    int i = 1;
                    foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
                    {
                        HyperLink HprRpta = new HyperLink();
                        HprRpta.ID = "HprRpta" + i.ToString();
                        HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
                        HprRpta.Target = "_Blank";
                        HprRpta.ForeColor = System.Drawing.Color.Blue;
                        HprRpta.Font.Underline = true;
                        HprRpta.Attributes.Add("onClick", "urlInt(event);");
                        PnlRpta.Controls.Add(HprRpta);
                        PnlRpta.Controls.Add(new LiteralControl("<br />"));
                        i += 1;
                    }
                }
                else
                {
                    LblRpta.Enabled = false;

                }

            }
            else if (DTMax[0].WFMovimientoPasoActual == "1")
            {
                this.LblMessageBox.Text = "Documento en Proceso de Tramite: <br />";
                //this.LblMessageBox.Text += "A cargo de la Dependencia: <br />" + DTMax[0].DependenciaNombre;
                this.ModalPopupExtender1.Show();

                if (DTMax[0].Respuesta != "0")
                {
                    LblRpta.Enabled = true;
                    DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
                    DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
                    DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(NroRad), "1");

                    int i = 1;
                    foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
                    {
                        HyperLink HprRpta = new HyperLink();
                        HprRpta.ID = "HprRpta" + i.ToString();
                        HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
                        HprRpta.Target = "_Blank";
                        HprRpta.ForeColor = System.Drawing.Color.Blue;
                        HprRpta.Font.Underline = true;
                        HprRpta.Attributes.Add("onClick", "urlInt(event);");
                        PnlRpta.Controls.Add(HprRpta);
                        PnlRpta.Controls.Add(new LiteralControl("<br />"));
                        i += 1;
                    }
                }
                else
                {
                    LblRpta.Enabled = false;
                }
            }
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "! No se pudo registrar en el Sistema ! " + Error.Message;
            this.ModalPopupExtender1.Show();
        }
    }
    protected void DropDownList2_Load(object sender, EventArgs e)
    {
        this.DropDownList2.DataBind();
    }
}


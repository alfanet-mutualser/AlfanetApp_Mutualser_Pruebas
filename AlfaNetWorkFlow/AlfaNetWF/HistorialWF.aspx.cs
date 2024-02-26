using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using AjaxControlToolKit;

public partial class _HistorialWF : System.Web.UI.Page 
{
    rutinas ejecutar = new rutinas();

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Data.DataTable tabla = new DataTable();
        string codImagen = Request["RadicadoCodigo"];
        string segui = "";
        try
        {
            if (!IsPostBack)
            {
                string codigodelgruporadicados = "";
                tabla = ejecutar.rtn_traer_tbtablas_por_Id("GRUPORAD");
                codigodelgruporadicados = tabla.Rows[0][0].ToString().Trim();

                tabla = ejecutar.rtn_traer_grupos_por_codigopadre(codigodelgruporadicados);

                if (tabla.Rows.Count == 0)
                {
                    tabla = ejecutar.rtn_traer_grupos_por_Id(codigodelgruporadicados);
                }

                this.DropDownListGrupo.DataTextField = "gruponombre";
                this.DropDownListGrupo.DataValueField = "grupocodigo";
                this.DropDownListGrupo.DataSource = tabla;
                this.DropDownListGrupo.DataBind();
                this.DropDownListGrupo.SelectedIndex = 0;
                Application["grupo"] = this.DropDownListGrupo.SelectedValue.ToString();

                string Admon = Request["Admon"];
                if (Admon == "S")
                {
                    ((MainMaster)this.Master).hidemenu();
                }
                else
                {
                    ((MainMaster)this.Master).showmenu();
                }
                
                //string codImagen = Request["RadicadoCodigo"];
                string GrupoCodigo= Request["GrupoCodigo"];
                if (codImagen != null)
                {
                HFCodigoSeleccionado.Value = codImagen;
                HFGrupoSeleccionado.Value = GrupoCodigo;
           
                this.LblDetalleMultitarea.Text = "Detalle Multitarea del Radicado Número: " + HFCodigoSeleccionado.Value;
                this.LblDetalleMultitarea.Visible = true;
                this.LblAccionEnterese.Text = "Detalle Accion Enterese del Radicado Número: " + HFCodigoSeleccionado.Value;
                this.LblAccionEnterese.Visible = true;
               
                this.DetailsView1.HeaderText = "Detalle Historico Radicado Número: " + HFCodigoSeleccionado.Value;
            
                this.DetailsView1.DataBind();
                

                DSRadicadoTableAdapters.Radicado_ConsultasHistoricoTableAdapter ObjTaRadHis = new DSRadicadoTableAdapters.Radicado_ConsultasHistoricoTableAdapter();
                DSRadicado.Radicado_ConsultasHistoricoDataTable DTRadHis = new DSRadicado.Radicado_ConsultasHistoricoDataTable();
                DTRadHis = ObjTaRadHis.GetRadicadoHistorial(Convert.ToInt32(HFCodigoSeleccionado.Value),GrupoCodigo);
             
                DSRadicado.Radicado_ConsultasHistoricoDataTable DTTip1 = new DSRadicado.Radicado_ConsultasHistoricoDataTable();
                DataRow[] rows = DTRadHis.Select("WfmovimientoTipo = 1 or WfmovimientoTipo = 3 or WfmovimientoTipo = 7");
                escriba(rows);
           
                DataRow[] RowsCopia = DTRadHis.Select("WfmovimientoTipo = 2");
                escribaCopias(RowsCopia);
               
                DataRow[] rowsProceso = DTRadHis.Select("WfmovimientoTipo = 4");
                escriba(rowsProceso);
             
                }
            }
            else
            {

            }

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema : " + codImagen+" | "+segui+" | "+Error.Message;
        }
        
    }  
    protected void ImgBtnFindHistorico_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.TxtSearchHistorico.Text.Contains(" | "))
            {
                HFCodigoSeleccionado.Value = this.TxtSearchHistorico.Text.Remove(this.TxtSearchHistorico.Text.IndexOf(" | "));
            }
            else
                HFCodigoSeleccionado.Value = this.TxtSearchHistorico.Text.ToString();
            HFGrupoSeleccionado.Value = DropDownListGrupo.SelectedValue;

            this.LblDetalleMultitarea.Text = "Detalle Multitarea del Radicado Número: " + HFCodigoSeleccionado.Value;
            this.LblDetalleMultitarea.Visible = true;
            this.LblAccionEnterese.Text = "Detalle Accion Enterese del Radicado Número: " + HFCodigoSeleccionado.Value;
            this.LblAccionEnterese.Visible = true;
            this.DetailsView1.HeaderText = "Detalle Historico Radicado Número: " + HFCodigoSeleccionado.Value;
            this.DetailsView1.DataBind();

        DSRadicadoTableAdapters.Radicado_ConsultasHistoricoTableAdapter ObjTaRadHis = new DSRadicadoTableAdapters.Radicado_ConsultasHistoricoTableAdapter();
        DSRadicado.Radicado_ConsultasHistoricoDataTable DTRadHis = new DSRadicado.Radicado_ConsultasHistoricoDataTable();
        DTRadHis = ObjTaRadHis.GetRadicadoHistorial(Convert.ToInt32(HFCodigoSeleccionado.Value),DropDownListGrupo.SelectedValue);
       
        DSRadicado.Radicado_ConsultasHistoricoDataTable DTTip1 = new DSRadicado.Radicado_ConsultasHistoricoDataTable();
        DataRow[] rows = DTRadHis.Select("WfmovimientoTipo = 1 or WfmovimientoTipo = 3 or WfmovimientoTipo = 7");
        escriba(rows);

        DataRow[] RowsCopia = DTRadHis.Select("WfmovimientoTipo = 2");
        escribaCopias(RowsCopia);

        DataRow[] rowsProceso = DTRadHis.Select("WfmovimientoTipo = 4");
        escriba(rowsProceso);
        }
        catch (Exception Error)
        {
        this.ExceptionDetails.Text = "Problema" + Error;
        }
        
    }
    //protected void escribaAnterior(DataRow[] rows)
    //{
    //    try
    //    {
        
    //    HtmlTable Tabla = new HtmlTable();

    //    int i = 1;

    //    foreach (DSRadicado.Radicado_ConsultasHistoricoRow DRradHis in rows)
    //    {
    //        DataRow RowSig;
    //        String Notas;
    //        if (i < rows.Length)
    //        {
    //            RowSig = rows[i];
    //            Notas = RowSig.ItemArray[16].ToString();
    //        }
    //        else
    //        {
    //            RowSig = rows[i-1];
    //            Notas = null;
    //        }
                    
    //        if (i % 2 != 0)
    //        {
    //            HtmlTableRow Row1 = new HtmlTableRow();

    //            Tabla.Rows.Add(Row1);

    //            HtmlTableCell Cell0 = new HtmlTableCell();

    //            Row1.Cells.Add(Cell0);
    //            Label LabelDep = new Label();
    //            LabelDep.ID = "LabelDep" + Convert.ToString(i);
    //            if (DRradHis.WfmovimientoTipo.ToString() == "1")
    //            {
    //                LabelDep.Text = DRradHis.DependenciaNombre.ToString();

    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
    //            {
    //                LabelDep.Text = DRradHis.SerieNombre.ToString();
    //            }
                
    //            LabelDep.Visible = true;
    //            LabelDep.Width = 150;
    //            Cell0.Controls.Add(LabelDep);
                                
    //            //if (DRradHis.WFMovimientoNotas != "" && DRradHis.WFMovimientoNotas != null)
                
    //            if (Notas != "" && Notas != null)
    //            {
    //                //HtmlTableCell Cell01 = new HtmlTableCell();
    //                //Row1.Cells.Add(Cell01);

    //                Image ImgPostIt = new Image();
    //                ImgPostIt.ID = "ImgPostIt" + Convert.ToString(i);
    //                ImgPostIt.ImageUrl = "~/AlfaNetImagen/ToolBar/post-it.gif";
    //                ImgPostIt.Visible = true;
    //                Cell0.Controls.Add(ImgPostIt);

    //                Panel PnlPostIt = new Panel();
    //                PnlPostIt.ID = "PnlPostIt" + Convert.ToString(i);
    //                PnlPostIt.CssClass = "popupControl";
    //                Cell0.Controls.Add(PnlPostIt);

    //                Label LbPasoPostIt = new Label();
    //                LbPasoPostIt.ID = "LbPasoPostIt" + Convert.ToString(i);
    //                LbPasoPostIt.Width = Unit.Pixel(300);
    //                LbPasoPostIt.Height = Unit.Pixel(80);
    //                LbPasoPostIt.Text = RowSig.ItemArray[16].ToString();
    //                LbPasoPostIt.Font.Bold = true;
    //                LbPasoPostIt.BackColor = System.Drawing.Color.Transparent;
    //                PnlPostIt.Controls.Add(LbPasoPostIt);

    //                PnlPostIt.HorizontalAlign = HorizontalAlign.Left;

    //                AjaxControlToolkit.PopupControlExtender PCPostIt = new AjaxControlToolkit.PopupControlExtender();
    //                PCPostIt.ID = "PCPostIt" + Convert.ToString(i);
    //                PCPostIt.TargetControlID = "ImgPostIt" + Convert.ToString(i);
    //                PCPostIt.PopupControlID = "PnlPostIt" + Convert.ToString(i);

    //                Cell0.Controls.Add(PCPostIt);
    //            }

    //            HtmlTableCell Cell1 = new HtmlTableCell();

    //            Row1.Cells.Add(Cell1);

                
    //            Image ImgPaso = new Image();
    //            ImgPaso.ID = "ImgPaso" + Convert.ToString(i);
    //            if (DRradHis.WfmovimientoTipo.ToString() == "1")
    //            {
    //                ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg.jpg";
    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
    //            {
    //                ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFArchivoImg.jpg";
    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "4" && DRradHis.SerieCodigo == null)
    //            {
    //                ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg.jpg";
    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "4" && DRradHis.SerieCodigo != null)
    //            {
    //                ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFArchivoImg.jpg";
    //            }
    //            ImgPaso.Visible = true;
    //            Cell1.Controls.Add(ImgPaso);

    //            /*Inicio de edicion de panel de paso*/

    //            Panel Pnl = new Panel();
    //            Pnl.ID = "Pnl" + Convert.ToString(i);
    //            //Pnl.CssClass = "popupControl";
    //            Cell1.Controls.Add(Pnl);

    //            /*Obtener la informacion de los pasos*/
    //            /*Obtener la informacion de los pasos*/
    //            String Datos_1 = "";
    //            String Datos_2 = "";
    //            String Datos_3 = "";

    //            if (DRradHis.WfmovimientoTipo.ToString() == "1")
    //            {
    //                Datos_3 = "Dependencia:";
    //                Datos_1 = Convert.ToString(DRradHis.DependenciaNombre);

    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
    //            {
    //                Datos_3 = "Serie:";
    //                Datos_1 = Convert.ToString(DRradHis.SerieNombre);
    //            }


    //            if (DRradHis.SerieCodigo == null)
    //                Datos_2 = "En Proceso";
    //            else
    //                Datos_2 = "Archivado";



    //            HtmlGenericControl nid = this.generarPanContent(0,Convert.ToString(i), Datos_3, Datos_1, Convert.ToString(DRradHis.WFAccionNombre),
    //                Convert.ToString(DRradHis.WFMovimientoFecha1), Convert.ToString(DRradHis.WFMovimientoFechaFin),
    //                Datos_2);


    //            /*Insertar el panel*/
    //            Pnl.Controls.Add(nid);
                
    //            /*Insercion de contenido*/
    //            /*
    //            Label LbPasoNombre = new Label();
    //            LbPasoNombre.ID = "LbPasoNombre" + Convert.ToString(i);
    //            LbPasoNombre.Text = "Paso: ";
    //            LbPasoNombre.Font.Bold = true;
    //            Pnl.Controls.Add(LbPasoNombre);

    //            Label LbPaso = new Label();
    //            LbPaso.ID = "LbPaso" + Convert.ToString(i);
    //            LbPaso.Text = Convert.ToString(DRradHis.WFMovimientoPaso);

    //            Pnl.Controls.Add(LbPaso);

    //            Pnl.Controls.Add(new LiteralControl("<br />"));

    //            Label LbDependenciaNombre = new Label();
    //            LbDependenciaNombre.ID = "LbDependenciaNombre" + Convert.ToString(i);
    //            if (DRradHis.WfmovimientoTipo.ToString() == "1")
    //            {
    //                LbDependenciaNombre.Text = "Dependencia: ";
                    
    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
    //            {
    //                LbDependenciaNombre.Text = "Serie: ";
    //            }
                
    //            LbDependenciaNombre.Font.Bold = true;

    //            Pnl.Controls.Add(LbDependenciaNombre);

    //            Label LbDependenciaText = new Label();
    //            LbDependenciaText.ID = "LbDependenciaText" + Convert.ToString(i);
    //            if (DRradHis.WfmovimientoTipo.ToString() == "1")
    //            {
    //                LbDependenciaText.Text = Convert.ToString(DRradHis.DependenciaNombre);

    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
    //            {
    //                LbDependenciaText.Text = Convert.ToString(DRradHis.SerieNombre);
    //            }
                

    //            Pnl.Controls.Add(LbDependenciaText);

    //            Pnl.Controls.Add(new LiteralControl("<br />"));

    //            Label LbAccioNombre = new Label();
    //            LbAccioNombre.ID = "LbAccionNombre" + Convert.ToString(i);
    //            LbAccioNombre.Text = "Accion: ";
    //            LbAccioNombre.Font.Bold = true;
    //            Pnl.Controls.Add(LbAccioNombre);

    //            Label LbAccionText = new Label();
    //            LbAccionText.ID = "LbAccionText" + Convert.ToString(i);
    //            LbAccionText.Text = Convert.ToString(DRradHis.WFAccionNombre);

    //            Pnl.Controls.Add(LbAccionText);

    //            Pnl.Controls.Add(new LiteralControl("<br />"));

    //            Label LbFechaInicioNombre = new Label();
    //            LbFechaInicioNombre.ID = "LbFechaInicioNombre" + Convert.ToString(i);
    //            LbFechaInicioNombre.Text = "Fecha Inicio: ";
    //            LbDependenciaNombre.Font.Bold = true;
    //            Pnl.Controls.Add(LbFechaInicioNombre);
    //            //Ojo es nombre Accion
    //            Label LbFechaInicioText = new Label();
    //            LbFechaInicioText.ID = "LbFechaInicioText" + Convert.ToString(i);
    //            LbFechaInicioText.Text = Convert.ToString(DRradHis.WFMovimientoFecha1);

    //            Pnl.Controls.Add(LbFechaInicioText);

    //            Pnl.Controls.Add(new LiteralControl("<br />"));

    //            Label LbFechaFinNombre = new Label();
    //            LbFechaFinNombre.ID = "LbFechaFinNombre" + Convert.ToString(i);
    //            LbFechaFinNombre.Text = "Fecha Fin: ";
    //            LbFechaFinNombre.Font.Bold = true;
    //            Pnl.Controls.Add(LbFechaFinNombre);

    //            Label LbFechaFinText = new Label();
    //            LbFechaFinText.ID = "LbFechaFinText" + Convert.ToString(i);
    //            //Ojo es fecha Fin

    //            LbFechaFinText.Text = Convert.ToString(DRradHis.WFMovimientoFechaFin);

    //            Pnl.Controls.Add(LbFechaFinText);

    //            Pnl.Controls.Add(new LiteralControl("<br />"));

    //            Label LbEstadoNombre = new Label();
    //            LbEstadoNombre.ID = "LbEstadoNombre" + Convert.ToString(i);
    //            LbEstadoNombre.Text = "Estado: ";
    //            LbEstadoNombre.Font.Bold = true;
    //            Pnl.Controls.Add(LbEstadoNombre);

    //            Label LbEstadoText = new Label();
    //            LbEstadoText.ID = "LbEstadoText" + Convert.ToString(i);

    //            if (DRradHis.SerieCodigo == null)
    //                LbEstadoText.Text = "En Proceso";
    //            else
    //                LbEstadoText.Text = "Archivado";

    //            Pnl.Controls.Add(LbEstadoText);
    //            */

    //            Pnl.HorizontalAlign = HorizontalAlign.Left;
    //            /*Final de edicion de panel de contenido*/

    //            AjaxControlToolkit.PopupControlExtender PCPaso = new AjaxControlToolkit.PopupControlExtender();
    //            PCPaso.ID = PCPaso + Convert.ToString(i);
    //            PCPaso.TargetControlID = "ImgPaso" + Convert.ToString(i);
    //            PCPaso.PopupControlID = "Pnl" + Convert.ToString(i);

    //            Cell1.Controls.Add(PCPaso);


    //            HtmlTableCell Cell2 = new HtmlTableCell();
    //            Row1.Cells.Add(Cell2);

    //            if (DRradHis.WFMovimientoPasoActual == "0" && DRradHis.WFMovimientoPasoFinal == "0")
    //            {
    //                ImageButton ImgFlecha = new ImageButton();
    //                ImgFlecha.ID = "ImgFlecha" + Convert.ToString(i);
    //                ImgFlecha.ImageUrl = "~/AlfaNetImagen/ToolBar/flechadanima.gif";
    //                ImgFlecha.PostBackUrl = "javascript:void(0);";
    //                ImgFlecha.Visible = true;

    //                Cell2.Controls.Add(ImgFlecha);
    //            }
    //            HtmlTableCell Cell2a = new HtmlTableCell();

    //            Row1.Cells.Add(Cell2a);

    //        }
    //        else
    //        {
    //            HtmlTableRow Row2 = new HtmlTableRow();

    //            Tabla.Rows.Add(Row2);

    //            HtmlTableCell Cell0 = new HtmlTableCell();
    //            Row2.Cells.Add(Cell0);


    //            HtmlTableCell Cell3 = new HtmlTableCell();

    //            Row2.Cells.Add(Cell3);
    //            if (DRradHis.WFMovimientoPasoActual == "0" && DRradHis.WFMovimientoPasoFinal == "0")
    //            {
    //                ImageButton ImgFlecha2 = new ImageButton();
    //                ImgFlecha2.ID = "ImgFlecha" + Convert.ToString(i);
    //                ImgFlecha2.ImageUrl = "~/AlfaNetImagen/ToolBar/flechaianima.gif";
    //                ImgFlecha2.PostBackUrl = "javascript:void(0);";
    //                ImgFlecha2.Visible = true;

    //                Cell3.Controls.Add(ImgFlecha2);
    //            }


    //            HtmlTableCell Cell4 = new HtmlTableCell();

    //            Row2.Cells.Add(Cell4);

    //            Image ImgPaso2 = new Image();
    //            ImgPaso2.ID = "ImgPaso" + Convert.ToString(i);
    //            if (DRradHis.WfmovimientoTipo.ToString() == "1")
    //            {
    //                ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg.jpg";
    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
    //            {
    //                ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFArchivoImg.jpg";
    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "4" && DRradHis.SerieCodigo == null)
    //            {
    //                ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg.jpg";
    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "4" && DRradHis.SerieCodigo != null)
    //            {
    //                ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFArchivoImg.jpg";
    //            }
    //            ImgPaso2.Visible = true;

    //            Cell4.Controls.Add(ImgPaso2);

    //            /*Creacion del panel del paso 2*/
    //            Panel Pnl1 = new Panel();
    //            Pnl1.ID = "Pnl1" + Convert.ToString(i);
    //            //Pnl1.CssClass = "popupControl";
    //            Cell4.Controls.Add(Pnl1);

    //            /*Obtener la informacion de los pasos*/
    //            String Datos_1 = "";
    //            String Datos_2 = "";
    //            String Datos_3 = "";

    //            if (DRradHis.WfmovimientoTipo.ToString() == "1")
    //            {
    //                Datos_3="Dependencia:";
    //                Datos_1 = Convert.ToString(DRradHis.DependenciaNombre);

    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
    //            {
    //                Datos_3 = "Serie:";
    //                Datos_1 = Convert.ToString(DRradHis.SerieNombre);
    //            }


    //            if (DRradHis.SerieCodigo == null)
    //                Datos_2 = "En Proceso";
    //            else
    //                Datos_2 = "Archivado";



    //            HtmlGenericControl nid = this.generarPanContent(0,Convert.ToString(i),Datos_3, Datos_1, Convert.ToString(DRradHis.WFAccionNombre),
    //                Convert.ToString(DRradHis.WFMovimientoFecha1), Convert.ToString(DRradHis.WFMovimientoFechaFin),
    //                Datos_2);

    //            /*Insertar el panel*/
    //            Pnl1.Controls.Add(nid);



    //            /*

    //            Label LbPasoNombre1 = new Label();
    //            LbPasoNombre1.ID = "LbPasoNombre1" + Convert.ToString(i);
    //            LbPasoNombre1.Text = "Paso: ";
    //            LbPasoNombre1.Font.Bold = true;
    //            Pnl1.Controls.Add(LbPasoNombre1);

    //            Label LbPaso1 = new Label();
    //            LbPaso1.ID = "LbPaso1" + Convert.ToString(i);
    //            LbPaso1.Text = Convert.ToString(DRradHis.WFMovimientoPaso);

    //            Pnl1.Controls.Add(LbPaso1);

    //            Pnl1.Controls.Add(new LiteralControl("<br />"));

    //            Label LbDependenciaNombre1 = new Label();
    //            LbDependenciaNombre1.ID = "LbDependenciaNombre1" + Convert.ToString(i);
    //            if (DRradHis.WfmovimientoTipo.ToString() == "1")
    //            {
    //                LbDependenciaNombre1.Text = "Dependencia: ";

    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
    //            {
    //                LbDependenciaNombre1.Text = "Serie: ";
    //            }
    //            //LbDependenciaNombre1.Text = "Dependencia: ";
    //            LbDependenciaNombre1.Font.Bold = true;
    //            Pnl1.Controls.Add(LbDependenciaNombre1);

    //            Label LbDependenciaText1 = new Label();
    //            LbDependenciaText1.ID = "LbDependenciaText1" + Convert.ToString(i);
    //            if (DRradHis.WfmovimientoTipo.ToString() == "1")
    //            {
    //                LbDependenciaText1.Text = Convert.ToString(DRradHis.DependenciaNombre);

    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
    //            {
    //                LbDependenciaText1.Text = Convert.ToString(DRradHis.SerieNombre);
    //            }
    //            //LbDependenciaText1.Text = Convert.ToString(DRradHis.DependenciaNombre);

    //            Pnl1.Controls.Add(LbDependenciaText1);

    //            Pnl1.Controls.Add(new LiteralControl("<br />"));

    //            Label LbAccioNombre1 = new Label();
    //            LbAccioNombre1.ID = "LbAccionNombre1" + Convert.ToString(i);
    //            LbAccioNombre1.Text = "Accion: ";
    //            LbAccioNombre1.Font.Bold = true;
    //            Pnl1.Controls.Add(LbAccioNombre1);

    //            Label LbAccionText1 = new Label();
    //            LbAccionText1.ID = "LbAccionText1" + Convert.ToString(i);
    //            LbAccionText1.Text = Convert.ToString(DRradHis.WFAccionNombre);

    //            Pnl1.Controls.Add(LbAccionText1);

    //            Pnl1.Controls.Add(new LiteralControl("<br />"));

    //            Label LbFechaInicioNombre1 = new Label();
    //            LbFechaInicioNombre1.ID = "LbFechaInicioNombre1" + Convert.ToString(i);
    //            LbFechaInicioNombre1.Text = "Fecha Inicio: ";
    //            LbDependenciaNombre1.Font.Bold = true;
    //            Pnl1.Controls.Add(LbFechaInicioNombre1);
    //            //Ojo es nombre Accion
    //            Label LbFechaInicioText1 = new Label();
    //            LbFechaInicioText1.ID = "LbFechaInicioText1" + Convert.ToString(i);
    //            LbFechaInicioText1.Text = Convert.ToString(DRradHis.WFMovimientoFecha1);

    //            Pnl1.Controls.Add(LbFechaInicioText1);

    //            Pnl1.Controls.Add(new LiteralControl("<br />"));

    //            Label LbFechaFinNombre1 = new Label();
    //            LbFechaFinNombre1.ID = "LbFechaFinNombre1" + Convert.ToString(i);
    //            LbFechaFinNombre1.Text = "Fecha Fin: ";
    //            LbFechaFinNombre1.Font.Bold = true;
    //            Pnl1.Controls.Add(LbFechaFinNombre1);

    //            Label LbFechaFinText1 = new Label();
    //            LbFechaFinText1.ID = "LbFechaFinText1" + Convert.ToString(i);
    //            //Ojo es fecha Fin

    //            LbFechaFinText1.Text = Convert.ToString(DRradHis.WFMovimientoFechaFin);

    //            Pnl1.Controls.Add(LbFechaFinText1);

    //            Pnl1.Controls.Add(new LiteralControl("<br />"));

    //            Label LbEstadoNombre1 = new Label();
    //            LbEstadoNombre1.ID = "LbEstadoNombre1" + Convert.ToString(i);
    //            LbEstadoNombre1.Text = "Estado: ";
    //            LbEstadoNombre1.Font.Bold = true;
    //            Pnl1.Controls.Add(LbEstadoNombre1);

    //            Label LbEstadoText1 = new Label();
    //            LbEstadoText1.ID = "LbEstadoText1" + Convert.ToString(i);

    //            if (DRradHis.SerieCodigo == null)
    //                LbEstadoText1.Text = "En Proceso";
    //            else
    //                LbEstadoText1.Text = "Archivado";

    //            Pnl1.Controls.Add(LbEstadoText1);
    //            */
    //            Pnl1.HorizontalAlign = HorizontalAlign.Left;

    //            AjaxControlToolkit.PopupControlExtender PCPaso1 = new AjaxControlToolkit.PopupControlExtender();
    //            PCPaso1.ID = "PCPaso1" + Convert.ToString(i);
    //            PCPaso1.TargetControlID = "ImgPaso" + Convert.ToString(i);
    //            PCPaso1.PopupControlID = "Pnl1" + Convert.ToString(i);

    //            Cell4.Controls.Add(PCPaso1);

    //            //if (DRradHis.WFMovimientoNotas != "" && DRradHis.WFMovimientoNotas != null)
    //            if (Notas != "" && Notas != null)
    //            {
    //                //HtmlTableCell Cell01a = new HtmlTableCell();
    //                //Row2.Cells.Add(Cell01a);

    //                Image ImgPostIt1 = new Image();
    //                ImgPostIt1.ID = "ImgPostIt1" + Convert.ToString(i);
    //                ImgPostIt1.ImageUrl = "~/AlfaNetImagen/ToolBar/post-it.gif";
    //                ImgPostIt1.Visible = true;
    //                Cell4.Controls.Add(ImgPostIt1);

    //                Panel Papost = new Panel();
    //                Papost.ID = "Papost" + Convert.ToString(i);
    //                Papost.CssClass = "popupControl";
    //                Cell4.Controls.Add(Papost);

    //                Label LbPasoPostIt1 = new Label();
    //                LbPasoPostIt1.ID = "LbPasoPostIt1" + Convert.ToString(i);
    //                LbPasoPostIt1.Width = Unit.Pixel(300);
    //                LbPasoPostIt1.Height = Unit.Pixel(80);
    //                LbPasoPostIt1.Text = RowSig.ItemArray[16].ToString();
    //                LbPasoPostIt1.Font.Bold = true;
    //                LbPasoPostIt1.BackColor = System.Drawing.Color.Transparent;
    //                Papost.Controls.Add(LbPasoPostIt1);

    //                Papost.HorizontalAlign = HorizontalAlign.Left;

    //                AjaxControlToolkit.PopupControlExtender PCPostIt1 = new AjaxControlToolkit.PopupControlExtender();
    //                PCPostIt1.ID = "PCPostIt1" + Convert.ToString(i);
    //                PCPostIt1.TargetControlID = "ImgPostIt1" + Convert.ToString(i);
    //                PCPostIt1.PopupControlID = "Papost" + Convert.ToString(i);

    //                Cell4.Controls.Add(PCPostIt1);
    //            }

    //            HtmlTableCell Cell4a = new HtmlTableCell();

    //            Row2.Cells.Add(Cell4a);

    //            Label LabelDep1 = new Label();
    //            LabelDep1.ID = "LabelDep" + Convert.ToString(i);
    //            if (DRradHis.WfmovimientoTipo.ToString() == "1")
    //            {
    //                LabelDep1.Text = DRradHis.DependenciaNombre.ToString();

    //            }
    //            else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
    //            {
    //                LabelDep1.Text = DRradHis.SerieNombre.ToString();
    //            }
    //            //LabelDep1.Text = DRradHis.DependenciaNombre.ToString();
    //            LabelDep1.Visible = true;
    //            LabelDep1.Width = 150;
    //            Cell4a.Controls.Add(LabelDep1);

    //        }
    //        i = i + 1;

    //    }
    //    this.Panel1.Controls.Add(Tabla);
    //}
    //catch (Exception Error)
    //{
    //    this.ExceptionDetails.Text = "Problema" + Error;
    //}
    //}
    


    protected void escriba(DataRow[] rows)
    {
        try
        {

            HtmlTable Tabla = new HtmlTable();

            int i = 1;

            foreach (DSRadicado.Radicado_ConsultasHistoricoRow DRradHis in rows)
            {
                DataRow RowSig;
                String Notas;
                if (i < rows.Length)
                {
                    RowSig = rows[i];
                    Notas = RowSig.ItemArray[16].ToString();
                }
                else
                {
                    RowSig = rows[i - 1];
                    Notas = null;
                }

                if (i % 2 != 0)
                {
                    HtmlTableRow Row1 = new HtmlTableRow();

                    Tabla.Rows.Add(Row1);

                    HtmlTableCell Cell0 = new HtmlTableCell();
                    Row1.Cells.Add(Cell0);
                    Cell0.Align = "Center";

                    Label LabelDep = new Label();
                    LabelDep.ID = "LabelDep" + Convert.ToString(i);
                    if (DRradHis.WfmovimientoTipo.ToString() == "1")
                    {
                        LabelDep.Text = DRradHis.DependenciaNombre.ToString();

                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
                    {
                        LabelDep.Text = DRradHis.SerieNombre.ToString();
                    }

                    LabelDep.Visible = true;
                    LabelDep.Width = 150;
                    Cell0.Controls.Add(LabelDep);

                    //if (DRradHis.WFMovimientoNotas != "" && DRradHis.WFMovimientoNotas != null)
                    HtmlTableCell Cell01 = new HtmlTableCell();
                    Row1.Cells.Add(Cell01);

                    HtmlTableCell Cell1 = new HtmlTableCell();

                    Row1.Cells.Add(Cell1);
                    Cell1.Align = "Right";


                    Image ImgPaso = new Image();
                    ImgPaso.ID = "ImgPaso" + Convert.ToString(i);
                    if (DRradHis.WfmovimientoTipo.ToString() == "1")
                    {
                        ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg2.jpg";
                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
                    {
                        ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFArchivoImg.jpg";
                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "4" && DRradHis.SerieCodigo == null)
                    {
                        ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg2.jpg";
                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "4" && DRradHis.SerieCodigo != null)
                    {
                        ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFArchivoImg.jpg";
                    }
                    ImgPaso.Visible = true;
                    ImgPaso.Height = 80;
                    Cell1.Controls.Add(ImgPaso);

                    /*Inicio de edicion de panel de paso*/

                    Panel Pnl = new Panel();
                    Pnl.ID = "Pnl" + Convert.ToString(i);
                    //Pnl.CssClass = "popupControl";
                    Cell1.Controls.Add(Pnl);

                    /*Obtener la informacion de los pasos*/
                    /*Obtener la informacion de los pasos*/
                    String Datos_1 = "";
                    String Datos_2 = "";
                    String Datos_3 = "";

                    if (DRradHis.WfmovimientoTipo.ToString() == "1")
                    {
                        Datos_3 = "Dependencia:";
                        Datos_1 = Convert.ToString(DRradHis.DependenciaNombre);

                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
                    {
                        Datos_3 = "Serie:";
                        Datos_1 = Convert.ToString(DRradHis.SerieNombre);
                    }


                    if (DRradHis.SerieCodigo == null)
                        Datos_2 = "En Proceso";
                    else
                        Datos_2 = "Archivado";



                    HtmlGenericControl nid = this.generarPanContent(0, Convert.ToString(i), Datos_3, Datos_1, Convert.ToString(DRradHis.WFAccionNombre),
                        Convert.ToString(DRradHis.WFMovimientoFecha1), Convert.ToString(DRradHis.WFMovimientoFechaFin),
                        Datos_2);


                    /*Insertar el panel*/
                    Pnl.Controls.Add(nid);
                    #region comentario 2

                    /*Insercion de contenido*/
                    /*
                    Label LbPasoNombre = new Label();
                    LbPasoNombre.ID = "LbPasoNombre" + Convert.ToString(i);
                    LbPasoNombre.Text = "Paso: ";
                    LbPasoNombre.Font.Bold = true;
                    Pnl.Controls.Add(LbPasoNombre);

                    Label LbPaso = new Label();
                    LbPaso.ID = "LbPaso" + Convert.ToString(i);
                    LbPaso.Text = Convert.ToString(DRradHis.WFMovimientoPaso);

                    Pnl.Controls.Add(LbPaso);

                    Pnl.Controls.Add(new LiteralControl("<br />"));

                    Label LbDependenciaNombre = new Label();
                    LbDependenciaNombre.ID = "LbDependenciaNombre" + Convert.ToString(i);
                    if (DRradHis.WfmovimientoTipo.ToString() == "1")
                    {
                        LbDependenciaNombre.Text = "Dependencia: ";
					
                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
                    {
                        LbDependenciaNombre.Text = "Serie: ";
                    }
				
                    LbDependenciaNombre.Font.Bold = true;

                    Pnl.Controls.Add(LbDependenciaNombre);

                    Label LbDependenciaText = new Label();
                    LbDependenciaText.ID = "LbDependenciaText" + Convert.ToString(i);
                    if (DRradHis.WfmovimientoTipo.ToString() == "1")
                    {
                        LbDependenciaText.Text = Convert.ToString(DRradHis.DependenciaNombre);

                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
                    {
                        LbDependenciaText.Text = Convert.ToString(DRradHis.SerieNombre);
                    }
				

                    Pnl.Controls.Add(LbDependenciaText);

                    Pnl.Controls.Add(new LiteralControl("<br />"));

                    Label LbAccioNombre = new Label();
                    LbAccioNombre.ID = "LbAccionNombre" + Convert.ToString(i);
                    LbAccioNombre.Text = "Accion: ";
                    LbAccioNombre.Font.Bold = true;
                    Pnl.Controls.Add(LbAccioNombre);

                    Label LbAccionText = new Label();
                    LbAccionText.ID = "LbAccionText" + Convert.ToString(i);
                    LbAccionText.Text = Convert.ToString(DRradHis.WFAccionNombre);

                    Pnl.Controls.Add(LbAccionText);

                    Pnl.Controls.Add(new LiteralControl("<br />"));

                    Label LbFechaInicioNombre = new Label();
                    LbFechaInicioNombre.ID = "LbFechaInicioNombre" + Convert.ToString(i);
                    LbFechaInicioNombre.Text = "Fecha Inicio: ";
                    LbDependenciaNombre.Font.Bold = true;
                    Pnl.Controls.Add(LbFechaInicioNombre);
                    //Ojo es nombre Accion
                    Label LbFechaInicioText = new Label();
                    LbFechaInicioText.ID = "LbFechaInicioText" + Convert.ToString(i);
                    LbFechaInicioText.Text = Convert.ToString(DRradHis.WFMovimientoFecha1);

                    Pnl.Controls.Add(LbFechaInicioText);

                    Pnl.Controls.Add(new LiteralControl("<br />"));

                    Label LbFechaFinNombre = new Label();
                    LbFechaFinNombre.ID = "LbFechaFinNombre" + Convert.ToString(i);
                    LbFechaFinNombre.Text = "Fecha Fin: ";
                    LbFechaFinNombre.Font.Bold = true;
                    Pnl.Controls.Add(LbFechaFinNombre);

                    Label LbFechaFinText = new Label();
                    LbFechaFinText.ID = "LbFechaFinText" + Convert.ToString(i);
                    //Ojo es fecha Fin

                    LbFechaFinText.Text = Convert.ToString(DRradHis.WFMovimientoFechaFin);

                    Pnl.Controls.Add(LbFechaFinText);

                    Pnl.Controls.Add(new LiteralControl("<br />"));

                    Label LbEstadoNombre = new Label();
                    LbEstadoNombre.ID = "LbEstadoNombre" + Convert.ToString(i);
                    LbEstadoNombre.Text = "Estado: ";
                    LbEstadoNombre.Font.Bold = true;
                    Pnl.Controls.Add(LbEstadoNombre);

                    Label LbEstadoText = new Label();
                    LbEstadoText.ID = "LbEstadoText" + Convert.ToString(i);

                    if (DRradHis.SerieCodigo == null)
                        LbEstadoText.Text = "En Proceso";
                    else
                        LbEstadoText.Text = "Archivado";

                    Pnl.Controls.Add(LbEstadoText);
                    */
                    #endregion

                    Pnl.HorizontalAlign = HorizontalAlign.Left;
                    /*Final de edicion de panel de contenido*/

                    AjaxControlToolkit.PopupControlExtender PCPaso = new AjaxControlToolkit.PopupControlExtender();
                    PCPaso.ID = PCPaso + Convert.ToString(i);
                    PCPaso.TargetControlID = "ImgPaso" + Convert.ToString(i);
                    PCPaso.PopupControlID = "Pnl" + Convert.ToString(i);

                    Cell1.Controls.Add(PCPaso);


                    HtmlTableCell Cell2 = new HtmlTableCell();
                    Row1.Cells.Add(Cell2);
                    Cell2.Align = "left";

                    if (DRradHis.WFMovimientoPasoActual == "0" && DRradHis.WFMovimientoPasoFinal == "0")
                    {
                        ImageButton ImgFlecha = new ImageButton();
                        ImgFlecha.ID = "ImgFlecha" + Convert.ToString(i);
                        ImgFlecha.ImageUrl = "~/AlfaNetImagen/ToolBar/flechadanima.gif";
                        ImgFlecha.Width = 60;
                        ImgFlecha.Height = 70;
                        ImgFlecha.PostBackUrl = "javascript:void(0);";
                        ImgFlecha.Visible = true;

                        Cell2.Controls.Add(ImgFlecha);
                    }

                    HtmlTableCell Cell2B = new HtmlTableCell();

                    Row1.Cells.Add(Cell2B);
                    Cell2B.Align = "left";

                    if (Notas != "" && Notas != null)
                    {
                        //HtmlTableCell Cell01 = new HtmlTableCell();
                        //Row1.Cells.Add(Cell01);

                        Image ImgPostIt = new Image();
                        ImgPostIt.ID = "ImgPostIt" + Convert.ToString(i);
                        ImgPostIt.ImageUrl = "~/AlfaNetImagen/ToolBar/post-it-big.png";
                        ImgPostIt.Visible = true;
                        ImgPostIt.Height = 50;
                        Cell2B.Controls.Add(ImgPostIt);

                        Panel PnlPostIt = new Panel();
                        PnlPostIt.ID = "PnlPostIt" + Convert.ToString(i);
                        PnlPostIt.CssClass = "popupControl";
                        PnlPostIt.BorderStyle = BorderStyle.None;
                        Cell2B.Controls.Add(PnlPostIt);

                        TextBox LbPasoPostIt = new TextBox();
                        LbPasoPostIt.ID = "LbPasoPostIt" + Convert.ToString(i);
                        LbPasoPostIt.TextMode = TextBoxMode.MultiLine;
                        LbPasoPostIt.Width = Unit.Pixel(300);
                        LbPasoPostIt.Height = Unit.Pixel(80);
                        LbPasoPostIt.Text = RowSig.ItemArray[16].ToString();
                        LbPasoPostIt.Font.Bold = true;
                        LbPasoPostIt.Enabled = false;
                        LbPasoPostIt.BackColor = System.Drawing.Color.FromArgb(253, 250, 143);
                        LbPasoPostIt.BorderStyle = BorderStyle.Outset;
                        LbPasoPostIt.BorderWidth = 2;
                        LbPasoPostIt.BorderColor = System.Drawing.Color.FromArgb(174, 175, 174);
                        PnlPostIt.Controls.Add(LbPasoPostIt);

                        //Label LbPasoPostIt = new Label();
                        //LbPasoPostIt.ID = "LbPasoPostIt" + Convert.ToString(i);
                        //LbPasoPostIt.Width = Unit.Pixel(300);
                        //LbPasoPostIt.Height = Unit.Pixel(80);
                        //LbPasoPostIt.Text = RowSig.ItemArray[16].ToString();
                        //LbPasoPostIt.Font.Bold = true;
                        //LbPasoPostIt.BackColor = System.Drawing.Color.FromArgb(253, 250, 143);
                        //LbPasoPostIt.BorderStyle = BorderStyle.Outset;
                        //PnlPostIt.Controls.Add(LbPasoPostIt);

                        PnlPostIt.HorizontalAlign = HorizontalAlign.Left;

                        AjaxControlToolkit.PopupControlExtender PCPostIt = new AjaxControlToolkit.PopupControlExtender();
                        PCPostIt.ID = "PCPostIt" + Convert.ToString(i);
                        PCPostIt.TargetControlID = "ImgPostIt" + Convert.ToString(i);
                        PCPostIt.PopupControlID = "PnlPostIt" + Convert.ToString(i);

                        Cell2B.Controls.Add(PCPostIt);
                    }
                    //HtmlTableCell Cell2a = new HtmlTableCell();

                    //Row1.Cells.Add(Cell2a);

                }
                else
                {
                    HtmlTableRow Row2 = new HtmlTableRow();

                    Tabla.Rows.Add(Row2);

                    HtmlTableCell Cell0 = new HtmlTableCell();
                    Row2.Cells.Add(Cell0);

                    HtmlTableCell Cell01 = new HtmlTableCell();
                    Row2.Cells.Add(Cell01);

                    HtmlTableCell Cell3 = new HtmlTableCell();
                    Row2.Cells.Add(Cell3);


                    Cell3.Align = "right";
                    if (DRradHis.WFMovimientoPasoActual == "0" && DRradHis.WFMovimientoPasoFinal == "0")
                    {
                        ImageButton ImgFlecha2 = new ImageButton();
                        ImgFlecha2.ID = "ImgFlecha" + Convert.ToString(i);
                        ImgFlecha2.ImageUrl = "~/AlfaNetImagen/ToolBar/flechaianima.gif";
                        ImgFlecha2.PostBackUrl = "javascript:void(0);";
                        ImgFlecha2.Width = 60;
                        ImgFlecha2.Height = 70;
                        ImgFlecha2.Visible = true;

                        Cell3.Controls.Add(ImgFlecha2);
                    }


                    HtmlTableCell Cell4 = new HtmlTableCell();

                    Row2.Cells.Add(Cell4);

                    HtmlTableCell Cell01a = new HtmlTableCell();
                    Row2.Cells.Add(Cell01a);
                    Cell01a.Align = "right";

                    Image ImgPaso2 = new Image();
                    ImgPaso2.ID = "ImgPaso" + Convert.ToString(i);
                    if (DRradHis.WfmovimientoTipo.ToString() == "1")
                    {
                        ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg2.jpg";
                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
                    {
                        ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFArchivoImg.jpg";
                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "4" && DRradHis.SerieCodigo == null)
                    {
                        ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg2.jpg";
                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "4" && DRradHis.SerieCodigo != null)
                    {
                        ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFArchivoImg.jpg";
                    }
                    ImgPaso2.Visible = true;
                    ImgPaso2.Height = 80;

                    Cell4.Controls.Add(ImgPaso2);

                    /*Creacion del panel del paso 2*/
                    Panel Pnl1 = new Panel();
                    Pnl1.ID = "Pnl1" + Convert.ToString(i);
                    //Pnl1.CssClass = "popupControl";
                    Cell4.Controls.Add(Pnl1);

                    /*Obtener la informacion de los pasos*/
                    String Datos_1 = "";
                    String Datos_2 = "";
                    String Datos_3 = "";

                    if (DRradHis.WfmovimientoTipo.ToString() == "1")
                    {
                        Datos_3 = "Dependencia:";
                        Datos_1 = Convert.ToString(DRradHis.DependenciaNombre);

                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
                    {
                        Datos_3 = "Serie:";
                        Datos_1 = Convert.ToString(DRradHis.SerieNombre);
                    }


                    if (DRradHis.SerieCodigo == null)
                        Datos_2 = "En Proceso";
                    else
                        Datos_2 = "Archivado";



                    HtmlGenericControl nid = this.generarPanContent(0, Convert.ToString(i), Datos_3, Datos_1, Convert.ToString(DRradHis.WFAccionNombre),
                        Convert.ToString(DRradHis.WFMovimientoFecha1), Convert.ToString(DRradHis.WFMovimientoFechaFin),
                        Datos_2);

                    /*Insertar el panel*/
                    Pnl1.Controls.Add(nid);

                    #region Comentario

                    /*

				Label LbPasoNombre1 = new Label();
				LbPasoNombre1.ID = "LbPasoNombre1" + Convert.ToString(i);
				LbPasoNombre1.Text = "Paso: ";
				LbPasoNombre1.Font.Bold = true;
				Pnl1.Controls.Add(LbPasoNombre1);

				Label LbPaso1 = new Label();
				LbPaso1.ID = "LbPaso1" + Convert.ToString(i);
				LbPaso1.Text = Convert.ToString(DRradHis.WFMovimientoPaso);

				Pnl1.Controls.Add(LbPaso1);

				Pnl1.Controls.Add(new LiteralControl("<br />"));

				Label LbDependenciaNombre1 = new Label();
				LbDependenciaNombre1.ID = "LbDependenciaNombre1" + Convert.ToString(i);
				if (DRradHis.WfmovimientoTipo.ToString() == "1")
				{
					LbDependenciaNombre1.Text = "Dependencia: ";

				}
				else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
				{
					LbDependenciaNombre1.Text = "Serie: ";
				}
				//LbDependenciaNombre1.Text = "Dependencia: ";
				LbDependenciaNombre1.Font.Bold = true;
				Pnl1.Controls.Add(LbDependenciaNombre1);

				Label LbDependenciaText1 = new Label();
				LbDependenciaText1.ID = "LbDependenciaText1" + Convert.ToString(i);
				if (DRradHis.WfmovimientoTipo.ToString() == "1")
				{
					LbDependenciaText1.Text = Convert.ToString(DRradHis.DependenciaNombre);

				}
				else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
				{
					LbDependenciaText1.Text = Convert.ToString(DRradHis.SerieNombre);
				}
				//LbDependenciaText1.Text = Convert.ToString(DRradHis.DependenciaNombre);

				Pnl1.Controls.Add(LbDependenciaText1);

				Pnl1.Controls.Add(new LiteralControl("<br />"));

				Label LbAccioNombre1 = new Label();
				LbAccioNombre1.ID = "LbAccionNombre1" + Convert.ToString(i);
				LbAccioNombre1.Text = "Accion: ";
				LbAccioNombre1.Font.Bold = true;
				Pnl1.Controls.Add(LbAccioNombre1);

				Label LbAccionText1 = new Label();
				LbAccionText1.ID = "LbAccionText1" + Convert.ToString(i);
				LbAccionText1.Text = Convert.ToString(DRradHis.WFAccionNombre);

				Pnl1.Controls.Add(LbAccionText1);

				Pnl1.Controls.Add(new LiteralControl("<br />"));

				Label LbFechaInicioNombre1 = new Label();
				LbFechaInicioNombre1.ID = "LbFechaInicioNombre1" + Convert.ToString(i);
				LbFechaInicioNombre1.Text = "Fecha Inicio: ";
				LbDependenciaNombre1.Font.Bold = true;
				Pnl1.Controls.Add(LbFechaInicioNombre1);
				//Ojo es nombre Accion
				Label LbFechaInicioText1 = new Label();
				LbFechaInicioText1.ID = "LbFechaInicioText1" + Convert.ToString(i);
				LbFechaInicioText1.Text = Convert.ToString(DRradHis.WFMovimientoFecha1);

				Pnl1.Controls.Add(LbFechaInicioText1);

				Pnl1.Controls.Add(new LiteralControl("<br />"));

				Label LbFechaFinNombre1 = new Label();
				LbFechaFinNombre1.ID = "LbFechaFinNombre1" + Convert.ToString(i);
				LbFechaFinNombre1.Text = "Fecha Fin: ";
				LbFechaFinNombre1.Font.Bold = true;
				Pnl1.Controls.Add(LbFechaFinNombre1);

				Label LbFechaFinText1 = new Label();
				LbFechaFinText1.ID = "LbFechaFinText1" + Convert.ToString(i);
				//Ojo es fecha Fin

				LbFechaFinText1.Text = Convert.ToString(DRradHis.WFMovimientoFechaFin);

				Pnl1.Controls.Add(LbFechaFinText1);

				Pnl1.Controls.Add(new LiteralControl("<br />"));

				Label LbEstadoNombre1 = new Label();
				LbEstadoNombre1.ID = "LbEstadoNombre1" + Convert.ToString(i);
				LbEstadoNombre1.Text = "Estado: ";
				LbEstadoNombre1.Font.Bold = true;
				Pnl1.Controls.Add(LbEstadoNombre1);

				Label LbEstadoText1 = new Label();
				LbEstadoText1.ID = "LbEstadoText1" + Convert.ToString(i);

				if (DRradHis.SerieCodigo == null)
					LbEstadoText1.Text = "En Proceso";
				else
					LbEstadoText1.Text = "Archivado";

				Pnl1.Controls.Add(LbEstadoText1);
				*/
                    #endregion

                    Pnl1.HorizontalAlign = HorizontalAlign.Left;

                    AjaxControlToolkit.PopupControlExtender PCPaso1 = new AjaxControlToolkit.PopupControlExtender();
                    PCPaso1.ID = "PCPaso1" + Convert.ToString(i);
                    PCPaso1.TargetControlID = "ImgPaso" + Convert.ToString(i);
                    PCPaso1.PopupControlID = "Pnl1" + Convert.ToString(i);

                    Cell4.Controls.Add(PCPaso1);

                    //if (DRradHis.WFMovimientoNotas != "" && DRradHis.WFMovimientoNotas != null)
                    if (Notas != "" && Notas != null)
                    {

                        Image ImgPostIt1 = new Image();
                        ImgPostIt1.ID = "ImgPostIt1" + Convert.ToString(i);
                        ImgPostIt1.ImageUrl = "~/AlfaNetImagen/ToolBar/post-it-big.png";
                        ImgPostIt1.Visible = true;
                        ImgPostIt1.Height = 50;
                        Cell01.Controls.Add(ImgPostIt1);

                        Panel Papost = new Panel();
                        Papost.ID = "Papost" + Convert.ToString(i);
                        Papost.CssClass = "popupControl";
                        Papost.BorderStyle = BorderStyle.None;
                        Cell01.Controls.Add(Papost);

                        //Label LbPasoPostIt1 = new Label();
                        TextBox LbPasoPostIt1 = new TextBox();
                        LbPasoPostIt1.ID = "LbPasoPostIt1" + Convert.ToString(i);
                        LbPasoPostIt1.TextMode = TextBoxMode.MultiLine;
                        LbPasoPostIt1.Width = Unit.Pixel(300);
                        LbPasoPostIt1.Height = Unit.Pixel(80);
                        LbPasoPostIt1.Text = RowSig.ItemArray[16].ToString();
                        LbPasoPostIt1.Font.Bold = true;
                        LbPasoPostIt1.Enabled = false;
                        LbPasoPostIt1.BackColor = System.Drawing.Color.FromArgb(253, 250, 143);
                        LbPasoPostIt1.BorderStyle = BorderStyle.Outset;
                        LbPasoPostIt1.BorderWidth = 2;
                        Papost.Controls.Add(LbPasoPostIt1);

                        Papost.HorizontalAlign = HorizontalAlign.Left;

                        AjaxControlToolkit.PopupControlExtender PCPostIt1 = new AjaxControlToolkit.PopupControlExtender();
                        PCPostIt1.ID = "PCPostIt1" + Convert.ToString(i);
                        PCPostIt1.TargetControlID = "ImgPostIt1" + Convert.ToString(i);
                        PCPostIt1.PopupControlID = "Papost" + Convert.ToString(i);

                        Cell01.Controls.Add(PCPostIt1);
                    }

                    HtmlTableCell Cell4a = new HtmlTableCell();

                    Row2.Cells.Add(Cell4a);
                    Cell4a.Align = "Center";

                    Label LabelDep1 = new Label();
                    LabelDep1.ID = "LabelDep" + Convert.ToString(i);
                    if (DRradHis.WfmovimientoTipo.ToString() == "1")
                    {
                        LabelDep1.Text = DRradHis.DependenciaNombre.ToString();

                    }
                    else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
                    {
                        LabelDep1.Text = DRradHis.SerieNombre.ToString();
                    }
                    //LabelDep1.Text = DRradHis.DependenciaNombre.ToString();
                    LabelDep1.Visible = true;
                    LabelDep1.Width = 150;
                    Cell4a.Controls.Add(LabelDep1);

                }
                i = i + 1;

            }
            this.Panel1.Controls.Add(Tabla);
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }


    /// <summary>
    /// Procedimiento para generar el código html de contenido del paso
    /// </summary>
    /// <returns>Retorna el tag embebido</returns>
    protected HtmlGenericControl generarPanContent(int tipo,String Paso,String Procede,String Cont,String Accion,
        String FechaIn, String FechaOut, String Estado)
    {
        HtmlGenericControl nid = new HtmlGenericControl("div");
        if (tipo == 0)
            nid.ID = "div_paso_" + Paso;
        else
            nid.ID = "div_copia_"+Paso;
        nid.InnerHtml = "<div class=\"shiftcontainer\" style=\"position: relative;left: 5px;top: 5px;\" ><div class=\"shadowcontainer\" style=\"width: 310px; background-color: #d1cfd0;\" ><div class=\"innerdiv\" style=\"border: 0px white; padding: 6px; position: relative; left: -5px; top: -5px;\" >" +
                      "<b>Paso " + Paso + "</b> <br />"+
                      "<table border=\"0\" cellspacing=\"-1\" width=320>"+
                      "<tr><td>" + Procede + "</td><td>" + Cont + "</td></tr>" +
                      "<tr><td>Acción:</td><td>" + Accion + "</td></tr>" +
                      "<tr><td>Fecha Inicio:</td><td>" + FechaIn + "</td></tr>" +
                      "<tr><td>Fecha Final:</td><td>" + FechaOut + "</td></tr>" +
                      "<tr><td>Estado:</td><td>" + Estado + "</td></tr></table>" +
                      "</div></div></div>";
        return nid;
    }




    protected void escribaCopiasAnterior(DataRow[] rows)
    {
        HtmlTable Tabla1 = new HtmlTable();

        int i = 1;

        foreach (DSRadicado.Radicado_ConsultasHistoricoRow DRradHis in rows)
        {
            
                HtmlTableRow Row1 = new HtmlTableRow();

                Tabla1.Rows.Add(Row1);

                HtmlTableCell Cell0 = new HtmlTableCell();

                Row1.Cells.Add(Cell0);
                Label LabelDep = new Label();
                LabelDep.ID = "LabelDepCopia" + Convert.ToString(i);
                LabelDep.Text = DRradHis.DependenciaNombre.ToString();
                LabelDep.Visible = true;
                LabelDep.Width = 150;
                Cell0.Controls.Add(LabelDep);

                HtmlTableCell Cell1 = new HtmlTableCell();

                Row1.Cells.Add(Cell1);

                Image ImgPaso = new Image();
                ImgPaso.ID = "ImgPasoCopia" + Convert.ToString(i);
                ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFDelegadoImg.jpg";
                ImgPaso.Visible = true;
                Cell1.Controls.Add(ImgPaso);


                /*Inserción de panel de contenido*/

                Panel Pnl1 = new Panel();
                Pnl1.ID = "PnlCopia" + Convert.ToString(i);
                //Pnl1.CssClass = "popupControl";
                Cell1.Controls.Add(Pnl1);



                
                  String Datos_1 = "";
                String Datos_2 = "";
                String Datos_3 = "";

                if (DRradHis.WfmovimientoTipo.ToString() == "1")
                {
                    Datos_3="Dependencia:";
                    Datos_1 = Convert.ToString(DRradHis.DependenciaNombre);

                }
                else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
                {
                    Datos_3 = "Serie:";
                    Datos_1 = Convert.ToString(DRradHis.SerieNombre);
                }


                if (DRradHis.SerieCodigo == null)
                    Datos_2 = "En Proceso";
                else
                    Datos_2 = "Archivado";



                HtmlGenericControl nid = this.generarPanContent(1,Convert.ToString(i),Datos_3, Datos_1, Convert.ToString(DRradHis.WFAccionNombre),
                    Convert.ToString(DRradHis.WFMovimientoFecha1), Convert.ToString(DRradHis.WFMovimientoFechaFin),
                    Datos_2);





                Pnl1.Controls.Add(nid);
                # region comentario
                /*

                Label LbPasoNombre = new Label();
                LbPasoNombre.ID = "LbPasoNombreCopia" + Convert.ToString(i);
                LbPasoNombre.Text = "Paso: ";
                LbPasoNombre.Font.Bold = true;
                Pnl1.Controls.Add(LbPasoNombre);

                Label LbPaso = new Label();
                LbPaso.ID = "LbPasoCopia" + Convert.ToString(i);
                LbPaso.Text = Convert.ToString(DRradHis.WFMovimientoPaso);

                Pnl1.Controls.Add(LbPaso);

                Pnl1.Controls.Add(new LiteralControl("<br />"));

                Label LbDependenciaNombre = new Label();
                LbDependenciaNombre.ID = "LbDependenciaNombreCopia" + Convert.ToString(i);
                LbDependenciaNombre.Text = "Dependencia: ";
                LbDependenciaNombre.Font.Bold = true;
                Pnl1.Controls.Add(LbDependenciaNombre);

                Label LbDependenciaText = new Label();
                LbDependenciaText.ID = "LbDependenciaTextCopia" + Convert.ToString(i);
                LbDependenciaText.Text = DRradHis.DependenciaNombre.ToString();

                Pnl1.Controls.Add(LbDependenciaText);

                Pnl1.Controls.Add(new LiteralControl("<br />"));

                Label LbAccioNombre = new Label();
                LbAccioNombre.ID = "LbAccionNombreCopia" + Convert.ToString(i);
                LbAccioNombre.Text = "Accion: ";
                LbAccioNombre.Font.Bold = true;
                Pnl1.Controls.Add(LbAccioNombre);

                Label LbAccionText = new Label();
                LbAccionText.ID = "LbAccionTextCopia" + Convert.ToString(i);
                LbAccionText.Text = Convert.ToString(DRradHis.WFAccionNombre);

                Pnl1.Controls.Add(LbAccionText);

                Pnl1.Controls.Add(new LiteralControl("<br />"));

                Label LbFechaInicioNombre = new Label();
                LbFechaInicioNombre.ID = "LbFechaInicioNombreCopia" + Convert.ToString(i);
                LbFechaInicioNombre.Text = "Fecha Inicio: ";
                LbFechaInicioNombre.Font.Bold = true;
                Pnl1.Controls.Add(LbFechaInicioNombre);
                //Ojo es nombre Accion
                Label LbFechaInicioText = new Label();
                LbFechaInicioText.ID = "LbFechaInicioTextCopia" + Convert.ToString(i);
                LbFechaInicioText.Text = Convert.ToString(DRradHis.WFMovimientoFecha1);

                Pnl1.Controls.Add(LbFechaInicioText);

                Pnl1.Controls.Add(new LiteralControl("<br />"));

                Label LbFechaFinNombre = new Label();
                LbFechaFinNombre.ID = "LbFechaFinNombreCopia" + Convert.ToString(i);
                LbFechaFinNombre.Text = "Fecha Fin: ";
                LbFechaFinNombre.Font.Bold = true;
                Pnl1.Controls.Add(LbFechaFinNombre);

                Label LbFechaFinText = new Label();
                LbFechaFinText.ID = "LbFechaFinTextCopia" + Convert.ToString(i);
                //Ojo es fecha Fin

                LbFechaFinText.Text = Convert.ToString(DRradHis.WFMovimientoFechaFin);

                Pnl1.Controls.Add(LbFechaFinText);

                Pnl1.Controls.Add(new LiteralControl("<br />"));

                Label LbEstadoNombre = new Label();
                LbEstadoNombre.ID = "LbEstadoNombreCopia" + Convert.ToString(i);
                LbEstadoNombre.Text = "Estado: ";
                LbEstadoNombre.Font.Bold = true;
                Pnl1.Controls.Add(LbEstadoNombre);

                Label LbEstadoText = new Label();
                LbEstadoText.ID = "LbEstadoTextCopia" + Convert.ToString(i);

                if (DRradHis.SerieCodigo == null)
                    LbEstadoText.Text = "En Proceso";
                else
                    LbEstadoText.Text = "Archivado";

                Pnl1.Controls.Add(LbEstadoText);

                 */
                # endregion

                Pnl1.HorizontalAlign = HorizontalAlign.Left;

                AjaxControlToolkit.PopupControlExtender PCPaso = new AjaxControlToolkit.PopupControlExtender();
                PCPaso.ID = "PCPasoCopia" + Convert.ToString(i);
                PCPaso.TargetControlID = "ImgPasoCopia" + Convert.ToString(i);
                PCPaso.PopupControlID = "PnlCopia" + Convert.ToString(i);

                Cell1.Controls.Add(PCPaso);

                HtmlTableCell Cell2 = new HtmlTableCell();
                Row1.Cells.Add(Cell2);

                
                HtmlTableCell Cell2a = new HtmlTableCell();

                Row1.Cells.Add(Cell2a);

                if (DRradHis.WFMovimientoNotas != "" && DRradHis.WFMovimientoNotas != null)
                {
                    //HtmlTableCell Cell01 = new HtmlTableCell();
                    //Row1.Cells.Add(Cell01);

                    Image ImgPostItCopia = new Image();
                    ImgPostItCopia.ID = "ImgPostItCopia" + Convert.ToString(i);
                    ImgPostItCopia.ImageUrl = "~/AlfaNetImagen/ToolBar/post-it.gif";
                    ImgPostItCopia.Visible = true;
                    Cell2a.Controls.Add(ImgPostItCopia);

                    Panel PnlPostItCopia = new Panel();
                    PnlPostItCopia.ID = "PnlPostItCopia" + Convert.ToString(i);
                    PnlPostItCopia.CssClass = "popupControl";
                    PnlPostItCopia.Height = Unit.Pixel(100);
                    PnlPostItCopia.Width = Unit.Pixel(300);
                    PnlPostItCopia.ScrollBars = ScrollBars.Vertical;
                    Cell2a.Controls.Add(PnlPostItCopia);

                    TextBox LbPasoPostItCopia = new TextBox();
                    //Label LbPasoPostItCopia = new Label();
                    LbPasoPostItCopia.ID = "LbPasoPostItCopia" + Convert.ToString(i);
                    LbPasoPostItCopia.TextMode = TextBoxMode.MultiLine;
                    LbPasoPostItCopia.Width = Unit.Pixel(290);
                    LbPasoPostItCopia.Height = Unit.Pixel(500);
                    LbPasoPostItCopia.Text = DRradHis.WFMovimientoNotas;
                    LbPasoPostItCopia.Font.Bold = true;
                    LbPasoPostItCopia.Enabled = false;
                    LbPasoPostItCopia.BackColor = System.Drawing.Color.FromArgb(253, 250, 143);
                    LbPasoPostItCopia.BorderStyle = BorderStyle.Outset;
                    LbPasoPostItCopia.BorderWidth = 2;
                    PnlPostItCopia.Controls.Add(LbPasoPostItCopia);



                    PnlPostItCopia.HorizontalAlign = HorizontalAlign.Left;

                    AjaxControlToolkit.PopupControlExtender PCPostItCopia = new AjaxControlToolkit.PopupControlExtender();
                    PCPostItCopia.ID = "PCPostItCopia" + Convert.ToString(i);
                    PCPostItCopia.TargetControlID = "ImgPostItCopia" + Convert.ToString(i);
                    PCPostItCopia.PopupControlID = "PnlPostItCopia" + Convert.ToString(i);

                    Cell2a.Controls.Add(PCPostItCopia);
                }



                i = i + 1;
            }
     
        this.Panel2.Controls.Add(Tabla1);
    }

    protected void escribaCopias(DataRow[] rows)
	{
		HtmlTable Tabla1 = new HtmlTable();

		int i = 1;

		foreach (DSRadicado.Radicado_ConsultasHistoricoRow DRradHis in rows)
		{
			
				HtmlTableRow Row1 = new HtmlTableRow();

				Tabla1.Rows.Add(Row1);

				HtmlTableCell Cell0 = new HtmlTableCell();

				Row1.Cells.Add(Cell0);
				Label LabelDep = new Label();
				LabelDep.ID = "LabelDepCopia" + Convert.ToString(i);
				LabelDep.Text = DRradHis.DependenciaNombre.ToString();
				LabelDep.Visible = true;
				LabelDep.Width = 150;
				Cell0.Controls.Add(LabelDep);

				HtmlTableCell Cell1 = new HtmlTableCell();

				Row1.Cells.Add(Cell1);

				Image ImgPaso = new Image();
				ImgPaso.ID = "ImgPasoCopia" + Convert.ToString(i);
				ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFDelegadoImg2.jpg";
				ImgPaso.Visible = true;
				Cell1.Controls.Add(ImgPaso);


				/*Inserción de panel de contenido*/

				Panel Pnl1 = new Panel();
				Pnl1.ID = "PnlCopia" + Convert.ToString(i);
				//Pnl1.CssClass = "popupControl";
				Cell1.Controls.Add(Pnl1);



				
				  String Datos_1 = "";
				String Datos_2 = "";
				String Datos_3 = "";

				if (DRradHis.WfmovimientoTipo.ToString() == "1")
				{
					Datos_3="Dependencia:";
					Datos_1 = Convert.ToString(DRradHis.DependenciaNombre);

				}
				else if (DRradHis.WfmovimientoTipo.ToString() == "3" || DRradHis.WfmovimientoTipo.ToString() == "7")
				{
					Datos_3 = "Serie:";
					Datos_1 = Convert.ToString(DRradHis.SerieNombre);
				}


				if (DRradHis.SerieCodigo == null)
					Datos_2 = "En Proceso";
				else
					Datos_2 = "Archivado";



				HtmlGenericControl nid = this.generarPanContent(1,Convert.ToString(i),Datos_3, Datos_1, Convert.ToString(DRradHis.WFAccionNombre),
					Convert.ToString(DRradHis.WFMovimientoFecha1), Convert.ToString(DRradHis.WFMovimientoFechaFin),
					Datos_2);





				Pnl1.Controls.Add(nid);

				/*

				Label LbPasoNombre = new Label();
				LbPasoNombre.ID = "LbPasoNombreCopia" + Convert.ToString(i);
				LbPasoNombre.Text = "Paso: ";
				LbPasoNombre.Font.Bold = true;
				Pnl1.Controls.Add(LbPasoNombre);

				Label LbPaso = new Label();
				LbPaso.ID = "LbPasoCopia" + Convert.ToString(i);
				LbPaso.Text = Convert.ToString(DRradHis.WFMovimientoPaso);

				Pnl1.Controls.Add(LbPaso);

				Pnl1.Controls.Add(new LiteralControl("<br />"));

				Label LbDependenciaNombre = new Label();
				LbDependenciaNombre.ID = "LbDependenciaNombreCopia" + Convert.ToString(i);
				LbDependenciaNombre.Text = "Dependencia: ";
				LbDependenciaNombre.Font.Bold = true;
				Pnl1.Controls.Add(LbDependenciaNombre);

				Label LbDependenciaText = new Label();
				LbDependenciaText.ID = "LbDependenciaTextCopia" + Convert.ToString(i);
				LbDependenciaText.Text = DRradHis.DependenciaNombre.ToString();

				Pnl1.Controls.Add(LbDependenciaText);

				Pnl1.Controls.Add(new LiteralControl("<br />"));

				Label LbAccioNombre = new Label();
				LbAccioNombre.ID = "LbAccionNombreCopia" + Convert.ToString(i);
				LbAccioNombre.Text = "Accion: ";
				LbAccioNombre.Font.Bold = true;
				Pnl1.Controls.Add(LbAccioNombre);

				Label LbAccionText = new Label();
				LbAccionText.ID = "LbAccionTextCopia" + Convert.ToString(i);
				LbAccionText.Text = Convert.ToString(DRradHis.WFAccionNombre);

				Pnl1.Controls.Add(LbAccionText);

				Pnl1.Controls.Add(new LiteralControl("<br />"));

				Label LbFechaInicioNombre = new Label();
				LbFechaInicioNombre.ID = "LbFechaInicioNombreCopia" + Convert.ToString(i);
				LbFechaInicioNombre.Text = "Fecha Inicio: ";
				LbFechaInicioNombre.Font.Bold = true;
				Pnl1.Controls.Add(LbFechaInicioNombre);
				//Ojo es nombre Accion
				Label LbFechaInicioText = new Label();
				LbFechaInicioText.ID = "LbFechaInicioTextCopia" + Convert.ToString(i);
				LbFechaInicioText.Text = Convert.ToString(DRradHis.WFMovimientoFecha1);

				Pnl1.Controls.Add(LbFechaInicioText);

				Pnl1.Controls.Add(new LiteralControl("<br />"));

				Label LbFechaFinNombre = new Label();
				LbFechaFinNombre.ID = "LbFechaFinNombreCopia" + Convert.ToString(i);
				LbFechaFinNombre.Text = "Fecha Fin: ";
				LbFechaFinNombre.Font.Bold = true;
				Pnl1.Controls.Add(LbFechaFinNombre);

				Label LbFechaFinText = new Label();
				LbFechaFinText.ID = "LbFechaFinTextCopia" + Convert.ToString(i);
				//Ojo es fecha Fin

				LbFechaFinText.Text = Convert.ToString(DRradHis.WFMovimientoFechaFin);

				Pnl1.Controls.Add(LbFechaFinText);

				Pnl1.Controls.Add(new LiteralControl("<br />"));

				Label LbEstadoNombre = new Label();
				LbEstadoNombre.ID = "LbEstadoNombreCopia" + Convert.ToString(i);
				LbEstadoNombre.Text = "Estado: ";
				LbEstadoNombre.Font.Bold = true;
				Pnl1.Controls.Add(LbEstadoNombre);

				Label LbEstadoText = new Label();
				LbEstadoText.ID = "LbEstadoTextCopia" + Convert.ToString(i);

				if (DRradHis.SerieCodigo == null)
					LbEstadoText.Text = "En Proceso";
				else
					LbEstadoText.Text = "Archivado";

				Pnl1.Controls.Add(LbEstadoText);

				 */
 
				Pnl1.HorizontalAlign = HorizontalAlign.Left;

				AjaxControlToolkit.PopupControlExtender PCPaso = new AjaxControlToolkit.PopupControlExtender();
				PCPaso.ID = "PCPasoCopia" + Convert.ToString(i);
				PCPaso.TargetControlID = "ImgPasoCopia" + Convert.ToString(i);
				PCPaso.PopupControlID = "PnlCopia" + Convert.ToString(i);

				Cell1.Controls.Add(PCPaso);

				HtmlTableCell Cell2 = new HtmlTableCell();
				Row1.Cells.Add(Cell2);

				
				HtmlTableCell Cell2a = new HtmlTableCell();
				Row1.Cells.Add(Cell2a);
				Cell2a.Align = "left";

				if (DRradHis.WFMovimientoNotas != "" && DRradHis.WFMovimientoNotas != null)
				{
					//HtmlTableCell Cell01 = new HtmlTableCell();
					//Row1.Cells.Add(Cell01);

					Image ImgPostItCopia = new Image();
					ImgPostItCopia.ID = "ImgPostItCopia" + Convert.ToString(i);
					ImgPostItCopia.ImageUrl = "~/AlfaNetImagen/ToolBar/post-it-big.png";
					ImgPostItCopia.Visible = true;
                    ImgPostItCopia.Height = 50;
					Cell2a.Controls.Add(ImgPostItCopia);

					Panel PnlPostItCopia = new Panel();
					PnlPostItCopia.ID = "PnlPostItCopia" + Convert.ToString(i);
					PnlPostItCopia.CssClass = "popupControl";
					PnlPostItCopia.Height = Unit.Pixel(100);
					PnlPostItCopia.Width = Unit.Pixel(300);
					PnlPostItCopia.ScrollBars = ScrollBars.Vertical;
					PnlPostItCopia.BorderStyle = BorderStyle.None;
					Cell2a.Controls.Add(PnlPostItCopia);

					//Label LbPasoPostItCopia = new Label();
					TextBox LbPasoPostItCopia = new TextBox();
					LbPasoPostItCopia.ID = "LbPasoPostItCopia" + Convert.ToString(i);
					LbPasoPostItCopia.TextMode = TextBoxMode.MultiLine;
					LbPasoPostItCopia.Width = Unit.Pixel(290);
					LbPasoPostItCopia.Height = Unit.Pixel(500);
					LbPasoPostItCopia.Text = DRradHis.WFMovimientoNotas;
					LbPasoPostItCopia.Font.Bold = true;
					LbPasoPostItCopia.BackColor = System.Drawing.Color.FromArgb(253, 250, 143);
                    LbPasoPostItCopia.BorderStyle = BorderStyle.Outset;
                    LbPasoPostItCopia.BorderWidth = 2;
					PnlPostItCopia.Controls.Add(LbPasoPostItCopia);


					PnlPostItCopia.HorizontalAlign = HorizontalAlign.Left;

					AjaxControlToolkit.PopupControlExtender PCPostItCopia = new AjaxControlToolkit.PopupControlExtender();
					PCPostItCopia.ID = "PCPostItCopia" + Convert.ToString(i);
					PCPostItCopia.TargetControlID = "ImgPostItCopia" + Convert.ToString(i);
					PCPostItCopia.PopupControlID = "PnlPostItCopia" + Convert.ToString(i);

					Cell2a.Controls.Add(PCPostItCopia);
				}



				i = i + 1;
			}
	 
		this.Panel2.Controls.Add(Tabla1);
	}




    protected void DropDownListGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownListGrupo_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Application["gruporegistro"] = this.DropDownListGrupo.SelectedValue.ToString();
        this.TxtSearchHistorico.Text = null;
    }
}

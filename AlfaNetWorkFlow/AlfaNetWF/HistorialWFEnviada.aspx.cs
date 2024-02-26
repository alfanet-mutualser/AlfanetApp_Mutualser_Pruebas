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

public partial class _HistorialWFNEnviada : System.Web.UI.Page 
{
    string WFAccion = "2";
    string GrpDocReg = "2";
    rutinas ejecutar = new rutinas();
    DataTable tabla = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string codigodelgruporadicados = "";
                string codigodelgruporegistros = "";


                tabla = ejecutar.rtn_traer_tbtablas_por_Id("GRUPOREG");
                codigodelgruporegistros = tabla.Rows[0][0].ToString().Trim();
                tabla = ejecutar.rtn_traer_grupos_por_codigopadre(codigodelgruporegistros);
                if (tabla.Rows.Count == 0)
                {
                    tabla = ejecutar.rtn_traer_grupos_por_Id(codigodelgruporegistros);
                }
                this.DropDownListGrupo.DataTextField = "gruponombre";
                this.DropDownListGrupo.DataValueField = "grupocodigo";
                this.DropDownListGrupo.DataSource = tabla;
                this.DropDownListGrupo.DataBind();
                this.DropDownListGrupo.SelectedIndex = 0;
                                              
                Application["gruporegistro"] = this.DropDownListGrupo.SelectedValue.ToString();
                string Admon = Request["Admon"];
                if (Admon == "S")
                {
                    ((MainMaster)this.Master).hidemenu();
                }
                else
                {
                    ((MainMaster)this.Master).showmenu();
                }
                
                string codImagen = Request["RadicadoCodigo"];
                string GrupoCodigo= Request["GrupoCodigo"];
                if (codImagen != null)
                {
                HFCodigoSeleccionado.Value = codImagen;
                HFGrupoSeleccionado.Value = GrupoCodigo;
                                
                this.LblDetalleMultitarea.Text = "Detalle Multitarea del Registro Número: " + HFCodigoSeleccionado.Value;
                this.LblDetalleMultitarea.Visible = true;
                this.LblAccionEnterese.Text = "Detalle Accion Enterese del Registro Número: " + HFCodigoSeleccionado.Value;
                this.LblAccionEnterese.Visible = true;
                this.DetailsView1.HeaderText = "Detalle Historico Registro Número: " + HFCodigoSeleccionado.Value;
                this.DetailsView1.DataBind();

                DSRegistroTableAdapters.Registro_ConsultasHistoricoTableAdapter ObjTaRegHis = new DSRegistroTableAdapters.Registro_ConsultasHistoricoTableAdapter();
                DSRegistro.Registro_ConsultasHistoricoDataTable DTRegHis = new DSRegistro.Registro_ConsultasHistoricoDataTable();
                DTRegHis = ObjTaRegHis.GetRegistroHistorico( Convert.ToInt32(HFCodigoSeleccionado.Value),GrupoCodigo);

                DataRow[] rows = DTRegHis.Select("WfmovimientoTipo = 1 OR WfmovimientoTipo = 0  or WfmovimientoTipo = 3 ");

                escriba(rows);

                DataRow[] RowsCopia = DTRegHis.Select("WfmovimientoTipo = 5 OR WfmovimientoTipo = 6");

                escribaCopias(RowsCopia);

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

            this.LblDetalleMultitarea.Text = "Detalle Multitarea del Registro Número: " + HFCodigoSeleccionado.Value;
            this.LblDetalleMultitarea.Visible = true;
            this.LblAccionEnterese.Text = "Detalle Accion Enterese del Registro Número: " + HFCodigoSeleccionado.Value;
            this.LblAccionEnterese.Visible = true;
            this.DetailsView1.HeaderText = "Detalle Historico Registro Número: " + HFCodigoSeleccionado.Value;
            this.DetailsView1.DataBind();

            DSRegistroTableAdapters.Registro_ConsultasHistoricoTableAdapter ObjTaRegHis = new DSRegistroTableAdapters.Registro_ConsultasHistoricoTableAdapter();
            DSRegistro.Registro_ConsultasHistoricoDataTable DTRegHis = new DSRegistro.Registro_ConsultasHistoricoDataTable();
            DTRegHis = ObjTaRegHis.GetRegistroHistorico(Convert.ToInt32(HFCodigoSeleccionado.Value),DropDownListGrupo.SelectedValue);

            DataRow[] rows = DTRegHis.Select("WfmovimientoTipo = 1 OR WfmovimientoTipo = 0  or WfmovimientoTipo = 3");

            escriba(rows);

            DataRow[] RowsCopia = DTRegHis.Select("WfmovimientoTipo = 5 OR WfmovimientoTipo = 6");

            escribaCopias(RowsCopia);

        
        
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
    protected HtmlGenericControl generarPanContent(int tipo, String Paso, String Procede, String Cont, String Accion,
        String FechaIn, String FechaOut, String Estado, String Destino)
    {
        HtmlGenericControl nid = new HtmlGenericControl("div");
        if (tipo == 0)
            nid.ID = "div_paso_" + Paso;
        else
            nid.ID = "div_copia_" + Paso;
        nid.InnerHtml = "<div class=\"shiftcontainer\" style=\"position: relative;left: 5px;top: 5px;\" ><div class=\"shadowcontainer\" style=\"width: 310px; background-color: #d1cfd0;\" ><div class=\"innerdiv\" style=\"border: 0px white; padding: 6px; position: relative; left: -5px; top: -5px;\" >" +
                      "<b>Paso " + Paso + "</b> <br />" +
                      "<table border=\"0\" cellspacing=\"-1\" width=320>" +
                      "<tr><td>" + Procede + "</td><td>" + Cont + "</td></tr>" +
                      "<tr><td>Acción:</td><td>" + Accion + "</td></tr>" +
                      "<tr><td>Fecha Inicio:</td><td>" + FechaIn + "</td></tr>" +
                      "<tr><td>Fecha Final:</td><td>" + FechaOut + "</td></tr>" +
                      "<tr><td>Estado:</td><td>" + Estado + "</td></tr>" +
                      "<tr><td>Destino:</td><td>" + Destino + "</td></tr></table>" +
                      "</div></div></div>";
        return nid;
    }



    protected void escriba(DataRow[] rows)
    {
        HtmlTable Tabla = new HtmlTable();

        int i = 1;

        foreach (DSRegistro.Registro_ConsultasHistoricoRow DRRegHis in rows)
        {
            DataRow RowSig;
            String Notas;
            if (i < rows.Length)
            {
                RowSig = rows[i];
                Notas = RowSig.ItemArray[13].ToString();
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
                if (DRRegHis.WfmovimientoTipo.ToString() == "1" || DRRegHis.WfmovimientoTipo.ToString() == "0")
                {
                    LabelDep.Text = DRRegHis.Destino.ToString();

                }
                else if (DRRegHis.WfmovimientoTipo.ToString() == "3" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    LabelDep.Text = DRRegHis.SerieNombre.ToString();
                }
                //LabelDep.Text = DRRegHis.Destino.ToString();
                LabelDep.Visible = true;
                LabelDep.Width = 150;
                Cell0.Controls.Add(LabelDep);

                if (!String.IsNullOrEmpty(Notas))//Reemplazo1
                {
                    //HtmlTableCell Cell01 = new HtmlTableCell();
                    //Cell01.Width = "20px";
                    //Row1.Cells.Add(Cell01);

                    Image ImgPostIt = new Image();
                    ImgPostIt.ID = "ImgPostIt" + Convert.ToString(i);
                    ImgPostIt.ImageUrl = "~/AlfaNetImagen/ToolBar/post-it-big.png";
                    ImgPostIt.Visible = true;
                    Cell0.Controls.Add(ImgPostIt);

                    Panel PnlPostIt = new Panel();
                    PnlPostIt.ID = "PnlPostIt" + Convert.ToString(i);
                    PnlPostIt.CssClass = "popupControl";
                    Cell0.Controls.Add(PnlPostIt);

                    Label LbPasoPostIt = new Label();
                    LbPasoPostIt.ID = "LbPasoPostIt" + Convert.ToString(i);
                    LbPasoPostIt.Width = Unit.Pixel(300);
                    LbPasoPostIt.Height = Unit.Pixel(80);
                    LbPasoPostIt.Text = Notas;
                    LbPasoPostIt.Font.Bold = true;
                    LbPasoPostIt.BackColor = System.Drawing.Color.Transparent;
                    PnlPostIt.Controls.Add(LbPasoPostIt);

                    PnlPostIt.HorizontalAlign = HorizontalAlign.Left;

                    AjaxControlToolkit.PopupControlExtender PCPostIt = new AjaxControlToolkit.PopupControlExtender();
                    PCPostIt.ID = "PCPostIt" + Convert.ToString(i);
                    PCPostIt.TargetControlID = "ImgPostIt" + Convert.ToString(i);
                    PCPostIt.PopupControlID = "PnlPostIt" + Convert.ToString(i);

                    Cell0.Controls.Add(PCPostIt);
                }


                HtmlTableCell Cell1 = new HtmlTableCell();

                Row1.Cells.Add(Cell1);

                Image ImgPaso = new Image();
                ImgPaso.ID = "ImgPaso" + Convert.ToString(i);
                if (DRRegHis.WfmovimientoTipo.ToString() == "1" || DRRegHis.WfmovimientoTipo.ToString() == "0")
                {
                    ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg2.jpg";
                }
                else if (DRRegHis.WfmovimientoTipo.ToString() == "3" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFArchivoImg2.jpg";
                }
                //ImgPaso.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg.jpg";
                ImgPaso.Visible = true;
                Cell1.Controls.Add(ImgPaso);

                Panel Pnl = new Panel();
                Pnl.ID = Pnl + Convert.ToString(i);
                //Pnl.CssClass = "popupControl";
                Cell1.Controls.Add(Pnl);

                /*Obtener la informacion de los pasos*/
                String Datos_1 = "";
                String Datos_2 = "";
                String Datos_3 = "";

                if (DRRegHis.WfmovimientoTipo.ToString() == "1" || DRRegHis.WfmovimientoTipo.ToString() == "0")
                {
                    Datos_3 = "Remite:";
                    Datos_1 = Convert.ToString(DRRegHis.DependenciaNombre);

                }
                else if (DRRegHis.WfmovimientoTipo.ToString() == "3" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    Datos_3 = "Serie:";
                    Datos_1 = Convert.ToString(DRRegHis.SerieNombre);
                }


                if (DRRegHis.SerieCodigo == null)
                    Datos_2 = "En Proceso";
                else
                    Datos_2 = "Archivado";

                string tmpDestino = "";

                if (DRRegHis.Destino != null)
                {
                    tmpDestino = DRRegHis.Destino.ToString();
                }

                HtmlGenericControl nid = this.generarPanContent(0, Convert.ToString(i), Datos_3, Datos_1, Convert.ToString(DRRegHis.WFAccionNombre),
                   Convert.ToString(DRRegHis.WFMovimientoFecha1), Convert.ToString(DRRegHis.WFMovimientoFechaFin),
                   Datos_2, tmpDestino);

                /*Insertar el panel*/
                Pnl.Controls.Add(nid);


                /*
                Label LbPasoNombre = new Label();
                LbPasoNombre.ID = "LbPasoNombre" + Convert.ToString(i);
                LbPasoNombre.Text = "Paso: ";
                LbPasoNombre.Font.Bold = true;
                Pnl.Controls.Add(LbPasoNombre);

                Label LbPaso = new Label();
                LbPaso.ID = "LbPaso" + Convert.ToString(i);
                LbPaso.Text = Convert.ToString(DRRegHis.WFMovimientoPaso);

                Pnl.Controls.Add(LbPaso);

                Pnl.Controls.Add(new LiteralControl("<br />"));

                Label LbDependenciaNombre = new Label();
                LbDependenciaNombre.ID = "LbDependenciaNombre" + Convert.ToString(i);
                if (DRRegHis.WfmovimientoTipo.ToString() == "1" || DRRegHis.WfmovimientoTipo.ToString() == "0")
                {
                    LbDependenciaNombre.Text = "Remite: ";

                }
                else if (DRRegHis.WfmovimientoTipo.ToString() == "3" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    LbDependenciaNombre.Text = "Serie: ";
                }

                //LbDependenciaNombre.Text = "Remite: ";
                LbDependenciaNombre.Font.Bold = true;
                Pnl.Controls.Add(LbDependenciaNombre);

                Label LbDependenciaText = new Label();
                LbDependenciaText.ID = "LbDependenciaText" + Convert.ToString(i);
                if (DRRegHis.WfmovimientoTipo.ToString() == "1" || DRRegHis.WfmovimientoTipo.ToString() == "0")
                {
                    LbDependenciaText.Text = Convert.ToString(DRRegHis.DependenciaNombre);

                }
                else if (DRRegHis.WfmovimientoTipo.ToString() == "3" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    LbDependenciaText.Text = Convert.ToString(DRRegHis.SerieNombre);
                }
                //LbDependenciaText.Text = Convert.ToString(DRRegHis.DependenciaNombre);
                Pnl.Controls.Add(LbDependenciaText);

                Pnl.Controls.Add(new LiteralControl("<br />"));

                Label LbAccioNombre = new Label();
                LbAccioNombre.ID = "LbAccionNombre" + Convert.ToString(i);
                LbAccioNombre.Text = "Accion: ";
                LbAccioNombre.Font.Bold = true;
                Pnl.Controls.Add(LbAccioNombre);

                Label LbAccionText = new Label();
                LbAccionText.ID = "LbAccionText" + Convert.ToString(i);
                LbAccionText.Text = Convert.ToString(DRRegHis.WFAccionNombre);

                Pnl.Controls.Add(LbAccionText);

                Pnl.Controls.Add(new LiteralControl("<br />"));

                Label LbFechaInicioNombre = new Label();
                LbFechaInicioNombre.ID = "LbFechaInicioNombre" + Convert.ToString(i);
                LbFechaInicioNombre.Text = "Fecha Inicio: ";
                LbFechaInicioNombre.Font.Bold = true;
                Pnl.Controls.Add(LbFechaInicioNombre);
                //Ojo es nombre Accion
                Label LbFechaInicioText = new Label();
                LbFechaInicioText.ID = "LbFechaInicioText" + Convert.ToString(i);
                LbFechaInicioText.Text = Convert.ToString(DRRegHis.WFMovimientoFecha1);

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

                LbFechaFinText.Text = Convert.ToString(DRRegHis.WFMovimientoFechaFin);

                Pnl.Controls.Add(LbFechaFinText);

                Pnl.Controls.Add(new LiteralControl("<br />"));

                Label LbEstadoNombre = new Label();
                LbEstadoNombre.ID = "LbEstadoNombre" + Convert.ToString(i);
                LbEstadoNombre.Text = "Estado: ";
                LbEstadoNombre.Font.Bold = true;
                Pnl.Controls.Add(LbEstadoNombre);

                Label LbEstadoText = new Label();
                LbEstadoText.ID = "LbEstadoText" + Convert.ToString(i);

                if (DRRegHis.SerieCodigo == null)
                    LbEstadoText.Text = "En Proceso";
                else
                    LbEstadoText.Text = "En Proceso";
                    //LbEstadoText.Text = "Archivado";

                Pnl.Controls.Add(LbEstadoText);

                //Pnl.Controls.Add(new LiteralControl("<br />"));

                //Label LbEstadoSerie = new Label();
                //LbEstadoSerie.ID = "LbEstadoSerie" + Convert.ToString(i);
                //LbEstadoSerie.Text = "Serie: ";
                //LbEstadoSerie.Font.Bold = true;
                //Pnl.Controls.Add(LbEstadoSerie);

                //Label LbSerieText = new Label();
                //LbSerieText.ID = "LbSerieText" + Convert.ToString(i);

                //if (DRRegHis.SerieCodigo == null)
                //    LbSerieText.Text = "";
                //else
                //    LbSerieText.Text = DRRegHis.SerieNombre.ToString();

                //Pnl.Controls.Add(LbSerieText);

                Pnl.Controls.Add(new LiteralControl("<br />"));

                Label LbDestinoNombre = new Label();
                LbDestinoNombre.ID = "LbDestinoNombre" + Convert.ToString(i);
                LbDestinoNombre.Text = "Destino: ";
                LbDestinoNombre.Font.Bold = true;
                Pnl.Controls.Add(LbDestinoNombre);

                Label LbDestino = new Label();
                LbDestino.ID = "LbDestino" + Convert.ToString(i);
                LbDestino.Text = DRRegHis.Destino.ToString();
               // LbDestino.Font.Bold = true;
                Pnl.Controls.Add(LbDestino);
                */
                Pnl.HorizontalAlign = HorizontalAlign.Left;

                AjaxControlToolkit.PopupControlExtender PCPaso = new AjaxControlToolkit.PopupControlExtender();
                PCPaso.ID = PCPaso + Convert.ToString(i);
                PCPaso.TargetControlID = "ImgPaso" + Convert.ToString(i);
                PCPaso.PopupControlID = Pnl + Convert.ToString(i);

                Cell1.Controls.Add(PCPaso);

                HtmlTableCell Cell2 = new HtmlTableCell();
                Row1.Cells.Add(Cell2);

                if (DRRegHis.WFMovimientoPasoActual == "0" && DRRegHis.WFMovimientoPasoFinal == "0")
                {
                    ImageButton ImgFlecha = new ImageButton();
                    ImgFlecha.ID = "ImgFlecha" + Convert.ToString(i);
                    ImgFlecha.ImageUrl = "~/AlfaNetImagen/ToolBar/flechadanima.gif";
                    ImgFlecha.PostBackUrl = "javascript:void(0);";
                    ImgFlecha.Visible = true;

                    Cell2.Controls.Add(ImgFlecha);
                }
                HtmlTableCell Cell2a = new HtmlTableCell();

                Row1.Cells.Add(Cell2a);

            }
            else
            {
                HtmlTableRow Row2 = new HtmlTableRow();

                Tabla.Rows.Add(Row2);

                HtmlTableCell Cell0 = new HtmlTableCell();
                Row2.Cells.Add(Cell0);


                HtmlTableCell Cell3 = new HtmlTableCell();

                Row2.Cells.Add(Cell3);
                if (DRRegHis.WFMovimientoPasoActual == "0" && DRRegHis.WFMovimientoPasoFinal == "0")
                {
                    ImageButton ImgFlecha2 = new ImageButton();
                    ImgFlecha2.ID = "ImgFlecha" + Convert.ToString(i);
                    ImgFlecha2.ImageUrl = "~/AlfaNetImagen/ToolBar/flechaianima.gif";
                    ImgFlecha2.PostBackUrl = "javascript:void(0);";
                    ImgFlecha2.Visible = true;

                    Cell3.Controls.Add(ImgFlecha2);
                }


                HtmlTableCell Cell4 = new HtmlTableCell();

                Row2.Cells.Add(Cell4);

                Image ImgPaso2 = new Image();
                ImgPaso2.ID = "ImgPaso" + Convert.ToString(i);
                if (DRRegHis.WfmovimientoTipo.ToString() == "1" || DRRegHis.WfmovimientoTipo.ToString() == "0")
                {
                    ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg2.jpg";
                }
                else if (DRRegHis.WfmovimientoTipo.ToString() == "3" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFArchivoImg2.jpg";
                }
                //ImgPaso2.ImageUrl = "~/AlfaNetImagen/WFImagen/WFEscritorioImg.jpg";
                ImgPaso2.Visible = true;

                Cell4.Controls.Add(ImgPaso2);

                Panel Pnl1 = new Panel();
                Pnl1.ID = Pnl1 + Convert.ToString(i);
                //Pnl1.CssClass = "popupControl";
                Cell4.Controls.Add(Pnl1);


                /*Obtener la informacion de los pasos*/
                String Datos_1 = "";
                String Datos_2 = "";
                String Datos_3 = "";

                if (DRRegHis.WfmovimientoTipo.ToString() == "1" || DRRegHis.WfmovimientoTipo.ToString() == "0")
                {
                    Datos_3 = "Remite:";
                    Datos_1 = Convert.ToString(DRRegHis.DependenciaNombre);

                }
                else if (DRRegHis.WfmovimientoTipo.ToString() == "3" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    Datos_3 = "Serie:";
                    Datos_1 = Convert.ToString(DRRegHis.SerieNombre);
                }


                if (DRRegHis.SerieCodigo == null)
                    Datos_2 = "En Proceso";
                else
                    Datos_2 = "Archivado";

                string tmpDestino = "";
                if (DRRegHis.Destino != null)
                {
                    tmpDestino = DRRegHis.Destino.ToString();
                }

                HtmlGenericControl nid = this.generarPanContent(0, Convert.ToString(i), Datos_3, Datos_1, Convert.ToString(DRRegHis.WFAccionNombre),
                   Convert.ToString(DRRegHis.WFMovimientoFecha1), Convert.ToString(DRRegHis.WFMovimientoFechaFin),
                   Datos_2, tmpDestino);

                Pnl1.Controls.Add(nid);
                /*
                Label LbPasoNombre1 = new Label();
                LbPasoNombre1.ID = "LbPasoNombre1" + Convert.ToString(i);
                LbPasoNombre1.Text = "Paso: ";
                LbPasoNombre1.Font.Bold = true;
                Pnl1.Controls.Add(LbPasoNombre1);

                Label LbPaso1 = new Label();
                LbPaso1.ID = "LbPaso1" + Convert.ToString(i);
                LbPaso1.Text = Convert.ToString(DRRegHis.WFMovimientoPaso);

                Pnl1.Controls.Add(LbPaso1);

                Pnl1.Controls.Add(new LiteralControl("<br />"));

                Label LbDependenciaNombre1 = new Label();
                LbDependenciaNombre1.ID = "LbDependenciaNombre1" + Convert.ToString(i);
                if (DRRegHis.WfmovimientoTipo.ToString() == "1" || DRRegHis.WfmovimientoTipo.ToString() == "0")
                {
                    LbDependenciaNombre1.Text = "Remite: ";

                }
                else if (DRRegHis.WfmovimientoTipo.ToString() == "3" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    LbDependenciaNombre1.Text = "Serie: ";
                }
                //LbDependenciaNombre1.Text = "Remite: ";
                LbDependenciaNombre1.Font.Bold = true;
                Pnl1.Controls.Add(LbDependenciaNombre1);

                Label LbDependenciaText1 = new Label();
                LbDependenciaText1.ID = "LbDependenciaText1" + Convert.ToString(i);
                if (DRRegHis.WfmovimientoTipo.ToString() == "1" || DRRegHis.WfmovimientoTipo.ToString() == "0")
                {
                    LbDependenciaText1.Text = Convert.ToString(DRRegHis.DependenciaNombre);

                }
                else if (DRRegHis.WfmovimientoTipo.ToString() == "3" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    LbDependenciaText1.Text = Convert.ToString(DRRegHis.SerieNombre);
                }
                //LbDependenciaText1.Text = Convert.ToString(DRRegHis.DependenciaNombre);

                Pnl1.Controls.Add(LbDependenciaText1);

                Pnl1.Controls.Add(new LiteralControl("<br />"));

                Label LbAccioNombre1 = new Label();
                LbAccioNombre1.ID = "LbAccionNombre1" + Convert.ToString(i);
                LbAccioNombre1.Text = "Accion: ";
                LbAccioNombre1.Font.Bold = true;
                Pnl1.Controls.Add(LbAccioNombre1);

                Label LbAccionText1 = new Label();
                LbAccionText1.ID = "LbAccionText1" + Convert.ToString(i);
                LbAccionText1.Text = Convert.ToString(DRRegHis.WFAccionNombre);

                Pnl1.Controls.Add(LbAccionText1);

                Pnl1.Controls.Add(new LiteralControl("<br />"));

                Label LbFechaInicioNombre1 = new Label();
                LbFechaInicioNombre1.ID = "LbFechaInicioNombre1" + Convert.ToString(i);
                LbFechaInicioNombre1.Text = "Fecha Inicio: ";
                LbFechaInicioNombre1.Font.Bold = true;
                Pnl1.Controls.Add(LbFechaInicioNombre1);
                //Ojo es nombre Accion
                Label LbFechaInicioText1 = new Label();
                LbFechaInicioText1.ID = "LbFechaInicioText1" + Convert.ToString(i);
                LbFechaInicioText1.Text = Convert.ToString(DRRegHis.WFMovimientoFecha1);

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

                LbFechaFinText1.Text = Convert.ToString(DRRegHis.WFMovimientoFechaFin);

                Pnl1.Controls.Add(LbFechaFinText1);

                Pnl1.Controls.Add(new LiteralControl("<br />"));

                Label LbEstadoNombre1 = new Label();
                LbEstadoNombre1.ID = "LbEstadoNombre1" + Convert.ToString(i);
                LbEstadoNombre1.Text = "Estado: ";
                LbEstadoNombre1.Font.Bold = true;
                Pnl1.Controls.Add(LbEstadoNombre1);

                Label LbEstadoText1 = new Label();
                LbEstadoText1.ID = "LbEstadoText1" + Convert.ToString(i);
                                               
                if (DRRegHis.SerieCodigo == null)
                    LbEstadoText1.Text = "En Proceso";
                else
                    LbEstadoText1.Text = "Archivado";

                Pnl1.Controls.Add(LbEstadoText1);

                //Pnl1.Controls.Add(new LiteralControl("<br />"));
                
                //Label LbEstadoSerie1 = new Label();
                //LbEstadoSerie1.ID = "LbEstadoSerie1" + Convert.ToString(i);
                //LbEstadoSerie1.Text = "Serie: ";
                //LbEstadoSerie1.Font.Bold = true;
                //Pnl1.Controls.Add(LbEstadoSerie1);

                //Label LbSerieText1 = new Label();
                //LbSerieText1.ID = "LbSerieText1" + Convert.ToString(i);

                //if (DRRegHis.SerieCodigo == null)
                //    LbSerieText1.Text = "";
                //else
                //    LbSerieText1.Text = DRRegHis.SerieNombre.ToString();

                //Pnl1.Controls.Add(LbSerieText1);

                Pnl1.Controls.Add(new LiteralControl("<br />"));

                Label LbDestinoNombre = new Label();
                LbDestinoNombre.ID = "LbDestinoNombre" + Convert.ToString(i);
                LbDestinoNombre.Text = "Destino: ";
                LbDestinoNombre.Font.Bold = true;
                Pnl1.Controls.Add(LbDestinoNombre);

                Label LbDestino = new Label();
                LbDestino.ID = "LbDestino" + Convert.ToString(i);
                LbDestino.Text = DRRegHis.Destino.ToString();
                //LbDestino.Font.Bold = true;
                Pnl1.Controls.Add(LbDestino);
                */
                Pnl1.HorizontalAlign = HorizontalAlign.Left;

                AjaxControlToolkit.PopupControlExtender PCPaso1 = new AjaxControlToolkit.PopupControlExtender();
                PCPaso1.ID = PCPaso1 + Convert.ToString(i);
                PCPaso1.TargetControlID = "ImgPaso" + Convert.ToString(i);
                PCPaso1.PopupControlID = Pnl1 + Convert.ToString(i);

                Cell4.Controls.Add(PCPaso1);

                if (!String.IsNullOrEmpty(Notas))
                {
                   // HtmlTableCell Cell01a = new HtmlTableCell();
                    //Cell01a.Width = "20px";
                    //Row2.Cells.Add(Cell01a);

                    Image ImgPostIt1 = new Image();
                    ImgPostIt1.ID = "ImgPostIt1" + Convert.ToString(i);
                    ImgPostIt1.ImageUrl = "~/AlfaNetImagen/ToolBar/post-it-big.png";
                    ImgPostIt1.Visible = true;
                    Cell4.Controls.Add(ImgPostIt1);

                    Panel PnlPostIt1 = new Panel();
                    PnlPostIt1.ID = "PnlPostIt1" + Convert.ToString(i);
                    PnlPostIt1.CssClass = "popupControl";
                    Cell4.Controls.Add(PnlPostIt1);

                    Label LbPasoPostIt1 = new Label();
                    LbPasoPostIt1.ID = "LbPasoPostIt1" + Convert.ToString(i);
                    LbPasoPostIt1.Width = Unit.Pixel(300);
                    LbPasoPostIt1.Height = Unit.Pixel(80);
                    LbPasoPostIt1.Text = Notas;
                    LbPasoPostIt1.Font.Bold = true;
                    LbPasoPostIt1.BackColor = System.Drawing.Color.Transparent;
                    PnlPostIt1.Controls.Add(LbPasoPostIt1);

                    PnlPostIt1.HorizontalAlign = HorizontalAlign.Left;

                    AjaxControlToolkit.PopupControlExtender PCPostIt1 = new AjaxControlToolkit.PopupControlExtender();
                    PCPostIt1.ID = "PCPostIt1" + Convert.ToString(i);
                    PCPostIt1.TargetControlID = "ImgPostIt1" + Convert.ToString(i);
                    PCPostIt1.PopupControlID = "PnlPostIt1" + Convert.ToString(i);

                    Cell4.Controls.Add(PCPostIt1);
                }

                HtmlTableCell Cell4a = new HtmlTableCell();

                Row2.Cells.Add(Cell4a);

                Label LabelDep1 = new Label();
                LabelDep1.ID = "LabelDep" + Convert.ToString(i);
                if (DRRegHis.WfmovimientoTipo.ToString() == "1" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    LabelDep1.Text = DRRegHis.Destino.ToString();

                }
                else if (DRRegHis.WfmovimientoTipo.ToString() == "3" || DRRegHis.WfmovimientoTipo.ToString() == "7")
                {
                    LabelDep1.Text = DRRegHis.SerieNombre.ToString();
                }
                //LabelDep1.Text = DRRegHis.Destino.ToString();
                LabelDep1.Visible = true;
                LabelDep1.Width = 150;
                Cell4a.Controls.Add(LabelDep1);

            }
            i = i + 1;

        }
        this.Panel1.Controls.Add(Tabla);
    }
    protected void escribaCopias(DataRow[] rows)
    {
        HtmlTable Tabla1 = new HtmlTable();

        int i = 1;

        foreach (DSRegistro.Registro_ConsultasHistoricoRow DRradHis in rows)
        {
            
                HtmlTableRow Row1 = new HtmlTableRow();

                Tabla1.Rows.Add(Row1);

                HtmlTableCell Cell0 = new HtmlTableCell();

                Row1.Cells.Add(Cell0);

                Label LabelDep = new Label();
                LabelDep.ID = "LabelDepCopia" + Convert.ToString(i);
                LabelDep.Text = DRradHis.DestinoCopias.ToString();
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

                Panel Pnl2 = new Panel();
                Pnl2.ID = "PnlCopia" + Convert.ToString(i);
                //Pnl2.CssClass = "popupControl";
                Cell1.Controls.Add(Pnl2);


                /*Obtener la informacion de los pasos*/
                String Datos_1 = "";
                String Datos_2 = "";
                String Datos_3 = "";

                
                Datos_3 = "Remite:";
                Datos_1 = Convert.ToString(DRradHis.DependenciaNombre);

                if (DRradHis.SerieCodigo == null)
                    Datos_2 = "En Proceso";
                else
                    Datos_2 = "Archivado";

                HtmlGenericControl nid = this.generarPanContent(1, Convert.ToString(i), Datos_3, Datos_1, Convert.ToString(DRradHis.WFAccionNombre),
                   Convert.ToString(DRradHis.WFMovimientoFecha1), Convert.ToString(DRradHis.WFMovimientoFechaFin),
                   Datos_2, DRradHis.Destino.ToString());

                Pnl2.Controls.Add(nid);
                /*
                Label LbPasoNombre = new Label();
                LbPasoNombre.ID = "LbPasoNombreCopia" + Convert.ToString(i);
                LbPasoNombre.Text = "Paso: ";
                LbPasoNombre.Font.Bold = true;

                Pnl2.Controls.Add(LbPasoNombre);

                Label LbPaso = new Label();
                LbPaso.ID = "LbPasoCopia" + Convert.ToString(i);
                LbPaso.Text = Convert.ToString(DRradHis.WFMovimientoPaso);

                Pnl2.Controls.Add(LbPaso);

                Pnl2.Controls.Add(new LiteralControl("<br />"));

                Label LbDependenciaNombre = new Label();
                LbDependenciaNombre.ID = "LbDependenciaNombreCopia" + Convert.ToString(i);
                LbDependenciaNombre.Text = "Remite: ";
                LbDependenciaNombre.Font.Bold = true;
                Pnl2.Controls.Add(LbDependenciaNombre);

                Label LbDependenciaText = new Label();
                LbDependenciaText.ID = "LbDependenciaTextCopia" + Convert.ToString(i);
                LbDependenciaText.Text = Convert.ToString(DRradHis.DependenciaNombre);

                Pnl2.Controls.Add(LbDependenciaText);

                Pnl2.Controls.Add(new LiteralControl("<br />"));

                Label LbAccioNombre = new Label();
                LbAccioNombre.ID = "LbAccionNombreCopia" + Convert.ToString(i);
                LbAccioNombre.Text = "Accion: ";
                LbAccioNombre.Font.Bold = true;
                Pnl2.Controls.Add(LbAccioNombre);

                Label LbAccionText = new Label();
                LbAccionText.ID = "LbAccionTextCopia" + Convert.ToString(i);
                LbAccionText.Text = Convert.ToString(DRradHis.WFAccionNombre);

                Pnl2.Controls.Add(LbAccionText);

                Pnl2.Controls.Add(new LiteralControl("<br />"));

                Label LbFechaInicioNombre = new Label();
                LbFechaInicioNombre.ID = "LbFechaInicioNombreCopia" + Convert.ToString(i);
                LbFechaInicioNombre.Text = "Fecha Inicio: ";
                LbFechaInicioNombre.Font.Bold = true;
                Pnl2.Controls.Add(LbFechaInicioNombre);
                //Ojo es nombre Accion
                Label LbFechaInicioText = new Label();
                LbFechaInicioText.ID = "LbFechaInicioTextCopia" + Convert.ToString(i);
                LbFechaInicioText.Text = Convert.ToString(DRradHis.WFMovimientoFecha1);

                Pnl2.Controls.Add(LbFechaInicioText);

                Pnl2.Controls.Add(new LiteralControl("<br />"));

                Label LbFechaFinNombre = new Label();
                LbFechaFinNombre.ID = "LbFechaFinNombreCopia" + Convert.ToString(i);
                LbFechaFinNombre.Text = "Fecha Fin: ";
                LbFechaFinNombre.Font.Bold = true;
                Pnl2.Controls.Add(LbFechaFinNombre);

                Label LbFechaFinText = new Label();
                LbFechaFinText.ID = "LbFechaFinTextCopia" + Convert.ToString(i);
                //Ojo es fecha Fin

                LbFechaFinText.Text = Convert.ToString(DRradHis.WFMovimientoFechaFin);

                Pnl2.Controls.Add(LbFechaFinText);

                Pnl2.Controls.Add(new LiteralControl("<br />"));

                Label LbEstadoNombre = new Label();
                LbEstadoNombre.ID = "LbEstadoNombreCopia" + Convert.ToString(i);
                LbEstadoNombre.Text = "Estado: ";
                LbEstadoNombre.Font.Bold = true;
                Pnl2.Controls.Add(LbEstadoNombre);

                Label LbEstadoText = new Label();
                LbEstadoText.ID = "LbEstadoTextCopia" + Convert.ToString(i);

                if (DRradHis.SerieCodigo == null)
                    LbEstadoText.Text = "En Proceso";
                else
                    LbEstadoText.Text = "Archivado";

                Pnl2.Controls.Add(LbEstadoText);

                Pnl2.Controls.Add(new LiteralControl("<br />"));

                Label LbDestinoCopiaNombre = new Label();
                LbDestinoCopiaNombre.ID = "LbDestinoCopiaNombre" + Convert.ToString(i);
                LbDestinoCopiaNombre.Text = "Destino: ";
                LbDestinoCopiaNombre.Font.Bold = true;
                Pnl2.Controls.Add(LbDestinoCopiaNombre);

                Label LbDestinoCopia = new Label();
                LbDestinoCopia.ID = "LbDestinoCopia" + Convert.ToString(i);
                LbDestinoCopia.Text = DRradHis.DestinoCopias;
               // LbDestinoCopia.Font.Bold = true;

                Pnl2.Controls.Add(LbDestinoCopia);
                */
                Pnl2.HorizontalAlign = HorizontalAlign.Left;

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
                    ImgPostItCopia.ImageUrl = "~/AlfaNetImagen/ToolBar/post-it-big.png";
                    ImgPostItCopia.Visible = true;
                    Cell2a.Controls.Add(ImgPostItCopia);

                    Panel PnlPostItCopia = new Panel();
                    PnlPostItCopia.ID = "PnlPostItCopia" + Convert.ToString(i);
                    PnlPostItCopia.CssClass = "popupControl";
                    PnlPostItCopia.Height = Unit.Pixel(100);
                    PnlPostItCopia.Width = Unit.Pixel(300);
                    PnlPostItCopia.ScrollBars = ScrollBars.Vertical;
                    Cell2a.Controls.Add(PnlPostItCopia);

                    Label LbPasoPostItCopia = new Label();
                    LbPasoPostItCopia.ID = "LbPasoPostItCopia" + Convert.ToString(i);
                    LbPasoPostItCopia.Width = Unit.Pixel(290);
                    LbPasoPostItCopia.Height = Unit.Pixel(500);
                    LbPasoPostItCopia.Text = DRradHis.WFMovimientoNotas;
                    LbPasoPostItCopia.Font.Bold = true;
                    LbPasoPostItCopia.BackColor = System.Drawing.Color.Transparent;
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
}

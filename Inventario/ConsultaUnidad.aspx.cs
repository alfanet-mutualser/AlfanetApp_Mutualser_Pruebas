using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.IO;
using DevExpress.Web.ASPxGridView;
using System.Web.UI.HtmlControls;
using System.Configuration;
using ClosedXML.Excel;
using OfficeOpenXml;

public partial class ConsultaUnidad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
    }
    protected void ChBFechaUni_CheckedChanged(object sender, EventArgs e)
    {

        if (ChBFechaUni.Checked == true)
            {
            this.LblFechaFinal.Visible = true;
            this.LblFechaInicial.Visible = true;
            this.TxtFechaFinal.Visible = true;
            this.TxtFechaInicial.Visible = true;
            this.ImgCalendarFinal.Visible = true;
            this.ImgCalendarInicial.Visible = true;
            }
        else
            {
                this.LblFechaFinal.Visible = false;
                this.LblFechaInicial.Visible = false;
                this.TxtFechaFinal.Visible = false;
                this.TxtFechaInicial.Visible = false;
                this.TxtFechaFinal.Text = "";
                this.TxtFechaInicial.Text = "";
                this.ImgCalendarFinal.Visible = false;
                this.ImgCalendarInicial.Visible = false;
            }
    
    }
    protected void ChBUnidCod_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBUnidCod.Checked == true)
        {
            this.LblUnidCodFinal.Visible = true;
            this.LblUnidCodInicial.Visible = true;
            this.TxtUnidCodFinal.Visible = true;
            this.TxtUnidCodInicial.Visible = true;

        }
        else
        {
            this.LblUnidCodFinal.Visible = false;
            this.LblUnidCodInicial.Visible = false;
            this.TxtUnidCodFinal.Visible = false;
            this.TxtUnidCodInicial.Visible = false;
            this.TxtUnidCodFinal.Text = "";
            this.TxtUnidCodInicial.Text = "";
        }
    }
    protected void ChBDependencia_CheckedChanged(object sender, EventArgs e)
   {
        if (ChBDependencia.Checked == true)
        {
            this.LblDependencia.Visible = true;
            this.TxtBDependencia.Visible = true;
        }
        else
        {
            this.LblDependencia.Visible = false;
            this.TxtBDependencia.Visible = false;
            this.TxtBDependencia.Text = "";
        }
    }

    protected void TreeVDependencia_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVDependencia.SelectedNode.Text)) == false)
        {

            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.SelectedNode.Text);

        }
    }
    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    }

    protected void ChBNombreUnidad_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBNombreUnidad.Checked == true)
        {
            this.LblNombreUnidad.Visible = true;
            this.TxtBNombreUnidad.Visible = true;
        }
        else
        {
            this.LblNombreUnidad.Visible = false;
            this.TxtBNombreUnidad.Visible = false;
            this.TxtBNombreUnidad.Text = "";
        }
    }

    protected void ChBUbicacion_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBUbicacion.Checked == true)
        {
            this.LblUbicacion.Visible = true;
            this.TxtBUbicacion.Visible = true;
        }
        else
        {
            this.LblUbicacion.Visible = false;
            this.TxtBUbicacion.Visible = false;
            this.TxtBUbicacion.Text = "";
        }
    }

    protected void ChBForma_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBForma.Checked == true)
        {
            this.LblForma.Visible = true;
            this.TxtBForma.Visible = true;
        }
        else
        {
            this.LblForma.Visible = false;
            this.TxtBForma.Visible = false;
            this.TxtBForma.Text = "";
        }
    }

    protected void ChBSerie_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBSerie.Checked == true)
        {
            this.LblSerie.Visible = true;
            this.TxtBSerie.Visible = true;
        }
        else
        {
            this.LblSerie.Visible = false;
            this.TxtBSerie.Visible = false;
            this.TxtBSerie.Text = "";
        }
    }

    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVSerie.SelectedNode == null)
        {
            ArbolesBLL ObjArbolSer = new ArbolesBLL();
            DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();


            DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
            PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
        }
    }

    protected void TreeVSerie_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVSerie.SelectedNode.Text)) == false)
        {

            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVSerie.SelectedNode.Text);

        }
    }

    protected void ChBAccion_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBAccion.Checked == true)
        {
            this.LblAccion.Visible = true;
            this.TxtBAccion.Visible = true;

        }
        else
        {
            this.LblAccion.Visible = false;
            this.TxtBAccion.Visible = false;
            this.TxtBAccion.Text = "";

        }
    }

    protected void TreeVAccion_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVAccion.SelectedNode.Text)) == false)
        {

            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVAccion.SelectedNode.Text);
        }
    }

    protected void TreeVAccion_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter TADSWFA = new DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter();
        DSAccion.WFAccion_SelectByTextDataTable DTWFAccion = new DSAccion.WFAccion_SelectByTextDataTable();
        DTWFAccion = TADSWFA.GetWFAccionTreeDataBy(Convert.ToString(e.Node.Value));

        PopulateNodes(DTWFAccion, e.Node.ChildNodes, "WFAccionCodigo", "WFAccionNombre");
    }

    protected void ChBTipologia_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBTipologia.Checked == true)
        {
            this.LblTipologia.Visible = true;
            this.TxtBTipologia.Visible = true;
        }
        else
        {
            this.LblTipologia.Visible = false;
            this.TxtBTipologia.Visible = false;
            this.TxtBTipologia.Text = "";
        }
    }
    protected void ChBRegInventario_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBRegInventario.Checked == true)
        {
            this.LblRegInventario.Visible = true;
            this.TxtBRegInventario.Visible = true;
        }
        else
        {
            this.LblRegInventario.Visible = false;
            this.TxtBRegInventario.Visible = false;
            this.TxtBRegInventario.Text = "";
        }
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();

            tn.Text = dr[Codigo].ToString() + "|" + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            nodes.Add(tn);


            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }



    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        //String conStr = @"Data Source=ALFANET2;Initial Catalog=Alfanet_Pruebas;password=Mutual2016$;User Id=sa; Connect Timeout=720";
		String conStr = @"Data Source=192.168.211.197;Initial Catalog=Alfanet_Pruebas;password=Bogota2020$$;User Id=archivar; Connect Timeout=720";
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand com = new SqlCommand("UnidadDocumentalConsulta2", con);

        if (TxtBNombreUnidad.Text == "" || TxtBNombreUnidad.Text == null)
        {

            com.Parameters.AddWithValue("@NombreUnidad", "null");
        }
        else
        {
            com.Parameters.AddWithValue("@NombreUnidad", TxtBNombreUnidad.Text);
        }

        if (TxtBRegInventario.Text == "" || TxtBRegInventario.Text == null)
        {
            com.Parameters.AddWithValue("@RegInventario", "null");
        }
        else
        {
            com.Parameters.AddWithValue("@RegInventario", TxtBRegInventario.Text);
        }

        if (TxtUnidCodInicial.Text == "" || TxtUnidCodInicial.Text == null)
        {
            com.Parameters.AddWithValue("@UnidCodInicial", 0);
        }
        else
        {
            com.Parameters.AddWithValue("@UnidCodInicial", TxtUnidCodInicial.Text);
        }

        if (TxtUnidCodFinal.Text == "" || TxtUnidCodFinal.Text == null)
        {
            com.Parameters.AddWithValue("@UnidCodFinal", 0);
        }
        else
        {
            com.Parameters.AddWithValue("@UnidCodFinal", TxtUnidCodFinal.Text);
        }

        if (TxtBDependencia.Text == "" || TxtBDependencia.Text == null)
        {

            com.Parameters.AddWithValue("@DependenciaCod", "null");
        }
        else
        {
            string[] DependenciaCod = TxtBDependencia.Text.Trim().Split('|');
            com.Parameters.AddWithValue("@DependenciaCod", DependenciaCod[0]);
        }
        
        if (TxtFechaInicial.Text == "" || TxtFechaInicial.Text == null)
        {
            com.Parameters.AddWithValue("@FechaInicial", "null");
        }
        else
        {
            com.Parameters.AddWithValue("@FechaInicial", TxtFechaInicial.Text);
        }

        if (TxtFechaFinal.Text == "" || TxtFechaFinal.Text == null)
        {
            com.Parameters.AddWithValue("@FechaFinal", "null");
        }
        else
        {
            com.Parameters.AddWithValue("@FechaFinal", TxtFechaFinal.Text);
        }
        if (TxtBUbicacion.Text == "" || TxtBUbicacion.Text == null)
        {
            com.Parameters.AddWithValue("@Ubicacion", "null");
        }
        else
        {
            string[] UbicacionCod = TxtBUbicacion.Text.Trim().Split('|');
            com.Parameters.AddWithValue("@Ubicacion", UbicacionCod[0]);
        }

        if (TxtBForma.Text == "" || TxtBForma.Text == null)
        {
            com.Parameters.AddWithValue("@FormaCod", "null");
        }
        else
        {
            string[] FormaCod = TxtBForma.Text.Trim().Split('|');
            com.Parameters.AddWithValue("@FormaCod", FormaCod[0]);
        }

        if (TxtBSerie.Text == "" || TxtBSerie.Text == null)
        {
            com.Parameters.AddWithValue("@SerieCod", "null");
        }
        else
        {
            string[] SerieCod = TxtBSerie.Text.Trim().Split('|');
            com.Parameters.AddWithValue("@SerieCod", SerieCod[0]);
        }

        if (TxtBAccion.Text == "" || TxtBAccion.Text == null)
        {
            com.Parameters.AddWithValue("@AccionCod", "null");
        }
        else
        {
            string[] AccionCod = TxtBAccion.Text.Trim().Split('|');
            com.Parameters.AddWithValue("@AccionCod", AccionCod[0]);
        }

        if (TxtBTipologia.Text == "" || TxtBTipologia.Text == null)
        {
            com.Parameters.AddWithValue("@TipologiaCod", "null");
        }
        else
        {
            string[] TipologiaCod = TxtBTipologia.Text.Trim().Split('|');
            com.Parameters.AddWithValue("@TipologiaCod", TipologiaCod[0]);
        }

      
        com.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(com);
        try
        {
            con.Open();
            da.Fill(dt);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            con.Close();
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();

        

        this.MyAccordion.SelectedIndex = 1;
    }

    protected void BtnNuevo_Click(object sender, EventArgs e)
    {

    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
		 DataTable dt = new DataTable("Gridview1");
        foreach (TableCell cell in GridView1.HeaderRow.Cells)
        {

            dt.Columns.Add(cell.Text);
            
        }
        foreach (GridViewRow row in GridView1.Rows)
        { 
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                
                dt.Rows[dt.Rows.Count - 1][i] = HttpUtility.HtmlDecode(row.Cells[i].Text);
            }
        }
        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dt);

            Response.Clear();
            Response.Buffer = true;
            //Response.ContentEncoding = System.Text.Encoding.Default;
            Response.Charset = "";
            //Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet; charset = utf-8" ;
            Response.AddHeader("content-disposition", "attachment;filename=UnidadesDocumentales.xlsx");
            //Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">" + Environment.NewLine);
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        // Page page = new Page();

        // HtmlForm form = new HtmlForm();

        // page.EnableEventValidation = false;

        // page.DesignerInitialize();

        // page.Controls.Add(form);
        // form.Controls.Add(GridView1);

        

        // Response.ClearContent();
        // Response.AddHeader("content-disposition", "attachment; filename=gvtoexcel.xls");
        // Response.ContentType = "application/ms-excel";
        // System.IO.StringWriter sw = new System.IO.StringWriter();
        // HtmlTextWriter htw = new HtmlTextWriter(sw);
        // page.RenderControl(htw);
        // Response.Write(sw.ToString());
        // Response.End();
    }


    protected void LinkImagenes_Click(object sender, EventArgs e)
    {        
        string _open = "window.open('AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + ((LinkButton)sender).CommandArgument + "&GrupoCodigo=30&GrupoPadreCodigo=30&Admon=S&ImagenFolio=1', '_blank' , 'top=100,left=100, width=1000,height=800,status=yes, resizable=yes,scrollbars=yes');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
    }
 }
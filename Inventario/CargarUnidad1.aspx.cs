using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;


public partial class CargarUnidad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        Class1 cls = new Class1();
        string r;
        r = cls.UnidadDocumentalInsertar(DDLDependencia.Text, TBFechaExtremaInicial.Text, TBFechaExtremaFinal.Text, TBNomUnidad.Text, TBDetUnidad.Text, DDLUbicacion.Text, DDLForma.Text, TBNumFolios.Text, DDLSerie.Text, DDLAccion.Text, DDLTipologia.Text, TBRegInventario.Text);
        if (r.Contains("N°"))
        {

            lblMessage2.Text =  r ;
            //Response.Write("<script language = javascript>alert" + r + ";</script>");
        }
        else
        {

            lblMessage2.Text = r;
            //Response.Write("<script language = javascript>alert" + r + ";</script>");
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
}
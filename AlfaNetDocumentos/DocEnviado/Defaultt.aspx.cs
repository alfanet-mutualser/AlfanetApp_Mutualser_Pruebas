using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Neodynamic.WebControls.ImageDraw;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;


public partial class _Defaultt :System.Web.UI.Page
{
    rutinas ejecutar = new rutinas();
    DataTable tabla = new DataTable();
    string GrpDocReg = "";
   // string GrpDocReg = "2";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ExceptionDetails.Text = "";

        GrpDocReg = this.DropDownListGrupo.SelectedValue.ToString(); //  "2";

        System.Data.DataTable tabla = new DataTable();

        try
        {

            if (!IsPostBack)
            {
                this.DateFechaRad.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                //this.TreeVDestino.Attributes["onClick"] = "return OnTreeDestinoClick(event);";
                this.TreeVDestino.Attributes["onClick"] = "return OnCheckBoxCheckChanged(event," + txtFullName.ClientID + ");";
                //this.TreeVDestino.Attributes["onClick"] = "return OnCheckBoxCheckChanged(event);";
                this.TreeVRemite.Attributes["onClick"] = "return OnTreeClick(event);";
                this.TreeVExpediente.Attributes["OnClick"] = "return OnTreeExpedienteClick(event)";
                this.TreeVMedio.Attributes["onClick"] = "return OnTreeMedioClick(event);";
                this.TreeVNaturaleza.Attributes["onClick"] = "return OnTreeNaturalezaClick(event);";
                this.TreeVSerie.Attributes["onClick"] = "return OnTreeSerieClick(event);";
                this.txtEmail.Attributes["OnTextChanged"] = "return updateImageCard();";
                
                // llena el cuadro de lista grupo
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



                // lista llena con gel grupo de radicacoines
                tabla = ejecutar.rtn_traer_tbtablas_por_Id("GRUPORAD");
                codigodelgruporadicados = tabla.Rows[0][0].ToString().Trim();
                tabla = ejecutar.rtn_traer_grupos_por_codigopadre(codigodelgruporadicados);
                if (tabla.Rows.Count == 0)
                {
                    tabla = ejecutar.rtn_traer_grupos_por_Id(codigodelgruporadicados);
                }
                this.DropDownListGrupoFuente.DataTextField = "gruponombre";
                this.DropDownListGrupoFuente.DataValueField = "grupocodigo";
                this.DropDownListGrupoFuente.DataSource = tabla;
                this.DropDownListGrupoFuente.DataBind();
                this.DropDownListGrupoFuente.SelectedIndex = 0;


                Application["grupo"] = this.DropDownListGrupoFuente.SelectedValue.ToString();
                Application["gruporegistro"] = this.DropDownListGrupo.SelectedValue.ToString();

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
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            this.ACEDestino.ServiceMethod = "GetDependenciaByText";
            this.Paneldep.Visible = false;
            this.ImgFindDestino.Visible = true;
           
        }
        if (RadioButtonList1.SelectedValue == "0")
        {
            this.ACEDestino.ServiceMethod = "GetProcedenciaByTextNombre";
            this.Paneldep.Visible = true;
            this.ImgFindDestino.Visible = false;
        }
        RadioButtonList1.Focus();
        this.SetFocus(RadioButtonList1);        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
        this.ExceptionDetails.Text = "";

        string WFAccion = "1";
        string RegistroCodigo = "1";
        try
        {
            String RadCodString;
            RadCodString = TxtRadFuente.Text;
            if (RadCodString == "")
                RadCodString = null;

            if (RadCodString != null)
            {
                if (RadCodString.Contains(" | "))
                {
                    RadCodString = RadCodString.Remove(RadCodString.IndexOf(" | "));
                }
            }

            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(HttpContext.Current.Server.MapPath("~/devjoker.pdf"), FileMode.OpenOrCreate));
            document.Open();

            GuardarImg Imgs = new GuardarImg();
            String FileName = "";

            RegistroBLL ObjReg = new RegistroBLL();

            String ANO = DateTime.Today.Year.ToString();
            String MES = DateTime.Today.Month.ToString();

            if (RadioButtonList1.SelectedValue == "1")
            {
                if (this.TreeVDestino.CheckedNodes.Count > 0)
                {

                    foreach (TreeNode myNode in this.TreeVDestino.CheckedNodes)
                    {
                        RegistroCodigo = ObjReg.AddRegistro(GrpDocReg, Convert.ToDateTime(DateFechaRad.Text.ToString()), null, myNode.Text.ToString(), txtPhone.Text.ToString(), TxtNaturaleza.Text.ToString(), Convert.ToInt32(RadCodString), this.txtEmail.Text.ToString(), null, null, null, null, Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString(), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), TextBox1.Text.ToString(), null, RadioButtonList1.Text.ToString(), WFAccion, Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToInt32(RadioButtonList1.Text.ToString()), null, "0");
                        
                        //foreach (System.Web.UI.WebControls.ListItem Item in ListBoxFuente.Items)
                        //{
                        //    if (Item.Text != null)
                        //    {
                        //        if (Item.Text.Contains(" | "))
                        //        {
                        //            Item.Text = Item.Text.Remove(Item.Text.IndexOf(" | "));
                        //        }
                        //    }
                        //    DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter TARadFuente = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter();
                        //    TARadFuente.Insert(Convert.ToInt32(RegistroCodigo), Convert.ToInt32(Item.Text));
                        //}
                        this.insertarradicadosfuente(RegistroCodigo);

                        Imgs.GuardarImgs(this.txtEmail.Text, myNode.Text, this.RadioButtonList1.SelectedValue.ToString(), RegistroCodigo + myNode.Value + ".png", RegistroCodigo, this.DropDownListGrupo.SelectedValue);
                        FileName = RegistroCodigo + myNode.Value + ".png";
                        //String Separador = @"\";
                        String PathFolder = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/Registros/" + ANO + "/" + MES + "/");
                        //String PathFolder = @"F:\AlfaNet\AlfaNetRepositorioImagenes" + Separador + "Registros" + Separador + "2009" + Separador + "5" + Separador;
                        String PathString = PathFolder + FileName;
                        iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(@PathString);
                        png.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
                        png.ScalePercent(80);
                        document.Add(png);

                        this.LblMessageBox.Text += string.Format("Se Genero el documento {0}", RegistroCodigo);
                        this.LblMessageBox.Text += " y su imagen <br />";

                    }
                }
                else if (this.txtFullName.Text != "Multiple")
                {
                    RegistroCodigo = ObjReg.AddRegistro(GrpDocReg, Convert.ToDateTime(DateFechaRad.Text.ToString()), null, this.txtFullName.Text.ToString(), txtPhone.Text.ToString(), TxtNaturaleza.Text.ToString(), Convert.ToInt32(RadCodString), this.txtEmail.Text.ToString(), null, null, null, null, Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString(), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), TextBox1.Text.ToString(), null, RadioButtonList1.Text.ToString(), WFAccion, Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToInt32(RadioButtonList1.Text.ToString()), null, "0");

                    this.insertarradicadosfuente(RegistroCodigo);
                    FileName = RegistroCodigo+ txtFullName.Text.Remove(txtFullName.Text.IndexOf(" | ")) + ".png";
                    Imgs.GuardarImgs(this.txtEmail.Text, txtFullName.Text, this.RadioButtonList1.SelectedValue.ToString(), FileName, RegistroCodigo, this.DropDownListGrupo.SelectedValue);
                     //FileName = FileName+ ".png";
                     //String Separador = @"\";
                    String PathFolder = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/Registros/" + ANO + "/" + MES + "/");
                    String PathString = PathFolder + FileName;
                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(@PathString);
                    png.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
                    png.ScalePercent(80);
                    document.Add(png);

                    this.LblMessageBox.Text += string.Format("Se Genero el documento {0}", RegistroCodigo);
                    this.LblMessageBox.Text += " y su imagen <br />";

                } 
                
              
            }           
            else if(RadioButtonList1.SelectedValue == "0")
            {
                foreach (System.Web.UI.WebControls.ListItem Procedencia in this.ListBoxEnterar.Items)
                {
                    RegistroCodigo = ObjReg.AddRegistro(GrpDocReg, Convert.ToDateTime(DateFechaRad.Text.ToString()), Procedencia.Text, null, txtPhone.Text.ToString(), TxtNaturaleza.Text.ToString(), Convert.ToInt32(RadCodString), txtEmail.Text.ToString(), null, null, null, null, Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString(), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), TextBox1.Text.ToString(), null, RadioButtonList1.Text.ToString(), WFAccion, Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToInt32(RadioButtonList1.Text.ToString()), null, "0");

                    // insertar radicados fuente
                    this.insertarradicadosfuente(RegistroCodigo);

                    //foreach (System.Web.UI.WebControls.ListItem Item in ListBoxFuente.Items)
                    //{
                    //    if (Item.Text != null)
                    //    {
                    //        if (Item.Text.Contains(" | "))
                    //        {
                    //            Item.Text = Item.Text.Remove(Item.Text.IndexOf(" | "));
                    //        }
                    //    }
                    //    DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter TARadFuente = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter();
                    //    TARadFuente.Insert(Convert.ToInt32(RegistroCodigo), Convert.ToInt32(Item.Text));
                    //}
                    String Proce = Procedencia.Text.Remove(Procedencia.Text.IndexOf(" | "));
                    Imgs.GuardarImgs(this.txtEmail.Text, Proce, this.RadioButtonList1.SelectedValue.ToString(), RegistroCodigo + Proce + ".png", RegistroCodigo, this.DropDownListGrupo.SelectedValue);
                    FileName = RegistroCodigo + Proce + ".png";
                    //String Separador = @"\";
                    String PathFolder = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/Registros/" + ANO + "/" + MES + "/");
                    //String PathFolder = @"F:\AlfaNet\AlfaNetRepositorioImagenes" + Separador + "Registros" + Separador + "2009" + Separador + "5" + Separador;
                    String PathString = PathFolder + FileName;
                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(@PathString);
                    png.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
                    png.ScalePercent(80);
                    document.Add(png);

                    this.LblMessageBox.Text += string.Format("Se Genero el documento {0}", RegistroCodigo);
                    this.LblMessageBox.Text += " y su imagen <br />";
                }
            }
            this.MPEMensaje.Show();

            document.Close();
            

            //this.LblMessageBox.Text = "Registro Nro" + " " + RegistroCodigo;
            

            //MailBLL Correo = new MailBLL();
            //MembershipUser usuario;
            //DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
            //DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();
            //DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(this.txtPhone.Text.Remove(txtPhone.Text.IndexOf(" | ")).ToString().Trim());
            //if (DTUsuariosxDependencia.Count > 0)
            //{
            //    DataRow[] rows = DTUsuariosxDependencia.Select();
            //    System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
            //    usuario = Membership.GetUser(a);
            //    string Body = "Tiene un nuevo Registro Nro " + RegistroCodigo + "<BR>" + " Fecha de Tramite: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "<BR>" + "Dependencia: " + this.txtPhone.Text.ToString() + "<BR>" + "Naturaleza: " + this.TxtNaturaleza.Text.ToString().Trim() + "<BR>";
            //    Correo.EnvioCorreo("soporte.archivar@gmail.com", usuario.Email, "Registro Nro" + " " + RegistroCodigo, Body, true, "1");
            //}
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    protected void RBEnterarA_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBEnterarA.SelectedValue == "T")
        {
            this.ListBoxEnterar.Items.Clear();
            this.txtFullName.Text = "";
            this.txtFullName.ReadOnly = true;

            this.ImgBtnAdd.Enabled = false;
            this.ImgBtnDelete.Enabled = false;
            this.ListBoxEnterar.Items.Add("Todas | Todas");
        }
        else
        {
            this.ListBoxEnterar.Items.Clear();
            this.txtFullName.Text = "";
            this.txtFullName.ReadOnly = false;

            this.ImgBtnAdd.Enabled = true;
            this.ImgBtnDelete.Enabled = true;
        }
    }
    private void guardar()
    {
        
    }
    protected void TreeVDestino_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        try
        {
            ArbolesBLL ObjArbolDep = new ArbolesBLL();
            DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
            DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
            PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
        }
        catch (Exception Error)
        {
            //throw Exception(Error.Message);
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(  0 );";
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
   
    protected void ImgBtnAddFuente_Click(object sender, ImageClickEventArgs e)
    {
        this.ListBoxFuente.Items.Add(this.DropDownListGrupoFuente.SelectedValue + "--" + this.TxtRadFuente.Text.ToString());
        this.TxtRadFuente.Text = "";
        this.TxtRadFuente.Focus();
    }
    protected void ImgBtnDeleteFuente_Click(object sender, ImageClickEventArgs e)
    {
        this.ListBoxFuente.Items.Remove(this.ListBoxFuente.SelectedItem);
        this.ListBoxFuente.Focus();
    }
    protected void RBFuente_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBFuente.SelectedValue == "T")
        {
            this.ListBoxFuente.Items.Clear();
            this.TxtRadFuente.Text = "";
            this.TxtRadFuente.ReadOnly = true;
            this.ImgBtnAddFuente.Enabled = false;
            this.ImgBtnDeleteFuente.Enabled = false;
            this.ListBoxFuente.Items.Add("Todas | Todas");
        }
        else
        {
            this.ListBoxFuente.Items.Clear();
            this.TxtRadFuente.Text = "";
            this.TxtRadFuente.ReadOnly = false;
            this.ImgBtnAddFuente.Enabled = true;
            this.ImgBtnDeleteFuente.Enabled = true;
        }
    }
    protected void TreeVMedio_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolMed = new ArbolesBLL();
        DSMedioSQL.MedioByTextDataTable DTMedio = new DSMedioSQL.MedioByTextDataTable();
        DTMedio = ObjArbolMed.GetMedioTree(Int32.Parse(e.Node.Value));
        PopulateNodes(DTMedio, e.Node.ChildNodes, "MedioCodigo", "MedioNombre");
    }
    protected void TreeVNaturaleza_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolNat = new ArbolesBLL();
        DSNaturalezaSQL.NaturalezaByTextDataTable DTNaturaleza = new DSNaturalezaSQL.NaturalezaByTextDataTable();
        DTNaturaleza = ObjArbolNat.GetNaturalezaTree(e.Node.Value);
        PopulateNodes(DTNaturaleza, e.Node.ChildNodes, "NaturalezaCodigo", "NaturalezaNombre");
    }
    public void TreeVExpediente_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolExp = new ArbolesBLL();
        DSExpedienteSQL.ExpedienteByTextDataTable DTExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
        DTExpediente = ObjArbolExp.GetExpedienteTree(e.Node.Value);
        PopulateNodes(DTExpediente, e.Node.ChildNodes, "ExpedienteCodigo", "ExpedienteNombre");
    }
    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolSer = new ArbolesBLL();
        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();
        DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
    }

    protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        this.ListBoxEnterar.Items.Add(this.txtFullName.Text.ToString());
        this.txtFullName.Text = "";
        if (this.ListBoxEnterar.Items.Count > 0)
            this.RFVDestino.Enabled = false;
        else
            this.RFVDestino.Enabled = true;

    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.ListBoxEnterar.Items.Remove(this.ListBoxEnterar.SelectedItem);

        if (this.ListBoxEnterar.Items.Count > 0)
            this.RFVDestino.Enabled = false;
        else
            this.RFVDestino.Enabled = true;
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-disposition", "attachment; filename=" + "devjoker.pdf");
        Response.WriteFile(HttpContext.Current.Server.MapPath("~/devjoker.pdf"));
        Response.Flush();
        Response.Close();
    }
    protected void DropDownListGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Application["gruporegistro"] = this.DropDownListGrupo.SelectedValue.ToString();
    }

    protected void DropDownListGrupoFuente_SelectedIndexChanged(object sender, EventArgs e)
    {
        Application["grupo"] = this.DropDownListGrupoFuente.SelectedValue.ToString();
    }
    protected void insertarradicadosfuente(string RegistroCodigo)
    {
        string grupofuente = "";
        foreach (System.Web.UI.WebControls.ListItem Item in ListBoxFuente.Items)
        {
            string xcodigo = "";
            if (Item.Text != null)
            {
                if (Item.Text.Contains(" | "))
                {

                    int correr = 0;
                    correr = Item.Text.IndexOf("|") - (Item.Text.IndexOf("--") + 2);
                    grupofuente = Item.Text.Substring(0, Item.Text.IndexOf("--"));
                    xcodigo = Item.Text.Substring(Item.Text.IndexOf("--") + 2, correr);

                }
            }
            DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter TARadFuente = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter();
            TARadFuente.Insert(GrpDocReg, Convert.ToInt32(RegistroCodigo), grupofuente, Convert.ToInt32(xcodigo));

        }


    }
}
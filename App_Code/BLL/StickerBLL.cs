using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSStickerTableAdapters;

/// <summary>
/// Descripción breve de StickerBLL
/// </summary>
public class StickerBLL
{
	public StickerBLL()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    private Radicado_ReadRadicadoStickerTableAdapter _RadicadoStickerAdapter = null;
    protected Radicado_ReadRadicadoStickerTableAdapter AdapterRadicadoSticker
    {
        get
        {
            if (_RadicadoStickerAdapter == null)
                _RadicadoStickerAdapter = new Radicado_ReadRadicadoStickerTableAdapter();

            return _RadicadoStickerAdapter;
        }
    }
    private Registro_ReadRegistroStickerTableAdapter _RegistroStickerAdapter = null;
    protected Registro_ReadRegistroStickerTableAdapter AdapterRegistroSticker
    {
        get
        {
            if (_RegistroStickerAdapter == null)
                _RegistroStickerAdapter = new Registro_ReadRegistroStickerTableAdapter();

            return _RegistroStickerAdapter;
        }
    }

    // SELECT METHOD Registro
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetRegistroSticker(String GrupoCodigo, Int32 RegistroCodigo)
    {
        DSSticker.Registro_ReadRegistroStickerDataTable DTRegistroSticker = new DSSticker.Registro_ReadRegistroStickerDataTable();
        DataTable mDataTable;
        mDataTable = CrearRegistroStickerDataTable();


        DTRegistroSticker = AdapterRegistroSticker.GetRegistroSticker(GrupoCodigo, RegistroCodigo);

        foreach (DataRow row in DTRegistroSticker.Rows)
        {
            DataRow Row = mDataTable.NewRow();

            Row["RegistroCodigo"] = row["RegistroCodigo"].ToString();
            Row["WFMovimientoFecha"] = row["WFMovimientoFecha"].ToString();
            Row["Empresa"] = row["Empresa"].ToString();
            Row["NombresUsuario"] = row["NombresUsuario"].ToString();
            Row["GrupoCodigo"] = row["GrupoCodigo"].ToString();
            Row["DependenciaNombre"] = row["DependenciaNombre"].ToString();
            Row["ProcedenciaNombre"] = row["ProcedenciaNombre"].ToString();
            Row["ProcedenciaDireccion"] = row["ProcedenciaDireccion"].ToString();
            Row["RegistroTipo"] = row["RegistroTipo"].ToString();

            String Anexo;
            Anexo = row["AnexoExtRegistro"].ToString();
            Row["CiudadNombre"] = row["CiudadNombre"].ToString();
            Row["DepartamentoNombre"] = row["DepartamentoNombre"].ToString();

            if (Anexo.ToUpper().Contains("FOLIO"))
            {
                Anexo = Anexo.Remove(Anexo.ToUpper().IndexOf("FOLIO"));

                String[] Anexos = Anexo.Trim().Split(' ');

                int ContAnexos = Anexos.Length;

                Anexo = Anexos[ContAnexos - 1].ToString();

            }
            else
            {
                Anexo = null;
            }

            Row["AnexoExtRegistro"] = Anexo;            
       
            mDataTable.Rows.Add(Row);
        }
        //return Prueba;
        //Prueba.Dispose();
        ////
        return mDataTable;        
    }
    // SELECT METHOD Radicado
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetRadicadoSticker(String GrupoCodigo, Int32 RadicadoCodigo)
    {
        DSSticker.Radicado_ReadRadicadoStickerDataTable DTRadicadoSticker = new DSSticker.Radicado_ReadRadicadoStickerDataTable();
        DataTable mDataTable;
        mDataTable = CrearRadicadoStickerDataTable();


        DTRadicadoSticker = AdapterRadicadoSticker.GetRadicadoSticker(GrupoCodigo, RadicadoCodigo);

        foreach (DataRow row in DTRadicadoSticker.Rows)
        {
            DataRow Row = mDataTable.NewRow();

            Row["RadicadoCodigo"] = row["RadicadoCodigo"].ToString();
            Row["WFMovimientoFecha"] = row["WFMovimientoFecha"].ToString();
            Row["Empresa"] = row["Empresa"].ToString();
            Row["NombresUsuario"] = row["NombresUsuario"].ToString();
            Row["GrupoCodigo"] = row["GrupoCodigo"].ToString();
            Row["DependenciaNombre"] = row["DependenciaNombre"].ToString();
            

            String Anexo;
            Anexo = row["RadicadoAnexo"].ToString();
            Row["ProcedenciaNombre"] = row["ProcedenciaNombre"].ToString();

            if (Anexo.ToUpper().Contains("FOLIO"))
            {
                Anexo = Anexo.Remove(Anexo.ToUpper().IndexOf("FOLIO"));
                
                String[] Anexos = Anexo.Trim().Split(' ');

                int ContAnexos = Anexos.Length;

                Anexo = Anexos[ContAnexos - 1].ToString();

            }
            else
            {
                Anexo = null;
            }
            
            Row["RadicadoAnexo"] = Anexo;

            mDataTable.Rows.Add(Row);
        }


        //return Prueba;
        //Prueba.Dispose();
        ////
        return mDataTable;

    }
    //Table Radicado
    private DataTable CrearRadicadoStickerDataTable()
    {
        // Create a new DataTable titled 'Names.'
        DataTable namesTable = new DataTable("RadicadoStickerDataTable");

        // Add three column objects to the table.
        DataColumn idColumn = new DataColumn();
        idColumn.DataType = System.Type.GetType("System.String");
        idColumn.ColumnName = "RadicadoCodigo";
        namesTable.Columns.Add(idColumn);

        DataColumn GrupoNameColumn = new DataColumn();
        GrupoNameColumn.DataType = System.Type.GetType("System.String");
        GrupoNameColumn.ColumnName = "GrupoCodigo";
        namesTable.Columns.Add(GrupoNameColumn);
        

        DataColumn WFechaNameColumn = new DataColumn();
        WFechaNameColumn.DataType = System.Type.GetType("System.DateTime");
        WFechaNameColumn.ColumnName = "WFMovimientoFecha";
        namesTable.Columns.Add(WFechaNameColumn);

        DataColumn EmpresNameColumn = new DataColumn();
        EmpresNameColumn.DataType = System.Type.GetType("System.String");
        EmpresNameColumn.ColumnName = "Empresa";
        namesTable.Columns.Add(EmpresNameColumn);

        DataColumn NombresNameColumn = new DataColumn();
        NombresNameColumn.DataType = System.Type.GetType("System.String");
        NombresNameColumn.ColumnName = "NombresUsuario";
        namesTable.Columns.Add(NombresNameColumn);

        DataColumn DependenciaNameColumn = new DataColumn();
        DependenciaNameColumn.DataType = System.Type.GetType("System.String");
        DependenciaNameColumn.ColumnName = "DependenciaNombre";
        namesTable.Columns.Add(DependenciaNameColumn);

        DataColumn AnexoNameColumn = new DataColumn();
        AnexoNameColumn.DataType = System.Type.GetType("System.String");
        AnexoNameColumn.ColumnName = "RadicadoAnexo";
        namesTable.Columns.Add(AnexoNameColumn);

        DataColumn ProcedenciaNameColumn = new DataColumn();
        ProcedenciaNameColumn.DataType = System.Type.GetType("System.String");
        ProcedenciaNameColumn.ColumnName = "ProcedenciaNombre";
        namesTable.Columns.Add(ProcedenciaNameColumn);

        // Return the new DataTable.
        return namesTable;
    }
    //Table Registro
    private DataTable CrearRegistroStickerDataTable()
    {
        // Create a new DataTable titled 'Names.'
        DataTable namesTable = new DataTable("RegistroStickerDataTable");

        // Add three column objects to the table.
        DataColumn idColumn = new DataColumn();
        idColumn.DataType = System.Type.GetType("System.String");
        idColumn.ColumnName = "RegistroCodigo";
        namesTable.Columns.Add(idColumn);

        DataColumn GrupoNameColumn = new DataColumn();
        GrupoNameColumn.DataType = System.Type.GetType("System.String");
        GrupoNameColumn.ColumnName = "GrupoCodigo";
        namesTable.Columns.Add(GrupoNameColumn);


        DataColumn WFechaNameColumn = new DataColumn();
        WFechaNameColumn.DataType = System.Type.GetType("System.DateTime");
        WFechaNameColumn.ColumnName = "WFMovimientoFecha";
        namesTable.Columns.Add(WFechaNameColumn);

        DataColumn EmpresNameColumn = new DataColumn();
        EmpresNameColumn.DataType = System.Type.GetType("System.String");
        EmpresNameColumn.ColumnName = "Empresa";
        namesTable.Columns.Add(EmpresNameColumn);

        DataColumn NombresNameColumn = new DataColumn();
        NombresNameColumn.DataType = System.Type.GetType("System.String");
        NombresNameColumn.ColumnName = "NombresUsuario";
        namesTable.Columns.Add(NombresNameColumn);

        DataColumn DependenciaNameColumn = new DataColumn();
        DependenciaNameColumn.DataType = System.Type.GetType("System.String");
        DependenciaNameColumn.ColumnName = "DependenciaNombre";
        namesTable.Columns.Add(DependenciaNameColumn);

        DataColumn ProcedenciaNameColumn = new DataColumn();
        ProcedenciaNameColumn.DataType = System.Type.GetType("System.String");
        ProcedenciaNameColumn.ColumnName = "ProcedenciaNombre";
        namesTable.Columns.Add(ProcedenciaNameColumn);

        DataColumn ProcedenciaDireccionColumn = new DataColumn();
        ProcedenciaDireccionColumn.DataType = System.Type.GetType("System.String");
        ProcedenciaDireccionColumn.ColumnName = "ProcedenciaDireccion";
        namesTable.Columns.Add(ProcedenciaDireccionColumn);

        DataColumn TipoNameColumn = new DataColumn();
        TipoNameColumn.DataType = System.Type.GetType("System.String");
        TipoNameColumn.ColumnName = "RegistroTipo";
        namesTable.Columns.Add(TipoNameColumn);

        DataColumn AnexoNameColumn = new DataColumn();
        AnexoNameColumn.DataType = System.Type.GetType("System.String");
        AnexoNameColumn.ColumnName = "AnexoExtRegistro";
        namesTable.Columns.Add(AnexoNameColumn);

        DataColumn CiudadNameColumn = new DataColumn();
        CiudadNameColumn.DataType = System.Type.GetType("System.String");
        CiudadNameColumn.ColumnName = "CiudadNombre";
        namesTable.Columns.Add(CiudadNameColumn);

        DataColumn DepartamentoNameColumn = new DataColumn();
        DepartamentoNameColumn.DataType = System.Type.GetType("System.String");
        DepartamentoNameColumn.ColumnName = "DepartamentoNombre";
        namesTable.Columns.Add(DepartamentoNameColumn);

        // Return the new DataTable.
        return namesTable;
    }



}

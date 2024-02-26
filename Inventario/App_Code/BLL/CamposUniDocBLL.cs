using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnidadDocumentalTableAdapters;
using System.Data;

/// <summary>
/// Summary description for CamposUniDocBLL
/// </summary>
public class CamposUniDocBLL
{
    #region Variables Instancias Oracle
    DAL_UnidadDocumental ObjNombreUnidad = new DAL_UnidadDocumental();
    DataTable mDataTable;
    DAL_UnidadDocumental ObjUbicacion = new DAL_UnidadDocumental();
    DAL_UnidadDocumental ObjForma = new DAL_UnidadDocumental();
    DAL_UnidadDocumental ObjTipologia = new DAL_UnidadDocumental();
    #endregion

    private UnidadDocumental_ReadNombreUnidadByTextTableAdapter _UnidadNombreByTextAdapter = null;
    protected UnidadDocumental_ReadNombreUnidadByTextTableAdapter AdapterUnidadNombreByText
    {
        get
        {
            if (_UnidadNombreByTextAdapter == null)
                _UnidadNombreByTextAdapter = new UnidadDocumental_ReadNombreUnidadByTextTableAdapter();

            return _UnidadNombreByTextAdapter;
        }
    }

    private Ubicacion_ReadUbicacionByTextTableAdapter _UbicacionByTextAdapter = null;
    protected Ubicacion_ReadUbicacionByTextTableAdapter AdapterUbicacionByText
    {
        get
        {
            if (_UbicacionByTextAdapter == null)
                _UbicacionByTextAdapter = new Ubicacion_ReadUbicacionByTextTableAdapter();

            return _UbicacionByTextAdapter;
        }
    }

    private Forma_ReadFormaByTextTableAdapter _FormaByTextAdapter = null;
    protected Forma_ReadFormaByTextTableAdapter AdapterFormaByText
    {
        get
        {
            if (_FormaByTextAdapter == null)
                _FormaByTextAdapter = new Forma_ReadFormaByTextTableAdapter();

            return _FormaByTextAdapter;
        }
    }

    private Tipologia_ReadTipologiaByTextTableAdapter _TipologiaByTextAdapter = null;
    protected Tipologia_ReadTipologiaByTextTableAdapter AdapterTipologiaByText
    {
        get
        {
            if (_TipologiaByTextAdapter == null)
                _TipologiaByTextAdapter = new Tipologia_ReadTipologiaByTextTableAdapter();

            return _TipologiaByTextAdapter;
        }
    }

    // SELECT METHOD NombreUnidad ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public UnidadDocumental.UnidadDocumental_ReadNombreUnidadByTextDataTable GetData(string NombreUnidad)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterUnidadNombreByText.GetData(NombreUnidad);
            }
            else
            {
                mDataTable = ObjNombreUnidad.ReadUnidadNombreByText(NombreUnidad);
                //return mDataTable;
                UnidadDocumental.UnidadDocumental_ReadNombreUnidadByTextDataTable Datos = new UnidadDocumental.UnidadDocumental_ReadNombreUnidadByTextDataTable();

                foreach (DataRow row in mDataTable.Rows)
                {
                    UnidadDocumental.UnidadDocumental_ReadNombreUnidadByTextRow Fila = Datos.NewUnidadDocumental_ReadNombreUnidadByTextRow();
                    Fila.UnidadNombre = row.ItemArray[1].ToString();
                    Datos.Rows.Add(Fila);
                }

                return Datos;
                Datos.Dispose();

            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }

    }

    // SELECT METHOD Ubicacion ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public UnidadDocumental.Ubicacion_ReadUbicacionByTextDataTable GetUbicacionByText(string UbicacionNombre, string UbicacionHabilitar)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterUbicacionByText.GetUbicacionByText(UbicacionNombre, UbicacionHabilitar);
            }
            else
            {
                mDataTable = ObjUbicacion.ReadUbicacionByText(UbicacionNombre, UbicacionHabilitar);
                //return mDataTable;
                UnidadDocumental.Ubicacion_ReadUbicacionByTextDataTable Datos = new UnidadDocumental.Ubicacion_ReadUbicacionByTextDataTable();

                foreach (DataRow row in mDataTable.Rows)
                {
                    UnidadDocumental.Ubicacion_ReadUbicacionByTextRow Fila = Datos.NewUbicacion_ReadUbicacionByTextRow();
                    Fila.UbicacionCodigo = row.ItemArray[0].ToString();
                    Fila.UbicacionNombre = row.ItemArray[1].ToString();
                    Datos.Rows.Add(Fila);
                }

                return Datos;
                Datos.Dispose();

            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }

    }

    // SELECT METHOD Forma ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public UnidadDocumental.Forma_ReadFormaByTextDataTable GetFormaByText(string FormaNombre, string FormaHabilitar)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterFormaByText.GetFormaByText(FormaNombre, FormaHabilitar);
            }
            else
            {
                mDataTable = ObjForma.ReadFormaByText(FormaNombre, FormaHabilitar);
                //return mDataTable;
                UnidadDocumental.Forma_ReadFormaByTextDataTable Datos = new UnidadDocumental.Forma_ReadFormaByTextDataTable();

                foreach (DataRow row in mDataTable.Rows)
                {
                    UnidadDocumental.Forma_ReadFormaByTextRow Fila = Datos.NewForma_ReadFormaByTextRow();
                    Fila.FormaCodigo = row.ItemArray[0].ToString();
                    Fila.FormaNombre = row.ItemArray[1].ToString();
                    Datos.Rows.Add(Fila);
                }

                return Datos;
                Datos.Dispose();

            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }

    }

    // SELECT METHOD Tipologia ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public UnidadDocumental.Tipologia_ReadTipologiaByTextDataTable GetTipologiaByText(string TipologiaNombre, string TipologiaHabilitar)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterTipologiaByText.GetTipologiaByText(TipologiaNombre, TipologiaHabilitar);
            }
            else
            {
                mDataTable = ObjTipologia.ReadTipologiaByText(TipologiaNombre, TipologiaHabilitar);
                //return mDataTable;
                UnidadDocumental.Tipologia_ReadTipologiaByTextDataTable Datos = new UnidadDocumental.Tipologia_ReadTipologiaByTextDataTable();

                foreach (DataRow row in mDataTable.Rows)
                {
                    UnidadDocumental.Tipologia_ReadTipologiaByTextRow Fila = Datos.NewTipologia_ReadTipologiaByTextRow();
                    Fila.TipologiaCodigo = row.ItemArray[0].ToString();
                    Fila.TipologiaNombre = row.ItemArray[1].ToString();
                    Datos.Rows.Add(Fila);
                }

                return Datos;
                Datos.Dispose();

            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }

    }

}
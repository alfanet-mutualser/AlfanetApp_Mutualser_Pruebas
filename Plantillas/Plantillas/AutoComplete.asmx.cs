using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Plantillas
{
    /// <summary>
    /// Descripción breve de AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {
/* [WebMethod]
        public string[] GetPaisByTextNombre(string prefixText)
        {

            List<string> PaisList = new List<string>(20);
            PaisBLL paises = new PaisBLL();
            foreach (DataRow DataRowCurrent in paises.GetPaisByTextNombre(prefixText, "1"))
            {
                PaisList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());

            }
            return (PaisList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetPaisByTextID(string prefixText)
        {
            List<string> PaisList = new List<string>(20);
            PaisBLL paises = new PaisBLL();
            foreach (DataRow DataRowCurrent in paises.GetPaisByTextId(prefixText, "1"))
            {
                PaisList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (PaisList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetPaisByTextNombrenull(string prefixText)
        {
            List<string> PaisList = new List<string>(20);
            PaisBLL paises = new PaisBLL();
            foreach (DataRow DataRowCurrent in paises.GetPaisByTextNombre(prefixText, null))
            {
                PaisList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());

            }
            return (PaisList.ToArray());
        }*/

        /* [WebMethod]
         public string[] GetPaisByTextIDnull(string prefixText)
         {
             List<string> PaisList = new List<string>(20);
             PaisBLL paises = new PaisBLL();
             foreach (DataRow DataRowCurrent in paises.GetPaisByTextId(prefixText, null))
             {
                 PaisList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
             }
             return (PaisList.ToArray());
         }*/
        /* [WebMethod]
         public string[] GetDepartamentoByTextNombre(string prefixText)
         {
             List<string> DepartamentoList = new List<string>(20);
             DepartamentoBLL departamentos = new DepartamentoBLL();
             foreach (DataRow DataRowCurrent in departamentos.GetDepartamentoByTextNombre(prefixText, "1"))
             {
                 DepartamentoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
             }
             return (DepartamentoList.ToArray());
         }*/

        /* [WebMethod]
         public string[] GetDepartamentoByTextId(string prefixText)
         {
             List<string> DepartamentoList = new List<string>(20);
             DepartamentoBLL departamentos = new DepartamentoBLL();
             foreach (DataRow DataRowCurrent in departamentos.GetDepartamentoByTextId(prefixText, "1"))
             {
                 DepartamentoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
             }
             return (DepartamentoList.ToArray());
         }*/

        /* [WebMethod]
         public string[] GetDepartamentoByTextNombrenull(string prefixText)
         {
             List<string> DepartamentoList = new List<string>(20);
             DepartamentoBLL departamentos = new DepartamentoBLL();
             foreach (DataRow DataRowCurrent in departamentos.GetDepartamentoByTextNombre(prefixText, null))
             {
                 DepartamentoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
             }
             return (DepartamentoList.ToArray());
         }*/

        /*[WebMethod]
        public string[] GetDepartamentoByTextIdnull(string prefixText)
        {
            List<string> DepartamentoList = new List<string>(20);
            DepartamentoBLL departamentos = new DepartamentoBLL();
            foreach (DataRow DataRowCurrent in departamentos.GetDepartamentoByTextId(prefixText, null))
            {
                DepartamentoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (DepartamentoList.ToArray());
        }*/

        /* [WebMethod]
         public string[] GetCiudadByTextNombre(string prefixText)
         {
             List<string> CiudadList = new List<string>(20);
             CiudadBLL ciudades = new CiudadBLL();
             foreach (DataRow DataRowCurrent in ciudades.GetCiudadByTextNombre(prefixText, "1"))
             {
                 CiudadList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString() + " | " + DataRowCurrent[2].ToString());
             }
             return (CiudadList.ToArray());
         }*/

        /*[WebMethod]
        public string[] GetCiudadByTextId(string prefixText)
        {
            List<string> CiudadList = new List<string>(20);
            CiudadBLL ciudades = new CiudadBLL();
            foreach (DataRow DataRowCurrent in ciudades.GetCiudadByTextId(prefixText, "1"))
            {
                CiudadList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString() + " | " + DataRowCurrent[2].ToString());
            }
            return (CiudadList.ToArray());
        }*/

        /* [WebMethod]
         public string[] GetCiudadByTextNombrenull(string prefixText)
         {
             List<string> CiudadList = new List<string>(20);
             CiudadBLL ciudades = new CiudadBLL();
             foreach (DataRow DataRowCurrent in ciudades.GetCiudadByTextNombre(prefixText, null))
             {
                 CiudadList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString() + " | " + DataRowCurrent[2].ToString());
             }
             return (CiudadList.ToArray());
         }*/

        /* [WebMethod]
         public string[] GetCiudadByTextIdnull(string prefixText)
         {
             List<string> CiudadList = new List<string>(20);
             CiudadBLL ciudades = new CiudadBLL();
             foreach (DataRow DataRowCurrent in ciudades.GetCiudadByTextId(prefixText, null))
             {
                 CiudadList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString() + " | " + DataRowCurrent[2].ToString());
             }
             return (CiudadList.ToArray());
         }*/

        [WebMethod]
        public string[] GetDependenciaByText(string prefixText)
        {            
            List<string> DependenciaList = new List<string>(20);
            //DependenciaBLL dependencias = new DependenciaBLL();
            DataSet data = new DataSet();
            Business BI = new Business();
            data = BI.GetDependenciaByText(prefixText, "1");

            foreach (DataRow DataRowCurrent in data.Tables[0].Rows)
            {
                DependenciaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (DependenciaList.ToArray());
        }
        /*[WebMethod]
        public string[] GetDependenciaByTextId(string prefixText)
        {
            List<String> DependenciaList = new List<string>(20);
            DependenciaBLL dependencias = new DependenciaBLL();
            foreach (DataRow DataRowCurrent in dependencias.GetDependenciaTextById(prefixText, "1"))
            {
                DependenciaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (DependenciaList.ToArray());
        }*/

       /* [WebMethod]
        public string[] GetDependenciaByTextnull(string prefixText)
        {
            List<string> DependenciaList = new List<string>(20);
            DependenciaBLL dependencias = new DependenciaBLL();
            foreach (DataRow DataRowCurrent in dependencias.GetDependenciaByText(prefixText, null))
            {
                DependenciaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (DependenciaList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetDependenciaByTextIdnull(string prefixText)
        {
            List<String> DependenciaList = new List<string>(20);
            DependenciaBLL dependencias = new DependenciaBLL();
            foreach (DataRow DataRowCurrent in dependencias.GetDependenciaTextById(prefixText, null))
            {
                DependenciaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (DependenciaList.ToArray());
        }*/

        [WebMethod]
        public string[] GetExpedienteByTextNombre(string prefixText)
        {
            List<String> ExpedienteList = new List<string>(20);
            //ExpedienteBLL Expedientes = new ExpedienteBLL();
            DataSet data = new DataSet();
            Business BI = new Business();
            data = BI.GetExpedienteByTextNombre(prefixText,true);
            foreach (DataRow DataRowCurrent in data.Tables[0].Rows)
            {
                ExpedienteList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (ExpedienteList.ToArray());
        }

        /*[WebMethod]
        public string[] GetExpedienteByTextId(string prefixText)
        {
            List<String> ExpedienteList = new List<string>(20);
            ExpedienteBLL Expedientes = new ExpedienteBLL();
            foreach (DataRow DataRowCurrent in Expedientes.GetExpedienteByTextId(prefixText, true))
            {
                ExpedienteList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (ExpedienteList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetExpedienteByTextNombrenull(string prefixText)
        {
            List<String> ExpedienteList = new List<string>(20);
            ExpedienteBLL Expedientes = new ExpedienteBLL();
            foreach (DataRow DataRowCurrent in Expedientes.GetExpedienteByTextNombre(prefixText, false))
            {
                ExpedienteList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (ExpedienteList.ToArray());
        }*/

       /* [WebMethod]
        public string[] GetExpedienteByTextIdnull(string prefixText)
        {
            List<String> ExpedienteList = new List<string>(20);
            ExpedienteBLL Expedientes = new ExpedienteBLL();
            foreach (DataRow DataRowCurrent in Expedientes.GetExpedienteByTextId(prefixText, false))
            {
                ExpedienteList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (ExpedienteList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetGrupoByText(string prefixText)
        {
            List<String> GrupoList = new List<string>(20);
            GrupoBLL Grupos = new GrupoBLL();
            foreach (DataRow DataRowCurrent in Grupos.GetGrupoByText(prefixText, "1"))
            {
                GrupoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (GrupoList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetGrupoByTextId(string prefixText)
        {
            List<String> GrupoList = new List<string>(20);
            GrupoBLL Grupos = new GrupoBLL();
            foreach (DataRow DataRowCurrent in Grupos.GetGrupoTextById(prefixText, "1"))
            {
                GrupoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (GrupoList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetGrupoByTextnull(string prefixText)
        {
            List<String> GrupoList = new List<string>(20);
            GrupoBLL Grupos = new GrupoBLL();
            foreach (DataRow DataRowCurrent in Grupos.GetGrupoByText(prefixText, null))
            {
                GrupoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (GrupoList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetGrupoByTextIdnull(string prefixText)
        {
            List<String> GrupoList = new List<string>(20);
            GrupoBLL Grupos = new GrupoBLL();
            foreach (DataRow DataRowCurrent in Grupos.GetGrupoTextById(prefixText, null))
            {
                GrupoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (GrupoList.ToArray());
        }*/

        [WebMethod]
        public string[] GetMedioByText(string prefixText)
        {
            List<String> MedioList = new List<string>(20);
            //MedioBLL Medios = new MedioBLL();
            DataSet data = new DataSet();
            Business BI = new Business();
            data = BI.GetMedioByText(prefixText, "1");
            foreach (DataRow DataRowCurrent in data.Tables[0].Rows)
            {
                MedioList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (MedioList.ToArray());
        }
        /*[WebMethod]
        public string[] GetMedioByTextId(string prefixText)
        {
            List<String> MedioList = new List<string>(20);
            MedioBLL Medios = new MedioBLL();
            foreach (DataRow DataRowCurrent in Medios.GetMedioByTextId(prefixText, "1"))
            {
                MedioList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (MedioList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetMedioByTextnull(string prefixText)
        {
            List<String> MedioList = new List<string>(20);
            MedioBLL Medios = new MedioBLL();
            foreach (DataRow DataRowCurrent in Medios.GetMedioByText(prefixText, null))
            {
                MedioList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (MedioList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetMedioByTextIdnull(string prefixText)
        {
            List<String> MedioList = new List<string>(20);
            MedioBLL Medios = new MedioBLL();
            foreach (DataRow DataRowCurrent in Medios.GetMedioByTextId(prefixText, null))
            {
                MedioList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (MedioList.ToArray());
        }*/

        [WebMethod]
        public string[] GetNaturalezaByText(string prefixText)
        {
            List<String> NaturalezaList = new List<string>(20);
            //NaturalezaBLL Naturalezas = new NaturalezaBLL();
            DataSet data = new DataSet();
            Business BI = new Business();
            data = BI.GetNaturalezaByText(prefixText, "1");
            foreach (DataRow DataRowCurrent in data.Tables[0].Rows)
            {
                NaturalezaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper() + " | " + DataRowCurrent[2].ToString());
            }
            return (NaturalezaList.ToArray());
        }
        /*[WebMethod]
        public string[] GetNaturalezaByTextId(string prefixText)
        {
            List<String> NaturalezaList = new List<string>(20);
            NaturalezaBLL Naturalezas = new NaturalezaBLL();
            foreach (DataRow DataRowCurrent in Naturalezas.GetNaturalezaByTextId(prefixText, "1"))
            {
                NaturalezaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (NaturalezaList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetNaturalezaByTextnull(string prefixText)
        {
            List<String> NaturalezaList = new List<string>(20);
            NaturalezaBLL Naturalezas = new NaturalezaBLL();
            foreach (DataRow DataRowCurrent in Naturalezas.GetNaturalezaByText(prefixText, null))
            {
                NaturalezaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (NaturalezaList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetNaturalezaByTextIdnull(string prefixText)
        {
            List<String> NaturalezaList = new List<string>(20);
            NaturalezaBLL Naturalezas = new NaturalezaBLL();
            foreach (DataRow DataRowCurrent in Naturalezas.GetNaturalezaByTextId(prefixText, null))
            {
                NaturalezaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (NaturalezaList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetNaturalezaByTextIdnullPQR(string prefixText)
        {
            List<String> NaturalezaList = new List<string>(20);
            NaturalezaBLL Naturalezas = new NaturalezaBLL();
            foreach (DataRow DataRowCurrent in Naturalezas.GetNaturalezaByTextIdPQR(prefixText, null))
            {
                NaturalezaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (NaturalezaList.ToArray());
        }*/
        [WebMethod]
        public string[] GetProcedenciaByTextNombre(string prefixText)
        {
            List<String> ProcedenciaList = new List<string>(20);
            //ProcedenciaBLL Procedencias = new ProcedenciaBLL();
            DataSet data = new DataSet();
            Business BI = new Business();
            data = BI.GetProcedenciaByTextNombre(prefixText, "1");
            foreach (DataRow DataRowCurrent in data.Tables[0].Rows)
            {
                ProcedenciaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[3].ToString() + " | " + DataRowCurrent[1].ToString() + " | " + DataRowCurrent[2].ToString());
            }
            return (ProcedenciaList.ToArray());
        }

        /*[WebMethod]
        public string[] GetProcedenciaByTextId(string prefixText)
        {
            List<String> ProcedenciaList = new List<string>(20);
            ProcedenciaBLL Procedencias = new ProcedenciaBLL();
            foreach (DataRow DataRowCurrent in Procedencias.GetProcedenciaByTextId(prefixText, "1"))
            {
                ProcedenciaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[3].ToString() + " | " + DataRowCurrent[1].ToString() + " | " + DataRowCurrent[2].ToString());
            }
            return (ProcedenciaList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetProcedenciaByTextNombrenull(string prefixText)
        {
            List<String> ProcedenciaList = new List<string>(20);
            ProcedenciaBLL Procedencias = new ProcedenciaBLL();
            foreach (DataRow DataRowCurrent in Procedencias.GetProcedenciaByTextNombre(prefixText, null))
            {
                ProcedenciaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[3].ToString() + " | " + DataRowCurrent[1].ToString() + " | " + DataRowCurrent[2].ToString());
            }
            return (ProcedenciaList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetProcedenciaByTextIdnull(string prefixText)
        {
            List<String> ProcedenciaList = new List<string>(20);
            ProcedenciaBLL Procedencias = new ProcedenciaBLL();
            foreach (DataRow DataRowCurrent in Procedencias.GetProcedenciaByTextId(prefixText, null))
            {
                ProcedenciaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[3].ToString() + " | " + DataRowCurrent[1].ToString() + " | " + DataRowCurrent[2].ToString());
            }
            return (ProcedenciaList.ToArray());
        }*/

        [WebMethod]
        public string[] GetSerieByText(string prefixText)
        {
            List<String> SerieList = new List<string>(20);
            //SerieBLL Series = new SerieBLL();
            DataSet data = new DataSet();
            Business BI = new Business();
            data = BI.GetSerieByText(prefixText, "1");
            foreach (DataRow DataRowCurrent in data.Tables[0].Rows)
            {
                SerieList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (SerieList.ToArray());
        }
        /*[WebMethod]
        public string[] GetSerieTextById(string prefixText)
        {
            List<String> SerieList = new List<string>(20);
            SerieBLL Series = new SerieBLL();
            foreach (DataRow DataRowCurrent in Series.GetSerieTextById(prefixText, "1"))
            {
                SerieList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (SerieList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetSerieByTextnull(string prefixText)
        {
            List<String> SerieList = new List<string>(20);
            SerieBLL Series = new SerieBLL();
            foreach (DataRow DataRowCurrent in Series.GetSerieByText(prefixText, null))
            {
                SerieList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (SerieList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetSerieTextByIdnull(string prefixText)
        {
            List<String> SerieList = new List<string>(20);
            SerieBLL Series = new SerieBLL();
            foreach (DataRow DataRowCurrent in Series.GetSerieTextById(prefixText, null))
            {
                SerieList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (SerieList.ToArray());
        }*/

        [WebMethod]
        public string[] GetRadicadoByCodigo(string prefixText)
        {

            List<String> RadicadoList = new List<string>(20);

            //RadicadoBLL Radicados = new RadicadoBLL();
            DataSet data = new DataSet();
            Business BI = new Business();
            data = BI.GetRadicadoByCodigo(prefixText);
            foreach (DataRow DataRowCurrent in data.Tables[0].Rows)
            {
                RadicadoList.Add(DataRowCurrent[0].ToString() + " | ");
            }

            return (RadicadoList.ToArray());
        }

        /*[WebMethod]
        public string[] GetRadicadoByGrupo(string prefixText)
        {

            string codigo = Application["grupo"].ToString();

            rutinas ejecutar = new rutinas();
            DataTable tabla = new DataTable();
            tabla = ejecutar.rtn_traer_radicados_por_grupo(codigo, prefixText);

            List<String> RadicadoList = new List<string>(20);
            foreach (DataRow DataRowCurrent in tabla.Rows)
            {
                RadicadoList.Add(DataRowCurrent[0].ToString() + " | ");
            }
            return (RadicadoList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetRadicadoFuenteByGrupo(string prefixText)
        {

            string codigo = Application["grupo"].ToString();

            rutinas ejecutar = new rutinas();
            DataTable tabla = new DataTable();
            tabla = ejecutar.rtn_traer_radicados_por_grupo(codigo, prefixText);

            List<String> RadicadoList = new List<string>(20);
            foreach (DataRow DataRowCurrent in tabla.Rows)
            {
                RadicadoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (RadicadoList.ToArray());
        }*/


        /*[WebMethod]
        public string[] GetRegistroCodigoByCodigo(string prefixText)
        {

            string codigo = Application["gruporegistro"].ToString();

            rutinas ejecutar = new rutinas();
            DataTable tabla = new DataTable();
            tabla = ejecutar.rtn_traer_registros_por_grupo(codigo, prefixText);
            List<String> RegistroList = new List<string>(20);
            foreach (DataRow DataRowCurrent in tabla.Rows)
            {
                RegistroList.Add(DataRowCurrent[0].ToString() + " | ");
            }

            return (RegistroList.ToArray());
        }*/
        [WebMethod]
        public string[] GetWFAccionTextByText(string prefixText)
        {
            List<string> WFAccionList = new List<string>(20);
            //WFAccionBLL WFAcciones = new WFAccionBLL();
            DataSet data = new DataSet();
            Business BI = new Business();
            data = BI.GetWFAccionTextByText(prefixText, "1");

            foreach (DataRow DataRowCurrent in data.Tables[0].Rows)
            {
                WFAccionList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());

            }
            return (WFAccionList.ToArray());
        }
        /*[WebMethod]
        public string[] GetWFAccionTextById(string prefixText)
        {
            List<string> WFAccionList = new List<string>(20);
            WFAccionBLL WFAcciones = new WFAccionBLL();
            foreach (DataRow DataRowCurrent in WFAcciones.GetWFAccionTextById(prefixText, "1"))
            {
                WFAccionList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (WFAccionList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetWFAccionTextByIdnull(string prefixText)
        {
            List<string> WFAccionList = new List<string>(20);
            WFAccionBLL WFAcciones = new WFAccionBLL();
            foreach (DataRow DataRowCurrent in WFAcciones.GetWFAccionTextById(prefixText, null))
            {
                WFAccionList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (WFAccionList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetWFAccionTextByTextnull(string prefixText)
        {
            List<string> WFAccionList = new List<string>(20);
            WFAccionBLL WFAcciones = new WFAccionBLL();
            foreach (DataRow DataRowCurrent in WFAcciones.GetWFAccionTextByText(prefixText, null))
            {
                WFAccionList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
            }
            return (WFAccionList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetWFProcesoTextByText(string prefixText)
        {
            List<string> WFProcesoList = new List<string>(20);
            WFProcesoBLL WFProcesos = new WFProcesoBLL();
            foreach (DataRow DataRowCurrent in WFProcesos.GetWFProcesoTextByText(prefixText, "1"))
            {
                WFProcesoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (WFProcesoList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetWFProcesoTextById(string prefixText)
        {
            List<string> WFProcesoList = new List<string>(20);
            WFProcesoBLL WFProcesos = new WFProcesoBLL();
            foreach (DataRow DataRowCurrent in WFProcesos.GetWFProcesoTextById(prefixText, "1"))
            {
                WFProcesoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (WFProcesoList.ToArray());
        }*/

        /*[WebMethod]
        public string[] GetWFProcesoTextByTextnull(string prefixText)
        {
            List<string> WFProcesoList = new List<string>(20);
            WFProcesoBLL WFProcesos = new WFProcesoBLL();
            foreach (DataRow DataRowCurrent in WFProcesos.GetWFProcesoTextByText(prefixText, null))
            {
                WFProcesoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (WFProcesoList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetWFProcesoTextByIdnull(string prefixText)
        {
            List<string> WFProcesoList = new List<string>(20);
            WFProcesoBLL WFProcesos = new WFProcesoBLL();
            foreach (DataRow DataRowCurrent in WFProcesos.GetWFProcesoTextById(prefixText, null))
            {
                WFProcesoList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
            }
            return (WFProcesoList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetPrestamoByCodigo(string prefixText)
        {

            List<String> PrestamosList = new List<string>(20);

            DSPrestamosTableAdapters.Prestamos_ReadPrestamosByCodigoTableAdapter Prestamo = new DSPrestamosTableAdapters.Prestamos_ReadPrestamosByCodigoTableAdapter();

            foreach (DataRow DataRowCurrent in Prestamo.GetData(prefixText))
            {
                PrestamosList.Add(DataRowCurrent[0].ToString() + " | ");
            }

            return (PrestamosList.ToArray());
        }*/
        /*[WebMethod]
        public string[] Getaspnet_UsersByUserName(string prefixText)
        {
            List<String> aspnet_UsersList = new List<string>(20);
            DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter aspnet_Users = new DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter();

            foreach (DataRow DataRowCurrent in aspnet_Users.Getaspnet_UsersByUsers(prefixText))
            {
                aspnet_UsersList.Add(DataRowCurrent[1].ToString());
            }

            return (aspnet_UsersList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetUsuariosByNombres(string prefixText)
        {
            List<String> UsuariosxNombresList = new List<string>(20);
            DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter UsuarioxNombre = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
            //DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter aspnet_Users = new DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter();

            foreach (DataRow DataRowCurrent in UsuarioxNombre.GetUsuarioByNombres(prefixText))
            {
                UsuariosxNombresList.Add(DataRowCurrent[2].ToString() + " | " + DataRowCurrent[3].ToString());
            }

            return (UsuariosxNombresList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetUsuariosByApellidos(string prefixText)
        {
            List<String> UsuariosxApellidosList = new List<string>(20);
            DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter UsuarioxApellidos = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
            //DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter aspnet_Users = new DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter();

            foreach (DataRow DataRowCurrent in UsuarioxApellidos.GetUsuarioByApellidos(prefixText))
            {
                UsuariosxApellidosList.Add(DataRowCurrent[3].ToString() + " | " + DataRowCurrent[2].ToString());
            }

            return (UsuariosxApellidosList.ToArray());
        }*/
        // 
        /*[WebMethod]
        public string[] GetDocArchivadosRecibidos(string prefixText)
        {
            List<String> DocArchivadosRecibidosList = new List<string>(20);
            DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadobyDocumentoTableAdapter DSWFDOCARCH = new DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadobyDocumentoTableAdapter();
            //DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter aspnet_Users = new DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter();

            foreach (DataRow DataRowCurrent in DSWFDOCARCH.GetDocArchivadoRecibido(prefixText, "1"))
            {
                DocArchivadosRecibidosList.Add(DataRowCurrent[0].ToString() + " | ");
            }
            return (DocArchivadosRecibidosList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetDocArchivadosEnviados(string prefixText)
        {
            List<String> DocArchivadosEnviadosList = new List<string>(20);
            DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadobyDocumentoTableAdapter DSWFDOCARCH = new DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadobyDocumentoTableAdapter();
            //DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter aspnet_Users = new DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter();

            foreach (DataRow DataRowCurrent in DSWFDOCARCH.GetDocArchivadoEnviadoBy(prefixText, "2"))
            {
                DocArchivadosEnviadosList.Add(DataRowCurrent[0].ToString() + " | ");
            }
            return (DocArchivadosEnviadosList.ToArray());
        }*/
        /*[WebMethod]
        public string[] GetRegistroCodigoByGrupo(string prefixText)
        {

            string codigo = Application["gruporegistro"].ToString();

            rutinas ejecutar = new rutinas();
            DataTable tabla = new DataTable();
            tabla = ejecutar.rtn_traer_registros_por_grupo(codigo, prefixText);
            List<String> RegistroList = new List<string>(20);
            foreach (DataRow DataRowCurrent in tabla.Rows)
            {
                RegistroList.Add(DataRowCurrent[0].ToString() + " | ");
            }

            return (RegistroList.ToArray());
        }*/
    }
}

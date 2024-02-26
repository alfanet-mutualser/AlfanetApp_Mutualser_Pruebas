using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

//namespace Entity
//{
    [Serializable]
    public class DatosRegistro
    {
        public DatosRegistro() { }

        [XmlElement("grupoCodigo")]
        public string grupoCodigo;

        [XmlElement("wFMovimientoFecha")]
        public DateTime wFMovimientoFecha;

        [XmlElement("procedenciaCodDestino")]
        public string procedenciaCodDestino;

        [XmlElement("dependenciaCodDestino")]
        public string dependenciaCodDestino;

        [XmlElement("dependenciaCodigo")]
        public string dependenciaCodigo;

        [XmlElement("naturalezaCodigo")]
        public string naturalezaCodigo;

        [XmlElement("radicadoCodigo")]
        public int radicadoCodigo;

        [XmlElement("registroDetalle")]
        public string registroDetalle;

        [XmlElement("registroGuia")]
        public string registroGuia;

        [XmlElement("registroEmpGuia")]
        public string registroEmpGuia;

        [XmlElement("anexoExtRegistro")]
        public string anexoExtRegistro;

        [XmlElement("logDigitador")]
        public string logDigitador;

        [XmlElement("expedienteCodigo")]
        public string expedienteCodigo;

        [XmlElement("medioCodigo")]
        public string medioCodigo;

        [XmlElement("serieCodigo")]
        public string serieCodigo;

        [XmlElement("regPesoEnvio")]
        public string regPesoEnvio;

        [XmlElement("regValorEnvio")]
        public string regValorEnvio;

        [XmlElement("registroTipo")]
        public string registroTipo;

        [XmlElement("wFAccionCodigo")]
        public string wFAccionCodigo;

        [XmlElement("wFMovimientoFechaEst")]
        public DateTime wFMovimientoFechaEst;

        [XmlElement("wFMovimientoFechaFin")]
        public DateTime wFMovimientoFechaFin;

        [XmlElement("wFMovimientoTipo")]
        public int wFMovimientoTipo;

        [XmlElement("wFMovimientoNotas")]
        public string wFMovimientoNotas;

        [XmlElement("wFMovimientoMultitarea")]
        public string wFMovimientoMultitarea;

        [XmlElement("userId")]
        public string userId;
    }
//}

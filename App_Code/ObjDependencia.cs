using System;
using System.Text;
using System.Xml.Serialization;

/// <summary>
/// Descripción breve de ObjDependencia
/// </summary>
[Serializable]
public class ObjDependencia
{	
	[XmlElement("dependenciaCodigo")]
    private string dependenciaCodigo;        

    [XmlElement("dependenciaNombre")]
    private string dependenciaNombre;

    public string DependenciaCodigo
    {
        get { return dependenciaCodigo; }
        set { dependenciaCodigo = value; }
    }

    public string DependenciaNombre
    {
        get { return dependenciaNombre; }
        set { dependenciaNombre = value; }
    }	
}

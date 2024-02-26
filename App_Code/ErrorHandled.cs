using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Descripción breve de ErrorHandled
/// </summary>
public class ErrorHandled
{
    protected int HResult { get; set; }

	public ErrorHandled()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static string FindError(Exception mError)
    {
        string mErrorDescription;

        if (mError is System.Data.Common.DbException)
        {
            mErrorDescription = " Error de base de datos. "; //+ mError.Message;
            if (mError.Message.Contains("Instrucción DELETE en conflicto con la restricción"))
            {
                mErrorDescription += "No se puede Eliminar debido a que tiene Informacion Asociada en la Base de Datos. ";
                //mErrorDescription += mError.Message;
            }
            else if (mError.Message.Contains("Infracción de la restricción PRIMARY KEY"))
            {
                mErrorDescription += "No se puede Insertar debido a que Ya Existe en la Base de Datos. ";
                //mErrorDescription += mError.Message;
            }
            else if (mError.Message.Contains("Instrucción UPDATE en conflicto con la restricción"))
            {
                mErrorDescription += "No se puede Actualizar debido a que tiene Informacion Asociada en la Base de Datos. ";
                //mErrorDescription += mError.Message;
            }
            else if (mError.Message.Contains("Instrucción INSERT en conflicto con la restricción FOREIGN KEY SAME TABLE"))
            {
                mErrorDescription += "No se puede Insertar debido a que El Codigo del Padre Asociado No existe en la Base de Datos. ";
                //mErrorDescription += mError.Message;
            }
            else if (mError.Message.Contains("Instrucción INSERT en conflicto con la restricción FOREIGN KEY"))
            {
                mErrorDescription += "No se puede Insertar debido a que El Codigo del Parametro Asociado No existe en la Base de Datos. ";
                if (mError.Message.Contains("dbo.Ciudad"))
                {
                    mErrorDescription += "Parametro Ciudad. ";
                    //mErrorDescription += mError.Message;
                }
                
                //mErrorDescription += mError.Message;
            }
            else if (mError.Message.Contains("No se puede insertar el valor NULL en la columna"))
            {
                mErrorDescription += "No se puede Insertar debido a que Falta un Campo Necesario. ";
                if (mError.Message.Contains("Dependencia"))
                {
                    mErrorDescription += "Campo Dependencia. ";
                    //mErrorDescription += mError.Message;
                }
            }
            else
            {
                mErrorDescription += mError.Message;
            }
        }

        else if (mError is NoNullAllowedException)
                mErrorDescription = " Falta uno o mas campos requeridos. ";
        else if (mError is ArgumentException)
                {
                    string mparamName = ((ArgumentException)mError).ParamName.ToString();
                    mErrorDescription = string.Concat(" El valor del parametro ", mparamName, " es ilegal. ");
                }
        else if (mError is ApplicationException)
                {
                    mErrorDescription = " Error de Aplicacion. ";

                    if (mError.Message.Contains("Error en la capa BLL"))
                    {
                        
                        if (mError.Message.Contains("Una o varias filas contienen valores que infringen las restricciones NON-NULL, UNIQUE o FOREIGN-KEY"))
                        {
                            mErrorDescription += " Uno o Varios Parametros no Existen o no Fueron Validados en las Listas ";

                        }
                        if (mError.Message.Contains("No se puede insertar una clave duplicada"))
                        {
                            mErrorDescription += " No se puede Insertar debido a que Ya Existe en la Base de Datos. ";
                        }

                    }
                }         
        else
                {
                    mErrorDescription = " Error desconocido. ";
                    if (mError != null)
                    {
                        if (mError.Message.Contains("Infracción de la restricción PRIMARY KEY"))
                        {
                            mErrorDescription += "No se puede Insertar debido a que Ya Existe. ";
                            //mErrorDescription += mError.Message;
                        }
                        else if (mError.Message.Contains("Índice fuera de los límites de la matriz."))
                        {
                            mErrorDescription += "El Documento Buscado No Existe, Verifique el Numero por Favor. ";
                        }
                             
                    }
                }

        return mErrorDescription;

    }

}

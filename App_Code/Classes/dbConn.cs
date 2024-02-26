using System;
using System.Data;
using System.Collections;
//using DotNetNuke.Common.Utilities.Null
using System.Reflection;
using Microsoft.CSharp;
using System.Data.Common;
//using IBM.Data.DB2.iSeries;


namespace AlfaNet.DataBase
{
    public class dbConn
    {
          private String connStr = null;
          private String connType = null;
          private IDbConnection objConn = null;
          private IDbTransaction objTran = null;
          private ArrayList objParm = new ArrayList();

          //        Constructor. Se crea la conexion
        public void New(String connString, String ConnTipo)
        {
            connStr = connString;
            connType = ConnTipo;
            objConn = dbHelper.getConexion(connStr, connType);
            
        }

    }

}
//Namespace Cooproconas.Database

   // Public Class dbConn
//       Implements IDisposable

//        Private connStr As String = Nothing
//        Private connType As String = Nothing
//        Private objConn As IDbConnection = Nothing
//        Private objTran As IDbTransaction = Nothing
//        Private objParm As New ArrayList

//        ' Constructor. Se crea la conexion
//        Public Sub New(ByVal connString As String, ByVal ConnTipo As String)
//            connStr = connString
//            connType = ConnTipo
//            objConn = dbHelper.getConexion(connStr, connType)
//        End Sub

//        ' Ejecutar una sentencia SELECT
//        Public Function ExecuteReader(ByVal SQLText As String) As IDataReader
//            Return dbHelper.ExecuteReader(objConn, objTran, SQLText, objParm)
//        End Function

//        'Executar sentencias UPDATE, DELETE, INSERT
//        Public Function ExecuteNonQuery(ByVal SQLText As String) As Integer
//            Return dbHelper.ExecuteNonQuery(objConn, objTran, SQLText, objParm)
//        End Function

//        ' Devuelve un solo valor
//        Public Function ExecuteScalar(ByVal SQLText As String) As Object
//            Return dbHelper.ExecuteScalar(objConn, objTran, SQLText, objParm)
//        End Function

//        ' Limpiar los parametros
//        Public Sub ClearParameter()
//            objParm.Clear()
//        End Sub

//        'Agregar parametros a la lista de parametros
//        Public Function AddParameter(ByVal Name As String, ByVal Value As Object, Optional ByVal Clear As Boolean = False) As Integer
//            If Clear Then
//                ClearParameter()
//            End If

//            Select Case connType
//                Case "DB2"
//                    'Dim Param As New iDB2Parameter(Name, Value)
//                    'If Param.iDB2DbType = iDB2DbType.iDB2TimeStamp Then
//                    '    If CType(Param.Value, Date) = CType(Param.Value, Date).Date Then
//                    '        Param.iDB2DbType = iDB2DbType.iDB2Date
//                    '    End If
//                    'End If
//                    'objParm.Add(Param)

//                Case "SQL"
//                    objParm.Add(New SqlParameter(Name, Value))

//            End Select

//            Return objParm.Count
//        End Function

//        'Iniciar transacción
//        Public Sub StartTransaction()
//            objTran = objConn.BeginTransaction
//        End Sub

//        'Guardar cambios
//        Public Sub Commit()
//            objTran.Commit()
//            objTran = Nothing
//        End Sub

//        'Deshacer los cambios
//        Public Sub RollBack()
//            objTran.Rollback()
//            objTran = Nothing
//        End Sub

//        ' Inserta un registro en la tabla de acuerdo a los parametros
//        Public Sub InsertarRegistro(ByVal objDatos As Object, ByVal TABLA As String, _
//                   ByVal TIPO As System.Type)

//            Dim i As Integer

//            Dim cmdSQL As String
//            Dim cmdFLD As String
//            Dim cmdVAL As String
//            Dim FldRead As String = ""

//            Dim CAMPO As PropertyInfo
//            Dim VALOR As Object
//            Dim alCAMPOS() As PropertyInfo

//            ' Lista de propiedades de la tabla 
//            alCAMPOS = TIPO.GetProperties()

//            CAMPO = TIPO.GetProperty("FieldsRead")
//            If Not CAMPO Is Nothing Then
//                FldRead = CAMPO.GetValue(objDatos, Nothing)
//            End If

//            cmdSQL = "INSERT INTO " + TABLA
//            cmdFLD = ""
//            cmdVAL = ""

//            ClearParameter()

//            For i = 0 To alCAMPOS.Length - 1
//                ' Campo que se analiza
//                CAMPO = alCAMPOS(i)

//                ' Si tiene valor, se agrega al insert
//                If CAMPO.CanWrite And _
//                   (FldRead.IndexOf(CAMPO.Name) = -1) Then
//                    VALOR = CAMPO.GetValue(objDatos, Nothing)
//                    If Not IsNull(VALOR) Then
//                        cmdFLD = cmdFLD + ", " + CAMPO.Name
//                        cmdVAL = cmdVAL + ", @" + CAMPO.Name

//                        AddParameter(CAMPO.Name, VALOR)
//                    End If
//                End If
//            Next i

//            cmdFLD = " (" + Mid(cmdFLD, 3) + ") "
//            cmdVAL = " VALUES (" + Mid(cmdVAL, 3) + ") "
//            cmdSQL = cmdSQL + cmdFLD + cmdVAL

//            ExecuteNonQuery(cmdSQL)

//        End Sub

//        ' Actualiza una tabla de acuerdo a los objetos recibidos
//        Public Sub ActualizarRegistro(ByVal objDatos As Object, ByVal objDatosI As Object, ByVal TABLA As String, _
//                   ByVal TIPO As System.Type, ByVal CLAVES() As String)

//            Dim i As Integer

//            Dim cmdSQL As String
//            Dim cmdFLD As String
//            Dim FldRead As String = ""

//            Dim CAMPO As PropertyInfo
//            Dim VALOR As Object

//            Dim CAMPOI As PropertyInfo
//            Dim VALORI As Object

//            Dim alCAMPOS() As PropertyInfo

//            ' Lista de propiedades de la tabla 
//            alCAMPOS = TIPO.GetProperties()

//            cmdSQL = "UPDATE " + TABLA + " SET "
//            cmdFLD = ""

//            ClearParameter()

//            CAMPO = TIPO.GetProperty("FieldsRead")
//            If Not CAMPO Is Nothing Then
//                FldRead = CAMPO.GetValue(objDatos, Nothing)
//            End If

//            For i = 0 To alCAMPOS.Length - 1
//                ' Campo que se analiza
//                CAMPO = alCAMPOS(i)
//                VALOR = CAMPO.GetValue(objDatos, Nothing)

//                CAMPOI = alCAMPOS(i)
//                VALORI = CAMPOI.GetValue(objDatosI, Nothing)

//                ' Si son diferentes los valores
//                If VALOR <> VALORI Then
//                    If CAMPO.CanWrite And _
//                       FldRead.IndexOf(CAMPO.Name) = -1 Then
//                        If VALOR Is Nothing Then
//                            cmdFLD = cmdFLD + ", " + CAMPO.Name + " = NULL"
//                        Else
//                            cmdFLD = cmdFLD + ", " + CAMPO.Name + " = @" + CAMPO.Name
//                            AddParameter(CAMPO.Name, VALOR)
//                        End If
//                    End If
//                End If
//            Next i

//            ' Si tiene campos para actualizar
//            If cmdFLD <> "" Then

//                cmdFLD = Mid(cmdFLD, 3)
//                cmdSQL = cmdSQL + cmdFLD + " WHERE "

//                ' campos clave de la tabla
//                For i = 0 To CLAVES.Length - 1
//                    If i > 0 Then
//                        cmdSQL = cmdSQL + " AND "
//                    End If
//                    cmdSQL = cmdSQL + CLAVES(i) + " = @" + CLAVES(i) + " "
//                    CAMPO = TIPO.GetProperty(CLAVES(i))
//                    VALOR = CAMPO.GetValue(objDatosI, Nothing)
//                    AddParameter(CLAVES(i), VALOR)
//                Next i

//                If ExecuteNonQuery(cmdSQL) = 0 Then
//                    Throw New Exception("No se encontro registro para la actualización")
//                End If
//            End If

//        End Sub

//        Private disposedValue As Boolean = False        ' To detect redundant calls

//        ' IDisposable
//        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
//            If Not Me.disposedValue Then
//                If disposing Then
//                    ' TODO: free unmanaged resources when explicitly called
//                End If

//                objConn.Close()
//                objConn.Dispose()

//            End If
//            Me.disposedValue = True
//        End Sub

//#Region " IDisposable Support "
//        ' This code added by Visual Basic to correctly implement the disposable pattern.
//        Public Sub Dispose() Implements IDisposable.Dispose
//            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
//            Dispose(True)
//            GC.SuppressFinalize(Me)
//        End Sub
//#End Region

  //  End Class



//End Namespace
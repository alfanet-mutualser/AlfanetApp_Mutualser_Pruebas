using System.Data.Common;
//'Imports IBM.Data.DB2.iSeries
using System.Data.SqlClient;
//using System.Data.OracleClient;
using System.Reflection;
using System;
using System.Data;
using System.Collections;
using Microsoft.CSharp;


//using IBM.Data.DB2.iSeries;

namespace AlfaNet.DataBase
{
    public sealed class dbHelper
    {
        // Quien genero la conexión, la clase o llego por parametro
        public enum ConnOwner
        {
                        Internal,
                        External
        }
        //       ' Genera una conexion
        public static IDbConnection getConexion(String connString, String connType)
        {
            IDbConnection objConn = null;

            switch (connType)
            {
                case "DB2":
                   // objConn = new iDB2Connection(connString);
                break;
                case "SQL":
                    objConn = new SqlConnection(connString);
                    break;
                //case "Oracle":
                    //objConn = new OracleConnection(connString);
                    
                //case 4:
                //    //...
               // break;
                default:
                    throw new Exception("El tipo de base de datos: " + connType + " no esta implementado");
                    
                break;
            }                    

            objConn.Open();

            return objConn;
            
        }

        private static void iDB2Connection(string connString)
        {
            throw new Exception("The method or operation is not implemented.");
        }
              

    }

}

//Namespace Cooproconas.Database

//    Public NotInheritable Class dbHelper

//        ' Quien genero la conexión, la clase o llego por parametro
//        Public Enum ConnOwner
//            Internal
//            External
//        End Enum

//        ' Genera una conexion
//        Public Shared Function getConexion(ByVal connString As String, ByVal connType As String) As IDbConnection
//            Dim objConn As IDbConnection = Nothing

//            Select Case connType
//                Case "DB2"
//                    'objConn = New iDB2Connection(connString)

//                Case "SQL"
//                    objConn = New SqlConnection(connString)

//                Case Else
//                    Throw New Exception("El tipo de base de datos: " + connType + " no esta implementado")
//            End Select

//            objConn.Open()

//            Return objConn
//        End Function

//        Public Shared Function CreateParameter(ByVal Name As String, ByVal Value As Object, ByVal connType As String) As IDataParameter
//            Select Case connType
//                Case "DB2"
//                    'Dim Param As New iDB2Parameter(Name, Value)
//                    'If Param.iDB2DbType = iDB2DbType.iDB2TimeStamp Then
//                    '    If CType(Param.Value, Date) = CType(Param.Value, Date).Date Then
//                    '        Param.iDB2DbType = iDB2DbType.iDB2Date
//                    '    End If
//                    'End If
//                    'Return ParamB

//                Case "SQL"
//                    Return New SqlParameter(Name, Value)

//                Case Else
//                    Throw New Exception("El tipo de base de datos: " + connType + " no esta implementado")
//            End Select
//        End Function

//        Public Shared Function ExecuteDataTable(ByVal ConnString As String, ByVal sqlText As String, ByVal ConnType As String) As DataTable
//            Dim objConn As IDbConnection = Nothing
//            Try
//                objConn = getConexion(ConnString, ConnType)
//                Dim objDataSet As New DataSet

//                Select Case ConnType
//                    Case "DB2"
//                        'Dim objData As iDB2DataAdapter
//                        'objData = New iDB2DataAdapter(sqlText, objConn)
//                        'objData.Fill(objDataSet)

//                    Case "SQL"
//                        Dim objData As SqlDataAdapter
//                        objData = New SqlDataAdapter(sqlText, CType(objConn, SqlConnection))
//                        objData.Fill(objDataSet)
//                End Select

//                Return objDataSet.Tables(0)
//            Catch ex As Exception
//                Throw ex

//            Finally
//                If Not objConn Is Nothing Then
//                    objConn.Close()
//                End If
//            End Try
//        End Function

//        Public Shared Function ExecuteDataSet(ByVal ConnString As String, ByVal sqlText As String, ByVal ConnType As String) As DataSet
//            Dim objConn As IDbConnection = Nothing
//            Try
//                objConn = getConexion(ConnString, ConnType)
//                Dim objDataSet As New DataSet

//                Select Case ConnType
//                    Case "DB2"
//                        'Dim objData As iDB2DataAdapter
//                        'objData = New iDB2DataAdapter(sqlText, objConn)
//                        'objData.Fill(objDataSet)

//                    Case "SQL"
//                        Dim objData As SqlDataAdapter
//                        objData = New SqlDataAdapter(sqlText, CType(objConn, SqlConnection))
//                        objData.Fill(objDataSet)
//                End Select

//                Return objDataSet
//            Catch ex As Exception
//                Throw ex
//            Finally
//                If Not objConn Is Nothing Then
//                    objConn.Close()
//                End If
//            End Try
//        End Function

//        ' Ejecuta un reader enviando la cadena de conexion y el comando
//        Public Shared Function ExecuteReader(ByVal connString As String, ByVal sqlText As String, Optional ByVal connType As String = "DB2") As IDataReader
//            ' Conexión a la base de datos
//            Dim objConn As IDbConnection = Nothing
//            Try
//                objConn = getConexion(ConnString, connType)
//                Return ExecuteReader(objConn, Nothing, sqlText, Nothing, ConnOwner.Internal)
//            Catch ex As Exception
//                If Not objConn Is Nothing Then
//                    objConn.Close()
//                End If
//                Throw ex
//            End Try
//        End Function

//        ' Ejecuta un reader enviando la cadena de conexion y el comando
//        Public Shared Function ExecuteReader(ByVal connString As String, ByVal sqlText As String, ByVal dbParms As ArrayList, ByVal connType As String) As IDataReader
//            ' Conexión a la base de datos
//            Dim objConn As IDbConnection = Nothing
//            Try
//                objConn = getConexion(connString, connType)
//                Return ExecuteReader(objConn, Nothing, sqlText, dbParms, ConnOwner.Internal)
//            Catch ex As Exception
//                If Not objConn Is Nothing Then
//                    objConn.Close()
//                End If
//                Throw ex
//            End Try
//        End Function

//        ' Ejecuta un Reader enviando la conexion y los demas parametros
//        Public Shared Function ExecuteReader(ByVal objConn As IDbConnection, ByVal dbTran As IDbTransaction, ByVal sqlText As String, ByVal dbParms As ArrayList, Optional ByVal dbConnOwner As ConnOwner = ConnOwner.External) As IDataReader

//            Dim dbComm As IDbCommand
//            dbComm = objConn.CreateCommand

//            ' Asigna la conexion y asigna la transacción
//            dbComm.Connection = objConn
//            If Not dbTran Is Nothing Then
//                dbComm.Transaction = dbTran
//            End If

//            ' Comando a ejecutar
//            dbComm.CommandText = sqlText

//            ' Parametros para la consulta
//            If Not dbParms Is Nothing Then
//                Dim Parameter As IDataParameter
//                For Each Parameter In dbParms
//                    dbComm.Parameters.Add(Parameter)
//                Next
//            End If

//            ' Si se debe mantener la conexion o cerrarla (Generada Internamente)
//            If dbConnOwner = ConnOwner.External Then
//                Return dbComm.ExecuteReader()
//            Else
//                Return dbComm.ExecuteReader(CommandBehavior.CloseConnection)
//            End If
//        End Function

//        ' Ejecuta un Scalar enviando la cadena de conexion y el comando
//        Public Shared Function ExecuteScalar(ByVal connString As String, ByVal sqlText As String, ByVal connType As String) As Object
//            ' Conexión a la base de datos
//            Dim objConn As IDbConnection = Nothing
//            Try
//                objConn = getConexion(connString, connType)
//                Return ExecuteScalar(objConn, Nothing, sqlText, Nothing, ConnOwner.Internal)
//            Catch ex As Exception
//                If Not objConn Is Nothing Then
//                    objConn.Close()
//                End If
//                Throw ex
//            End Try
//        End Function

//        ' Ejecuta un Scalar enviando la cadena de conexion y el comando
//        Public Shared Function ExecuteScalar(ByVal connString As String, ByVal sqlText As String, ByVal dbParms As ArrayList, ByVal connType As String) As Object
//            ' Conexión a la base de datos
//            Dim objConn As IDbConnection = Nothing
//            Try
//                objConn = getConexion(connString, connType)
//                Return ExecuteScalar(objConn, Nothing, sqlText, dbParms, ConnOwner.Internal)
//            Catch ex As Exception
//                If Not objConn Is Nothing Then
//                    objConn.Close()
//                End If
//                Throw ex
//            End Try
//        End Function

//        ' Ejecuta un Scalar enviando la conexion y los demas parametros
//        Public Shared Function ExecuteScalar(ByVal objConn As IDbConnection, ByVal dbTran As IDbTransaction, ByVal sqlText As String, ByVal dbParms As ArrayList, Optional ByVal dbConnOwner As ConnOwner = ConnOwner.External) As Object

//            Dim dbComm As IDbCommand
//            dbComm = objConn.CreateCommand

//            ' Asigna la conexion y asigna la transacción
//            dbComm.Connection = objConn
//            If Not dbTran Is Nothing Then
//                dbComm.Transaction = dbTran
//            End If

//            dbComm.CommandText = sqlText

//            ' Parametros para la consulta
//            If Not dbParms Is Nothing Then
//                Dim Parameter As IDataParameter
//                For Each Parameter In dbParms
//                    dbComm.Parameters.Add(Parameter)
//                Next
//            End If

//            ' Si se debe mantener la conexion o cerrarla (Generada Internamente)
//            Dim RetVal As Object = dbComm.ExecuteScalar()
//            If dbConnOwner = ConnOwner.Internal Then
//                objConn.Close()
//            End If

//            Return RetVal
//        End Function

//        ' Ejecuta un not reader enviando la cadena de conexion y el comando
//        Public Shared Function ExecuteNonQuery(ByVal connString As String, ByVal sqlText As String, ByVal connType As String) As Integer
//            ' Conexión a la base de datos
//            Dim objConn As IDbConnection = Nothing
//            Try
//                objConn = getConexion(connString, connType)
//                Return ExecuteNonQuery(objConn, Nothing, sqlText, Nothing, ConnOwner.Internal)
//            Catch ex As Exception
//                If Not objConn Is Nothing Then
//                    objConn.Close()
//                End If
//                Throw ex
//            End Try
//        End Function

//        ' Ejecuta un not Reader enviando la conexion y los demas parametros
//        Public Shared Function ExecuteNonQuery(ByVal objConn As IDbConnection, ByVal dbTran As IDbTransaction, ByVal sqlText As String, ByVal dbParms As ArrayList, Optional ByVal dbConnOwner As ConnOwner = ConnOwner.External) As Integer

//            Dim dbComm As IDbCommand
//            dbComm = objConn.CreateCommand

//            ' Asigna la conexion y asigna la transacción
//            dbComm.Connection = objConn
//            If Not dbTran Is Nothing Then
//                dbComm.Transaction = dbTran
//            End If

//            ' Comando a ejecutar
//            dbComm.CommandText = sqlText

//            ' Parametros para la consulta
//            If Not dbParms Is Nothing Then
//                Dim Parameter As IDataParameter
//                For Each Parameter In dbParms
//                    dbComm.Parameters.Add(Parameter)
//                Next
//            End If

//            ' Si se debe mantener la conexion o cerrarla (Generada Internamente)
//            Dim RetVal As Integer = dbComm.ExecuteNonQuery()
//            If dbConnOwner = ConnOwner.Internal Then
//                objConn.Close()
//            End If

//            Return RetVal
//        End Function

//    End Class

//End Namespace
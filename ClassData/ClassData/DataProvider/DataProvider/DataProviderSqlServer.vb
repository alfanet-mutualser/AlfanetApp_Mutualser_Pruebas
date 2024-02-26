Imports System.Data


Public Class DataProviderSqlServer
    Inherits gDatosSql
    Private Shared instance As DataProviderSqlServer
    Sub New()
    End Sub
    Sub New(ByVal CadenaConexion As String)
        Me.New()
        Me.CadenaConexion = CadenaConexion
    End Sub
    Sub New(ByVal Servidor As String, ByVal Base As String)
        Me.New()
        Me.Base = Base
        Me.Servidor = Servidor
    End Sub
    Public Shared Function Instances() As DataProviderSqlServer

        ' initialize if not already done
        If Instance Is Nothing Then
            Dim Config As System.Configuration.ConfigurationSettings
            Dim cnn As String = Config.AppSettings("connectionString")
            instance = New DataProviderSqlServer(cnn)
        End If
        ' return the initialized instance of the Singleton Class
        Return instance
    End Function 'Instance

    Public Overrides Property CadenaConexion() As String
        Get
            If Len(MyBase.mCadenaConexion) = 0 Then
                If Len(Me.Servidor) <> 0 And Len(Me.Base) <> 0 Then
                    Dim sCadena As New System.Text.StringBuilder( _
                    "data source=<SERVIDOR>;" & _
                    "initial catalog=<BASE>;password='';" & _
                    "persist security info=True;" & _
                    "user id=sa;packet size=4096")
                    sCadena.Replace("<SERVIDOR>", Me.Servidor)
                    sCadena.Replace("<BASE>", Me.Base)
                    mCadenaConexion = sCadena.ToString
                Else
                    Throw New _
                       System.Exception( _
                       "No se puede establecer la cadena de conexión")

                End If
            End If
            Return mCadenaConexion

        End Get
        Set(ByVal Value As String)
            mCadenaConexion = Value
        End Set
    End Property

    Protected Overrides Sub CargarParametros(ByVal Comando As System.Data.IDbCommand, ByVal Args() As Object)
        Dim i As Integer
        With Comando
            For i = 0 To Args.GetUpperBound(0)
                Try
                    CType(.Parameters(i), Data.SqlClient.SqlParameter).Value = Args(i)
                Catch Qex As Exception
                    Throw (Qex)
                End Try
            Next
        End With
    End Sub

    Shared mColComandos As New System.Collections.Hashtable

    Protected Overrides Function Comando( _
      ByVal ProcedimientoAlmacenado As String) _
      As System.Data.IDbCommand
        Dim mComando As Data.SqlClient.SqlCommand
        If mColComandos.Contains(ProcedimientoAlmacenado) Then
            mComando = _
               CType(mColComandos.Item(ProcedimientoAlmacenado) _
            , Data.SqlClient.SqlCommand)
        Else
            Dim oConexion2 As New Data.SqlClient.SqlConnection( _
               CadenaConexion)
            oConexion2.Open()
            mComando = New _
               Data.SqlClient.SqlCommand( _
               ProcedimientoAlmacenado, oConexion2)
            Dim mConstructor As New _
               Data.SqlClient.SqlCommandBuilder
            mComando.CommandType = CommandType.StoredProcedure
            mConstructor.DeriveParameters(mComando)
            oConexion2.Close()
            mColComandos.Add(ProcedimientoAlmacenado, mComando)
        End If
        With mComando
            .Connection = Me.Conexion
            .Transaction = MyBase.mTransaccion
        End With
        Return mComando
    End Function

    Protected Overrides Function CrearConexion( _
      ByVal Cadena As String) As System.Data.IDbConnection
        Return New Data.SqlClient.SqlConnection(Cadena)
    End Function

    Protected Overrides Function CrearDataAdapter( _
         ByVal ProcedimientoAlmacenado As String, _
         ByVal ParamArray Args() As Object) As _
         System.Data.IDataAdapter
        Dim mCom As Data.SqlClient.SqlCommand = _
           Comando(ProcedimientoAlmacenado)
        ' Si se han recibido Argumentos, 
        'se procede a asignar los valores correspondientes
        If Not Args Is Nothing Then
            CargarParametros(mCom, Args)
        End If
        Return New Data.SqlClient.SqlDataAdapter(mCom)
    End Function
    Public Overloads Function Ejecutar( _
      ByVal ProcedimientoAlmacenado As String, _
      ByVal ParamArray Argumentos() As System.Object) _
      As Integer
        Dim mCom As Data.SqlClient.SqlCommand = _
           Comando(ProcedimientoAlmacenado)
        Dim Resp As Integer
        CargarParametros(mCom, Argumentos)
        Resp = mCom.ExecuteNonQuery
        Dim oPar As Data.SqlClient.SqlParameter
        Dim i As Integer
        For i = 0 To mCom.Parameters.Count - 1
            With mCom.Parameters(i)
                If .Direction = ParameterDirection.InputOutput _
                   Or .Direction = ParameterDirection.Output Then
                    Argumentos.SetValue(.Value, i)
                End If
            End With
        Next
        Return Resp
    End Function
End Class



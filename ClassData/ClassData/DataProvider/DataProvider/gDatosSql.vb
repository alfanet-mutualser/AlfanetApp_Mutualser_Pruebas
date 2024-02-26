Imports System.Data
Public MustInherit Class gDatosSql
#Region "Declaración de Variables"
    Protected mServidor As String
    Protected mBase As String
    Protected mConexion As System.Data.IDbConnection
    Protected mCadenaConexion As String

#End Region
#Region "Propiedades"
    'Nombre del Servidor de Base de Datos
    Public Property Servidor() As String
        Get
            Return mServidor
        End Get
        Set(ByVal Value As String)
            mServidor = Value
        End Set
    End Property
    'Nombre de la base de Datos
    Public Property Base() As String
        Get
            Return mBase
        End Get
        Set(ByVal Value As String)
            mBase = Value
        End Set
    End Property
    ' Definición de la cadena de Conexión
    Public MustOverride Property CadenaConexion() As String
#End Region
#Region "Privadas"
    ' Devuelve un objeto Conexión
    Protected ReadOnly Property Conexion() As System.Data.IDbConnection
        Get
            If mConexion Is Nothing Then ' si no existe 
                ' llama al método de la clase que lo hereda
                mConexion = CrearConexion(Me.CadenaConexion)
            End If
            With mConexion
                ' Controla que la conexión esté abierta
                If .State <> ConnectionState.Open Then .Open()
            End With
            Return mConexion
        End Get
    End Property
#End Region
#Region "Lecturas"
    Public Overloads Function TraerDataSet( _
       ByVal ProcedimientoAlmacenado As String) _
       As System.Data.DataSet
        'Se crea el Dataset que luego será llenado y retornado
        Dim mDataSet As New System.Data.DataSet
        CrearDataAdapter(ProcedimientoAlmacenado).Fill(mDataSet)
        Return mDataSet
    End Function
    Public Overloads Function TraerDataSet( _
       ByVal ProcedimientoAlmacenado As String, _
       ByVal ParamArray Argumentos() As System.Object) _
       As System.Data.DataSet
        Dim mDataSet As New System.Data.DataSet
        CrearDataAdapter( _
           ProcedimientoAlmacenado, _
           Argumentos).Fill(mDataSet)
        Return mDataSet
    End Function
    Public Overloads Function TraerDataTable( _
       ByVal ProcedimientoAlmacenado As String) _
       As System.Data.DataTable
        Return TraerDataSet( _
        ProcedimientoAlmacenado).Tables(0).Copy
    End Function
    Public Overloads Function TraerDataTable( _
       ByVal ProcedimientoAlmacenado As String, _
       ByVal ParamArray Argumentos() As System.Object) _
       As System.Data.DataTable
        Return TraerDataSet( _
           ProcedimientoAlmacenado, _
           Argumentos).Tables(0).Copy
    End Function
    Public Overloads Function TraerValor( _
       ByVal ProcedimientoAlmacenado As String) _
       As System.Object
        With Comando(ProcedimientoAlmacenado)
            .ExecuteNonQuery()
            Dim oPar As System.Data.IDataParameter
            For Each oPar In .Parameters
                If oPar.Direction = _
                   ParameterDirection.InputOutput Or _
                   oPar.Direction = _
                   ParameterDirection.Output Then
                    Return oPar.Value
                    Exit For
                End If
            Next
        End With
    End Function
    Public Overloads Function TraerValor( _
       ByVal ProcedimientoAlmacenado As String, _
       ByVal ParamArray Argumentos() As System.Object) _
     As System.Object
        Dim mCom As System.Data.IDbCommand = _
           Comando(ProcedimientoAlmacenado)
        CargarParametros(mCom, Argumentos)
        With mCom
            .ExecuteNonQuery()
            Dim oPar As System.Data.IDataParameter
            For Each oPar In .Parameters
                If oPar.Direction = _
                   ParameterDirection.InputOutput Or _
                   oPar.Direction = _
                   ParameterDirection.Output Then
                    Return oPar.Value
                    Exit For
                End If
            Next
        End With
    End Function
#End Region
#Region "Acciones"
    Protected MustOverride Function CrearConexion( _
             ByVal Cadena As String) _
             As System.Data.IDbConnection
    Protected MustOverride Function Comando( _
             ByVal ProcedimientoAlmacenado As String) _
             As System.Data.IDbCommand
    Protected MustOverride Function CrearDataAdapter( _
          ByVal ProcedimientoAlmacenado As String, _
          ByVal ParamArray Args() As System.Object) _
          As System.Data.IDataAdapter
    Protected MustOverride Sub CargarParametros( _
       ByVal Comando As System.Data.IDbCommand, _
       ByVal Args() As System.Object)
    Public Overloads Function Ejecutar( _
       ByVal ProcedimientoAlmacenado As String) _
       As Integer
        Return Comando( _
           ProcedimientoAlmacenado).ExecuteNonQuery
    End Function
    Public Overloads Function Ejecutar( _
          ByVal ProcedimientoAlmacenado As String, _
          ByVal ParamArray Argumentos() As System.Object) _
          As Integer
        Dim resp As Integer
        resp = 0
        Return resp
    End Function
#End Region
#Region "Transacciones"
    Protected mTransaccion As System.Data.IDbTransaction
    Private EnTransaccion As Boolean
    Public Sub IniciarTransaccion()
        mTransaccion = Me.Conexion.BeginTransaction
        EnTransaccion = True
    End Sub
    Public Sub TerminarTransaccion()
        Try
            mTransaccion.Commit()
        Catch ex As System.Exception
            Throw ex
        Finally
            EnTransaccion = False
            mTransaccion = Nothing
        End Try

    End Sub
    Public Sub AbortarTransaccion()
        Try
            mTransaccion.Rollback()
        Catch Ex As System.Exception
            Throw Ex
        Finally
            mTransaccion = Nothing
            EnTransaccion = False
        End Try
    End Sub

#End Region
End Class



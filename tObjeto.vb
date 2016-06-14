Public Class tObjeto
    Public Sub New(ByVal tipo As String, ByVal tiempo As Integer, Optional ByVal enUso As Boolean = False)

        _tipo = tipo
        _enUso = enUso
        _tiempo = tiempo
        'Try
        '    Select Case tipo
        '        Case "datos"
        '            _tiempo = 1000
        '        Case Else
        '            _tiempo = 0
        '    End Select
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.OkOnly, String.Format("Class: {0}", Me.GetType().Name))
        'End Try
    End Sub
    Private _tiempo As Integer
    Public Property tiempo() As Integer
        Get
            Return _tiempo
        End Get
        Set(ByVal value As Integer)
            _tiempo = value
        End Set
    End Property
    Private _tipo As String
    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property
    Private _enUso As Boolean
    Public Property enUso() As Boolean
        Get
            Return _enUso
        End Get
        Set(ByVal value As Boolean)
            _enUso = value
        End Set
    End Property
End Class
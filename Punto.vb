Public Class Punto
    Public Sub New(ByVal x As Single, ByVal y As Single, ByVal tipo As String, ByVal id As String, Optional ByVal mouseOver As Boolean = False)
        _puntoLocalizacion = New PointF(x, y)
        _tipo = tipo
        _id = id
        _mouseOver = mouseOver
    End Sub
    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
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
    Private _puntoLocalizacion As PointF
    Public Property puntoLocalizacion() As PointF
        Get
            Return _puntoLocalizacion
        End Get
        Set(ByVal value As PointF)
            _puntoLocalizacion = value
            'rObjetoUpdate()
        End Set
    End Property
    Private _mouseOver As Boolean = Nothing
    Public Property mouseOver() As Boolean
        Get
            Return _mouseOver
        End Get
        Set(ByVal value As Boolean)
            _mouseOver = value
        End Set
    End Property
    Private _eliminar As Boolean = False
    Public Property eliminar() As Boolean
        Get
            Return _eliminar
        End Get
        Set(ByVal value As Boolean)
            _eliminar = value
        End Set
    End Property
End Class

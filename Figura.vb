Public Class Figura
    Public Sub New(ByVal id As String, Optional ByVal mouseOver As Boolean = False)
        '_longitud = longitud
        '_tipo = tipo
        _lPunto = New List(Of Punto)
        _id = id
        _mouseOver = mouseOver
    End Sub
    'Private _longitud As Integer
    'Public Property longitud() As Integer
    '    Get
    '        Return _longitud
    '    End Get
    '    Set(ByVal value As Integer)
    '        _longitud = value
    '    End Set
    'End Property
    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    'Private _tipo As String
    'Public Property tipo() As String
    '    Get
    '        Return _tipo
    '    End Get
    '    Set(ByVal value As String)
    '        _tipo = value
    '    End Set
    'End Property
    Private _lPunto As List(Of Punto)
    Public Property lPunto() As List(Of Punto)
        Get
            Return _lPunto
        End Get
        Set(ByVal value As List(Of Punto))
            _lPunto = value
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
    Public Sub addPunto(ByVal punto As Punto)
        _lPunto.Add(punto)
    End Sub
End Class

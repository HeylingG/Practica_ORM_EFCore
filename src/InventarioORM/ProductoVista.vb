''' <summary>Datos de un producto preparados para mostrarse en pantalla.</summary>
Public Class ProductoVista
    Public Property Id As Integer
    Public Property Nombre As String = ""
    Public Property Categoria As String = ""
    Public Property CategoriaId As Integer
    Public Property Precio As Decimal
    Public Property Existencia As Integer
    Public Property VersionFila As Integer
End Class
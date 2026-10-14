Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

''' <summary>Entidad que representa la tabla "categorias".</summary>
<Table("categorias")>                       ' clase → tabla
Public Class Categoria

    <Key>                                   ' clave primaria
    <Column("id_categoria")>                ' propiedad → columna
    Public Property Id As Integer

    <Required, StringLength(60)>
    <Column("nombre")>
    Public Property Nombre As String = ""

    ' Propiedad de navegación: una categoría tiene muchos productos (1 → N)
    Public Property Productos As ICollection(Of Producto) = New List(Of Producto)()

End Class

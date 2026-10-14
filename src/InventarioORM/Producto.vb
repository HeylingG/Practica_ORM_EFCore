Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

''' <summary>Entidad que representa la tabla "productos".</summary>
<Table("productos")>
Public Class Producto

    <Key, Column("id_producto")>
    Public Property Id As Integer

    <Required, StringLength(100), Column("nombre")>
    Public Property Nombre As String = ""

    ' TypeName asegura DECIMAL(10,2): precios en córdobas con dos decimales
    <Column("precio", TypeName:="decimal(10,2)")>
    Public Property Precio As Decimal

    <Column("existencia")>
    Public Property Existencia As Integer

    ' Clave foránea (columna) ...
    <Column("id_categoria")>
    Public Property CategoriaId As Integer

    ' ... y su propiedad de navegación (objeto relacionado)
    <ForeignKey(NameOf(CategoriaId))>
    Public Property Categoria As Categoria

    ' Token de concurrencia: EF lo agrega al WHERE de UPDATE y DELETE
    <ConcurrencyCheck, Column("version_fila")>
    Public Property VersionFila As Integer = 1

End Class
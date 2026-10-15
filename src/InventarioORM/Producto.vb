
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

''' <summary>Entidad que representa la tabla "productos".</summary>
<Table("productos")>
Public Class Producto

    <Key, Column("id_producto")>
    Public Property Id As Integer

    <Required, StringLength(100), Column("nombre")>
    Public Property Nombre As String = ""

    <Column("precio", TypeName:="decimal(10,2)")>
    Public Property Precio As Decimal

    <Column("existencia")>
    Public Property Existencia As Integer

    <Column("id_categoria")>
    Public Property CategoriaId As Integer

    <ForeignKey(NameOf(CategoriaId))>
    Public Overridable Property Categoria As Categoria

    <ConcurrencyCheck, Column("version_fila")>
    Public Property VersionFila As Integer = 1

    <StringLength(20), Column("codigo_barras")>
    Public Property CodigoBarras As String

End Class

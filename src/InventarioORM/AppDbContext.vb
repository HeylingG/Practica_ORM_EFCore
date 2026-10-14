Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Logging

''' <summary>Sesión de trabajo con la base de datos libreria_segovia.</summary>
Public Class AppDbContext
    Inherits DbContext

    ' Cada DbSet representa una tabla
    Public Property Categorias As DbSet(Of Categoria)
    Public Property Productos As DbSet(Of Producto)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.
            UseMySql(CadenaConexion, New MariaDbServerVersion(VersionServidor)).
            LogTo(Sub(mensaje) Debug.WriteLine(mensaje), LogLevel.Information).
            EnableSensitiveDataLogging()   ' muestra valores de parámetros (solo para aprender)
    End Sub

End Class
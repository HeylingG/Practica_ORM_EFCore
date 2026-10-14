''' <summary>Configuración centralizada de acceso a MariaDB.</summary>
Module ConexionBD

    ' Ajuste usuario y contraseña según su instalación de MariaDB
    Public Const CadenaConexion As String =
        "Server=localhost;Port=3307;Database=libreria_segovia;" &
        "Uid=root;Pwd=INGDESISTEMAS;"

    ' Versión del servidor MariaDB instalado (consulte con: SELECT VERSION();)
    Public ReadOnly VersionServidor As New Version(11, 4, 0)

End Module
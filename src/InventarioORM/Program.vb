Imports System.Windows.Forms

''' <summary>Punto de entrada de la aplicación.</summary>
Module Program

    <STAThread>
    Sub Main()
        Application.SetHighDpiMode(HighDpiMode.SystemAware)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    End Sub

End Module

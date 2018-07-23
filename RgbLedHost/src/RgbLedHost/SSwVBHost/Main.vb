Imports System.Threading

Namespace SSwVBHost
    Public Module Main
        Sub Main()
            Dim app As App = New App()
            app.Run()
            Thread.Sleep(Timeout.Infinite)
        End Sub
    End Module
End Namespace

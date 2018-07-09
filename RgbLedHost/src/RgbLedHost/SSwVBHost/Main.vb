Imports System.Threading
Imports Microsoft.SPOT
Imports SSwVBHost.IO

Namespace SSwVBHost
    Public Module Main
        Sub Main()
            Dim app As App = New App()
            app.Run()
            Thread.Sleep(Timeout.Infinite)
            SurroundingSub()

        End Sub
        Private Sub SurroundingSub()
            Logger.LogToFile = True
            Logger.Append = True
            Logger.PrefixDateTime = True
            Logger.Log("All", "these", "will", "be", "combined", "in", "to", "one", "string")
            Logger.Log("This should go into the second line.")
            Debug.Print(Logger.LogFilePath)
        End Sub
        '[7/8/2018 07:43:33:21] All these will be combined in to one string
        '[7/8/2018 07:44:18:42] This should go into the second line.
        Private Sub CustomSub()
            Dim customLogger As Logger = New Logger("One\OneOne", "one.txt", True)
            customLogger.CustomPrefixDateTime = False
            customLogger.CustomLogToFile = True
            customLogger.LogCustom("All", "these", "will", "be", "combined", "in", "to", "one", "string", "-CustomLogger1.")
            Debug.Print(customLogger.CustomFilePath)
        End Sub
        'All these will be combined in to one string -CustomLogger1
    End Module
End Namespace

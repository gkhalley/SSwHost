Imports Maple
Imports Microsoft.SPOT

Namespace SSwVBHost
    Public Class RequestHandler
        Inherits RequestHandlerBase

        Public Event TurnOn As EventHandler
        Public Event TurnOff As EventHandler
        Public Event StartBlink As EventHandler
        Public Event StartPulse As EventHandler
        Public Event StartRunningColors As EventHandler

        Public Sub New()
        End Sub

        Public Sub postTurnOn()
            RaiseEvent TurnOn(Me, EventArgs.Empty)
            StatusResponse()
        End Sub

        Public Sub postTurnOff()
            RaiseEvent TurnOff(Me, EventArgs.Empty)
            StatusResponse()
        End Sub

        Public Sub postStartBlink()
            RaiseEvent StartBlink(Me, EventArgs.Empty)
            StatusResponse()
        End Sub

        Public Sub postStartPulse()
            RaiseEvent StartPulse(Me, EventArgs.Empty)
            StatusResponse()
        End Sub

        Public Sub postStartRunningColors()
            RaiseEvent StartRunningColors(Me, EventArgs.Empty)
            StatusResponse()
        End Sub

        Private Sub StatusResponse()
            Context.Response.ContentType = "application/json"
            Context.Response.StatusCode = 200
            Send()
        End Sub
    End Class
End Namespace

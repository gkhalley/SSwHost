Imports Netduino.Foundation.LEDs
Imports System
Imports System.Collections

Namespace SSwVBHost
    Public Class SSwController
        Protected _rgbPwmLed As RgbPwmLed

        Public Sub New(ByVal rgbPwmLed As RgbPwmLed)
            _rgbPwmLed = rgbPwmLed
            _rgbPwmLed.SetColor(Netduino.Foundation.Color.Red)
        End Sub

        Public Sub TurnOn()
            _rgbPwmLed.[Stop]()
            _rgbPwmLed.SetColor(GetRandomColor())
        End Sub

        Public Sub TurnOff()
            _rgbPwmLed.[Stop]()
            _rgbPwmLed.SetColor(Netduino.Foundation.Color.FromHsba(0, 0, 0))
        End Sub

        Public Sub StartBlink()
            _rgbPwmLed.[Stop]()
            _rgbPwmLed.StartBlink(GetRandomColor())
        End Sub

        Public Sub StartPulse()
            _rgbPwmLed.[Stop]()
            _rgbPwmLed.StartPulse(GetRandomColor())
        End Sub

        Public Sub StartRunningColors()
            Dim arrayColors = New ArrayList()
            Dim i As Integer = 0

            While i < 360
                Dim hue = (CDbl(i) / 360.0F)
                arrayColors.Add(Netduino.Foundation.Color.FromHsba((CDbl(i) / 360.0F), 1, 1))
                i = i + 5
            End While

            Dim intervals As Integer() = New Integer(arrayColors.Count - 1) {}

            For i = 0 To intervals.Length - 1
                intervals(i) = 100
            Next

            _rgbPwmLed.[Stop]()
            _rgbPwmLed.StartRunningColors(arrayColors, intervals)
        End Sub

        Public Sub NetworkConnected()
            _rgbPwmLed.[Stop]()
            _rgbPwmLed.SetColor(Netduino.Foundation.Color.Green)
        End Sub

        Protected Function GetRandomColor() As Netduino.Foundation.Color
            Dim random = New Random()
            Return Netduino.Foundation.Color.FromHsba(random.NextDouble(), 1, 1)
        End Function
    End Class
End Namespace

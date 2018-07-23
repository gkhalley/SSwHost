Imports Maple
Imports Microsoft.SPOT
Imports Microsoft.SPOT.Hardware
Imports Netduino.Foundation.LEDs
Imports Netduino.Foundation.Network
Imports System.Threading
Imports N = SecretLabs.NETMF.Hardware.Netduino

Namespace SSwVBHost
    Public Class App
        Shared _blinkDuration As Integer = 100
        Protected _server As MapleServer
        Protected _rgbController As SSwController

        Public Sub New()
            InitializePeripherals()
            InitializeWebServer()
        End Sub

        Protected Sub InitializePeripherals()
            Dim rgbPwmLed = New RgbPwmLed(N.PWMChannels.PWM_PIN_D11, N.PWMChannels.PWM_PIN_D10, N.PWMChannels.PWM_PIN_D9, 1.05F, 1.5F, 1.5F, False)
            _rgbController = New SSwController(rgbPwmLed)
        End Sub

        Protected Sub InitializeWebServer()
            Dim handler = New RequestHandler()
            AddHandler handler.TurnOn, AddressOf _rgbController.TurnOn

            AddHandler handler.TurnOff, AddressOf _rgbController.TurnOff

            AddHandler handler.StartBlink, AddressOf _rgbController.StartBlink

            AddHandler handler.StartPulse, AddressOf _rgbController.StartPulse

            AddHandler handler.StartRunningColors, AddressOf _rgbController.StartRunningColors

            _server = New MapleServer()
            _server.[AddHandler](handler)
        End Sub

        Public Sub Run()
            Initializer.InitializeNetwork()
            Debug.Print("InitializeNetwork()")

            While Initializer.CurrentNetworkInterface Is Nothing
            End While

            _server.Start("SSwHost", Initializer.CurrentNetworkInterface.IPAddress)
            _rgbController.NetworkConnected()
        End Sub
    End Class
End Namespace

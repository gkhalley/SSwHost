
using Maple;
using Microsoft.SPOT;
using Netduino.Foundation.LEDs;
using Netduino.Foundation.Network;
using N = SecretLabs.NETMF.Hardware.Netduino;

namespace SSwHost
{
    public class App
    {
        static int _blinkDuration = 100;
        protected MapleServer _server;
        protected SSwController _receptacleController;

        public App()
        {
            InitializePeripherals();
            InitializePowerServer();
        }

        protected void InitializePeripherals()
        {
            var rgbPwmLed = new RgbPwmLed
            (
                N.PWMChannels.PWM_PIN_D11,
                N.PWMChannels.PWM_PIN_D10,
                N.PWMChannels.PWM_PIN_D9,
                1.05f,
                1.5f,
                1.5f,
                false // Common anode or cathode?
            );

            _receptacleController = new SSwController(rgbPwmLed);
        }

        protected void InitializePowerServer()
        {
            var handler = new RequestHandler();

            handler.TurnOn += (s, e) => { _receptacleController.TurnOn1(); };
            handler.TurnOff += (s, e) => { _receptacleController.TurnOff1(); };
            handler.StartRunningColors += (s, e) => { _receptacleController.StartRunningColors(); };

            _server = new MapleServer();
            _server.AddHandler(handler);
        }

        public void Run()
        {
            Initializer.InitializeNetwork();

            Debug.Print("InitializeNetwork()");

            while (Initializer.CurrentNetworkInterface == null) { }

            _server.Start("SSwHost", Initializer.CurrentNetworkInterface.IPAddress);
            _receptacleController.NetworkConnected();
        }
    }
}
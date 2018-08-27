using Microsoft.SPOT.Hardware;
using Netduino.Foundation.LEDs;
using SecretLabs.NETMF.Hardware.Netduino;
using System;
using System.Collections;

namespace SSwHost
{
    public class SSwController
    {
        // create red-green-blue(rgb) pulse width modulator(Pwm) output to an LED
        protected RgbPwmLed _rgbPwmLed;

        // create a relay output port (a port that can be written to) and connect it to Digital Pin 2
        protected OutputPort _rec1Relay = new OutputPort(Pins.GPIO_PIN_D2, false);

        // constructor that set up the initial state of the outputs
        public SSwController(RgbPwmLed rgbPwmLed)
        {
            _rgbPwmLed = rgbPwmLed;
            _rgbPwmLed.SetColor(Netduino.Foundation.Color.Red);
            _rec1Relay.Write(false);
        }

        // Turn on the receptacle 1 relay
        public void TurnOn1()
        {
            _rec1Relay.Write(true);
        }

        // Turn off the receptacle 1 relay
        public void TurnOff1()
        {
            _rec1Relay.Write(false);
        }

        // Feedback for the network connectivity
        public void StartBlink()
        {
            _rgbPwmLed.Stop();
            _rgbPwmLed.StartBlink(GetRandomColor());
        }

        public void StartPulse()
        {
            _rgbPwmLed.Stop();
            _rgbPwmLed.StartPulse(GetRandomColor());
        }

        public void StartRunningColors()
        {
            var arrayColors = new ArrayList();
            for (int i = 0; i < 360; i = i + 5)
            {
                var hue = ((double)i / 360F);
                arrayColors.Add(Netduino.Foundation.Color.FromHsba(((double)i / 360F), 1, 1));
            }

            int[] intervals = new int[arrayColors.Count];
            for (int i = 0; i < intervals.Length; i++)
            {
                intervals[i] = 100;
            }

            _rgbPwmLed.Stop();
            _rgbPwmLed.StartRunningColors(arrayColors, intervals);
        }

        public void NetworkConnected()
        {
            _rgbPwmLed.Stop();
            _rgbPwmLed.SetColor(Netduino.Foundation.Color.Green);
        }

        protected Netduino.Foundation.Color GetRandomColor()
        {
            var random = new Random();
            return Netduino.Foundation.Color.FromHsba(random.NextDouble(), 1, 1);
        }
    }
}
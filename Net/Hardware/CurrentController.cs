using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Netduino.Foundation.Relays;
using SLH = SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace SSwHost.Hardware
{
    class CurrentController
    {
        // events
        public event EventHandler Current1 = delegate { };
        public event EventHandler Current2 = delegate { };
        // peripherals
        static AnalogInput _current1 = new AnalogInput(AnalogChannels.ANALOG_PIN_A0);
        protected AnalogInput _current2 = new AnalogInput(AnalogChannels.ANALOG_PIN_A1);
        OutputPort receptacle1 = new OutputPort(Pins.GPIO_PIN_D2, false);
        OutputPort receptacle2 = new OutputPort(Pins.GPIO_PIN_D3, false);

        // properties
        public bool Running
        {
            get { return _running; }
        }
        protected bool _running = false;

        public void CurrentScale()
        {
            _current1.Scale = 360;
            
        }
        // An interrupt port raises events when its value changes. in this case, 
        // we use it to create an event when the button is clicked.
        // We set the Interrupt mode to raise an event on both edges of the signal;
        // both down, and up.
        static InterruptPort _currInterrupt = new InterruptPort((Cpu.Pin)0x15, false,
            Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);

        public int value()
        {
            return (int)_current1.Pin;
        }

    }
}

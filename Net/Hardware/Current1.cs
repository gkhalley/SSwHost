using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SLH = SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Net.Hardware
{
    class Current1
    {
        AnalogInput current = new AnalogInput(AnalogChannels.ANALOG_PIN_A1);
        public Current1()
        {
            current.Scale = 360;
            
        }
        public int value()
        {
            return (int)current.Pin;
        }

    }
}

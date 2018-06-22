using System.Text;
using System.Threading;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace BasicSPI
{
    public class Program
    {
        public static void Main()
        {
            SPI.Configuration spiConfig = new SPI.Configuration(
                ChipSelect_Port: Pins.GPIO_PIN_D4,      // Chip select is digital IO 4.
                ChipSelect_ActiveState: false,          // Chip select is active low.
                ChipSelect_SetupTime: 0,                // Amount of time between selection and the clock starting
                ChipSelect_HoldTime: 0,                 // Amount of time the device must be active after the data has been read.
                Clock_Edge: false,                      // Sample on the falling edge.
                Clock_IdleState: true,                  // Clock is idle when high.
                Clock_RateKHz: 2000,                    // 2MHz clock speed.
                SPI_mod: SPI_Devices.SPI1               // Use SPI1
            );

            SPI spi = new SPI(spiConfig);
            byte[] buffer = Encoding.UTF8.GetBytes("Message Text.");
            while (true)
            {
                spi.Write(buffer);
                Thread.Sleep(100);
            }
        }
    }
}
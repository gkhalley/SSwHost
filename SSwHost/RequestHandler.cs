using Maple;
using System.Text;
using System.IO;
using Microsoft.SPOT;
using System.Collections;
using Microsoft.SPOT.IO;

namespace SSwHost

{
    public class RequestHandler : RequestHandlerBase
    {
        public event EventHandler TurnOn = delegate { };
        public event EventHandler TurnOff = delegate { };
        public event EventHandler StartRunningColors = delegate { };

        public RequestHandler() { }

        public void postTurnOn()
        {
            TurnOn(this, EventArgs.Empty);
            StatusResponse();
        }

        public void postTurnOff()
        {
            TurnOff(this, EventArgs.Empty);
            StatusResponse();
        }

        public void setFileName()
        {

            var volume = new VolumeInfo("SD");

            // check to see if there's an SD card inserted
            if (volume != null)
            {
                // "SD" is the volume name,
                var path = Path.Combine("SD", "test.txt");

                // write some text to a file
                File.WriteAllBytes(path, Encoding.UTF8.GetBytes("Foooooooo"));

                // Must call flush to write immediately. Otherwise, there's no guarantee 
                // as to when the file is written. 
                volume.FlushAll();
            }
            else
            {
                Debug.Print("There doesn't appear to be an SD card inserted");
            }
        }


        public void postStartRunningColors()
        {
            StartRunningColors(this, EventArgs.Empty);
            StatusResponse();
        }

        private static bool _isPowerOn;
        private void StatusResponse()
        {
            Context.Response.ContentType = "application/json";
            Context.Response.StatusCode = 200;
            Hashtable result = new Hashtable { { "isPowerOn", _isPowerOn.ToString().ToLower() } };
            Send(result);
        }
    }
}
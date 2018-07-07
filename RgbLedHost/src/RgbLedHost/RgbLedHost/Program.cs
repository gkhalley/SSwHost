using System.Threading;

namespace SSwHost
{
    public class Program
    {
        public static void Main()
        {
            App app = new App();
            app.Run();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}

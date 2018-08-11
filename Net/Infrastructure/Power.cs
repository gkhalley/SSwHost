using System;
using Microsoft.SPOT;

namespace SSwHost.Infrastructure
{
    class Power
    {
        static DateTime time = new DateTime();
        public enum PeriodMax
        {
            Second,
            Minute,
            FiveMinute,
            FifeteenMinute,
            Hour
        }
        PeriodMax period;

        static double current;
        private double defaultVoltage { get; } = 120.0;
        public Power(DateTime time_, PeriodMax periodMax, double current_)
        {
            time = time_;
            period = periodMax;
            current = current_;
        }
        public Power(double defaultVoltage_)
        {
            defaultVoltage = defaultVoltage_;
        }
    }
}

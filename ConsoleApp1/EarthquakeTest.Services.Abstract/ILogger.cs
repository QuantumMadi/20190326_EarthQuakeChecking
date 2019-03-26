using System;

namespace EarthquakeTest.Services.Abstract
{
    public interface ILogger
    {
        void LogError(Exception exception);
        void LogMessage(string text);
    }
}

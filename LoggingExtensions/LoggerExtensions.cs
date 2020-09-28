using System;
using System.Text;
using Microsoft.Extensions.Logging;

namespace LoggingExtensions
{
    public static class LoggerExtensions
    {
        public static void Info(this ILogger logger, string message, params (string key, object value)[] properties)
        {
            StringBuilder sb = new StringBuilder(message);
            object[] valuesOfProps = new object[properties.Length];

            for (var i = 0; i < properties.Length; i++)
            {
                var key = properties[i].key;
                var value = properties[i].value;
                sb.Append($" {{{key}}}");
                valuesOfProps[i] = value;
            }

            logger.LogInformation(sb.ToString(), valuesOfProps);
        }
    }
}

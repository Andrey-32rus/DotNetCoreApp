using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace LoggingExtensions
{
    public static class LoggerExtensions
    {
        private static (string message, object[] args) PrepareArgs(string message, IList<(string key, object value)> properties)
        {
            StringBuilder sb = new StringBuilder(message);
            object[] valuesOfProps = new object[properties.Count];

            for (var i = 0; i < properties.Count; i++)
            {
                sb.Append($" {{{properties[i].key}}}");
                valuesOfProps[i] = properties[i].value;
            }

            return (sb.ToString(), valuesOfProps);
        }

        public static void Info(this ILogger logger, string message, params (string key, object value)[] properties)
        {
            var (resMessage, args) = PrepareArgs(message, properties);
            logger.LogInformation(resMessage, args);
        }
    }
}

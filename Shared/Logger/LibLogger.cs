using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Shared.Logger
{
    public class LibLogger : ILogger
    {
        /// <summary>
        /// 1- Error, 2- Warn,Error, 3- Info, Warn, Error, 4-Debug, Info, Warn, Error
        /// </summary>
        public static int LogLevel{get; set;}
         static LibLogger()
        {
            int logLevel;
            int.TryParse(WebConfigurationManager.AppSettings["loglevel"],out logLevel) ;
            LogLevel = logLevel;
        }

        /// <summary>
        /// To log an error. Log level should be 1
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public void Error(string msg, Exception ex)
        {
            if(LogLevel<1)
            {
                return;
            }
            //TODO log the error mesages
        }

        /// <summary>
        /// For warning. The log level should be greater than 1 to log.
        /// </summary>
        /// <param name="msg"></param>
        public void Warn(string msg)
        {
            if (LogLevel <2)
            {
                return;
            }
            //TODO warn the usage
        }

        /// <summary>
        /// To log the info messages.
        /// The log level should be greater than 2 to log.
        /// </summary>
        /// <param name="msg"></param>
        public void Info(string msg)
        {
            if (LogLevel < 3)
            {
                return;
            }
            //TODO log the info message
        }

        /// <summary>
        /// For debuging purposes
        /// The log level should be greater than 3 to log.
        /// </summary>
        /// <param name="msg"></param>
        public void Debug(string msg)
        {
            if (LogLevel < 4)
            {
                return;
            }
            //TODO debug
        }

    }
}

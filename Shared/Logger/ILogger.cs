using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Logger
{

    /// <summary>
    /// Interface log details like Debug, Warnings, Errors
    /// for wasy understanding and bug fixing.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Interface to log debug information
        /// </summary>
        /// <param name="msg">The message to log</param>
        void Debug(string msg);
        /// <summary>
        /// Interface to log required information from a method
        /// </summary>
        /// <param name="msg">The message to log</param>
        void Info(String msg);
        /// <summary>
        /// Interface to log warning information
        /// </summary>
        /// <param name="msg">The message to log</param>
        /// <param name="ex">Exception occured.</param>
        void Warn(String msg);
        /// <summary>
        /// Interface to log error information
        /// </summary>
        /// <param name="msg">The message to log</param>
        /// <param name="ex">Exception occured.</param>
        void Error(String msg, Exception ex);
    }
}

using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

namespace Shared.Utilities
{
   /// <summary>
   /// Static class to have the common funcalities of the project
   /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Returns the memory stream  from the http url data
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Stream GetStreamFromURL(string url)
        {
            Stream streamObj = null;
            using (WebClient client = new WebClient())
            {
                streamObj =  new MemoryStream(client.DownloadData(url));
            }
            return streamObj;
        }
    }
}
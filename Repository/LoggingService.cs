using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VinOpenID.Repository
{
    public class LoggingService : ILoggingService
    {
        #region "Ghi log vào file"
        /// <summary>
        /// Ghi log xuống folder log trong website directory
        /// </summary>
        /// <param name="Content">content Log</param>
        public void WriteLog(string Content)
        {
            try
            {
                Content = Content + "\r\n----------------------------------------------------------------------------------------------------";

                string LogFile = "~/Log/Log-" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                System.IO.StreamWriter strW = new System.IO.StreamWriter(System.Web.Hosting.HostingEnvironment.MapPath(LogFile), true);
                strW.WriteLine(DateTime.Now + ": " + Content);
                strW.Close();
            }
            catch (Exception ex)
            {
            }

        }
        #endregion
    }
}
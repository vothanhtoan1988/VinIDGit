using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VinOpenID.Repository
{
    public interface ILoggingService
    {
        void WriteLog(string Content);
    }
}
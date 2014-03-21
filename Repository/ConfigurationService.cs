using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VinOpenID.Repository
{
    public class ConfigurationService
    {
        private string _openIDServiceUri;

        public string OpenIDServiceUri
        {
            get { return _openIDServiceUri; }

            set
            {
                _openIDServiceUri = System.Configuration.ConfigurationManager.AppSettings["OpenIDServiceUri"];
            }
        }        
    }
}
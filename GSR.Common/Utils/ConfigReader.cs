using System;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GSR.Common.Utils
{
    public class ConfigReader
    {


        public static string ActiveConnectionStringKey
        {
            get
            {
                string keyToFetch = AppSettings("KeyToFetchConnectionString");
                if (keyToFetch.Trim().Equals(""))
                {
                    keyToFetch = "DefaultConnectionString";
                }
                return keyToFetch;
            }
        }

        public static string APPLICATION_TITLE
        {
            get
            {
                return AppSettings("APPLICATION_TITLE");
            }
        }

        public static string AppSettings(string key)
        {
            string returnValue = "";
            if (ConfigurationManager.AppSettings[key] != null)
            {
                returnValue = ConfigurationManager.AppSettings[key];
            }
            return returnValue;
        }

        public static bool AppSettingsAsBoolean(string key)
        {
            bool returnValue = false;
            if (ConfigurationManager.AppSettings[key] != null)
            {
                try
                {
                    returnValue = Convert.ToBoolean(ConfigurationManager.AppSettings[key]);
                }
                catch
                {
                    returnValue = false;
                }
            }
            return returnValue;
        }
    }
}

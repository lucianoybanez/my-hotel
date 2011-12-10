using System.Configuration;

namespace JLY.Hotel.Web.Services
{
    public class ConfigurationService : IConfigurationService
    {
        
        private string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public string SmtpServer
        {
            get { return GetValue("SmtpServer"); }
        }

    }
}
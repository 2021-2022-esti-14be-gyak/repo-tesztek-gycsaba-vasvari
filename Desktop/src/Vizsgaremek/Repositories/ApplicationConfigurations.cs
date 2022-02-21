using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

using System.Collections.Specialized;

namespace Vizsgaremek.Repositories
{
    public class ApplicationConfigurations
    {
        private string appName;
        private Dictionary<string, string> databaseSources;
        private Dictionary<string, string> languages;

        public string AppName { get => appName; set => appName = value; }
        public Dictionary<string, string> DatabaseSources { get => databaseSources; set => databaseSources = value; }
        public Dictionary<string, string> Languages { get => languages; set => languages = value; }

        public ApplicationConfigurations()
        {
            var name = ConfigurationManager.AppSettings.Get("name");

            NameValueCollection devopsVersionsConfigSection = ConfigurationManager.GetSection("devopsVersions") as NameValueCollection;
            NameValueCollection lanuagesSettingsConfigSection = ConfigurationManager.GetSection("languages") as NameValueCollection;

            databaseSources = new Dictionary<string, string>();
            databaseSources = devopsVersionsConfigSection.AllKeys.ToDictionary(k => k, k => devopsVersionsConfigSection[k]);

            languages = new Dictionary<string, string>();
            languages = lanuagesSettingsConfigSection.AllKeys.ToDictionary(k => k, k => lanuagesSettingsConfigSection[k]);
        }
    }
}

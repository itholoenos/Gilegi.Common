using System.Configuration;
using System.Diagnostics;

namespace Gilegi.Common.Utilities.Configuration
{
    public class VirtualSection
    {
        private readonly string _sectionName;

        public VirtualSection(string name)
        {
            _sectionName = name;
        }

        public string Get(string key, bool allowNull = true, bool allowEmpty = true)
        {
            //compine section with key
            key = $"{_sectionName}:{key}";

            //retrieve value
            var value = ConfigurationManager.AppSettings[key];

            //check if it's null
            if (!allowNull && value == null)
            {
                var error = $"Could not find a configuration value for key '{key}'. Please make sure you have this app setting in your .config file";

                //show message in debug
                Debug.Fail(error);

                throw new ConfigurationErrorsException(error);
            }

            //check if it's empty
            if (!allowEmpty && string.IsNullOrEmpty(value))
            {
                var error = $"Retrieved value for '{key}' is EMPTY. Please type a value for this key in your .config file";

                //show message in debug
                Debug.Fail(error);

                throw new ConfigurationErrorsException(error);
            }

            return value;
        }
    }
}
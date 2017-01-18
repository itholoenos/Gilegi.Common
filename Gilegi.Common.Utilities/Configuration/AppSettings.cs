using System.Configuration;

namespace Gilegi.Common.Utilities.Configuration
{
    public static class AppSettings
    {
        /// <summary>
        /// returns an application setting by key. set params if you want to throw exceptions when null or empty
        /// </summary>
        /// <param name="key"></param>
        /// <param name="allowNull"></param>
        /// <param name="allowEmpty"></param>
        /// <returns></returns>
        public static string Get(string key, bool allowNull = true, bool allowEmpty = true)
        {
            //retrieve value
            var value = ConfigurationManager.AppSettings[key];

            //check if it's null
            if (!allowNull && value == null)
            {
                var error = $"Could not find a configuration value for key '{key}'. Please make sure you have this app setting in your .config file";
                throw new ConfigurationErrorsException(error);
            }

            //check if it's empty
            if (!allowEmpty && string.IsNullOrEmpty(value))
            {
                var error = $"Retrieved value for '{key}' is EMPTY. Please type a value for this key in your .config file";
                throw new ConfigurationErrorsException(error);
            }

            return value;
        }

        /// <summary>
        /// returns an application setting by key based on the convention 'section:key'. set params if you want to throw exceptions when null or empty
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="allowNull"></param>
        /// <param name="allowEmpty"></param>
        /// <returns></returns>
        public static string Get(string section, string key, bool allowNull = true, bool allowEmpty = true)
        {
            //compine section with key
            key = $"{section}:{key}";

            return Get(key, allowNull, allowEmpty);
        }
    }
}
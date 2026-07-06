using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Hotel_Management_System
{
    internal static class ConfigurationRepair
    {
        public static void EnsureSettingsConfigValid()
        {
            try
            {
                // Access a setting to force the settings system to load.
                var value = Properties.Settings.Default.OnityIP;
                _ = value;
            }
            catch (TypeInitializationException ex) when (ex.InnerException is ConfigurationErrorsException inner)
            {
                HandleCorruptConfig(inner);
            }
            catch (ConfigurationErrorsException ex)
            {
                HandleCorruptConfig(ex);
            }
        }

        public static bool TryRepairCorruptConfig(ConfigurationErrorsException ex)
        {
            if (ex == null)
            {
                return false;
            }

            string filename = ex.Filename;
            if (string.IsNullOrWhiteSpace(filename) || !filename.EndsWith("user.config", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }
            catch
            {
                // Ignore any cleanup failure.
            }

            ResetSettingsInstance();
            return true;
        }

        private static void HandleCorruptConfig(ConfigurationErrorsException ex)
        {
            if (TryRepairCorruptConfig(ex))
            {
                return;
            }

            throw new ConfigurationErrorsException("Unable to repair application configuration.", ex);
        }

        private static void ResetSettingsInstance()
        {
            FieldInfo field = typeof(Properties.Settings).GetField("defaultInstance", BindingFlags.NonPublic | BindingFlags.Static);
            if (field == null)
            {
                return;
            }

            field.SetValue(null, ApplicationSettingsBase.Synchronized(new Properties.Settings()));
        }
    }
}

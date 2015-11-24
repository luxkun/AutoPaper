using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using AutoPaper.Properties;

namespace AutoPaper
{
    internal class Conf
    {
        internal static readonly string name = "AutoPaper";
        internal static readonly float version = 0.1f;

        private static readonly Dictionary<string, Func<object, bool>> costrains = new Dictionary
            <string, Func<object, bool>>
        {
            {"delay", (object v) => (int)v > 0},
            {"policyA", (object v) => possiblePoliciesA.Contains((string) v)},
            {"policyB", (object v) => possiblePoliciesB.Contains((string) v)},
            {"style", (object v) => possibleStyles.Contains((string) v)}
        };

        internal static List<string> possibleStyles = new List<string>
        {
            "Centered",
            "Stretched",
            "Tiled"
        };

        internal static List<string> possiblePoliciesA = new List<string>
        {
            "Top",
            "Random"
        };

        internal static List<string> possiblePoliciesB = new List<string>
        {
            "Hot",
            "New",
            "Rising",
            "Controversial",
            "Top",
            "Gilded"
        };

        internal static void Save()
        {
            Settings.Default.Save();
        }

        internal static object GetConf(string k)
        {
            var result = Settings.Default[k];
            return result;
        }

        internal static bool SetConf(string k, object v)
        {
            if (!costrains.ContainsKey(k) || costrains[k](v))
            {
                Settings.Default[k] = v;
                return true;
            }
            return false;
        }

        internal static bool ConfExists(string settingName)
        {
            return Settings.Default.Properties.Cast<SettingsProperty>().Any(prop => prop.Name == settingName);
        }
    }
}
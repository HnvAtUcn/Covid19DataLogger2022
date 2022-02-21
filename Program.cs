using System;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Data;
using System.Collections.Generic;

namespace Covid19DataLogger2022
{
    class MainClass
    {
        static void Main(string[] args)
        {
            // 1) Command line should be like: -settingsfile C:\\YourDataDirectory\\YourSettingsFile.json
            // 2) If no command line args, try to use the settings file in the project, Settings.json
            // 3) If the settings file exists, construct new Covid19_DataLogger object from these settings
            // 4) Start logging (scraping) data with the Log(string Settings) method
            string SettingsPath = "";

            if (args.Length > 0)
            {
                string arg0 = args[0].ToLower().Trim();
                if (arg0 == "-settingsfile")
                {
                    if (args.Length > 1)
                    {
                        SettingsPath = args[1];
                    }
                }
            }
            else
            {
                SettingsPath = @"Settings.json";
            }

            if (File.Exists(SettingsPath))
            {
                Covid19_DataLogger theLogger = new();
                theLogger.Log(File.ReadAllText(SettingsPath));
            }
        }
    }
}


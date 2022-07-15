/* This file is part of Home Chatter
 * A program that allows to chat using basic LAN connection.
 *
 * Copyright © Ala Ibrahim Hadid 2013
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Reflection;
namespace HomeChatter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Load settings
            settings = new Properties.Settings();
            settings.Reload();
            //set the language before loading resources
            Language = settings.Language;
            resources = new ResourceManager("HomeChatter.LanguageResources.Resource",
              Assembly.GetExecutingAssembly());

            Application.Run(new Form_Main());
        }
        private static ResourceManager resources;
        //TODO: find another way to detect supported languages
        private static string[,] supportedLanguages =
        { { "English (United States)", "en-US","English (United States)" },
          { "Arabic (Syria)", "ar-SY","(العربية (سوريا" } };
        private static Properties.Settings settings;
        /// <summary>
        /// Get the settings class
        /// </summary>
        public static Properties.Settings Settings
        { get { return settings; } }
        /// <summary>
        /// Get the version of ASM
        /// </summary>
        public static string Version
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }
        public static string StartUpPath
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        }
        public static string[,] SupportedLanguages
        { get { return supportedLanguages; } }
        public static string Language
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.NativeName;
            }
            set
            {
                for (int i = 0; i < Program.SupportedLanguages.Length / 3; i++)
                {
                    if (Program.SupportedLanguages[i, 0] == value)
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Program.SupportedLanguages[i, 1]);
                        break;
                    }
                }
            }
        }
        public static CultureInfo CultureInfo
        { get { return Thread.CurrentThread.CurrentUICulture; } }
        /// <summary>
        /// Get or set the resources manager
        /// </summary>
        public static ResourceManager ResourceManager
        { get { return resources; } set { resources = value; } }
    }
}

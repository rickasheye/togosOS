using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace togos
{
    class ApplicationManager
    {
        public List<Application> Applications { get; private set; }

        public ApplicationManager()
        {
            Applications = new List<Application>();

            if (!Directory.Exists(ApplicationPath))
                Directory.CreateDirectory(ApplicationPath);

            string[] appFiles = Directory.GetFiles(ApplicationPath, "*.togos");
            if(appFiles.Length > 0)
            {
                CustomConsole.WarningLog("Loading Applications!");
                foreach(string file in appFiles)
                {
                    CustomConsole.WarningLog("Loading Application: " + file);
                    LoadApplications(file);
                }
                CustomConsole.SuccessLog("Finished Loading Applications!");
            }
            else
            {
                CustomConsole.WarningLog("No Applications Found!");
            }

            CustomConsole.WarningLog(Applications.Count + " Applications Loaded");
        }

        public void UnloadApplication(string name)
        {
            Applications.Remove(Applications.First(p => p.Name == name));
        }

        public void LoadApplications(string file)
        {
            try
            {
                //Load the application
                //Check if there is a .meta file if so then read it
                //string[] data = File.ReadAllLinesAsync(file + "/application.meta/");
            }
            catch(Exception e)
            {
                CustomConsole.ErrorLog("Could not load application: Error: " + e);
                if (e.InnerException != null)
                    CustomConsole.ErrorLog("InnerException: " + e.InnerException.GetType() + " Message: " + e.InnerException.Message + " Stacktrace: " + e.InnerException.StackTrace);
            }
        }

        private string ApplicationPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
            }
        }
    }
}

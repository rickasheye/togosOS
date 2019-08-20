using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace togos
{
    class NewApplicationManager
    {
        /*public Dictionary<string, string> apps = new Dictionary<string, string>();
        public NewApplicationManager()
        {
            Start();
        }

        public void Start()
        {
            //Try to get all of the applications that are installed in the programs folder
            string[] files = API.FileExplorer.GetDirectories("0://plugins/");
            //We got all the files lets load them in
            foreach(string file in files)
            {
                string[] filesInside = API.FileExplorer.GetFiles(file);
                foreach(string filesInsidem in filesInside)
                {
                    string filename = Path.GetFileName(filesInsidem);

                    //Easier code management
                    bool errorFound = false;
                    if(filename == "properties.txt")
                    {
                        bool fileExists = API.FileExplorer.fileExists(filesInsidem);
                        if(fileExists == false)
                        {
                            CustomConsole.ErrorLog("Plugin : " + filesInsidem + " doesnt include a properties file!!!");
                            errorFound = true;
                        }
                    }

                    if(filename == "code.mn")
                    {
                        bool fileExists = API.FileExplorer.fileExists(filesInsidem);
                        if(fileExists == false)
                        {
                            CustomConsole.ErrorLog("Plugin : " + filesInsidem + " doesnt include a main code file!!!");
                            errorFound = true;
                        }
                    }

                    if (errorFound == false)
                    {
                        string metaFileJson = API.FileExplorer.ReadText(Path.Combine(file, "properties.txt"));
                        string codeFile = API.FileExplorer.ReadText(Path.Combine(file, "code.mn"));
                        RootObject metaFileJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(metaFileJson);
                        CustomConsole.SuccessLog("Found runnable application here: " + filesInsidem);
                        CustomConsole.WarningLog("Loading Application");
                        apps.Add(metaFileJson, codeFile);
                        CustomConsole.SuccessLog("Loaded App, " + metaFileJSON.name + " Created at: " + metaFileJSON.date);
                    }
                    else
                    {
                        CustomConsole.WarningLog("Stopping process of loading the application.");
                    }
                }
            }
        }
    }

    public class RootObject
    {
        public string name { get; set; }
        public string date { get; set; }
    }*/
    }
}

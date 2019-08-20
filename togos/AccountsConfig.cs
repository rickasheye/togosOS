using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace togos
{
    public class AccountsConfig
    {
        [System.Serializable]
        public struct account
        {
            public string username;
            public string password;
            public bool autologin;
        }

        [JsonProperty("accounts")]
        public List<account> accounts = new List<account>();

        public void SaveConfig()
        {
            string pathSave = Path.Combine(CommandExecutor.currentDirectory + "accounts.cfg");
            if(API.FileExplorer.fileExists(pathSave)){
                List<account> accountsSaved = JsonConvert.DeserializeObject<List<account>>(pathSave);
                account[] accountsOpen = accounts.ToArray();
                accountsSaved.AddRange(accountsOpen);
                //Save the accounts
                API.FileExplorer.EditTextDocument(pathSave, JsonConvert.SerializeObject(accountsSaved));
            }
            else
            {
                API.FileExplorer.CreateTextDocument(pathSave, JsonConvert.SerializeObject(accounts));
            }
            Console.WriteLine("Created a new config or saved one");
        }

        public void LoadConfig()
        {
            string pathSave = Path.Combine(CommandExecutor.currentDirectory + "accounts.cfg");
            if (API.FileExplorer.fileExists(pathSave))
            {
                accounts = JsonConvert.DeserializeObject<List<account>>(pathSave);
            }
            else
            {
                CustomConsole.ErrorLog("Unable to find the config, please create a new one!");
            }
        }
    }
}

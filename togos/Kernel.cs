using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using IL2CPU.API.Attribs;
using ConsoleGameEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace togos
{
    public class Kernel : Sys.Kernel
    {
        Canvas aCanvas;
        public static Sys.FileSystem.CosmosVFS fs;
        AccountsConfig config;

        [ManifestResourceStream(ResourceName = "togos.Resources.0.bmp")]
        public static byte[] zero;

        public static AccountsConfig.account loggedAccount;

        protected override void BeforeRun()
        {
            //Register an account
            if(!API.FileExplorer.fileExists(System.IO.Path.Combine(CommandExecutor.currentDirectory + "accounts.cfg"))){
                AccountRegistration();
            }
            else
            {
                FirstLogin();
            }
        }

        public void FirstLogin()
        {
            Console.WriteLine("Accounts Exists logging in or trying to find an account");
            config.LoadConfig();
            List<AccountsConfig.account> accounts = config.accounts;
            if (accounts.Count <= 1)
            {
                //Select the primary account else then put up a selection
                ExteriorLogin(accounts[0]);
            }
            else
            {
                foreach (AccountsConfig.account a in accounts)
                {
                    Console.WriteLine("Account: " + a.username);
                }
                Console.WriteLine("Select an account");
                string readInput = Console.ReadLine();
                //If the account exists ask for a password
                if (containsAccount(readInput))
                {
                    //Ask for the password
                    Console.Write("password:");
                    string password = Console.ReadLine();
                    ExteriorLogin(readInput, password);
                }
            }
        }

        public bool containsAccount(string username)
        {
            bool containAccount = false;
            foreach(AccountsConfig.account a in config.accounts)
            {
                if(a.username == username)
                {
                    containAccount = true;
                }
            }
            return containAccount;
        }

        public AccountsConfig.account getAccount(string username, string password)
        {
            AccountsConfig.account containAccount = new AccountsConfig.account();
            foreach (AccountsConfig.account a in config.accounts)
            {
                if (a.username == username)
                {
                    containAccount = a;
                }
            }
            return containAccount;
        }

        public void ExteriorLogin(AccountsConfig.account accountSelected)
        {
            if (accountSelected.autologin == true)
            {
                bool loginStatus = LoginAccount(accountSelected.username, accountSelected.password);
                if(loginStatus == false) { FirstLogin(); }
            }
            else
            {
                //Ask for the password then login
                Console.WriteLine("password for " + accountSelected.username);
                string password = Console.ReadLine();
                bool loginStatus = LoginAccount(accountSelected.username, password);
                if (loginStatus == false) { FirstLogin(); }
            }
        }

        public void ExteriorLogin(string username, string _password)
        {
            AccountsConfig.account accountSelected = new AccountsConfig.account();
            foreach(AccountsConfig.account a in config.accounts)
            {
                if (a.username == username && a.password == _password)
                {
                    accountSelected = a; 
                }
            }

            if (accountSelected.autologin == true)
            {
                LoginAccount(accountSelected.username, accountSelected.password);
            }
            else
            {
                //Ask for the password then login
                Console.WriteLine("password for " + accountSelected.username);
                string password = Console.ReadLine();
                LoginAccount(accountSelected.username, password);
            }
        }

        public void AccountRegistration()
        {
            //Go through the registration process to create an account
            //Create a root account if the user does not like to create an account
            Console.WriteLine("Would you like to create an account or create a root account? (Y/N)?");
            string choice = Console.ReadLine();
            switch (choice.ToLower())
            {
                case "y":
                case "yes":
                    Console.WriteLine("Selected yes please write down a username");
                    string username = Console.ReadLine();
                    Console.WriteLine("Then now a password");
                    string password = Console.ReadLine();
                    Console.WriteLine("Would you like to autologin? (y/n)");
                    string autoLogin = Console.ReadLine();
                    bool autoLoginChoice = false;
                    if(autoLogin.ToLower() == "y" || autoLogin.ToLower() == "yes") { autoLoginChoice = true; }
                    CreateAccount(username, password, autoLoginChoice);
                    break;
                case "n":
                case "no":
                    //Create the root account and skip the setup
                    Console.WriteLine("Creating root account");
                    CreateAccount("root", "root", true);
                    Console.WriteLine("Created account");
                    break;
                default:
                    Console.WriteLine("Incorrect answer please try again!");
                    AccountRegistration();
                    break;
            }
        }

        public void CreateAccount(string name, string password, bool autologin)
        {
            //Get the original object
            CustomConsole.SendLogType("Creating Account...", CustomConsole.MessageQuality.WARNING);
            List<AccountsConfig.account> accounts = config.accounts;
            AccountsConfig.account newaccount = new AccountsConfig.account();
            newaccount.username = name;
            newaccount.password = password;
            newaccount.autologin = autologin;
            accounts.Add(newaccount);
            config.SaveConfig();
            CustomConsole.SendLogType("Created Account!", CustomConsole.MessageQuality.SUCESS);
        }

        public bool LoginAccount(string username, string password)
        {
            bool successfulLogin = false;
            AccountsConfig.account accountSelected = new AccountsConfig.account();
            foreach(AccountsConfig.account a in config.accounts)
            {
                //Disect the accounts and select an account
                if(a.username == username)
                {
                    accountSelected = a;
                }
            }

            if(accountSelected.username != null)
            {
                if(accountSelected.password == password)
                {
                    loggedAccount = accountSelected;
                    CustomConsole.SendLogType("Logged in", CustomConsole.MessageQuality.SUCESS);
                    successfulLogin = true;
                }
                else
                {
                    CustomConsole.SendLogType("Incorrect Password please try again", CustomConsole.MessageQuality.ERROR);
                    successfulLogin = false;
                }
            }
            else
            {
                CustomConsole.SendLogType("No account was found please retry", CustomConsole.MessageQuality.ERROR);
                successfulLogin = false;

            }
            return successfulLogin;
        }

        public static  void KernelShutdown()
        {
            CustomConsole.WarningLog("Shutting Down!");
            Sys.Power.Shutdown();
        }

        public static void KernelRestart()
        {
            CustomConsole.WarningLog("Recieved Restart Command");
            Sys.Power.Reboot();
        }

        protected override void Run()
        {
            CommandExecutor.ExecuteCommand();
        }
    }
}

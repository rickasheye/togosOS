using System;

namespace togos
{
    public static class CommandExecutor
    {
        public static string currentDirectory = "0:\\";

        public static void ExecuteCommand()
        {
            //Console.WriteLine("Welcome to my Cosmos Kernal made by Rickasheye");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Kernel.loggedAccount.username + "@" + currentDirectory);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" >");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();
            InitTextMode(input);
            CustomConsole.WarningLog("Hmm... youve seem to hit rock bottom");
            CustomConsole.WarningLog("Let me kick you back in");
            ExecuteCommand();
        }

        public static void InitTextMode(string command)
        {
            string[] args = command.ToLower().Split(' ');
            try
            {
                switch (args[0].ToLower())
                {
                    case "readreg":
                        string VariableType = args[1];
                        switch (VariableType.ToLower())
                        {
                            case "string":
                            case "word":
                                //Word find
                                if (API.RegistryEditor.StringExists(args[2]))
                                {
                                    CustomConsole.SuccessLog("The value for " + args[2] + " is " + API.RegistryEditor.returnString(args[2]));
                                }
                                else
                                {
                                    CustomConsole.ErrorLog("That string either doesnt have a value or doesnt exist.");
                                }
                                break;
                            case "integer":
                            case "number":
                                //Number find
                                if (API.RegistryEditor.IntegerExists(args[2]))
                                {
                                    CustomConsole.SuccessLog("The value for " + args[2] + " is " + API.RegistryEditor.returnString(args[2]));
                                }
                                else
                                {
                                    CustomConsole.ErrorLog("That integer either doesnt have a value or doesnt exist.");
                                }
                                break;
                            case "float":
                                //Float find
                                if (API.RegistryEditor.FloatExists(args[2]))
                                {
                                    CustomConsole.SuccessLog("The value for " + args[2] + " is " + API.RegistryEditor.returnString(args[2]));
                                }
                                else
                                {
                                    CustomConsole.ErrorLog("That integer either doesnt have a value or doesnt exist.");
                                }
                                break;
                        }
                        break;
                    case "editreg":
                        API.Commands.editreg regEdit = new API.Commands.editreg();
                        regEdit.Start(args);
                        break;
                    case "getinfo":
                        Console.WriteLine("Directories: ");
                        string[] pathsDirectories = API.FileExplorer.GetDirectories(currentDirectory);
                        for (int i = 0; i < pathsDirectories.Length; i++)
                        {
                            Console.WriteLine(pathsDirectories[i]);
                        }
                        Console.WriteLine("Files: ");
                        string[] pathsFiles = API.FileExplorer.GetFiles(currentDirectory);
                        for (int m = 0; m < pathsFiles.Length; m++)
                        {
                            Console.WriteLine(pathsFiles[m]);
                        }
                        break;
                    case "changedirectory":
                    case "cd":
                        try
                        {
                            if (args[1] != "" || args[1] != null)
                            {
                                if (API.FileExplorer.DirectoryExists(args[1]) != false)
                                {
                                    currentDirectory = args[1];
                                }
                                else
                                {
                                    CustomConsole.ErrorLog("Seems like that this isnt a directory");
                                    currentDirectory = "0:\\";
                                }
                            }
                            else if(args[1] == "" || args[1] == null)
                            {
                                currentDirectory = "0:\\";
                            }
                            else
                            {
                                currentDirectory = "0:\\";
                            }
                        }
                        catch (Exception e)
                        {
                            CustomConsole.ErrorLog("" + e);
                            currentDirectory = "0:\\";
                        }
                        break;
                    case "getdir":
                    case "getd":
                        Console.WriteLine("Directories: ");
                        string[] pathsDirectoriesM = API.FileExplorer.GetDirectories(currentDirectory);
                        for (int i = 0; i < pathsDirectoriesM.Length; i++)
                        {
                            Console.WriteLine(pathsDirectoriesM[i]);
                        }
                        break;
                    case "getfiles":
                    case "getf":
                    case "gfiles":
                        Console.WriteLine("Files: ");
                        string[] pathsFilesM = API.FileExplorer.GetFiles(currentDirectory);
                        for (int m = 0; m < pathsFilesM.Length; m++)
                        {
                            Console.WriteLine(pathsFilesM[m]);
                        }
                        break;
                    case "createdir":
                    case "cdir":
                        //string[] argsSplit = command.ToLower().Split(' ');
                        API.FileExplorer.CreateDirectory(currentDirectory + args[1]);
                        break;
                    case "rmdir":
                    case "removedir":
                        API.FileExplorer.DeleteDirectory(currentDirectory + args[1]);
                        break;
                    case "createfile":
                    case "cfile":
                    case "cf":
                        API.FileExplorer.CreateFile(currentDirectory + args[1]);
                        break;
                    case "rmfile":
                    case "deletefile":
                        API.FileExplorer.DeleteFile(currentDirectory + args[1]);
                        break;
                    case "readText":
                        string[] files = API.FileExplorer.ReadTextArray(currentDirectory + args[1]);
                        foreach (string m in files)
                        {
                            Console.WriteLine(m);
                        }
                        break;
                    case "ping":
                        ping.Run(command);
                        break;
                    case "power":
                        switch (args[1].ToLower())
                        {
                            case "shutdown":
                            case "powerdown":
                                Cosmos.System.Power.Shutdown();
                                break;
                            case "restart":
                            case "reboot":
                                Cosmos.System.Power.Reboot();
                                break;
                            default:
                                CustomConsole.ErrorLog("No Power State was defined!");
                                break;
                        }
                        break;
                    case "cgsinit":
                    case "initgraphics":
                    case "initg":
                    case "cgs":
                        switch (args[1].ToLower())
                        {
                            case "launch":
                                Desktop.InitGraphics();
                                break;
                            case "drawfilledsquare":
                                //API.DisplayDriver.DrawFilledRectangle(Color.FromName(args[2].ToLower()), int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5]), int.Parse(args[6]));
                                CustomConsole.WarningLog("Drawing a filled square is not a supported function yet...");
                                break;
                            case "clear":
                                //API.DisplayDriver.Clear(Color.FromName(args[2].ToLower()));
                                CustomConsole.WarningLog("Clear is not a supported function yet.");
                                break;
                            default:
                                CustomConsole.ErrorLog("No Cosmos Graphics System Launch Paremeter was defined!");
                                break;
                        }
                        break;
                    case "echo":
                    case "message":
                        string message = string.Join(' ', args);
                        message = message.Replace(args[0].ToLower(), " ");
                        Console.WriteLine(string.Join(' ', args));
                        break;
                    case "cls":
                    case "clear":
                        Console.Clear();
                        break;
                    case "repeat":
                        if (args[1] != "")
                        {
                            try
                            {
                                int parse = int.Parse(args[1]);
                                for (int i = 0; i < parse; i++)
                                {
                                    if (args[2] != "")
                                    {
                                        InitTextMode(args[2]);
                                    }
                                    else
                                    {
                                        //No command is defined
                                        CustomConsole.ErrorLog("Unable to execute... no command defined!");
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                CustomConsole.ErrorLog(e.Message);
                                //Error occured try to execute the first parameter
                                InitTextMode(args[1]);
                            }
                        }
                        else
                        {
                            CustomConsole.ErrorLog("no count is defined!");
                        }
                        break;
                    default:
                        CustomConsole.ErrorLog("unknown command");
                        break;
                    case "loop":
                        if(args[1] != "")
                        {
                            try
                            {
                                if(args[2] != null)
                                {
                                    while (true)
                                    {
                                        InitTextMode(args[2]);
                                    }
                                }
                            }catch(Exception e)
                            {
                                CustomConsole.ErrorLog(e.Message);
                            }
                        }
                        break;
                }
                //Just for shits and giggles lets let the user run a command from the runtime
                //Convert the string command to an array to run on the command executor
                string[] fakeProgram = { command };
                ApplicationRuntime.StartApplication(fakeProgram);
                ExecuteCommand();
            }
            catch (Exception e)
            {
                CustomConsole.ErrorLog(e.ToString());
                ExecuteCommand();
            }
        }
    }
}

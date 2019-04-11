using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace togos
{
    public static class CommandExecutor
    {
        static string currentDirectory = "0://";

        public static void ExecuteCommand()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(currentDirectory);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" >");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();
            InitTextMode(input);
        }

        public static void InitTextMode(string command)
        {
            string[] args = command.ToLower().Split(' ');
            try
            {
                switch (args[0])
                {
                    case "readReg":
                        string VariableType = args[1];
                        switch (VariableType)
                        {
                            case "string":
                            case "STRING":
                            case "String":
                            case "Word":
                            case "WORD":
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
                            case "INTEGER":
                            case "Integer":
                            case "number":
                            case "NUMBER":
                            case "Number":
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
                            case "FLOAT":
                            case "Float":
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
                        break;
                    case "getinfo":
                    case "getInfo":
                    case "GetInfo":
                    case "Getinfo":
                    case "GETINFO":
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
                    case "getdir":
                    case "GETDIR":
                    case "gDir":
                    case "getDir":
                    case "GetDir":
                    case "gdir":
                        if (args[1] != "" || args[1] != " " || args[1] != null)
                        {
                            Console.WriteLine("Directories: ");
                            string[] pathsDirectoriesM = API.FileExplorer.GetDirectories(currentDirectory);
                            for (int i = 0; i < pathsDirectoriesM.Length; i++)
                            {
                                Console.WriteLine(pathsDirectoriesM[i]);
                            }
                        }
                        else
                        {
                            CustomConsole.WarningLog("No directory defined reverting to original directory");
                            currentDirectory = "0://";
                        }
                        break;
                    case "getfiles":
                    case "gFiles":
                    case "getF":
                    case "getf":
                    case "gfiles":
                    case "GETFILES":
                    case "GetFiles":
                    case "getFiles":
                    case "Getfiles":
                        Console.WriteLine("Files: ");
                        string[] pathsFilesM = API.FileExplorer.GetFiles(currentDirectory);
                        for (int m = 0; m < pathsFilesM.Length; m++)
                        {
                            Console.WriteLine(pathsFilesM[m]);
                        }
                        break;
                    case "createdir":
                    case "cdir":
                    case "CREATEDIR":
                    case "CDIR":
                    case "createDir":
                    case "CreateDir":
                        //string[] argsSplit = command.ToLower().Split(' ');
                        API.FileExplorer.CreateDirectory(currentDirectory + args[1]);
                        break;
                    case "rmdir":
                    case "removeDirectory":
                    case "RemoveDirectory":
                    case "RMDIR":
                    case "REMOVEDIR":
                    case "removeDir":
                    case "removedir":
                    case "RemoveDir":
                        API.FileExplorer.DeleteDirectory(currentDirectory + args[1]);
                        break;
                    case "createfile":
                    case "cfile":
                    case "cf":
                    case "CREATEFILE":
                        API.FileExplorer.CreateFile(currentDirectory + args[1]);
                        break;
                    case "rmfile":
                    case "deletefile":
                    case "DeleteFile":
                    case "deleteFile":
                    case "RMFILE":
                    case "removeFile":
                    case "RemoveFile":
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
                        switch (args[1])
                        {
                            case "shutdown":
                            case "Shutdown":
                            case "powerdown":
                            case "SHUTDOWN":
                            case "ShutDown":
                                Cosmos.System.Power.Shutdown();
                                break;
                            case "restart":
                            case "Restart":
                            case "reboot":
                            case "REBOOT":
                            case "Reboot":
                            case "RESTART":
                            case "ReStart":
                                Cosmos.System.Power.Reboot();
                                break;
                        }
                        break;
                    case "cgsinit":
                    case "initGraphics":
                    case "initgraphics":
                    case "initg":
                    case "cgs":
                        CustomConsole.WarningLog("uh oh this part isnt implemented yet.");
                        break;
                    case "echo":
                    case "message":
                        for(int i = 1; i < args.Length; i++)
                        {
                            if(i == 1)
                            {
                                Console.WriteLine(args[1]);
                            }
                            else
                            {
                                Console.Write(args[i]);
                            }
                        }
                        break;
                    case "cls":
                    case "clear":
                    case "CLEAR":
                        Console.Clear();
                        break;
                    default:
                        CustomConsole.ErrorLog("unknown command");
                        break;
                }
            }
            catch (Exception e)
            {
                CustomConsole.ErrorLog(e.ToString());
            }
        }
    }
}

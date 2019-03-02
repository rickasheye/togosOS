using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace togos
{
    public class CommandExecutor
    {
        string currentDirectory = "0://";
        Kernel kernelSaved;

        public CommandExecutor(Kernel kernel)
        {
            Console.WriteLine("Welcome to Console Mode Created By Lethen Parkes");
            kernelSaved = kernel;
        }

        public void ExecuteCommand(FileSystem system)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(currentDirectory);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" >");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();
            InitTextMode(input, system);
        }

        public void InitTextMode(string command, FileSystem system)
        {
            string[] args = command.ToLower().Split(' ');
            try
            {
                switch (args[0])
                {
                    case "getinfo":
                    case "getInfo":
                    case "GetInfo":
                    case "Getinfo":
                    case "GETINFO":
                        Console.WriteLine("Directories: ");
                        string[] pathsDirectories = system.GetDirFadr(currentDirectory);
                        for (int i = 0; i < pathsDirectories.Length; i++)
                        {
                            Console.WriteLine(pathsDirectories[i]);
                        }
                        Console.WriteLine("Files: ");
                        string[] pathsFiles = system.GetFsFadr(currentDirectory);
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
                        if (args[1] != "" || args[1] != " " || args[1] != null)
                        {
                            Console.WriteLine("Directories: ");
                            string[] pathsDirectoriesM = system.GetDirFadr(currentDirectory);
                            for (int i = 0; i < pathsDirectoriesM.Length; i++)
                            {
                                Console.WriteLine(pathsDirectoriesM[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No directory defined reverting to original directory");
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
                        string[] pathsFilesM = system.GetFsFadr(currentDirectory);
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
                        Directory.CreateDirectory(currentDirectory + args[1]);
                        Console.WriteLine("Created: " + args[1]);
                        break;
                    case "rmdir":
                    case "removeDirectory":
                    case "RemoveDirectory":
                    case "RMDIR":
                    case "REMOVEDIR":
                    case "removeDir":
                    case "removedir":
                    case "RemoveDir":
                        Directory.Delete(currentDirectory + args[1]);
                        Console.WriteLine("Deleted: " + args[1]);
                        break;
                    case "createfile":
                    case "cfile":
                    case "cf":
                    case "CREATEFILE":
                        File.Create(currentDirectory + args[1]);
                        Console.WriteLine("Created: " + args[1]);
                        break;
                    case "rmfile":
                    case "deletefile":
                    case "DeleteFile":
                    case "deleteFile":
                    case "RMFILE":
                    case "removeFile":
                    case "RemoveFile":
                        File.Delete(currentDirectory + args[1]);
                        Console.WriteLine("Deleted: " + args[1]);
                        break;
                    case "readText":
                        string[] files = File.ReadAllLines(currentDirectory + args[1]);
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
                        kernelSaved.InitGraphics();
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: unknown command");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: " + e);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

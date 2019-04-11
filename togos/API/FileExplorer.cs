using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;

namespace togos.API
{
    class FileExplorer
    {
        public static void DeleteFile(string path)
        {
            if (isFileSystemRunning())
            {
                File.Delete(path);
                CustomConsole.SuccessLog("Deleted a file at " + path);
            }
            else
            {
                InitialiseFileSystem();
                DeleteFile(path);
            }
        }

        public static void CreateFile(string path)
        {
            if (isFileSystemRunning())
            {
                File.Create(path);
                CustomConsole.SuccessLog("Created a file at " + path);
            }
            else
            {
                InitialiseFileSystem();
                CreateFile(path);
            }
        }

        public static void CreateTextDocument(string path, string[] content)
        {
            if (isFileSystemRunning())
            {
                File.WriteAllLines(path, content);
                CustomConsole.SuccessLog("Created Text Document at " + path);
            }
            else
            {
                InitialiseFileSystem();
                CreateTextDocument(path, content);
            }
        }

        public static void CreateTextDocument(string path, string content)
        {
            if (isFileSystemRunning())
            {
                File.WriteAllText(path, content);
                CustomConsole.SuccessLog("Created Text Document at " + path);
            }
            else
            {
                InitialiseFileSystem();
                CreateTextDocument(path, content);
            }
        }

        public static string ReadText(string path)
        {
            if (isFileSystemRunning())
            {
                return File.ReadAllText(path);
            }
            else
            {
                InitialiseFileSystem();
                return ReadText(path);
            }
        }

        public static string[] ReadTextArray(string path)
        {
            if (isFileSystemRunning())
            {
                return File.ReadAllLines(path);
            }
            else
            {
                InitialiseFileSystem();
                return ReadTextArray(path);
            }
        }

        public static void CopyFile(string pathOriginal, string pathFinal)
        {
            if (isFileSystemRunning())
            {
                FileStream currentfile = File.Open(pathOriginal, FileMode.Open);
                FileStream copyToFile = File.Create(pathFinal);
                currentfile.CopyTo(copyToFile);
                CustomConsole.SuccessLog("Copied file from " + pathOriginal + " to " + pathFinal);
            }
            else
            {
                InitialiseFileSystem();
                CopyFile(pathOriginal, pathFinal);
            }
        }

        public static void DuplicateFile(string path)
        {
            if (isFileSystemRunning())
            {
                FileStream currentFile = File.Open(path, FileMode.Open);
                string[] directories = Directory.GetFiles(Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar));
                FileStream copyToFile = File.Create(Path.GetFileName(path) + "(" + directories.Length + 1 + ")");
                currentFile.CopyTo(copyToFile);
                CustomConsole.SuccessLog("Duplicated file at " + path);
            }
            else
            {
                InitialiseFileSystem();
                DuplicateFile(path);
            }
        }

        public static void CopyFileAsync(string pathOriginal, string pathFinal)
        {
            if (isFileSystemRunning())
            {
                FileStream currentFile = File.Open(pathOriginal, FileMode.Open);
                FileStream copyToFile = File.Create(pathFinal);
                currentFile.CopyToAsync(copyToFile);
                CustomConsole.SuccessLog("Copied file from " + pathOriginal + " to " + pathFinal);
            }
            else
            {
                InitialiseFileSystem();
                CopyFileAsync(pathOriginal, pathFinal);
            }
        }

        public static void DuplicateFileAsync(string path)
        {
            if (isFileSystemRunning())
            {
                FileStream currentFile = File.Open(path, FileMode.Open);
                string[] directories = Directory.GetFiles(Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar));
                FileStream copyToFile = File.Create(Path.GetFileName(path) + "(" + directories.Length + 1 + ")");
                currentFile.CopyToAsync(copyToFile);
                CustomConsole.SuccessLog("Duplicated file " + path);
            }
            else
            {
                InitialiseFileSystem();
                DuplicateFileAsync(path);
            }
        }

        public static string[] GetDirectories(string path)
        {
            if (isFileSystemRunning())
            {
                return Directory.GetDirectories(path);
            }
            else
            {
                InitialiseFileSystem();
                return GetDirectories(path);
            }
        }

        public static void CreateDirectory(string path)
        {
            if (isFileSystemRunning())
            {
                Directory.CreateDirectory(path);
                CustomConsole.SuccessLog("Created a Directory in " + path);
            }
            else
            {
                InitialiseFileSystem();
                CreateDirectory(path);
            }
        }

        public static string[] GetFiles(string path)
        {
            if (isFileSystemRunning())
            {
                return Directory.GetFiles(path);
            }
            else
            {
                InitialiseFileSystem();
                return GetFiles(path);
            }
        }

        public static void DeleteDirectory(string path)
        {
            if (isFileSystemRunning())
            {
                Directory.Delete(path);
                CustomConsole.SuccessLog("Deleted Directory in " + path);
            }
            else
            {
                InitialiseFileSystem();
                DeleteDirectory(path);
            }
        }

        public static void InitialiseFileSystem()
        {
            CustomConsole.WarningLog("Booting file system because it was not booted before!");
            Kernel.fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(Kernel.fs);
        }

        public static bool isFileSystemRunning()
        {
            if(Kernel.fs == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

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

        public static bool fileExists(string path)
        {
            if (isFileSystemRunning())
            {
                bool fileExists = File.Exists(path);
                return fileExists;
            }
            else
            {
                InitialiseFileSystem();
                return fileExists(path);
            }
        }

        public static FileStream CreateFile(string path)
        {
            if (isFileSystemRunning())
            {
                FileStream stream = File.Create(path);
                stream.Close();
                CustomConsole.SuccessLog("Created a file at " + path);
                return stream;
            }
            else
            {
                InitialiseFileSystem();
                return CreateFile(path);
            }
        }

        public static void CreateTextDocument(string path, string[] content)
        {
            if (isFileSystemRunning())
            {
                using(FileStream fs = File.Create(path))
                {
                    foreach (string item in content)
                    {
                        AddText(fs, item);
                    }
                    fs.Close();
                }
                CustomConsole.SuccessLog("Created Text Document at " + path);
            }
            else
            {
                InitialiseFileSystem();
                CreateTextDocument(path, content);
            }
        }

        public static void EditTextDocument(string path, string[] content)
        {
            if (isFileSystemRunning())
            {
                if (fileExists(path))
                {
                    File.WriteAllLinesAsync(path, content);
                    CustomConsole.SuccessLog("Created Text Document at " + path);
                }
                else
                {
                    //Create the text document and place the content inside there
                    CreateTextDocument(path, content);
                }
            }
            else
            {
                InitialiseFileSystem();
                CreateTextDocument(path, content);
            }
        }

        public static void EditTextDocument(string path, string content)
        {
            if (isFileSystemRunning())
            {
                if (fileExists(path))
                {
                    File.WriteAllTextAsync(path, content);
                    CustomConsole.SuccessLog("Created Text Document at " + path);
                }
                else
                {
                    //Create the text document and place the content inside there
                    CreateTextDocument(path, content);
                }
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
                using(FileStream fs = File.Create(path))
                {
                    AddText(fs, content);
                    fs.Close();
                }
                CustomConsole.SuccessLog("Created Text Document at " + path);
            }
            else
            {
                InitialiseFileSystem();
                CreateTextDocument(path, content);
            }
        }

        public static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        public static string ReadText(string path)
        {
            if (isFileSystemRunning())
            {
                string data = "";
                using (FileStream fs = File.OpenRead(path))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while(fs.Read(b, 0, b.Length) > 0)
                    {
                        data += temp.GetString(b);
                    }
                    fs.Close();
                }
                return data;
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
                List<String> data = new List<string>();
                using (FileStream fs = File.OpenRead(path))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while(fs.Read(b, 0, b.Length) > 0)
                    {
                        data.Add(temp.GetString(b));
                    }
                    fs.Close();
                }
                return data.ToArray();
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

        public static bool DirectoryExists(string path)
        {
            if (isFileSystemRunning())
            {
                return Directory.Exists(path);
            }
            else
            {
                InitialiseFileSystem();
                return DirectoryExists(path);
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

        public static byte[] ReadAllBytes(string path)
        {
            if (isFileSystemRunning())
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                InitialiseFileSystem();
                return ReadAllBytes(path);
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

using System;
using System.Collections.Generic;
using System.Text;

namespace togos.API.Commands
{
    public static class fileRead
    {
        public static void Run(string path)
        {
            string readFile = FileExplorer.ReadText(path);
            CustomConsole.WarningLog(readFile);
        }
    }
}

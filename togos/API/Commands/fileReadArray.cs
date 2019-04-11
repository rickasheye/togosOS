using System;
using System.Collections.Generic;
using System.Text;

namespace togos.API.Commands
{
    public static class fileReadArray
    {
        public static void Run(string file)
        {
            string[] fileRead = FileExplorer.ReadTextArray(file);
            foreach (string item in fileRead)
            {
                CustomConsole.WarningLog(item);
            }
        }
    }
}

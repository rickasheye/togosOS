using System;
using System.Collections.Generic;
using System.Text;

namespace togos.API.Commands
{
    public static class fileDelete
    {
        public static void Run(string path)
        {
            FileExplorer.DeleteFile(path);
        }
    }
}

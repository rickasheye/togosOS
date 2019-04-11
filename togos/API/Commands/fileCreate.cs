using System;
using System.Collections.Generic;
using System.Text;

namespace togos.API.Commands
{
    public static class fileCreate
    {

        public static void Run(string filepath)
        {
            FileExplorer.CreateFile(filepath);
        }
    }
}

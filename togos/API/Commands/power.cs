using System;
using System.Collections.Generic;
using System.Text;

namespace togos.API.Commands
{
    public static class power
    {

        public static void Run(string args)
        {
            switch (args)
            {
                case "shutdown":
                    Kernel.KernelShutdown();
                    break;
                case "restart":
                    Kernel.KernelRestart();
                    break;
            }
        }
    }
}

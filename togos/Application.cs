using System;
using System.Collections.Generic;
using System.Text;

namespace togos
{
    public interface Application
    {
        string Name { get; }
        string Path { get; }
        bool startup { get; }
    }
}

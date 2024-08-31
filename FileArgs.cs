using System;

namespace Delegates_Events
{
    public class FileArgs : EventArgs
    {
        public string Name { get; }

        public FileArgs(string name)
        {
            Name = name;
        }
    }
}

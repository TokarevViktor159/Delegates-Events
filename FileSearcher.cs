using System;
using System.IO;

namespace Delegates_Events
{
    public class FileSearcher
    {
        public event EventHandler<FileArgs> FileFound;

        private bool _cancel = false;

        public void Search(string directory_path)
        {
            _cancel = false;
            if (!Directory.Exists(directory_path))
                throw new DirectoryNotFoundException("Directory does not exist.");

            foreach (string file_path in Directory.GetFiles(directory_path))
            {
                if (_cancel) break;
                OnFileFound(new FileArgs(file_path));
            }
        }

        public void CancelSearch() => _cancel = true;

        protected virtual void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }
    }

    public class FileArgs : EventArgs
    {
        public string Name { get; }

        public FileArgs(string name)
        {
            Name = name;
        }
    }
}

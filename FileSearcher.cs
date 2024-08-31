using System;
using System.IO;

namespace Delegates_Events
{
    public class FileSearcher
    {
        public event EventHandler<FileArgs> FileFound;

        public bool Cancel { get; set; } = false;


        private void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }
        public void Search(string directoryPath)
        {
            Cancel = false;
            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException("Directory does not exist.");

            foreach (string filePath in Directory.GetFiles(directoryPath))
            {
                if (Cancel) break;
                OnFileFound(new FileArgs(filePath));
            }
        }
    }
}

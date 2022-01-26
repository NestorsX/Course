using Microsoft.Win32;
using System.IO;

namespace TextProcessor
{
    public class FileController
    {
        private string? _filePath;
        private readonly OpenFileDialog _openFileDialog;
        private readonly SaveFileDialog _saveFileDialog;

        public FileController()
        {
            _filePath = null;
            _openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt"
            };

            _saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt"
            };
        }

        public string? OpenFile()
        {
            if (_openFileDialog.ShowDialog() == true)
            {
                _filePath = _openFileDialog.FileName;
                return File.ReadAllText(_filePath);
            }

            return null;
        }

        public void SaveFile(string text)
        {
            if (_filePath == null)
            {
                SaveFileAs(text);
            }
            else
            {
                File.WriteAllText(_filePath, text);
            }
        }

        public void SaveFileAs(string text)
        {
            if (_saveFileDialog.ShowDialog() == true)
            {
                _filePath = _saveFileDialog.FileName;
                File.WriteAllText(_filePath, text);
            }
        }
    }
}

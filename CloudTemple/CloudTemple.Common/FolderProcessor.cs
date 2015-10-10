namespace CloudTemple.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Microsoft.Win32;

    public static class FolderProcessor
    {
        private const string DirectorySearchPattern = @"\d{1,2}-\w{2,3}-\d{4}";

        public static IEnumerable<DirectoryInfo> GetDirectoriesByPattern(
            string dirPath, string pattern = DirectorySearchPattern)
        {
            var dir = new DirectoryInfo(dirPath);
            var containingDirs = dir.GetDirectories().Where(d => Regex.IsMatch(d.Name, pattern));
            return containingDirs;
        }

        public static void CreateDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        public static void OpenDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                CreateDirectory(dirPath);
            }

            Process.Start(dirPath);
        }

        public static DateTime ParseDateTimeSafely(string text)
        {
            return string.IsNullOrEmpty(text) ? DateTime.Now : DateTime.Parse(text);
        }


        /// <summary>
        /// Sets the file dialog filter. Useful for WPF.
        /// </summary>
        /// <param name="dialog">The dialog.</param>
        /// <param name="extension">The extension.</param>
        /// <param name="defaultFileName">Default name of the file.</param>
        public static void SetFileDialogFilter(FileDialog dialog, string extension, string defaultFileName = null)
        {
            switch (extension)
            {
                case "zip":
                    {
                        dialog.DefaultExt = ".zip";
                        dialog.Filter = "Zip File (.zip)|*.zip";
                        break;
                    }

                case "xlsx":
                    {
                        dialog.DefaultExt = ".xlsx";
                        dialog.Filter = "Excel File (.xlsx)|*.xlsx";
                        break;
                    }

                case "pdf":
                    {
                        dialog.DefaultExt = ".pdf";
                        dialog.Filter = "Pdf File (.pdf)|*.pdf";
                        break;
                    }

                case "xml":
                    {
                        dialog.DefaultExt = ".xml";
                        dialog.Filter = "XML File (.xml)|*.xml";
                        break;
                    }

                default:
                    {
                        dialog.FileName = "All files (*.*)|*.*";
                        break;
                    }
            }

            if (!string.IsNullOrEmpty(defaultFileName))
            {
                dialog.FileName = defaultFileName;
            }
        }
    }
}
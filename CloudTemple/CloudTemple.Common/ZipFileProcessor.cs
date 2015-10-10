namespace CloudTemple.Common
{
    using System.Collections.Generic;
    using Ionic.Zip;

    public static class ZipFileProcessor
    {
        public static void ExtractZipFile(string sourceFile, string destinationDirectory)
        {
            using (var zip = ZipFile.Read(sourceFile))
            {
                foreach (var file in zip)
                {
                    file.Extract(destinationDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        public static void CreateZipArchiveFromFiles(string archiveName, IEnumerable<string> filesToZip)
        {
            using (var zip = new ZipFile(archiveName))
            {
                foreach (var file in filesToZip)
                {
                    zip.AddFile(file);
                }

                zip.Save();
            }
        }

        public static void CreateZipArchiveFromDirectory(string archiveName, string directoryToZip)
        {
            using (var zip = new ZipFile(archiveName))
            {
                zip.AddDirectory(directoryToZip);
                zip.Save();
            }
        }
    }
}
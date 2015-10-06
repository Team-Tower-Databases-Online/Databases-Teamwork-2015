namespace CloudTemple.Common
{
    using Ionic.Zip;

    public class ZipFileExtractor
    {
        public void Extract(string sourceFile, string destinationDirectory)
        {
            using (var zipFile = ZipFile.Read(sourceFile))
            {
                foreach (var item in zipFile)
                {
                    item.Extract(destinationDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
}
using System;
using System.IO;
using System.IO.Compression;

namespace Core.Const
{   
    public class FileUploader
    {
        // The folder where the files will be uploaded
        private string uploadFolder;

        // The constructor that takes the upload folder as a parameter
        public FileUploader(string uploadFolder)
        {
            this.uploadFolder = uploadFolder;
        }

        // The method that uploads a file to the upload folder
        public void UploadFile(string filePath)
        {
            try
            {

            // Get the file name from the file path
            string fileName = Path.GetFileName(filePath);

            // Get the destination path in the upload folder
            string destPath = Path.Combine(uploadFolder, fileName);

            // Check if a file with the same name already exists in the upload folder
            if (File.Exists(destPath))
            {
                // Replace the existing file with the new file
                File.Replace(filePath, destPath, null);
            }
            else
            {
                // Copy the new file to the upload folder
                File.Copy(filePath, destPath);
            }

            // Compress the file to reduce its size
            CompressFile(destPath);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // The method that compresses a file using gzip format
        private void CompressFile(string filePath)
        {
            try
            {

           
            // Get the compressed file name by adding .gz extension
            string compressedFilePath = filePath + ".gz";

            // Create a file stream for reading the original file
            using (FileStream sourceStream = File.OpenRead(filePath))
            {
                // Create a file stream for writing the compressed file
                using (FileStream destStream = File.Create(compressedFilePath))
                {
                    // Create a gzip stream for compressing the data
                    using (GZipStream compressionStream = new GZipStream(destStream, CompressionMode.Compress))
                    {
                        // Copy the data from the source stream to the compression stream
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }

            // Delete the original file
            File.Delete(filePath);
                 }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

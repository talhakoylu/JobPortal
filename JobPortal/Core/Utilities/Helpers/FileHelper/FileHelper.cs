using Microsoft.AspNetCore.Http;
using System.IO;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper
    {
        public static string Add(IFormFile file, string filePath)
        {
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Move(sourcePath, filePath);
            return filePath;
        }

        public static void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string Update(string oldFilePath, IFormFile file, string newFilePath)
        {
            if (newFilePath.Length > 0)
            {
                using (var stream = new FileStream(newFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(oldFilePath);
            return newFilePath;
        }
    }
}

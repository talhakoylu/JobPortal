using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Core.Constants.Messages;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper
    {
        public static IDataResult<string> Add(IFormFile file, string filePath)
        {
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            else
            {
                return new ErrorDataResult<string>(Messages.FileHelper.FileUploadError);
            }

            File.Move(sourcePath, filePath);
            return new SuccessDataResult<string>(filePath, Messages.FileHelper.FileUploadSuccess);
        }

        public static async Task<IDataResult<string>> AddAsync(IFormFile file, string filePath)
        {
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                
            }
            else
            {
                return new ErrorDataResult<string>(Messages.FileHelper.FileUploadError);
            }

            File.Move(sourcePath, filePath);
            return new SuccessDataResult<string>(filePath, Messages.FileHelper.FileUploadSuccess);
        }

        public static IResult Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return new SuccessResult(Messages.FileHelper.FileDeleteSuccess);
            }

            return new ErrorResult(Messages.FileHelper.FileNotFoundError);
        }
        
        public static async Task<IResult> DeleteAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
                return new SuccessResult(Messages.FileHelper.FileDeleteSuccess);
            }

            return new ErrorResult(Messages.FileHelper.FileNotFoundError);
        }

        public static IDataResult<string> Update(string oldFilePath, IFormFile file, string newFilePath)
        {
            if (newFilePath.Length > 0)
            {
                using (var stream = new FileStream(newFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            else
            {
                return new ErrorDataResult<string>(Messages.FileHelper.FileUpdateError);
            }

            File.Delete(oldFilePath);
            return new SuccessDataResult<string>(newFilePath, Messages.FileHelper.FileUpdateSuccess);
        }
        public static async Task<IDataResult<string>> UpdateAsync(string oldFilePath, IFormFile file, string newFilePath)
        {
            if (newFilePath.Length > 0)
            {
                using (var stream = new FileStream(newFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            else
            {
                return new ErrorDataResult<string>(Messages.FileHelper.FileUploadError);
            }

            File.Delete(oldFilePath);
            return new SuccessDataResult<string>(newFilePath, Messages.FileHelper.FileUpdateSuccess);
        }
    }
}

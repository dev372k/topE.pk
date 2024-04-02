using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Commons;
namespace BL.Services
{
    public interface IFileService
    {
        Task<string> SaveImage(byte[] imageData);
    }
    public class FileService : IFileService
    {
        public async Task<string> SaveImage(byte[] imageData)
        {
            var filename = Path.Combine(PathConstants.IMAGEPATH, $"{Guid.NewGuid()}.jpeg");
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);

            await File.WriteAllBytesAsync(filePath, imageData);

            return filename;
        }
    }
}

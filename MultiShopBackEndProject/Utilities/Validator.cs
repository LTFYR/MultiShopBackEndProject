using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Utilities
{
    public static class Validator
    {
        public static async Task<string> FileCreator(this IFormFile formFile,string root, string folder)
        {
            string name = string.Concat(Guid.NewGuid(), formFile.FileName);
            string path = Path.Combine(root, folder);
            string file = Path.Combine(path, name);
            try
            {
                using(FileStream fileStream = new FileStream(file, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
            }
            catch (Exception)
            {

                throw new FileLoadException();
            }
            return name;    
        }
        public static bool ImageIsOk(this IFormFile file,int MB)
        {
            return file.Length / 1024 / 1024 < MB && file.ContentType.Contains("image/");
        }
        public static void Delete(string root, string folder, string image)
        {
            string path = Path.Combine(root, folder, image);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}

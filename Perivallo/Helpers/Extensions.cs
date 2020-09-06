using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Helpers
{
    public static class Extensions
    {
        public enum Role
        {
            Admin,
            Moderator,
            User
        }

        public static bool isImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        public static bool MaxLength(this IFormFile file, int storage)
        {
            return file.Length / 1024 >= storage;
        }

        public async static Task<string> SaveImg(this IFormFile file, string root, string folder)
        {
            string path = Path.Combine(root, folder);
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string resultPath = Path.Combine(path, fileName);
            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }

        public static void DeleteImg(string root, string folder, string image)
        {
            string filePath = Path.Combine(root, folder, image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
    }
}

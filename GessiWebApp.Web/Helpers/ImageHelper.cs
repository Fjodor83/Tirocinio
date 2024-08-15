// GessiWebApp.Web/Helpers/ImageHelper.cs
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

namespace GessiWebApp.Web.Helpers
{
    public static class ImageHelper
    {
        public static async Task<string> SaveImageAsync(Stream imageStream, string wwwrootPath, string folderPath)
        {
            var fileName = $"{Guid.NewGuid()}.jpg";
            var filePath = Path.Combine(wwwrootPath, folderPath, fileName);

            using (var image = await Image.LoadAsync(imageStream))
            {
                image.Mutate(x => x.Resize(800, 0));
                await image.SaveAsJpegAsync(filePath);
            }

            return Path.Combine(folderPath, fileName);
        }

        public static async Task DeleteImageAsync(string imagePath, string wwwrootPath)
        {
            var fullPath = Path.Combine(wwwrootPath, imagePath);
            if (File.Exists(fullPath))
            {
                await Task.Run(() => File.Delete(fullPath));
            }
        }
    }
}
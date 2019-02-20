using SolsticeAPI.Services.Interfaces;
using System;
using System.Drawing;
using System.IO;

namespace SolsticeAPI.Services.Implementation
{
    public class FileService : IFileService
    {
        private const string PATH = "/ProfileImages";

        public void SaveImage(string base64ImageString, string contactName)
        {

            byte[] bytes = Convert.FromBase64String(base64ImageString);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            var path = $"{PATH}/{contactName}/";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            image.Save(path + "ProfileImage.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}

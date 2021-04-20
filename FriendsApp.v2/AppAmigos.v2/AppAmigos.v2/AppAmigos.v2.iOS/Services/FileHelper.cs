using AppAmigos.v2.iOS.Services;
using AppAmigos.v2.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace AppAmigos.v2.iOS.Services
{
    class FileHelper : IFileHelper
    {

        public string GetLocalFilePath(string fileName)
        {
            string docFolder =
                Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string libFolder =
                Path.Combine(docFolder, "..", "Database");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, fileName);
        }
    }
}
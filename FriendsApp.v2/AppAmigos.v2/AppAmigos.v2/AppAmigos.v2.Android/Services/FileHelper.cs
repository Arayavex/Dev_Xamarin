using AppAmigos.v2.Droid.Services;
using AppAmigos.v2.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace AppAmigos.v2.Droid.Services
{
    public class FileHelper : IFileHelper
    {

        public string GetLocalFilePath(string fileName)
        {
            //Accede a cada folder especial personal
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Aviaticketv1
{
    static class Uri_Element
    {
        public static string GetDirectory_files()
        {
            string appFolderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string resourcesFolderPath = Directory.GetParent(appFolderPath).Parent.FullName;
            string path = Directory.GetParent(resourcesFolderPath).FullName;
            return path;
        }
    }
}

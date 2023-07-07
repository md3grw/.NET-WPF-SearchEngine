using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SearchEngine.FileManagement
{
    internal class Logger
    {
        static readonly string filePath = "C:\\Users\\" + Environment.UserName + "\\Documents\\SearchEngine\\log.txt";

        public Logger() 
        {
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\SearchEngine";

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if (!File.Exists(filePath)) File.Create(filePath).Close();
        }

        static public void Log(string message) 
        {
            System.IO.File.WriteAllText(filePath, message);
        }
    }
}

﻿using System;
using System.IO;
using CoreGame.Strategies.Interfaces;

namespace DefaultNamespace
{
    public class DateFileNamingStrategy : FileNamingStrategy
    {
        public string CreateFile(string directoryPath)
        {

            string date = DateTime.Now.ToString("dddd, dd MMMM yyyy HH;mm;ss");
            //date = date.Replace(":", "'");
            
            string filePath = $"{directoryPath}data ({date}).csv";



            if(File.Exists(filePath)) throw new Exception("Somehow, filename already exist");

            return filePath;
        }
    }
}
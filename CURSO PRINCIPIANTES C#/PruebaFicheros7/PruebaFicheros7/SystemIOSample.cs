using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PruebaFicheros7
{
    public static class SystemIOSample
    {
        public static void SampleFile()
        {
            if (File.Exists("C:\\Users\\leila.fraile\\Desktop\\MiFichero.txt"))
            {
                //el fichero existe
            }
            else
            {
                //el fichero no existe
            }
		}

        public static void SampleDirectory()
        {
            Directory.Move("C:\\Users\\leila.fraile\\Desktop\\MiFichero.txt", "D:\\");

		}

        public static void FileInfoDirectoryInfoSample()
        {
            FileInfo fileInfo = new FileInfo("C:\\Users\\leila.fraile\\Desktop\\MiFichero.txt");
            DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Users\\leila.fraile\\Desktop");
        }

        public static void WorkingWithFile()
        {
            //Stream
            //MemoryStream
            //StreamWriter
            //StreamReader
            //FileStream
            //StreamWriter writer = new StreamWriter("C:\\Users\\leila.fraile\\Desktop\\MiFichero.txt");
            //StreamReader reader = new StreamReader("C:\\Users\\leila.fraile\\Desktop\\MiFichero.txt");
            //FileStream fileStream = new FileStream("C:\\Users\\leila.fraile\\Desktop\\MiFichero.txt", FileMode.OpenOrCreate);
            FileStream fileStr = new FileStream("C:\\Users\\leila.fraile\\Desktop\\MiFichero.txt", FileMode.OpenOrCreate);
            //mueve el cursor al inicio
            fileStr.Seek(0, SeekOrigin.Begin);
            fileStr.Close();
		}
    }
}

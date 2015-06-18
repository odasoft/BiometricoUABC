using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlayerUABC
{
    class DirectoryData
    {
        /// <summary>
        /// return a list of PATH's from the directory 
        /// </summary>
        /// <returns></returns>
        public static List<string> getSongsInDirectory(string directoryPATH, string dataType)
        {
            List<string> listOfPATH = new List<string>();
            if (Directory.Exists(directoryPATH))
            {
                string[] songsDir = Directory.GetFiles(directoryPATH, "*." + dataType);
                for (int i = 0; i < getNumberOfSongs(directoryPATH, dataType); i++)
                {
                    listOfPATH.Add(songsDir[i]);
                }
            }
            else
            {
                Directory.CreateDirectory(directoryPATH);
            }
            return listOfPATH;
        }

        /// <summary>
        /// return the number song in the directory
        /// </summary>
        /// <returns></returns>
        public static int getNumberOfSongs(string directoryPATH, string dataType)
        {
            string[] songsDir = Directory.GetFiles(directoryPATH, "*." + dataType);
            return songsDir.Length;
        }
    }
}
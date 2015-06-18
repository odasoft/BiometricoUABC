using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace PlayerUABC
{
    class Library
    {
        public bool isRepeted = false;
        public string pathSong;
        const string libraryPath = "../../Library/";
        public void addNewSongToLibrary()
        {
            List<string> songsInLibrary = DirectoryData.getSongsInDirectory(libraryPath, "mp3");
            pathSong = OpenFile.openDialogFile();
            if (!pathSong.Equals(""))
            {
                int potition = 0;
                for (int i = 0; i < pathSong.Length; i++)
                {
                    if (pathSong.Substring(i, 1).Equals("\\"))
                    {
                        potition = i + 1;
                    }
                }
                string songName = pathSong.Substring(potition, pathSong.Length - potition);//name of the song
                for (int j = 0; j < songsInLibrary.LongCount(); j++)
                {
                    if (songsInLibrary.Contains(libraryPath + songName))
                    {
                        isRepeted = true;
                    }
                }
                if (!isRepeted)
                {
                    File.Copy(pathSong, libraryPath + songName, true);
                }
                else
                    MessageBox.Show("The song is already in the library!");

            }

        }
    }
}
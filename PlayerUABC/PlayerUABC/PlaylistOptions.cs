using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayerUABC
{
    class PlaylistOptions
    {
        const string directoryPATH = "../../Playlist/";//path from playlists

        /// <summary>
        /// create a new playlist
        /// </summary>
        public static void createNewPlaylist()
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            List<string> listOfPlaylist = DirectoryData.getSongsInDirectory(directoryPATH, "dat");
            PlaylistInfo dataSave = new PlaylistInfo();
            FileStream file;
            if (listOfPlaylist.LongCount() == 0) //create a new playlist is there is no one
            {
                file = File.Create("../../Playlist/Playlist1.dat");
            }
            else
            {
                int intLastSong = System.Int32.Parse(listOfPlaylist.Last().ElementAt(23).ToString());
                intLastSong++;
                file = File.Create(directoryPATH+"Playlist"+intLastSong.ToString()+".dat");
            }
            bf.Serialize(file, dataSave);
            file.Close();

        }
        /// <summary>
        /// Add a new son in a list
        /// </summary>
        /// <param name="PathfromSong">path from the song</param>
        /// <param name="numberOfList">number of the playlist</param>
        public static void addNewSongToPlaylist(string PathfromSong, int numberOfList)
        {
            PlaylistInfo dataSave = new PlaylistInfo();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(directoryPATH+"Playlist"+numberOfList.ToString()+".dat",FileMode.Open);
            bool isRepeted = false;
            dataSave = (PlaylistInfo)bf.Deserialize(file);
            for (int i = 0; i < dataSave.paths.LongCount(); i++)
            {
                if (dataSave.paths.Contains(PathfromSong))
                {
                    isRepeted = true;
                }
            }
            if (!isRepeted)
            {
                dataSave.paths.Add(PathfromSong);
                file.Close();
                BinaryFormatter bf2 = new BinaryFormatter();
                FileStream file2 = File.Create(directoryPATH + "Playlist" + numberOfList.ToString() + ".dat");
                bf2.Serialize(file2, dataSave);
            }
            else
                MessageBox.Show("The item is already in the playlist!");

        }
        /// <summary>
        /// return the list of songs in the index selected
        /// </summary>
        /// <param name="numberOfList">number of the playlist</param>
        /// <returns></returns>
        public static List<string> getSongsInList(int numberOfList)
        {
            PlaylistInfo dataSave = new PlaylistInfo();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(directoryPATH + "Playlist" + numberOfList.ToString() + ".dat", FileMode.Open);
            dataSave = (PlaylistInfo)bf.Deserialize(file);
            List<string> songsInPlaylis = dataSave.paths;
            file.Close();
            return songsInPlaylis;
        }
        //serializable class
        [Serializable]
        public class PlaylistInfo
        {
            public List<string> paths = new List<string>();
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PlayerUABC
{

    class WriteXML
    {
        public WriteXML()
        {

        }

        /*
        private static int nextSongID()
        {
            XDocument xdoc = XDocument.Load("../../Song.xml");

            return Convert.ToInt32(
                    (from data in xdoc.Descendants("song")
                     orderby Convert.ToInt32(data.Attribute("id").Value) descending
                     select data.Attribute("id").Value).FirstOrDefault()
                    ) + 1;
        }

        private static int nextPlaylistID()
        {
            XDocument xdoc = XDocument.Load("../../Playlist.xml");

            return Convert.ToInt32(
                    (from data in xdoc.Descendants("playlist")
                     orderby Convert.ToInt32(data.Attribute("id").Value) descending
                     select data.Attribute("id").Value).FirstOrDefault()
                    ) + 1;
        }

        public static void saveSong(Song song)
        {
            XDocument xdoc = XDocument.Load("../../Song.xml");

            if (song.id > 0)
            {
                XElement oldSong = xdoc.Descendants("song").Where(x => x.Attribute("id").Value.Equals(song.id.ToString())).FirstOrDefault();
                if (oldSong != null)
                {
                    oldSong.SetElementValue("title", song.title);
                    oldSong.SetElementValue("artist", song.artist);
                    oldSong.SetElementValue("album", song.album);
                    oldSong.SetElementValue("year", song.year);

                    xdoc.Save("../../Song.xml");
                }
            }
            else
            {
                XElement newSong = new XElement("song", new XAttribute("id", nextSongID()));

                newSong.Add(new XElement("title", song.title));
                newSong.Add(new XElement("artist", song.artist));
                newSong.Add(new XElement("album", song.album));
                newSong.Add(new XElement("year", song.year));
                xdoc.Element("list").Add(newSong);
                xdoc.Save("../../Song.xml");
            }
        }

        public static void savePlaylist(Playlist playlist)
        {
            XDocument xdoc = XDocument.Load("../../Playlist.xml");

            if (playlist.id > 0)
            {
                XElement updatePlaylist = xdoc.Descendants("playlist").Where(x => x.Attribute("id").Value.Equals(playlist.id.ToString())).FirstOrDefault();
                if (updatePlaylist != null)
                {
                    updatePlaylist.SetElementValue("name", playlist.name);
                    xdoc.Save("../../Playlist.xml");
                }
            }
            else
            {
                XElement newPlaylist = new XElement("playlist", new XAttribute("id", nextPlaylistID()));

                newPlaylist.Add(new XElement("name", playlist.name));
                for (int i = 0; i < playlist.list.Count; i++)
                    newPlaylist.Add(new XElement("song", playlist.list[i]));

                xdoc.Element("list").Add(newPlaylist);
                xdoc.Save("../../Playlist.xml");
            }
        }

        public static void deleteSong(int id)
        {
            XDocument xdoc = XDocument.Load("../../Song.xml");
            xdoc.Element("list").Elements("song").Where(x => x.Attribute("id").Value.Equals(id.ToString())).Remove();
            xdoc.Save("../../Song.xml");
        }

        public static void deletePlaylist(int id)
        {
            XDocument xdoc = XDocument.Load("../../Playlist.xml");
            xdoc.Element("list").Elements("playlist").Where(x => x.Attribute("id").Value.Equals(id.ToString())).Remove();
            xdoc.Save("../../Playlist.xml");
        }

        public static void deleteSongPlaylist(int playlistID, int songID)
        {
            XDocument xdoc = XDocument.Load("../../Playlist.xml");
            xdoc.Element("list").Elements("playlist").Where(x => x.Attribute("id").Value.Equals(playlistID.ToString())).Elements("song").Where(x => x.Value.Equals(songID.ToString())).Remove();
            xdoc.Save("../../Playlist.xml");
        }

        public static void addSongPlaylist(int playlistID, int songID)
        {
            XDocument xdoc = XDocument.Load("../../Playlist.xml");
            XElement updatePlaylist = xdoc.Descendants("playlist").Where(x => x.Attribute("id").Value.Equals(playlistID.ToString())).FirstOrDefault();
            if (updatePlaylist != null)
            {
                updatePlaylist.Add(new XElement("song", songID));
                xdoc.Element("list").Add(updatePlaylist);
                xdoc.Save("../../Playlist.xml");
            }
            xdoc.Save("../../Playlist.xml");
        }
        */
    }
}
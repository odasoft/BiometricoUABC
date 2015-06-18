using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace PlayerUABC
{
    class ReadXML
    {
        public ReadXML()
        {

        }
        /*
        public static Song findSong(int x)
        {
            XDocument xdoc = XDocument.Load("../../Song.xml");

            return (from data in xdoc.Descendants("song")
                    where data.Attribute("id").Value.Equals(x.ToString())
                    select new Song
                    {
                        id = (int)data.Attribute("id"),
                        title = (string)data.Element("title"),
                        artist = (string)data.Element("artist"),
                        year = (string)data.Element("year")
                    }).FirstOrDefault();

        }

        public static List<Song> getSongList()
        {
            XDocument xdoc = XDocument.Load("../../Song.xml");

            return (from data in xdoc.Descendants("song")
                    select new Song
                    {
                        id = (int)data.Attribute("id"),
                        title = data.Element("title").Value,
                        artist = data.Element("artist").Value,
                        year = data.Element("year").Value
                    }).ToList();
        }
        
        public static void findPlaylist(Playlist playlist)
        {
            XDocument xdoc = XDocument.Load("../../Playlist.xml");
            playlist.name = xdoc.Descendants("playlist").Where(x => x.Attribute("id").Value.Equals(playlist.id.ToString())).Select(x => x.Element("name").Value).FirstOrDefault();

            var songs = xdoc.Descendants("playlist").Where(x => x.Attribute("id").Value.Equals(playlist.id.ToString())).Elements("song");
            foreach (var song in songs)
            {
                playlist.list.Add((int)song);
            }
        }
         * */
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlayerUABC
{
    class SongData
    {
        private byte[] buffer;
        private string title;
        private string artist;
        private string album;
        private string year;
        private string comment;
        private FileStream fs;

        public SongData(string songPath)
        {
            buffer = new byte[128];
            fs = new FileStream(songPath, FileMode.Open);
            fs.Seek(-128, SeekOrigin.End);
            fs.Read(buffer, 0, 128);
            fs.Close();

            Encoding encode = new ASCIIEncoding();
            string id3 = encode.GetString(buffer);

            if (id3.Substring(0, 3).Equals("TAG"))
            {
                title = id3.Substring(3, 30).TrimEnd();
                artist = id3.Substring(33, 30).TrimEnd();
                album = id3.Substring(63, 30).TrimEnd();
                year = id3.Substring(93, 4).TrimEnd();
                comment = id3.Substring(97, 28).TrimEnd();
            }
            else
            {
                title = "Undefined";
                artist = "Undefined";
                album = "Undefined";
                year = "Undefined";
                comment = "Undefined";
            }
            /*
            String sFlag = Encoding.Default.GetString(b, 0, 3);
            if (sFlag.Equals("TAG"))
            {
                Title = Encoding.Default.GetString(b, 3, 30);
                Singer = Encoding.Default.GetString(b, 33, 30);
                Album = Encoding.Default.GetString(b, 63, 30);
            }
            else
            {
                Title = "Undefined";
                Singer = "Undefined";
                Album = "Undefined";
            */

        }
        public string CleanInvalidXmlChars(string text)
        {
            // From xml spec valid chars: 
            // #x9 | #xA | #xD | [#x20-#xD7FF] | [#xE000-#xFFFD] | [#x10000-#x10FFFF]     
            // any Unicode character, excluding the surrogate blocks, FFFE, and FFFF. 
            string re = @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]";
            return Regex.Replace(text, re, "");
        }

        public string getTitle()
        {
            return CleanInvalidXmlChars(title);
        }

        public string getAlbum()
        {
            return CleanInvalidXmlChars(album);
        }

        public string getArtist()
        {
            return CleanInvalidXmlChars(artist);
        }

        public string getYear()
        {
            return CleanInvalidXmlChars(year);
        }

        public string getComment()
        {
            return CleanInvalidXmlChars(comment);
        }
    }
}

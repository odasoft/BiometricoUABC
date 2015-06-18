using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUABC
{
    class OpenFile
    {
         public static string openDialogFile() {
            Microsoft.Win32.OpenFileDialog File = new Microsoft.Win32.OpenFileDialog();
            File.Filter = "Music File (.mp3)|*.mp3";
            File.FilterIndex = 1;
            Nullable<bool> result = File.ShowDialog();
            if (result == true) {
                return File.FileName;
            }
            return "";
        }
    }
}

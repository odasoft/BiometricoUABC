using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlayerUABC
{
    class PlayerHandler
    {
        public static void InitPlayer(Slider sliderReproduccion ,MediaElement player)
        {
            sliderReproduccion.Minimum = 0;
            sliderReproduccion.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
            sliderReproduccion.Value = player.Position.TotalSeconds;
        }

        public static void InitTickControls(MediaElement player, string path) 
        {
            player.Stop();
            player.Source = new Uri(System.IO.Path.GetFullPath(path));
            player.Play();
        }

        public static void InitPlayControl(MediaElement player, string selectedSong)
        {
            player.Stop();
            player.Source = new Uri(System.IO.Path.GetFullPath(selectedSong));            
            selectedSong = "";
        }
    }
}

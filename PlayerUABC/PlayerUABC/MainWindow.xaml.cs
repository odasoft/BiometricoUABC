using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace PlayerUABC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSliderPlayer = false;
        private bool userIsDraggingSliderVolume = false;
        private List<string> libraryList;
        private string directoryPath = "../../Library/";
        private string selectedSong = "";
        private Boolean repeatSong = false;
        public MainWindow()
        {
            InitializeComponent();
            libraryList = DirectoryData.getSongsInDirectory(directoryPath, "mp3");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            refreshLibrary();
            if (libraryList.LongCount() != 0)
                player.Source = new Uri(System.IO.Path.GetFullPath(libraryList[0]));                                    
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((player.Source != null) && (player.NaturalDuration.HasTimeSpan) && (!userIsDraggingSliderPlayer))
            {
                PlayerHandler.InitPlayer(sliderReproduccion, player);
            }
            if(sliderReproduccion.Value == sliderReproduccion.Maximum)
            {

                string songpath = player.Source.AbsolutePath;
                songpath = songpath.Replace("%20", " ");
                int index = songList.Items.IndexOf(songpath);
                if (repeatSong) 
                {
                    PlayerHandler.InitTickControls(player, libraryList[index]);
                    repeatSong = false;
                }
                else if (index + 1 < songList.Items.Count)
                {
                    PlayerHandler.InitTickControls(player, libraryList[index + 1]);
                }
            }
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (player != null) && (player.Source != null);
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (selectedSong.Length > 0)
            {
                PlayerHandler.InitPlayControl(player, selectedSong);                
            }
            player.Play();
            mediaPlayerIsPlaying = true;
        }

        private void Previous_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (player != null) && (player.Source != null);
        }

        private void Previous_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string songpath = player.Source.AbsolutePath;
            songpath = songpath.Replace("%20", " ");
            int index = songList.Items.IndexOf(songpath);
            if (index - 1 >= 0) 
            {
                player.Stop();
                player.Source = new Uri(System.IO.Path.GetFullPath(libraryList[index - 1]));
                player.Play();
            }
            mediaPlayerIsPlaying = true;            
        }

        private void Next_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (player != null) && (player.Source != null);
        }

        private void Next_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string songpath = player.Source.AbsolutePath;
            songpath = songpath.Replace("%20"," ");
            Console.Write(songpath);
            int index = songList.Items.IndexOf(songpath);
            if (index + 1 < songList.Items.Count)
            {
                player.Stop();
                player.Source = new Uri(System.IO.Path.GetFullPath(libraryList[index + 1]));
                player.Play();
            }
            mediaPlayerIsPlaying = true;
        }

        private void botonVolumen_MouseEnter(object sender, RoutedEventArgs e)
        {
            sliderVolumen.Visibility = System.Windows.Visibility.Visible;            
        }

        private void botonVolumen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void botonVolumen_MouseLeave(object sender, MouseEventArgs e)
        {
            sliderVolumen.Visibility = System.Windows.Visibility.Hidden;
        }

        private void sliderVolumen_MouseEnter(object sender, MouseEventArgs e)
        {
            sliderVolumen.Visibility = System.Windows.Visibility.Visible;
        }

        private void sliderVolumen_MouseLeave(object sender, MouseEventArgs e)
        {
            sliderVolumen.Visibility = System.Windows.Visibility.Hidden;
        }

        private void sliderVolumen_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSliderVolume = true;            
        }

        private void sliderReproduccion_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {            

        }

        private void sliderReproduccion_DragStarted(object sender, DragStartedEventArgs e) 
        {
            userIsDraggingSliderPlayer = true;
        }

        private void sliderReproduccion_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSliderPlayer = false;
            player.Position = TimeSpan.FromSeconds(sliderReproduccion.Value);
        }

        private void sliderVolumen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = sliderVolumen.Value * 0.1;
            Console.Write("\n");
            Console.Write("Player Volume: " + player.Volume);
            Console.Write("  Slider Volume: " + sliderVolumen.Value);
        }

        private void songList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void botonNuevaLista_Click(object sender, RoutedEventArgs e)
        {
            Library lib = new Library();
            lib.addNewSongToLibrary();
            refreshLibrary();
            if (!lib.isRepeted)
            {
                addSong(lib.pathSong);
            }
        }

        private void addSong(String path)
        {
            SongData data = new SongData(path);

            Song song = new Song()
            {
                title = data.getTitle(),
                artist = data.getArtist(),
                album = data.getAlbum(),
                year = data.getYear()
            };

            //WriteXML.saveSong(song);
        }

        private void refreshLibrary() {
            songList.Items.Clear();
            libraryList = DirectoryData.getSongsInDirectory(directoryPath, "mp3");
            for (int i = 0; i < libraryList.LongCount(); i++)
            {
                SongData actualSong = new SongData(libraryList[i]);
                //mediaAux.Source = new Uri(System.IO.Path.GetFullPath(libraryList[i]));
                //songList.Items.Add(actualSong.getTitle());
                songList.Items.Add(new Uri(System.IO.Path.GetFullPath(libraryList[i])));
            }
        }

        private void songList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Console.Write(songList.SelectedValue.ToString());
            string song = songList.SelectedValue.ToString();
            int index = songList.Items.IndexOf(song);
            player.Source = new Uri(System.IO.Path.GetFullPath(libraryList[index]));
            player.Play();
        }

        private void songList_MouseUp(object sender, MouseButtonEventArgs e)
        {            
            string song = songList.SelectedValue.ToString();
            int index = songList.Items.IndexOf(song);
            selectedSong = System.IO.Path.GetFullPath(libraryList[index]);
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void botonAleatorio_Click(object sender, RoutedEventArgs e)
        {            
            int n = songList.Items.Count;
            Random random = new Random();
            while( n > 1)
            {
                n--;
                int k = random.Next(n+1);                
                object value = songList.Items.GetItemAt(k);
                string value2 = libraryList[k];
                songList.Items[k] = songList.Items.GetItemAt(n);
                libraryList[k] = libraryList[n];
                songList.Items[n] = value;
                libraryList[n] = value2;                
            }                                    
            player.Source = new Uri(System.IO.Path.GetFullPath(libraryList[0]));
        }

        private void botonRepetir_Click(object sender, RoutedEventArgs e)
        {
            repeatSong = true;
        }        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TV_Konevskii
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Classes.TV TV = new Classes.TV();
        public MainWindow()
        {
            InitializeComponent();
            VideoPlayer.Source = new Uri(TV.Channels[TV.ActiveChannel].Src);
            VideoPlayer.Play();
            ProgressVol.Value = TV.activeVolume;
        }

        private void NextChannel(object sender, RoutedEventArgs e)
        {
            TV.BackChannel(VideoPlayer, NameChannel);
        }

        private void BackChannel(object sender, RoutedEventArgs e)
        {
            TV.NextChannel(VideoPlayer, NameChannel);
        }

        private void DownVolume(object sender, RoutedEventArgs e)
        {
            if (TV.activeVolume >= 0)
            {
                TV.DownSound(VideoPlayer);
                ProgressVol.Value -= 10;
            }
        }

        private void InputChannel(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int.TryParse(ChannelInput.Text, out int channel);
                TV.ActiveChannel = channel;
                TV.SwapChannel(VideoPlayer,NameChannel);
            }
        }

        private void VolumeUp(object sender, RoutedEventArgs e)
        {
            if (TV.activeVolume <= 100)
            TV.UpSound(VideoPlayer);
            ProgressVol.Value += 10;
        }
    }
}

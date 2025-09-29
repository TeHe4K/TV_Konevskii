using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TV_Konevskii.Classes
{
    internal class TV
    {
        public int activeChannel;
        public int activeVolume = 50;

        public int ActiveChannel { 
            get { 
                return activeChannel; 
            } 
            set { 
                if (activeChannel < Channels.Count - 1)
                    activeChannel = value;
                else activeChannel = 0; 
                if(activeChannel < 0)
                    activeChannel = Channels.Count - 1;
            } 
        }
        public List<Channel> Channels = new List<Channel>();

        public TV()
        {
            Channels.Add(new Channel()
            {
                Name = "Мопс лижет экран",
                Src = @"C:\Users\student-a502\Downloads\video_ee0379adf30d480d883fdc6b60767a73_480_20250929120925.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "\"Жизнь на пенсии\".. Один день из жизни пенсионерки.",
                Src = @"C:\Users\student-a502\Downloads\video_9a46b7daafee1048c92268ccdab1e0c9_480_20250929121631.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Моем ,солим грузди ,топим баню.",
                Src = @"C:\Users\student-a502\Downloads\video_3675683d18879aa3b0e44dc8a5574193_480_20250929122008.mp4"
            });
        }
        public void SwapChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            DoubleAnimation StartAnimation = new DoubleAnimation();
            StartAnimation.From = 1;
            StartAnimation.To = 0;
            StartAnimation.Duration = TimeSpan.FromSeconds(0.6);
            StartAnimation.Completed += delegate
            {
                _MediaElement.Source = new Uri(this.Channels[this.activeChannel].Src, UriKind.RelativeOrAbsolute);
                _MediaElement.Play();
                DoubleAnimation EndAnimation = new DoubleAnimation();
                EndAnimation.From = 0;
                EndAnimation.To = 1;
                EndAnimation.Duration = TimeSpan.FromSeconds(0.6);
                _MediaElement.BeginAnimation(MediaElement.OpacityProperty, EndAnimation);
            };
            _MediaElement.BeginAnimation(MediaElement.OpacityProperty, StartAnimation);
            _NameChannel.Content = this.Channels[this.activeChannel].Name;

        }
        public void NextChannel(MediaElement _MediaElement, Label _NameChannel) 
        {
            ActiveChannel++;
            SwapChannel(_MediaElement, _NameChannel);
        }
        public void BackChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel--;
            SwapChannel(_MediaElement, _NameChannel);
        }
        public void UpSound(MediaElement _MediaElement)
        {
            activeVolume++;
            _MediaElement.Volume += activeVolume;
        }
        public void DownSound(MediaElement _MediaElement) 
        {
            activeVolume--;
            _MediaElement.Volume -= activeVolume;
        }
    }
}

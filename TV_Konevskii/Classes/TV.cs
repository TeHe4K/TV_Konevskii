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
        private int activeChannel;
        private int activeVolume;
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
                Name = "Прпрпр",
                Src = @"Путь"
            });
            Channels.Add(new Channel()
            {
                Name = "Прпрпр",
                Src = @"Путь"
            });
            Channels.Add(new Channel()
            {
                Name = "Прпрпр",
                Src = @"Путь"
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
                _MediaElement.Source = new Uri(this.Channels[this.activeChannel].Src);
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
        public void UpSound()
        {

        }
        public void DownSound() 
        {

        }
    }
}

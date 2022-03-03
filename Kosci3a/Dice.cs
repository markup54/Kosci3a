using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosci3a
{
    public class Dice : INotifyPropertyChanged
    {
        private static readonly string[] images = new string[] {
            @"Images/kostkapusta.png",
            @"Images/kostka1.png",
            @"Images/kostka2.png",
            @"Images/kostka3.png",
            @"Images/kostka4.png",
            @"Images/kostka5.png",
            @"Images/kostka6.png",
        };

        private int _value;
        public int Value 
        {   get => _value;
            set
            {
                _value = value;
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("Image");
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }

        public string Image { get => images[Value]; }
        public float Opacity { get => IsSelected ? 0.5f : 1f;}

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                if(PropertyChanged != null)
                {
                    OnPropertyChanged("Opacity");
                    PropertyChanged.Invoke(this,new PropertyChangedEventArgs(nameof(IsSelected)));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string prop)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

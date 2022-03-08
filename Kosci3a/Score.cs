using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosci3a
{
    public class Score : NotifyPropertyChanged
    {
        public string Name { get; set; }
        private int _points;
        public int Points
        {
            get { return _points; }
            set
            {
                _points = value;
                OnPropertyChanged();
            }
        }
        private bool _isSet;
        public bool IsSet
        {
            get { return _isSet; }
            set { _isSet = value;
                OnPropertyChanged();
            }
        }

        public Score(string name)
        {
            Name = name;
            Points = 0;
            IsSet = false;
        }
    }
}

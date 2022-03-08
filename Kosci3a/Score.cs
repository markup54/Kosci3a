using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosci3a
{
    public class Score
    {
        public string Name { get; set; }   
        public int Points { get; set; }
        private bool _isSet;
        public bool IsSet
        {
            get { return _isSet; }
            set { _isSet = value; }
        }

        public Score(string name)
        {
            Name = name;
            Points = 0;
            IsSet = false;
        }
    }
}

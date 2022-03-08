using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Kosci3a
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection <Dice> results { get; set; }
        public ObservableCollection <Score> scores { get; set; }
        public int NumberOfDice { get; set; }
        private int NumberOfTries;
        private int NumberOfTriesW = 3 ;
        public MainWindow()
        {
            InitializeComponent();
            NumberOfDice = 10;
            results = new ObservableCollection<Dice>();
            scores = new ObservableCollection<Score>();
            preparegame();
            DataContext = this;
        }
        private void preparegame()
        {
            NumberOfTries = NumberOfTriesW;
            scores.Add(new Score("jedynki"));
            scores.Add(new Score("dwójki"));
            scores.Add(new Score("trójki"));
            scores.Add(new Score("czwórki"));
            scores.Add(new Score("piątki"));
            scores.Add(new Score("szóstki"));
            
            scores.Add(new Score("para"));
            scores.Add(new Score("dwie pary"));
            scores.Add(new Score("trójka"));
            scores.Add(new Score("full (2+3)"));
            scores.Add(new Score("kareta"));
            scores.Add(new Score("poker"));
            scores.Add(new Score("mały strit"));
            scores.Add(new Score("duży strit"));
            scores.Add(new Score("szansa"));

        }
        private void showPoint()
        {
            for (int i = 0; i < 6; i++)
            {
                if (scores[i].IsSet == false)
                {
                    scores[i].Points = sumaGorna(results, i+1);
                }
            }
            if (scores[14].IsSet == false)
            {
                scores[14].Points = sumAll(results);
            }
            
        }
        private int sumaGorna(ObservableCollection<Dice> tablica, int wartosc)
        {
            int s=0;
            int licznik=0;
            foreach(Dice dice in tablica)
            {
                if (dice.Value == wartosc)
                {
                    licznik++;
                }
            }
            s = (licznik - 3) * wartosc;
            return s;
        }
        private int sumAll(ObservableCollection<Dice> tablica)
        {
            int s =0;
            foreach(Dice d in tablica)
            {
                s = s + d.Value;
            }
            if (NumberOfTries == NumberOfTriesW - 1)
            {
                s = s * 2;
            }
            return s;
        }

        private void rollbtn_Click(object sender, RoutedEventArgs e)
        {
            if (NumberOfTries > 0)
            {
                var random = new Random();
                foreach (var item in results)
                {
                    if (!item.IsSelected)
                    {
                        item.Value = random.Next(1, 7);
                    }
                }
                NumberOfTries--;
                showPoint();
            }
            else
            {
                rollbtn.IsEnabled = false;
            }
        }

        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            for (int i = 0; i < NumberOfDice; i++)
            {
                results.Add(new Dice());
            }
            NumberOfTries = NumberOfTriesW;
        }

        private void dicebtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dice = button.DataContext as Dice;
            dice.IsSelected = ! dice.IsSelected;
        }

        private void zatwierdzbtn_Click(object sender, RoutedEventArgs e)
        {
            NumberOfTries = NumberOfTriesW;
            rollbtn.IsEnabled = true;
            results.Clear();
            for(int i = 0;i < NumberOfDice; i++)
            {
                results.Add(new Dice());
            }
        }
    }
}

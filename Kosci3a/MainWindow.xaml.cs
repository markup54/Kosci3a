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
        public int NumberOfDice { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            NumberOfDice = 10;
            results = new ObservableCollection<Dice>();
            DataContext = this;
        }

        private void rollbtn_Click(object sender, RoutedEventArgs e)
        {
            
            var random = new Random();
            foreach(var item in results)
            {
                if (!item.IsSelected)
                {
                    item.Value = random.Next(1,7);
                }
            }
        }

        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            for (int i = 0; i < NumberOfDice; i++)
            {
                results.Add(new Dice());
            }
        }

        private void dicebtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dice = button.DataContext as Dice;
            dice.IsSelected = ! dice.IsSelected;
        }
    }
}

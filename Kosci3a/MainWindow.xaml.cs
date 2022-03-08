﻿using System;
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

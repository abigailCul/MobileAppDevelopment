﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media.Animation;
using System.Collections.ObjectModel;
using Windows.Storage;
using System.Text;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MemoryGame
{

    public sealed partial class MainPage : Page
    {

       
        public MainPage()
        {
            InitializeComponent(); 

    }

        public Card Card = new Card();

        private void Play_Game(object sender, RoutedEventArgs e)
        {
            Card.Background = ((Brush)App.Current.Resources["ApplicationSecondaryForegroundThemeBrush"]);
            Card.NewGame(Display);
        }
    }
}

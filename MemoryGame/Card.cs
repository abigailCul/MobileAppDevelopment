using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace MemoryGame
{
    class Card
    {

        private int moves = 0;
        private int firstId = 0;
        private int secondId = 0;
        private Canvas first;
        private Canvas second;
        private int[,] board = new int[4, 4];
        private List<int> matches = new List<int>();
        private Random random = new Random((int)DateTime.Now.Ticks);

        Random a = new Random();
        BitmapImage Img;


        Stack<int> compare = new Stack<int>();
        Stack<int> bostack = new Stack<int>();
        int count = 0;

        public Brush Background { get; set; }

        public void Show(string content, string title)
        {
            IAsyncOperation<IUICommand> command = new MessageDialog(content, title).ShowAsync();
        }

        //Image *********************
        /* Uri uri = new Uri("ms-appx:///images/ariel.png", UriKind.RelativeOrAbsolute);
        BitmapImage bitmap = new BitmapImage(uri);*/


        public void PageLoaded(object sender, RoutedEventArgs args , int type)
        {
            switch (type)
            {
                case 1: 
                    Img = new BitmapImage(new Uri("ms-appx:///images/ariel.png", UriKind.RelativeOrAbsolute));
                    
                    break;
                case 2:
                    Img = new BitmapImage(new Uri("ms-appx:///images/belle.jpg"));
                    break;
                case 3:
                    Img = new BitmapImage(new Uri("ms-appx:///images/cinderella.jpg"));
                    break;
                case 4:
                    Img = new BitmapImage(new Uri("ms-appx:///images/elsajpg"));
                    break;
                case 5:
                    Img = new BitmapImage(new Uri("ms-appx:///images/jasmin.jpg"));

                    break;
                case 6:
                    Img = new BitmapImage(new Uri("ms-appx:///images/mulan.jpg"));

                    break;
                case 7:
                    Img = new BitmapImage(new Uri("ms-appx:///images/pochahontas.jpg"));

                    break;
                default:
                    Img = new BitmapImage(new Uri("ms-appx:///images/snowWhite.jpg"));
                    break;
            }
           
        }
    }
}

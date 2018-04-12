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

        public Brush Background { get; set; }

        public void Show(string content, string title)
        {
            IAsyncOperation<IUICommand> command = new MessageDialog(content, title).ShowAsync();
        }

       
    }
}

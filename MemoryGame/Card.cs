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
using Windows.UI.Xaml.Resources;

namespace MemoryGame
{
    public class Card
    {
        //Used for images in game
        Random a = new Random();
        BitmapImage Img1, Img2, Img3, Img4, Img5, Img6, Img7, Img8;

        


        private int turn = 0;
        private int firstId = 0;
        private int secondId = 0;
        private Canvas first;
        private Canvas second;
        private int[,] board = new int[4, 4];
        private List<int> matches = new List<int>();
        private Random random = new Random((int)DateTime.Now.Ticks);

        public ImageSource Source { get; set; }


        public Brush Background { get; set; }

        public void Show(string content, string title)
        {
            IAsyncOperation<IUICommand> command = new MessageDialog(content, title).ShowAsync();
        }


        private UIElement card(int choice)
        {
            
            switch (choice)
            {
                case 1:
                    Image img1 = new Image();
                    img1.Source = new BitmapImage(new Uri("ms-appx:///images/ariel.png"));
                    img1.Width = 100;
                   img1.Height = 100;
                    return img1;             
                case 2:
                    Image img2 = new Image();
                    img2.Source = new BitmapImage(new Uri("ms-appx:///images/belle.jpg"));
                    return img2; ;
                case 3:
                    Image img3 = new Image();
                    img3.Source = new BitmapImage(new Uri("ms-appx:///images/cinderella.jpg"));
                    return img3;
                case 4:
                    Image img4 = new Image();
                    img4.Source = new BitmapImage(new Uri("ms-appx:///images/elsajpg"));
                    return img4;
                case 5:
                    Image img5 = new Image();
                    img5.Source = new BitmapImage(new Uri("ms-appx:///images/jasmin.jpg"));

                    return img5;
                case 6:
                    Image img6 = new Image();
                    img6.Source = new BitmapImage(new Uri("ms-appx:///images/mulan.jpg"));

                    return img6;
                case 7:
                    Image img7 = new Image();
                    img7.Source = new BitmapImage(new Uri("ms-appx:///images/pochahontas.jpg"));

                    return img7;
                case 8:
                    Image img8 = new Image();
                     img8.Source = new BitmapImage(new Uri("ms-appx:///images/pochahontas.jpg"));
                    return img8;
                default:


                    return null;
            }

        }

        /*
         * Design of the 4*4 grid layout
         * Gives 16 cards to be flipped over
         */
        private void gridLayout(ref Grid Grid)
        {
            turn = 0;
            matches.Clear();
            Grid.Children.Clear();
            Grid.ColumnDefinitions.Clear();
            Grid.RowDefinitions.Clear();
            // Setup for the 4*4 Grid
            for (int Index = 0; (Index <= 3); Index++)
            {
                Grid.RowDefinitions.Add(new RowDefinition());
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            addGrid(ref Grid, 0, 0);
            addGrid(ref Grid, 0, 1);
            addGrid(ref Grid, 0, 2);
            addGrid(ref Grid, 0, 3);
            addGrid(ref Grid, 1, 0);
            addGrid(ref Grid, 1, 1);
            addGrid(ref Grid, 1, 2);
            addGrid(ref Grid, 1, 3);
            addGrid(ref Grid, 2, 0);
            addGrid(ref Grid, 2, 1);
            addGrid(ref Grid, 2, 2);
            addGrid(ref Grid, 2, 3);
            addGrid(ref Grid, 3, 0);
            addGrid(ref Grid, 3, 1);
            addGrid(ref Grid, 3, 2);
            addGrid(ref Grid, 3, 3);
        }


        private void addGrid(ref Grid grid, int row, int column)
        {
            Canvas canvas = new Canvas();
            canvas.Height = 100;
            canvas.Width = 100;
            canvas.Background = new SolidColorBrush(Colors.HotPink);
            canvas.Tapped += async (object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) =>
            {
                int selected;
                canvas = ((Canvas)(sender));
                row = (int)canvas.GetValue(Grid.RowProperty);
                column = (int)canvas.GetValue(Grid.ColumnProperty);
                selected = board[row, column];
                if ((matches.IndexOf(selected) < 0))
                {
                    // Choices do not match

                    if ((firstId == 0)) 
                    {
                        first = canvas;
                        firstId = selected;
                        first.Children.Clear();
                        first.Children.Add(card(selected));
                    }
                    else if ((secondId == 0))
                    {
                        second = canvas;
                        if (!first.Equals(second)) // Different
                        {
                            secondId = selected;
                            second.Children.Clear();
                            second.Children.Add(card(selected));
                            // Your cards do match
                            if ((firstId == secondId)) 
                            {
                                matches.Add(firstId);
                                matches.Add(secondId);
                                if (!(first == null))
                                {
                                    first.Background = null;
                                    first = null;
                                }
                                if (!(second == null))
                                {
                                    second.Background = null;
                                    second = null;
                                }
                                //When all 16 cards are matched
                                if ((matches.Count == 16))
                                {
                                    Show("Well Done! You matched pictures in " + turn + " goes!", "Memory Game");
                                }
                            }
                            else // No Match cards flip back over
                            {
                                await Task.Delay(TimeSpan.FromSeconds(1.5));
                                if (!(first == null))
                                {
                                    first.Children.Clear();
                                    first = null;
                                }
                                if (!(second == null))
                                {
                                    second.Children.Clear();
                                    second = null;
                                }
                            }
                            turn++;
                            firstId = 0;
                            secondId = 0;
                        }
                    }
                }
            };
            canvas.SetValue(Grid.ColumnProperty, column);
            canvas.SetValue(Grid.RowProperty, row);
            grid.Children.Add(canvas);
        }

         
    private List<int> select(int start, int finish, int total)
    {
        int number;
        List<int> numbers = new List<int>();
        while ((numbers.Count < total)) // Select Numbers
        {
            // Random Number between Start and Finish
            number = random.Next(start, finish + 1);
            if ((!numbers.Contains(number)) || (numbers.Count < 1))
            {
                numbers.Add(number); // Add if number Chosen or None
            }
        }
        return numbers;
    }

        /*
         * New grid when you win the game
         */
        public void New(Grid grid)
        {
            gridLayout(ref grid);
            List<int> values = new List<int>();
            List<int> indices = new List<int>();
            int counter = 0;
            while (values.Count < 17)
            {
                List<int> numbers = select(1, 8, 8); // Random pictures 1 - 8
                for (int number = 0; (number <= 7); number++)
                {
                    values.Add(numbers[number]); // Add to Cards
                }
            }
            indices = select(1, 16, 16); // Random pictures in box from 1 - 16
            for (int Column = 0; (Column <= 3); Column++) 
            {
                for (int Row = 0; (Row <= 3); Row++) 
                    board[Column, Row] = values[indices[counter] - 1];
                    counter++;
                }
            }
        }

        }

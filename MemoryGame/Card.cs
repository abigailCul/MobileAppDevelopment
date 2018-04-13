using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

public class Card
{

    //Used for images in game
    Random a = new Random();

    public Brush Background { get; set; }

    /*
     * Variables for grid
     * */
    private int turn = 0;
    private int firstChoice = 0;
    private int secondChoice = 0;

    private Canvas Choice1;
    private Canvas Choice2;

    private int[,] GameGrid = new int[4, 4];
    private List<int> matches = new List<int>();
    private Random random = new Random((int)DateTime.Now.Ticks);

    public void Show(string content, string title)
    {
        IAsyncOperation<IUICommand> command = new MessageDialog(content, title).ShowAsync();
    }

    /*
     * Switch Images that are generated in the game
     * Gets the image source from the files
     * Change the size to fit in the canvas
     */
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
                img2.Source = new BitmapImage(new Uri("ms-appx:///images/belle.png"));
                img2.Width = 100;
                img2.Height = 100;
                return img2;
            case 3:
                Image img3 = new Image();
                img3.Source = new BitmapImage(new Uri("ms-appx:///images/cinderella.png"));
                img3.Width = 100;
                img3.Height = 100;
                return img3;
            case 4:
                Image img4 = new Image();
                img4.Source = new BitmapImage(new Uri("ms-appx:///images/elsa.png"));
                img4.Width = 100;
                img4.Height = 100;
                return img4;
            case 5:
                Image img5 = new Image();
                img5.Source = new BitmapImage(new Uri("ms-appx:///images/jasmin.png"));
                img5.Width = 100;
                img5.Height = 100;
                return img5;
            case 6:
                Image img6 = new Image();
                img6.Source = new BitmapImage(new Uri("ms-appx:///images/mulan.png"));
                img6.Width = 100;
                img6.Height = 100;
                return img6;
            case 7:
                Image img7 = new Image();
                img7.Source = new BitmapImage(new Uri("ms-appx:///images/pocahontas.png"));
                img7.Width = 100;
                img7.Height = 100;
                return img7;
            case 8:
                Image img8 = new Image();
                img8.Source = new BitmapImage(new Uri("ms-appx:///images/snowWhite.png"));
                img8.Width = 100;
                img8.Height = 100;
                return img8;
            default:


                return null;
        }

    }

    private void Gridlayout(ref Grid Grid)
    {
        turn = 0;
        matches.Clear();
        Grid.Children.Clear();
        Grid.ColumnDefinitions.Clear();
        Grid.RowDefinitions.Clear();
        // Setup 4x4 Grid 16 boxes
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
        /*
         * Change canvas size and colour of the blocks on the canvas 
         */
        Canvas canvas = new Canvas();
        canvas.Height = 100;
        canvas.Width = 100;
        canvas.Background = new SolidColorBrush(Colors.HotPink);
        canvas.Tapped += async (object sender, TappedRoutedEventArgs e) =>
        {
            /*
             * Gets the grid and row 
             * */
            int select;
            canvas = ((Canvas)(sender));
            row = (int)canvas.GetValue(Grid.RowProperty);
            column = (int)canvas.GetValue(Grid.ColumnProperty);
            select = GameGrid[row, column];
            if ((matches.IndexOf(select) < 0))
            {
                if ((firstChoice == 0)) // Dont match 
                {
                    Choice1 = canvas;
                    firstChoice = select;
                    Choice1.Children.Clear();
                    Choice1.Children.Add(card(select));
                }
                else if ((secondChoice == 0))
                {
                    Choice2 = canvas;

                    // If they are different they turn back
                    if (!Choice1.Equals(Choice2)) 
                    {
                        secondChoice = select;
                        Choice2.Children.Clear();
                        Choice2.Children.Add(card(select));
                        // If the choices do match they stay up
                        if ((firstChoice == secondChoice)) 
                        {
                            matches.Add(firstChoice);
                            matches.Add(secondChoice);
                            if (!(Choice1 == null))
                            {
                                Choice1.Background = null;
                                Choice1 = null;
                            }
                            if (!(Choice2 == null))
                            {
                                Choice2.Background = null;
                                Choice2 = null;
                            }
                            if ((matches.Count == 16))
                            {
                                Show("Woohoo! You matched all the princesses in " + turn + " moves!", "Princess Memory Game");
                            }
                        }
                        else // No Match
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1.5));
                            if (!(Choice1 == null))
                            {
                                Choice1.Children.Clear();
                                Choice1 = null;
                            }
                            if (!(Choice2 == null))
                            {
                                Choice2.Children.Clear();
                                Choice2 = null;
                            }
                        }
                        turn++;
                        firstChoice = 0;
                        secondChoice = 0;
                    }
                }
            }
        };
        canvas.SetValue(Grid.ColumnProperty, column);
        canvas.SetValue(Grid.RowProperty, row);
        grid.Children.Add(canvas);
    }


    private List<int> selectBlock(int start, int finish, int total)
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
     * When you chose to play a new game
     * The Canvas will regenerate randomally
     */
    public void NewGame (Grid grid)
    {
        Gridlayout(ref grid);
        List<int> values = new List<int>();
        List<int> indices = new List<int>();
        int counter = 0;
        while (values.Count < 17)
        {
            //Random 1-8 random pictures
            List<int> numbers = selectBlock(1, 8, 8); 
            for (int number = 0; (number <= 7); number++)
            {
                // Add numbers to the card spaces
                values.Add(numbers[number]); 
            }
        }
        // Random squares of 1-16
        indices = selectBlock(1, 16, 16); 
        for (int Column = 0; (Column <= 3); Column++)
        {
            // Rows for the grid
            for (int Row = 0; (Row <= 3); Row++) 
            {
                GameGrid[Column, Row] = values[indices[counter] - 1];
                counter++;
            }
        }
    }
}
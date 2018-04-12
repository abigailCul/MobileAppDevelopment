# Mobile App UWP Project
A windows app in uwp for my 3rd year mobile app project. Developed an app for the windows store using c# and xaml.
## Description
I have done a memory game using images of disney princesses. The aim of the games is to flip the card and find the matching cards.
You are first presented with a homepage and have to press button to chose play game. You are then brought to the grid game. Each time you press play game it generates a new random game.

## Prerequisites

I used github for my project so it would not be lost and be easy for other people to access.

### Push to Github:

In order to submit my project changes to github from my github folder i used the following commands:
git add .
git commit -m "Initial commit"
git push

### Download from github:
For you to download my project you must clone my repository link from the command promp:

git clone https://github.com/abigailCul/MobileAppDevelopment.git

### You can then run my code using:
Visual Studio. Then you can run my desktop app from your desktop.

## Coding Syle

In my project i used C# and xaml as my designer.
I used xaml to design my home page using images and a bar button at the bottom to bring you to my game page. 
In xaml i used image tags to show my image on screen and appBar with button.

<AppBar IsOpen="True" IsSticky="True">
            <StackPanel Orientation="Vertical">
                <AppBarButton Icon="Play" Label="Play Game" Click="Play_Game" Background="MediumPurple"/>
            </StackPanel>
        </AppBar>

<Image x:Name="Card1_Click" Source="images/question.png" Grid.Row="0" Grid.Column="0" />
**

In my c# I used UIElement for the visual appearance of my images which are in a switch statement.
The switch statement helps to generate my eight pictures that i used. I also used BitmapImage to get my image from my source folder.
**
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
**



## Resources i used for my project.
https://msdn.microsoft.com/en-us/library/dd553235.aspx
https://www.youtube.com/watch?v=0_pQsHgfuVo&t=249s
https://www.youtube.com/watch?v=frDKP-A71W0
http://www.dreamincode.net/forums/topic/278421-resizing-bitmapimage/
https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.image
https://www.mooict.com/c-tutorial-create-a-superhero-memory-game/
https://www.c-sharpcorner.com/article/memory-game/
https://github.com/kptran12/MemoryMatchGame/tree/master/MemoryMatchGame/MemoryMatchGame
https://blogs.windows.com/buildingapps/2015/03/13/how-to-make-a-windows-store-game-with-c-and-xaml-part-1/#okYb8CwEIb17y4Dm.97


## License

This project is licensed under the Apache License- see the LICENSE.md file for details

  

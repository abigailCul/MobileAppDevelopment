﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace MemoryGame
{

    //Card width and height
  
    public class Cards : INotifyPropertyChanged
    {
        public struct Size
        {
            public int width, height;


            public Size(int width, int height)
            {
                this.width = width;
                this.height = height;

            }
        };


        public Size CardSize { get; private set; }
        private ImageBrush cardImage;

        public ImageBrush CardImage
        {
            get { return cardImage; }
            set
            {
                cardImage = value;
                RaisePropertyChanged("CardImage");
            }
        }


        private bool selected;

        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                RaisePropertyChanged("Selected");
            }
        }


        public Cards(Size cardSize, ImageBrush cardImage)
        {

            this.CardSize = cardSize;
            this.CardImage = cardImage;


        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string Selected)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Selected));
        }
    }




}

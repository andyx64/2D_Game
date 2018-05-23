using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2dGame
{


    abstract class GameObject : INotifyPropertyChanged
    {
        protected double height;
        protected double width;

        protected double getTop;
        protected double getLeft;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual double Height
        {
            get { return height; }
            set { height = value; NotifyPropertyChanged(); }
        }
        public virtual double Width
        {
            get { return width; }
            set { width = value; NotifyPropertyChanged(); }
        }
        public virtual double GetTop
        {
            get { return getTop; }
            set { getTop = value; NotifyPropertyChanged(); }
        }
        public virtual double GetLeft
        {
            get { return getLeft; }
            set { getLeft = value; NotifyPropertyChanged(); }
        }
    }
}

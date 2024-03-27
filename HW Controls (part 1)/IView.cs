using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HW_Controls__part_1_
{
    internal interface IView
    {
        void AddPhotoTab(string imageName, Image image);
        event EventHandler<EventArgs> Next;
        event EventHandler<EventArgs> Previous;
        event EventHandler<EventArgs> Add;
        event EventHandler<EventArgs> Delete;
    }
}
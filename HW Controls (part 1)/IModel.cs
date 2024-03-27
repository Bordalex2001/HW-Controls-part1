using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Controls__part_1_
{
    internal interface IModel
    {
        List<Photo> Photos { get; set; }
        List<Photo> LoadPhotos();
    }
}
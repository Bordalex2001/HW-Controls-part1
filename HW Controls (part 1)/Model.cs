using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Controls__part_1_
{
    internal class Model : IModel
    {
        public List<Photo> Photos { get; set; }
        public Model()
        {
            Photos = LoadPhotos();
        }
        public List<Photo> LoadPhotos()
        {
            return new List<Photo>
            {
                new Photo { Name = "photo1.jpg" },
                new Photo { Name = "photo2.jpg" },
                new Photo { Name = "photo3.jpg" },
                new Photo { Name = "photo4.jpg" }
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGalleriesApp.Models
{
    public class Photo
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public Photo() { }
        public Photo(string name, string image)
        {
            Name = name;
            Image = image;
        }
    }
}

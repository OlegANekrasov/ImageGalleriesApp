using ImageGalleriesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageGalleriesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();
        }

        public ImagePage(Photo photo)
        {
            InitializeComponent();

            img.Source = photo.Image;

            FileInfo fi = new FileInfo(photo.Image);
            path.Text = fi.CreationTime.ToString("dd.MM.yyyy HH:mm:ss");
        }
    }
}
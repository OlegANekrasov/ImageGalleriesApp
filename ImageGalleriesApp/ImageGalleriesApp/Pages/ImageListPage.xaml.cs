using ImageGalleriesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageGalleriesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageListPage : ContentPage
    {
        string folderPath = @"/storage/emulated/0/DCIM/Camera";
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();
        Photo selected;

        public ImageListPage()
        {
            InitializeComponent();

            try
            {
                var filesList = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f));
                foreach (var file in filesList)
                {
                    Photos.Add(new Photo(file, Path.Combine(folderPath, file)));
                }
            }
            catch (Exception ex)
            {
                DisplayAlert(null, ex.Message, "OK");
            }

            BindingContext = this;
        }

        /// <summary>
        /// Обработчик выбора
        /// </summary>
        private void deviceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // распаковка модели из объекта
            selected = (Photo)e.SelectedItem;
        }

        /// <summary>
        /// Обработчик открытия выбранного изображения 
        /// </summary>
        private async void Open(object sender, EventArgs e)
        {
            if (selected != null)
            {
                await Navigation.PushAsync(new ImagePage(selected));
            }
            else
            {
                await DisplayAlert(null, $"Фотография не выбрана!", "ОК");
            }
        }

        /// <summary>
        /// Обработчик удаления выбранного изображения 
        /// </summary>
        private async void Remove(object sender, EventArgs e)
        {
            if (selected != null)
            {
                Photos.Remove(selected);

                try
                {
                    File.Delete(Path.Combine(folderPath, selected.Name));
                    await DisplayAlert(null, "Файл удален: " + selected.Name, "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert(null, ex.Message, "OK");
                }

                selected = null;
            }
            else
            {
                await DisplayAlert(null, $"Фотография не выбрана!", "ОК");
            }
        }
    }
}
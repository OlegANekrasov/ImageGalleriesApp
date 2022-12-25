using ImageGalleriesApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ImageGalleriesApp
{
    public partial class MainPage : ContentPage
    {
        bool FirstStart = false;
        string pin = "";

        public MainPage()
        {
            InitializeComponent();

            pin = Preferences.Get("PIN", "");
            if (string.IsNullOrEmpty(pin))
            {
                loginButton.Text = $"Установите PIN-код";
                FirstStart = true;
            }
            else
            {
                loginButton.Text = $"Введите PIN-код";
                FirstStart = false;
            }
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            if (FirstStart)
            {
                string value = EntryPIN.Text;
                if (string.IsNullOrEmpty(value))
                {
                    infoMessage.Text = "Не введен PIN-код";
                    return;
                }

                if (value.Length != 4)
                {
                    infoMessage.Text = "Необходимо четыре символа";
                    return;
                }

                Preferences.Set("PIN", value);
                pin = value;

                loginButton.Text = $"Введите PIN-код";
                FirstStart = false;
            }
            else
            {
                if (string.Compare(pin, EntryPIN.Text) != 0)
                {
                    infoMessage.Text = "Неверный PIN-код";
                    return;
                }
            }

            infoMessage.Text = "";
            await Navigation.PushAsync(new ImageListPage());     
        }
    }
}

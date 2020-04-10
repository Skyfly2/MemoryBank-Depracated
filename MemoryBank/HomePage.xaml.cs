using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MemoryBank
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            greet.Text = "Hello " + Account.First() + ",";

        }

        async void Settings_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SettingsPage());
        }

        async void About(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new AboutPage());
        }

        void Search(System.Object sender, System.EventArgs e)
        {
        }

        void Personal_Info(System.Object sender, System.EventArgs e)
        {
        }

        void Passwords(System.Object sender, System.EventArgs e)
        {
        }

        async void Notes(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new MenuPage());
        }
    }
}

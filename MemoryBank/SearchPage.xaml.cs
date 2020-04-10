using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MemoryBank
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        async void Search(System.Object sender, System.EventArgs e)
        {
        }

        async void ViewContent(System.Object sender, System.EventArgs e)
        {
        }

        async void Settings_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SettingsPage());
        }
    }
}

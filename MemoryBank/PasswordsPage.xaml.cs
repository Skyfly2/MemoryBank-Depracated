using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MemoryBank
{
    public partial class PasswordsPage : ContentPage
    {
        public PasswordsPage()
        {
            InitializeComponent();
        }

        void NewPass(System.Object sender, System.EventArgs e)
        {
        }

        void EditPass(System.Object sender, System.EventArgs e)
        {
        }

        async void Settings_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SettingsPage());
        }
    }
}

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MemoryBank
{
    public partial class PersonalPage : ContentPage
    {
        public PersonalPage()
        {
            InitializeComponent();
            name.Text = "Name: " + Account.First() + " " + Account.Last();
            email.Text = Account.Email();
        }

        void NewPersonalInfo(System.Object sender, System.EventArgs e)
        {
        }

        void UpdateData(System.Object sender, System.EventArgs e)
        {
        }

        void EditSSN(System.Object sender, System.EventArgs e)
        {
        }

        void ViewSSN(System.Object sender, System.EventArgs e)
        {
        }

        async void Settings_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SettingsPage());
        }
    }
}

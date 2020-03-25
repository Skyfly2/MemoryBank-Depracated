using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MemoryBank
{
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        async void Back(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void RegisterFunc(System.Object sender, System.EventArgs e)
        {

        }
    }
}

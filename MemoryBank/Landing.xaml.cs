using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MemoryBank
{
    public partial class Landing : ContentPage
    {
        public Landing()
        {
            InitializeComponent();
        }

        async void Register(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Register());
        }

        void Login(System.Object sender, System.EventArgs e)
        {
        }
        
        void Reset_Pass(System.Object sender, System.EventArgs e)
        {
        }
    }
}

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MemoryBank
{
    public partial class Landing : ContentPage
    {
        LoginManager manage;

        public Landing()
        {
            InitializeComponent();
            manage = LoginManager.Default;
        }

        async void Register(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Register());
        }

        async void Login(System.Object sender, System.EventArgs e)
        {
            LoginInfo info = new LoginInfo();
            info.Id = user.Text;
            info.Pass = pass.Text;
            
            if (await manage.Login(info))
            {
                await Navigation.PushModalAsync(new HomePage());
                
            }
            else
            {
                await DisplayAlert("Login Failed", "Incorrect Username or Password", "Dismiss");
                
            }
        }
        
        void Reset_Pass(System.Object sender, System.EventArgs e)
        {
        }
    }
}

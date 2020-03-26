using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MemoryBank
{
    public partial class Register : ContentPage
    {
        RegisterManager manage;
        public Register()
        {
            InitializeComponent();
            manage = RegisterManager.Default;
        }

        async void Back(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void RegisterFunc(System.Object sender, System.EventArgs e)
        {
            var info = new Registration { First = firstname.Text };
            info.Last = lastname.Text;
            info.Pass = pass.Text;
            info.CPass = cpass.Text;
            info.Email = email.Text;

            if ((info.Pass == info.CPass)){
                if (!String.IsNullOrWhiteSpace(info.Last) && !String.IsNullOrWhiteSpace(info.First) && !String.IsNullOrWhiteSpace(info.Email) && !String.IsNullOrWhiteSpace(info.Pass))
                {
                    Reg(info);
                }
                else
                {
                    DisplayAlert("Registration Error", "Please Fill Out All Fields", "Close");
                }
            }
            else
            {
                cpass.Text = "";
                pass.Text = "";
                DisplayAlert("Registration Error", "Passwords Do Not Match", "Close");
                
            }

        }

        void Reg(Registration info)
        {
      
        }
    }
}

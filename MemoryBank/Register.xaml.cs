using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MemoryBank
{
    public partial class Register : ContentPage
    {
        LoginManager manage;
        public Register()
        {
            InitializeComponent();
            manage = LoginManager.Default;
        }

        async void Back(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void RegisterFunc(System.Object sender, System.EventArgs e)
        {
            // Store user data
            var info = new LoginInfo { First = firstname.Text };
            info.Last = lastname.Text;
            info.Email = email.Text;
            info.Id = user.Text;

            // Field validation
            if (await manage.NoIdExists(info.Id))
            {
                if (pass.Text == cpass.Text)
                {
                    if (manage.PasswordRequirements(pass.Text))
                    {
                        if (!String.IsNullOrWhiteSpace(info.First) && !String.IsNullOrWhiteSpace(info.Email) && !String.IsNullOrWhiteSpace(info.Last) && !String.IsNullOrWhiteSpace(info.Id))
                        {
                            // Register the user
                            Reg(info);
                        }
                        else
                        {
                            // Registration Error
                            await DisplayAlert("Registration Error", "Please Fill Out All Fields", "Close");
                        }
                    }
                    else
                    {
                        // Password Fails Security Requirements
                        cpass.Text = "";
                        pass.Text = "";
                        await DisplayAlert("Registation Error", "Password must be between 8 and 40 characters and contain an uppercase and lowercase letter, a number, and a special character", "Close");
                    }
                }
                else
                {
                    // Password Mismatch Error
                    cpass.Text = "";
                    pass.Text = "";
                    await DisplayAlert("Registration Error", "Passwords Do Not Match", "Close");

                }
            }
            else
            {
                // Username already exists
                user.Text = "";
                await DisplayAlert("Registration Error", "Username Taken", "Close");
            }

        }

        void Reg(LoginInfo info)
        {
            // Hash password
            byte[] salt;

            // Build salt
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Obtain hash value
            var pbkdf2 = new Rfc2898DeriveBytes(pass.Text, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashedPass = new byte[36];

            // Build Hashed Password
            Array.Copy(salt, 0, hashedPass, 0, 16);
            Array.Copy(hash, 0, hashedPass, 16, 20);

            info.Pass = Convert.ToBase64String(hashedPass);

            if (manage.RegisterUser(info))
            {
                DisplayAlert("Registration Notice", "Successful Registration", "Dismiss");
                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Registration Notice", "Registration Failed", "Dismiss");
            }
        }
    }
}

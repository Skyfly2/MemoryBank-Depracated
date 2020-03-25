using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoryBank
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Landing();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

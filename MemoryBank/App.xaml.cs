using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoryBank
{
    public partial class App : Application
    {
        // Set up cryptography key storage
        static KeyData db;

        public static KeyData DB
        {
            get
            {
                if(db == null)
                {
                    db = new KeyData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "keys.db3"));
                }
                return db;
            }
        }
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

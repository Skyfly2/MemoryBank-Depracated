using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Xamarin.Forms;

namespace MemoryBank
{
    public partial class NewNote : ContentPage
    {
        DataManager manage = DataManager.Default;
        Aes encrypter = Aes.Create();

        public NewNote()
        {
            InitializeComponent();
        }

        async void SaveNote(System.Object sender, System.EventArgs e)
        {
            var newNote = new Note { };
            newNote.id = Account.User();
            newNote.title = title.Text;
            try
            {
                using (RijndaelManaged encrypt = new RijndaelManaged())
                {
                    encrypt.GenerateIV();
                    encrypt.GenerateKey();
                    Key key = new Key
                    {
                        iv = Convert.ToBase64String(encrypt.IV)
                    };
                    key.ID = 0;
                    await App.DB.addKey(key);
                    newNote.content = Encryptor.Encrypt(content.Text, encrypt.Key, encrypt.IV);
                    Console.WriteLine("Encrypted Content: " + newNote.content);
                    Key k = await App.DB.getKey(0);
                    newNote.content = Encryptor.Decrypt(newNote.content, Convert.FromBase64String(k.key), Convert.FromBase64String(k.iv));
                    Console.WriteLine("Decrypted Content: " + newNote.content);
                    await manage.UploadNote(newNote);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error {0}", ex.Message);
            }
            finally
            {
                await Navigation.PopModalAsync();
            }
        }

        async void Cancel(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        static void PrintFolderPath(System.Environment.SpecialFolder folder)
        {
            Console.WriteLine("{0}={1}", folder, System.Environment.GetFolderPath(folder));
        }
    }
}

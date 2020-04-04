using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace MemoryBank
{
    public partial class LoginManager
    {
        static LoginManager def = new LoginManager();

        const string accountURL = @"https://memorybank.documents.azure.com:443/";
        const string pKey = @"5HCoinu3i0IHXtp6g1U4XCN7mdd3SdWlNOfLiCgtwrYElYq2C4kCXYeLmUh0nSCQwH6PvcSasaiyrMLH4JYVRQ==";
        const string databaseId = @"MemoryBank";
        const string collection = @"Registration";

        private Uri connect = UriFactory.CreateDocumentCollectionUri(databaseId, collection);

        private DocumentClient client;

        private LoginManager()
        {
            client = new DocumentClient(new System.Uri(accountURL), pKey);
        }

        public static LoginManager Default
        {
            get { return def; }
            set { def = value; }
        }

        public bool RegisterUser(LoginInfo info)
        {
            try
            {
                var query = client.CreateDocumentAsync(connect, info);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Error {0}", e.Message);
            }
            return false;
        }

        public async Task<bool> Login(LoginInfo info)
        {
            try
            {
                // Query for matching username
                var result = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collection, info.Id), new RequestOptions
                { PartitionKey = new Microsoft.Azure.Documents.PartitionKey(info.Id)});
                LoginInfo real = (LoginInfo)(dynamic)result.Resource;
                string realPass = real.Pass;

                // Check passwords
                byte[] hashedPass = Convert.FromBase64String(realPass);
                byte[] salt = new byte[16];
                Array.Copy(hashedPass, 0, salt, 0, 16);

                var pbkdf2 = new Rfc2898DeriveBytes(info.Pass, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                for (int c = 0; c < 20; c++)
                {
                    if (hashedPass[c + 16] != hash[c])
                    {
                        // Login failed
                        return false;
                    }
                }
                // Successful login
                return true;
            }
            catch (Exception e)
            {
                // Account not found
                Console.WriteLine(@"Error: {0}", e.Message);
                return false;
            }
        }

        public async Task<bool> NoIdExists(string id)
        {
            try
            {
                // Query id
                var result = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collection, id), new RequestOptions
                { PartitionKey = new Microsoft.Azure.Documents.PartitionKey(id) });
                // ID exists
                return false;
            }
            catch(Exception e)
            {
                // ID doesn't exist
                Console.WriteLine("Error: {0}", e.Message);
                return true;
            }
        }

        public bool PasswordRequirements(string pass)
        {
            bool upper = false;
            bool lower = false;
            bool number = false;
            bool special = false;

            if(pass.Length >= 8 && pass.Length <= 40)
            {
                // Check characters for matches
                for(int c = 0; c < pass.Length; c++)
                {
                    char curr = pass[c];
                    if(curr >= 65 && curr <= 90)
                    {
                        upper = true;
                    }
                    else if(curr >= 97 && curr <= 122)
                    {
                        lower = true;
                    }
                    else if(curr >= 48 && curr <= 57)
                    {
                        number = true;
                    }
                    else if((curr >= 33 && curr <=47) || (curr >= 58 && curr <= 64) || (curr >= 91 && curr <= 96) || (curr >= 123 && curr <= 126))
                    {
                        special = true;
                    }
                    if (upper && lower && number && special)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

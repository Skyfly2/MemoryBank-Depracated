using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace MemoryBank
{
    public partial class DataManager
    {
        static DataManager def = new DataManager();

        const string accountURL = @"https://memorybank.documents.azure.com:443/";
        const string pKey = @"5HCoinu3i0IHXtp6g1U4XCN7mdd3SdWlNOfLiCgtwrYElYq2C4kCXYeLmUh0nSCQwH6PvcSasaiyrMLH4JYVRQ==";
        const string databaseId = @"MemoryBank";
        const string collection = @"Registration";

        private Uri connect = UriFactory.CreateDocumentCollectionUri(databaseId, collection);

        private DocumentClient client;

        private DataManager()
        {
            client = new DocumentClient(new System.Uri(accountURL), pKey);
        }

        public static DataManager Default
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
            catch(Exception e)
            {
                Console.WriteLine(@"Error {0}", e.Message);
            }
            return false;
        }

        public bool Login(LoginInfo info)
        {
            return false;
        }

    }
}

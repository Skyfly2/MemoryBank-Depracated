using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;

namespace MemoryBank
{
    public class DataManager
    {
        static DataManager def = new DataManager();

        const string accountURL = @"https://memorybank.documents.azure.com:443/";
        const string pKey = @"5HCoinu3i0IHXtp6g1U4XCN7mdd3SdWlNOfLiCgtwrYElYq2C4kCXYeLmUh0nSCQwH6PvcSasaiyrMLH4JYVRQ==";
        const string databaseId = @"MemoryBank";
        string container;

        private Uri connect;

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

        public async Task<bool> UploadNote(Note note)
        {
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace MemoryBank
{
    public partial class RegisterManager
    {
        static RegisterManager def = new RegisterManager();

        const string accountURL = @"https://memorybank.documents.azure.com:443/";
        const string primaryKey = @"5HCoinu3i0IHXtp6g1U4XCN7mdd3SdWlNOfLiCgtwrYElYq2C4kCXYeLmUh0nSCQwH6PvcSasaiyrMLH4JYVRQ==";
        const string databaseId = @"MemoryBank";
        const string collection = @"Registration";

        private Uri connect = UriFactory.CreateDocumentCollectionUri(databaseId, collection);

        private DocumentClient client;

        private RegisterManager()
        {
            client = new DocumentClient(new System.Uri(accountURL), primaryKey);
        }

        public static RegisterManager Default{
            get { return def; }
            set { def = value; }
            }


    }
}

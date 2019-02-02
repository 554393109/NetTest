using System.Collections.Generic;

namespace NetTest.HttpClientUtils
{
    public class ClientContext
    {
        private NetTest.HttpClientUtils.IClient client;

        public ClientContext(IClient _client)
        {
            this.client = _client;
        }

        public string Post(string url, object content)
        {
            return this.client.Post(url, content);
        }
    }
}

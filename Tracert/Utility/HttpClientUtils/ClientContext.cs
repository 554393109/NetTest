using System.Collections.Generic;

namespace Tracert.HttpClientUtils
{
    public class ClientContext
    {
        private Tracert.HttpClientUtils.IClient client;

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

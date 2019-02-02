namespace NetTest.HttpClientUtils
{
    public interface IClient
    {
        string Post(string url, object content);
    }
}

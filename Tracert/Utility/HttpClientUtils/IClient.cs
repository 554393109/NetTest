namespace Tracert.HttpClientUtils
{
    public interface IClient
    {
        string Post(string url, object content);
    }
}

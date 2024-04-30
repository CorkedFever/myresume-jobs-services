namespace Corkedfever.Client.Jobs
{
    public class JobsClient : JobsClientBase
    {
        public JobsClient(string baseUri) : base(baseUri)
        {
            BaseUrl = baseUri;
        }

    }
}

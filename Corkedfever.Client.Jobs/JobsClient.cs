namespace Corkedfever.Client.Jobs
{
    public class JobsClient : ClientBase
    {
        public JobsClient(string baseUri) : base(baseUri)
        {
            BaseUrl = baseUri;
        }

    }
}

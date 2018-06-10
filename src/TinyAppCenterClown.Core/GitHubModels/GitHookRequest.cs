namespace TinyAppCenterClown.Core.GitHubModels
{
    public class GitHookRequest
    {
        public string @ref { get; set; }
        public string ref_type { get; set; }
        public string master_branch { get; set; }
        public string description { get; set; }
        public string pusher_type { get; set; }
        public Repository repository { get; set; }
        public Sender sender { get; set; }
    }
}

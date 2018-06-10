using System;
using TinyAppCenterClown.Core.GitHubModels;

namespace TinyAppCenterClown.Core.GitHub
{
    public class GitHubWebHookHandler : IWebHookHandler
    {
        public GitHookResult Handle(GitHookRequest request)
        {
            var result = new GitHookResult();

            if (request.ref_type == "branch")
            {
                
            }
            else
            {
                result.Succeded = true;
                result.Log("This was not related to the creation of a branch so it wasn't handled by TACC");
            }

            return result;
        }
    }
}

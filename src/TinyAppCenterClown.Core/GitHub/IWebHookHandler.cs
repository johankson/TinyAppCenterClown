using System;
using TinyAppCenterClown.Core.GitHubModels;
namespace TinyAppCenterClown.Core.GitHub
{
    public interface IWebHookHandler
    {
        GitHookResult Handle(GitHookRequest request);
    }
}

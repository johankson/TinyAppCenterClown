using System;
using Microsoft.AspNetCore.Mvc;
using TinyAppCenterClown.Core.GitHub;
using TinyAppCenterClown.Core.GitHubModels;

namespace TinyAppCenterClown.Web.Controllers
{
   
    public class WebHookController : Controller
    {
        [Route("api/projects/{projectId}/webhook")]
        [HttpPost]
        public IActionResult WebhookReceived(int projectId, [FromBody]GitHookRequest request)
        {
            var handler = new GitHubWebHookHandler();
            handler.Handle(request);

            return new OkResult();
        }
    }
}

using System;
using Xunit;
using TinyAppCenterClown.Core.GitHub;
using TinyAppCenterClown.Core.GitHubModels;

namespace TinyAppCenterClown.Tests
{
    public class BranchCreatedTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var json = System.IO.File.ReadAllText("BranchCreatedWebHookRequest.json");
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<GitHookRequest>(json);
            var handler = new GitHubWebHookHandler();

            // Act
            handler.Handle(request);

        }
    }
}

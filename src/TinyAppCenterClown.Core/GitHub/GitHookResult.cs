using System;
using System.Text;

namespace TinyAppCenterClown.Core.GitHub
{
    /// <summary>
    /// Contains the result of the processing of the git hook call
    /// </summary>
    public class GitHookResult
    {
        private StringBuilder log;

        public bool Succeded { get; set; }

        public void Log(string entry)
        {
            log.AppendLine($"{DateTime.Now}: {entry}");
        }
    }
}

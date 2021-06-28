using System;
using System.Threading;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;

namespace ElsaServer.Activities.Implementations
{
    [Activity(
        Category = "User implemented activities",
        DisplayName = "Long running process")]
    public class LongRunningProc : Activity
    {
        private readonly Guid _guid;

        public LongRunningProc()
        {
            _guid = Guid.NewGuid();
        }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"[{i}] {_guid}");
            }

            return Done();
        }
    }
}

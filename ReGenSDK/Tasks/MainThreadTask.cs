using System;
using System.Threading.Tasks;
using Firebase.Extensions;
using UnityEngine;

namespace ReGenSDK.Tasks
{
    public static class MainThreadTask
    {
        public static Task Run(Func<Task> operation)
        {
            return Task.CompletedTask.ContinueWithOnMainThread(async dummy => await operation());
        }

        public static Task Run(this MonoBehaviour behaviour, Func<Task> operation)
        {
            return Run(operation);
        }
    }
}
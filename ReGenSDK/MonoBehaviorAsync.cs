using System;
using System.Threading.Tasks;
using Firebase.Extensions;
using UnityEngine;

namespace ReGenSDK
{
    public static class MonoBehaviorAsync
    {
        public static void Run(this MonoBehaviour behaviour, Func<Task> asyncOperation)
        {
            Task.CompletedTask.ContinueWithOnMainThread(task => { asyncOperation(); });
        }

        
    }
}
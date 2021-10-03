using System;
using DefaultNamespace.Models;
using Newtonsoft.Json;
using Proyecto26;
using UnityEngine;

namespace DefaultNamespace.Services
{
    public static class MatchService
    {
        public static void PostResults(MatchResults results)
        {
            var json = JsonConvert.SerializeObject(results, Formatting.Indented);
            Debug.Log(json);
            Debug.Log($"{Constants.ApiUrl}/match/results");
        
            RestClient.Post($"{Constants.ApiUrl}/match/results", json)
                .Then(response =>
                {
                    Debug.Log("Request successful");
                })
                .Catch(error =>
                {
                    Debug.Log("Request failed");
                    Debug.Log(error?.InnerException?.Message ?? "");
                    Debug.Log($"Could not post match results.{Environment.NewLine}{error.Message}");
                });
        }
    }
}
using System;
using Models;
using Newtonsoft.Json;
using Proyecto26;
using UnityEngine;

namespace Clients
{
    public static class MatchClient
    {
        public static void PostResults(MatchResults results)
        {
            var json = JsonConvert.SerializeObject(results, Formatting.Indented);
            Debug.Log(json);
            
            var url = $"{Constants.ApiUrl}/match/results";
            Debug.Log(url);
        
            RestClient.Post(url, json)
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
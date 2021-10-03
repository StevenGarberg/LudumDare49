using System;
using Extensions;
using Models;
using Newtonsoft.Json;
using Proyecto26;
using UnityEngine;

namespace Clients
{
    public static class PlayerClient
    {
        public static Player Player { get; set; } = new Player(new PlayerData());

        public static void Save()
        {
            var json = JsonConvert.SerializeObject(Player, Formatting.Indented);
            Debug.Log(json);
        
            var url = $"{Constants.ApiUrl}/players";
            Debug.Log(url);
        
            RestClient.Put(url, json)
                .Then(response =>
                {
                    Debug.Log("Request successful");
                    Player = JsonConvert.DeserializeObject<Player>(response.Text);
                })
                .Catch(error =>
                {
                    Debug.Log("Request failed");
                    Debug.Log(error?.InnerException?.Message ?? "");
                    Debug.Log($"Could not save the player.{Environment.NewLine}{error.Message}");
                });
        }

        public static void Fetch()
        {
            var encodedDeviceId = SystemInfo.deviceUniqueIdentifier.ToBase64String();
            var url = $"{Constants.ApiUrl}/players/{encodedDeviceId}?useOwnerId=true";
            Debug.Log(url);
        
            RestClient.Get(url)
                .Then(response =>
                {
                    Debug.Log("Request successful");
                    Player = JsonConvert.DeserializeObject<Player>(response.Text);
                    Debug.Log(JsonConvert.SerializeObject(Player, Formatting.Indented));
                })
                .Catch(error =>
                {
                    Debug.Log("Request failed");
                    Debug.Log(error?.InnerException?.Message ?? "");
                    Debug.Log($"Could not fetch the player.{Environment.NewLine}{error.Message}");
                });
        }
    }
}

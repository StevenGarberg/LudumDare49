﻿using System;
using Extensions;
using Models;
using Newtonsoft.Json;
using Proyecto26;
using UnityEngine;

namespace Clients
{
    public static class PlayerClient
    {
        public static void Save(Player player, Action<Player> successCallback)
        {
            var json = JsonConvert.SerializeObject(player, Formatting.Indented);
            Debug.Log(json);
        
            var url = $"{Constants.ApiUrl}/players";
            Debug.Log(url);
        
            RestClient.Put(url, json)
                .Then(response =>
                {
                    Debug.Log("Request successful");
                    var deserializedPlayer = JsonConvert.DeserializeObject<Player>(response.Text);
                    successCallback(deserializedPlayer);
                })
                .Catch(error =>
                {
                    Debug.Log("Request failed");
                    Debug.Log(error?.InnerException?.Message ?? "");
                    Debug.Log($"Could not save the player.{Environment.NewLine}{error.Message}");
                });
        }

        public static void Fetch(Action<Player> successCallback)
        {
            var encodedDeviceId = SystemInfo.deviceUniqueIdentifier.ToBase64String();
            var url = $"{Constants.ApiUrl}/players/{encodedDeviceId}?useOwnerId=true";
            Debug.Log(url);
        
            RestClient.Get(url)
                .Then(response =>
                {
                    Debug.Log("Request successful");
                    var deserializedPlayer = JsonConvert.DeserializeObject<Player>(response.Text);
                    successCallback(deserializedPlayer);
                    Debug.Log(JsonConvert.SerializeObject(deserializedPlayer, Formatting.Indented));
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

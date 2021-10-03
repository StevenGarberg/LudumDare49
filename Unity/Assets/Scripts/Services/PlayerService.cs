using System;
using DefaultNamespace;
using DefaultNamespace.Extensions;
using DefaultNamespace.Models;
using Newtonsoft.Json;
using Proyecto26;
using UnityEngine;
using Random = UnityEngine.Random;

public static class PlayerService
{
    public static Player Player { get; set; } = new Player(new PlayerData());

    public static void Save()
    {
        // TODO: Remove when UI controls hooked up
        Player.Data.DisplayName = $"Player {Random.Range(1, 1000)}";
        Player.Data.FavoriteColor = ColorUtility.ToHtmlStringRGB(ColorRandomizer.GetRandomPresetColor());
        
        var json = JsonConvert.SerializeObject(Player, Formatting.Indented);
        Debug.Log(JsonConvert.SerializeObject(Player, Formatting.Indented));
        Debug.Log($"{Constants.ApiUrl}/players");
        
        RestClient.Put($"{Constants.ApiUrl}/players", json)
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
        Debug.Log($"{Constants.ApiUrl}/players/{encodedDeviceId}?useOwnerId=true");
        
        RestClient.Get($"{Constants.ApiUrl}/players/{encodedDeviceId}?useOwnerId=true")
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

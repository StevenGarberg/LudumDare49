using System;
using DefaultNamespace;
using DefaultNamespace.Models;
using Newtonsoft.Json;
using Proyecto26;
using UnityEngine;

public static class PlayerService
{
    public static Player Player { get; set; } = new Player(new PlayerData());

    public static void Save()
    {
        var json = JsonConvert.SerializeObject(Player, Formatting.Indented);
        Debug.Log(JsonConvert.SerializeObject(Player, Formatting.Indented));
        Debug.Log(Constants.ApiUrl + "/players");
        
        RestClient.Put(Constants.ApiUrl + "/players", json)
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
}

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
        Debug.Log(JsonConvert.SerializeObject(Player, Formatting.Indented));
        Debug.Log(Constants.ApiUrl + "/players");
        
        RestClient.Put<Player>(Constants.ApiUrl + "/players", Player)
            .Then(response =>
            {
                Debug.Log("Request successful");
                Player = response;
            })
            .Catch(error =>
            {
                Debug.Log("Request failed");
                Debug.Log(error?.InnerException?.Message ?? "");
                Debug.Log($"Could not save the player.{Environment.NewLine}{error.Message}");
            });
    }
}

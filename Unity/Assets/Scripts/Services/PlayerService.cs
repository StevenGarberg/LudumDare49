using System;
using DefaultNamespace;
using DefaultNamespace.Models;
using Proyecto26;

public static class PlayerService
{
    public static object Player { get; set; } = new Player(new PlayerData());

    public static void Save()
    {
        RestClient.Put<Player>(Constants.ApiUrl + "/players", Player)
            .Then(response =>
            {
                Player = response;
            })
            .Catch(error =>
            {
                Console.WriteLine($"Could not save the player.{Environment.NewLine}{error.Message}");
            });
    }
}

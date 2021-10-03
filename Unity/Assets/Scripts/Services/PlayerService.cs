using Clients;
using Models;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services
{
    public static class PlayerService
    {
        public static Player Player { get; set; } = new Player(new PlayerData());

        public static void Save()
        {
            // TODO: Remove when UI controls hooked up
            Player.Data.DisplayName = $"Player {Random.Range(1, 1000)}";
            Player.Data.FavoriteColor = ColorUtility.ToHtmlStringRGB(ColorRandomizer.GetRandomPresetColor());
        
            PlayerClient.Save(Player, player =>
            {
                Player = player;
            });
        }

        public static void Fetch()
        {
            PlayerClient.Fetch(player =>
            {
                Player = player;
            });
        }
    }
}

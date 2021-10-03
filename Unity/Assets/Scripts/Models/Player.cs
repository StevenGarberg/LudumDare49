using System;
using System.Text;
using DefaultNamespace.Extensions;
using DefaultNamespace.Models;
using UnityEngine;

public class Player
{
    public string Id { get; set; }
    public string OwnerId { get; set; }
    public int Version { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public PlayerData Data { get; set; }
    
    public Player() { }

    public Player(PlayerData data)
    {
        OwnerId = SystemInfo.deviceUniqueIdentifier.ToBase64String();
        Version = 1;
        Data = data;
    }
}

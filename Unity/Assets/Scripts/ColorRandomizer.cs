﻿using UnityEngine;

public static class ColorRandomizer
{
    public static Color GetRandomColor()
    {
        var colors = new[]
        {
            Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow
        };
        var randomNumber = Random.Range(0, colors.Length);
        return colors[randomNumber];
    }
}
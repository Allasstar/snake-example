using System;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class Food
{
    public string foodName;
    public int foodScore;
    
    [JsonProperty]
    private float[] foodColorRGBA;
    
    [JsonIgnore]
    public Color foodColor
    {
        get => GetColor();
        set => foodColorRGBA = value.ToArray();
    }

    private Color GetColor()
    {
        return new Color().FromArray(foodColorRGBA);
    }
}

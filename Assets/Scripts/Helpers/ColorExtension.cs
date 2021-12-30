using UnityEngine;

public static class ColorExtension
{
    public static float[] ToArray(this Color color)
    {
        return new float[4] {
            color.r,
            color.g,
            color.b,
            color.a,
        };
    }
    
    public static Color FromArray(this Color color, float[] rgba)
    {
        return rgba.Length != 4 ? Color.white : new Color(rgba[0], rgba[1], rgba[2], rgba[3]);
    }
}

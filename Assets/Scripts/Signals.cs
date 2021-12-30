using System;

public static class Signals
{
   public static Action<int> LoadScene = i => { };
   public static Action<int> SceneLoaded = i => { };
   public static Action FoodPickUpTrigger = () => { };
   public static Action GameOverTrigger = () => { };
}

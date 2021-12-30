using System.Collections.Generic;

public static class DataKeeper
{
    public static ObservableValue<int> Score;
    public static ObservableValue<int> BestScore;
    public static ObservableValue<int> Streak;
    public static List<Food> Foods { get; private set;  }

    public static void SetFoods(List<Food> food)
    {
        Foods = new List<Food>();
        Foods.AddRange(food);
    }
}

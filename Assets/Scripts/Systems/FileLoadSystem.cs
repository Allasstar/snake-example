using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class FileLoadSystem : DontDestroyMonoBehaviour
{
    private void Awake()
    {
        InitializeDontDestroyOnLoad();
    }

    private void Start()
    {
        LoadFoods();
    }

    private void LoadFoods()
    {
        var file = Resources.Load<TextAsset>("FoodData");
        DataKeeper.SetFoods(JsonConvert.DeserializeObject<List<Food>>(file.text));
    }
}

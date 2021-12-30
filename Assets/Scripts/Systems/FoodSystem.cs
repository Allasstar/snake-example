using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    [SerializeField] private Vector2 _gameFieldX = new Vector2(11, 31);
    [SerializeField] private Vector2 _gameFieldY = new Vector2(9, 44);

    private Food _currentFood;
    private string _lastFood = "";
    
    private void Awake()
    {
        Signals.FoodPickUpTrigger += FoodTrigger;
        DataKeeper.Streak.SetValue(1);
        ReplaceFood();
    }

    private void OnDestroy()
    {
        Signals.FoodPickUpTrigger -= FoodTrigger;
    }
    
    private void FoodTrigger()
    {
        var streak = _currentFood.foodName.Equals(_lastFood) ? DataKeeper.Streak.Value + 1 : 1;
        var score = DataKeeper.Score.Value + _currentFood.foodScore * streak;

        _lastFood = _currentFood.foodName;

        DataKeeper.Streak.SetValue(streak);
        DataKeeper.Score.SetValue(score);

        ReplaceFood();
    }

    private void ReplaceFood()
    {
        _currentFood = DataKeeper.Foods[Random.Range(0, DataKeeper.Foods.Count)];
        _sprite.color = _currentFood.foodColor;
        transform.position = new Vector3(
            Mathf.Round(Random.Range(_gameFieldX.x, _gameFieldX.y)),
            Mathf.Round(Random.Range(_gameFieldY.x, _gameFieldY.y)),
            0
        );
    }
}

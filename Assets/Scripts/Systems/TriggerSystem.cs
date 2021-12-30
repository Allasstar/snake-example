using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case Tags.Food:
                Signals.FoodPickUpTrigger?.Invoke();
                break;
            case Tags.Wall:
            case Tags.SnakeBody:
                Signals.GameOverTrigger?.Invoke();
            break;
        }
    }
}

using UnityEngine;

public class Tester : DontDestroyMonoBehaviour
{
    private void Awake()
    {
        InitializeDontDestroyOnLoad();
    }

    [ContextMenu("Reset Best Score")]
    private void ResetBestScore()
    {
        PlayerPrefs.DeleteAll();
        DataKeeper.BestScore.SetValue(0);
    }
    
    [ContextMenu("Trigger: Game Over")]
    private void GameOver()
    {
        Signals.GameOverTrigger?.Invoke();
    }
    
    [ContextMenu("Trigger: Pick Up Food")]
    private void FoodPickUp()
    {
        Signals.FoodPickUpTrigger?.Invoke();
    }
}

using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _streak;
    
    private void OnEnable()
    {
        // Signals.ScoreChanged += SetScoreUI;
        // Signals.StreakChanged += SetStreakUI;
        DataKeeper.Score.ValueChanged += SetScoreUI;
        DataKeeper.Streak.ValueChanged += SetStreakUI;
        SetScoreUI(0);
        SetStreakUI(1);
    }

    private void OnDisable()
    {
        // Signals.ScoreChanged -= SetScoreUI;
        // Signals.StreakChanged -= SetStreakUI;

        DataKeeper.Score.ValueChanged -= SetScoreUI;
        DataKeeper.Streak.ValueChanged -= SetStreakUI;
    }
    
    private void SetScoreUI(int score)
    {
        _score.text = $"Score: {score}";
    }
    
    private void SetStreakUI(int streak)
    {
        _streak.text = $"x{streak}";
    }
}

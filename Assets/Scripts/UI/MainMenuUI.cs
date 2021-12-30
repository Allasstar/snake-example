using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreValue;
    [SerializeField] private Button _startGame;

    private void OnEnable()
    {
        _startGame.onClick.AddListener(StartGame);
        DataKeeper.BestScore.ValueChanged += BestScoreChanged;
    }

    private void OnDisable()
    {
        _startGame.onClick.RemoveListener(StartGame);
        DataKeeper.BestScore.ValueChanged -= BestScoreChanged;
    }

    private void StartGame()
    {
        Signals.LoadScene?.Invoke(1);
    }
    
    private void BestScoreChanged(int bestScore)
    {
        _scoreValue.text = $"Best Score: {bestScore}";
    }
}

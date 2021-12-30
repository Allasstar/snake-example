using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopupUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private Button _button;
    
    private void Awake()
    {
        _button.onClick.AddListener(LoadMainScene);
        Signals.GameOverTrigger += GameOverTrigger;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(LoadMainScene);
        Signals.GameOverTrigger -= GameOverTrigger;
    }
    
    private void GameOverTrigger()
    {
        _score.text = $"Score: {DataKeeper.Score.Value}";
        gameObject.SetActive(true);
    }

    private void LoadMainScene()
    {
        Signals.LoadScene?.Invoke(0);
    }
}

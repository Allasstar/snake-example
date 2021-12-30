using UnityEngine;

public class ScoreSystem : DontDestroyMonoBehaviour
{
    private void Awake()
    {
        InitializeDontDestroyOnLoad();
        Signals.SceneLoaded += SceneLoaded;
        DataKeeper.Score.ValueChanged += ScoreChanged;
    }

    private void OnDestroy()
    {
        Signals.SceneLoaded -= SceneLoaded;
        DataKeeper.Score.ValueChanged -= ScoreChanged;
    }

    private void Start()
    {
        LoadBestScore();
    }

    private void ScoreChanged(int score)
    {
        if (score <= DataKeeper.BestScore.Value) return;
        DataKeeper.BestScore.SetValue(score);
        PlayerPrefs.SetInt(PlayerPrefsKeys.BestScore, score);
        PlayerPrefs.Save();
    }

    private void SceneLoaded(int index)
    {
        switch (index)
        {
            case 0:
                LoadBestScore();
                break;
            case 1:
                DataKeeper.Score.SetValue(0);
                break;
        }
    }

    private static void LoadBestScore()
    {
        DataKeeper.BestScore.SetValue(PlayerPrefs.GetInt(PlayerPrefsKeys.BestScore, 0));
    }
}

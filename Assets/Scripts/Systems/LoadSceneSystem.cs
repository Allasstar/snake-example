using UnityEngine.SceneManagement;

public class LoadSceneSystem : DontDestroyMonoBehaviour
{
    private void Awake()
    {
        InitializeDontDestroyOnLoad();
        Signals.LoadScene += LoadScene;
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void OnDestroy()
    {
        Signals.LoadScene -= LoadScene;
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    
    private void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Signals.SceneLoaded?.Invoke(scene.buildIndex);
    }
}

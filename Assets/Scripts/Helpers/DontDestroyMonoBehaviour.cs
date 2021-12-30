using System.Collections.Generic;
using UnityEngine;

public abstract class DontDestroyMonoBehaviour : MonoBehaviour
{
    private static List<string> InitializedGameObjects = new List<string>();

    protected void InitializeDontDestroyOnLoad()
    {
        if (InitializedGameObjects.Contains(this.name))
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        InitializedGameObjects.Add(this.name);
    }
}

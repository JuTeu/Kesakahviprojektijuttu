using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    bool levelIsLoaded = false;

    public bool GetIsLevelLoaded() { return levelIsLoaded; }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenLevel(string levelName)
    {
        StartCoroutine(IEOpenLevel(levelName));
    }

    public void CloseLevel(string levelName)
    {
        SceneManager.UnloadSceneAsync(levelName);
    }

    IEnumerator IEOpenLevel(string levelName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        levelIsLoaded = true;
    }
}

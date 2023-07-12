using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    bool levelIsLoaded = false;
    [SerializeField] Sprite[] collectibleSprites;

    [SerializeField] string[] levelNames;

    public bool GetIsLevelLoaded() => levelIsLoaded;
    public string[] GetLevelNames() => levelNames;
    
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

    public Sprite GetCollectibleSprite(int id, bool specifyLevel)
    {
        int index = GameManager.currentLevel * 4 + id;
        if (specifyLevel) index = id;
        if (collectibleSprites.Length > index)
        return collectibleSprites[index];
        return null;
    }
}

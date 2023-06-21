using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Onko peli mobiililaitteella vai ei. Vaikuttaa esim. käyttöliittymään.
    public static bool isMobile = false;

    public static bool playerIsInControl = true;

    public static bool levelExitPortalFinishedClosing = false;
    public static bool playerIsReturningFromPortal = false;

    
    // Kahvila = 0, Tasohyppy = 1
    public static int gameMode = 0;

    // 0 = Testikenttä, 1 = Vesi temppeli
    public static int currentLevel = 0;

    public GameObject cafe;
    public GameObject player;
    Collider2D[] cafeColliders;
    LevelManager levelManager;

    void Start()
    {
        Instance = this;
        levelManager = GetComponent<LevelManager>();
    }

    void Update()
    {
        
    }

    public static void SetGameMode(int mode)
    {
        if (mode == 0)
        {
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else if (mode == 1)
        {
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 2;
        }
        gameMode = mode;
    }

    public static void EnableCafeCollisions(bool toggle)
    {
        Instance.cafeColliders = Instance.cafe.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D col in Instance.cafeColliders)
        {
            if (col != null && col.gameObject.name != "Placeholder_Room_1") col.enabled = toggle;
        }
    }

    public static void TurnCafeIntoAChildOfThePlayer(bool toggle)
    {
        if (toggle)
        {
            Instance.cafe.transform.SetParent(Instance.player.transform);
        }
        else
        {
            Instance.cafe.transform.SetParent(null);
        }
    }
    public static void ActivateCafe(bool toggle)
    {
        Instance.cafe.SetActive(toggle);
    }

    public static void OpenLevel(string levelName)
    {
        Instance.levelManager.OpenLevel(levelName);
    }

    public static void CloseLevel(string levelName)
    {
        Instance.levelManager.CloseLevel(levelName);
    }

    public static bool GetIsLevelLoaded()
    {
        return Instance.levelManager.GetIsLevelLoaded();
    }
}

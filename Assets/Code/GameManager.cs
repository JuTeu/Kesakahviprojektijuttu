using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    /*-----------/
    /   Vakiot   /
    /-----------*/

    // Onko peli mobiililaitteella vai ei. Vaikuttaa esim. käyttöliittymään.
    public const bool isMobile = false;
    // Miten asiat skaalautuvat kahvilassa suhteessa niiden sijaintiin y-aksellilla.
    public const float cafeScalingModifier = 0.1f;


    /*------------------------/
    /   Globaalit muuttujat   /
    /------------------------*/

    public static bool playerIsInControl = true;
    public static bool levelExitPortalFinishedClosing = false;
    public static bool playerIsReturningFromPortal = false;
    // Kahvila = 0, Tasohyppy = 1
    public static int gameMode = 0;


    /*-------------------------/
    /   Tallennettavat asiat   /
    /-------------------------*/
    
    // 0 = Testikenttä, 1 = Vesi temppeli
    public static int currentLevel;

    // 1 = Kenttä on avattu; 10 = Kenttä on suoritettu; 100, 1000, 10000 = Kerättävät
    public static int[] levels;


    /*-------------------------------------------/
    /   GameManagerin viitteet muihin olioihin   /
    /-------------------------------------------*/

    Collider2D[] cafeColliders;
    LevelManager levelManager;
    [SerializeField] GameObject cafe, player, cafeMainRoom;


    void Start()
    {
        Instance = this;
        levelManager = GetComponent<LevelManager>();

        currentLevel = 0;

        levels = new int[3];
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = PlayerPrefs.GetInt("Level" + i, 0);
        }

    }

    void Update()
    {
        
    }

    public static void SetGameMode(int mode)
    {
        if (mode == 0)
        {
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
            GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().size = new Vector2(0.9f, 0.4f);
            GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.2f);
        }
        else if (mode == 1)
        {
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 2;
            GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().size = new Vector2(0.9f, 0.9f);
            GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
        }
        gameMode = mode;
    }

    public static void EnableCafeCollisions(bool toggle)
    {
        Instance.cafeColliders = Instance.cafe.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D col in Instance.cafeColliders)
        {
            if (col != null && col.gameObject != Instance.cafeMainRoom) col.enabled = toggle;
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

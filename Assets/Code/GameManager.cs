using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static bool isMobile = false;

    // Kahvila = 0, Tasohyppy = 1
    public static int gameMode = 0;
    public GameObject cafe;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        cafe = GameObject.Find("Cafe");
    }

    // Update is called once per frame
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

    public static void ActivateCafe(bool toggle)
    {
        Instance.cafe.SetActive(toggle);
    }
}

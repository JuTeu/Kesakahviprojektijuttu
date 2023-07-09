using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] TextMeshProUGUI title1, percent1, title2, percent2, startText1, startText2;
    [SerializeField] Button startButton;

    string startText = "Aloita";
    string[] levelName = {"Testikenttä", "Vesitemppeli", "Joku"};
    string[] test2 = {"2%", "4%", "6%"};

    int levelCount, currentLevel;
    bool releasedOpenButton = false;
    PlayerMover playerMover;
    // Start is called before the first frame update
    void Start()
    {
        startText1.text = startText;
        startText2.text = startText;

        playerMover = GameObject.FindWithTag("Player").GetComponent<PlayerMover>();
        currentLevel = GameManager.currentLevel;
        levelCount = levelName.Length - 1;
        title2.text = levelName[currentLevel];
        percent2.text = test2[currentLevel];
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("None")) return;
        
        if (!releasedOpenButton && !playerMover.GetAction1Input())
        {
            releasedOpenButton = true;
        }
        else if (releasedOpenButton && playerMover.GetAction1Input())
        {
            GameManager.CloseLevel("LevelSelectMenu");
            GameManager.currentLevel = currentLevel;
            GameManager.playerIsReturningFromPortal = false;
            GameManager.playerIsInControl = true;
        }

        if (playerMover.GetMoveInput().x < 0 && currentLevel > 0)
        {
            title1.text = levelName[currentLevel - 1];
            title2.text = levelName[currentLevel];
            
            percent1.text = test2[currentLevel - 1];

            currentLevel--;
            anim.Play("TurnPageLeft");
        }
        else if (playerMover.GetMoveInput().x > 0 && currentLevel < levelCount)
        {
            title1.text = levelName[currentLevel];
            title2.text = levelName[currentLevel + 1];

            percent1.text = test2[currentLevel];
            percent2.text = test2[currentLevel + 1];
            currentLevel++;
            anim.Play("TurnPageRight");
        }
    }

    public void PageTurned()
    {
        title2.text = levelName[currentLevel];
        percent2.text = test2[currentLevel];
    }
}

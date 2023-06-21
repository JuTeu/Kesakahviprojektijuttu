using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] TextMeshProUGUI text1, text2l, text2r, text3;
    string[] test = {"Sivu 1", "kolme", "Viisi sivu"};
    string[] test2 = {"sivu kaks", "neöjä", "kuusi"};
    int levelCount, currentLevel = 0;
    bool releasedOpenButton = false;
    PlayerMover playerMover;
    // Start is called before the first frame update
    void Start()
    {
        playerMover = GameObject.FindWithTag("Player").GetComponent<PlayerMover>();
        levelCount = test.Length - 1;
        text2r.text = test[currentLevel];
        text3.text = test2[currentLevel];
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
            text1.text = test[currentLevel - 1];
            text2r.text = test[currentLevel];
            
            text2l.text = test2[currentLevel - 1];

            currentLevel--;
            anim.Play("TurnPageLeft");
        }
        else if (playerMover.GetMoveInput().x > 0 && currentLevel < levelCount)
        {
            text1.text = test[currentLevel];
            text2r.text = test[currentLevel + 1];

            text2l.text = test2[currentLevel];
            text3.text = test2[currentLevel + 1];
            currentLevel++;
            anim.Play("TurnPageRight");
        }
    }

    public void PageTurned()
    {
        text2r.text = test[currentLevel];
        text3.text = test2[currentLevel];
    }
}

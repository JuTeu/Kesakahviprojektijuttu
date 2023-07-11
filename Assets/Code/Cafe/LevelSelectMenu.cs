using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] TextMeshProUGUI title1, percent1, title2, percent2, startText1, startText2;
    [SerializeField] Image[] itemIcons1, itemIcons2, checkMarks1, checkMarks2;
    [SerializeField] Button startButton;
    [SerializeField] Sprite missingIcon, uncheck, check;

    // Näihin pitäisi kyllä keksiä parempi ratkaisu...
    string startText = "Aloita";
    string[] levelName = {"Testikenttä", "Vesitemppeli", "Joku"};

    int levelCount, currentLevel;
    bool releasedOpenButton = false;
    Sprite newIcon;
    PlayerMover playerMover;
    
    void Start()
    {
        startText1.text = startText;
        startText2.text = startText;

        playerMover = GameObject.FindWithTag("Player").GetComponent<PlayerMover>();
        currentLevel = GameManager.currentLevel;
        levelCount = GameManager.levels.Length - 1;
        title2.text = levelName[currentLevel];
        SetIcons(itemIcons2, 0);
        SetChecks(checkMarks2, itemIcons2, percent2, 0);
    }

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

            SetIcons(itemIcons1, -1);
            SetIcons(itemIcons2, 0);

            SetChecks(checkMarks1, itemIcons1, percent1, -1);
            SetChecks(checkMarks2, itemIcons2, percent2, 0);
            
            currentLevel--;
            anim.Play("TurnPageLeft");
        }
        else if (playerMover.GetMoveInput().x > 0 && currentLevel < levelCount)
        {
            title1.text = levelName[currentLevel];
            title2.text = levelName[currentLevel + 1];

            SetIcons(itemIcons1, 0);
            SetIcons(itemIcons2, 1);

            SetChecks(checkMarks1, itemIcons1, percent1, 0);
            SetChecks(checkMarks2, itemIcons2, percent2, 1);

            currentLevel++;
            anim.Play("TurnPageRight");
        }
    }

    public void PageTurned()
    {
        title2.text = levelName[currentLevel];
        SetIcons(itemIcons2, 0);
        SetChecks(checkMarks2, itemIcons2, percent2, 0);
    }

    void SetIcons(Image[] itemIcons, int offset)
    {
        for (int i = 0; i < itemIcons.Length; i++)
        {
            newIcon = GameManager.GetCollectibleSprite((currentLevel + offset) * 4 + i, true);
            if (newIcon != null)
            {
                itemIcons[i].sprite = newIcon;
            }
            else
            {
                itemIcons[i].sprite = missingIcon;
            }
        }
    }

    void SetChecks(Image[] checkMarks, Image[] itemIcons, TextMeshProUGUI percent, int offset)
    {

        bool mainIcon = (GameManager.levels[currentLevel + offset] & 0b_10) == 0b_10;
        bool collectibleIcon1 = (GameManager.levels[currentLevel + offset] & 0b_100) == 0b_100;
        bool collectibleIcon2 = (GameManager.levels[currentLevel + offset] & 0b_1000) == 0b_1000;
        bool collectibleIcon3 = (GameManager.levels[currentLevel + offset] & 0b_10000) == 0b_10000;

        itemIcons[0].color = mainIcon ? Color.white : Color.black;
        checkMarks[0].sprite = collectibleIcon1 ? check : uncheck;
        checkMarks[1].sprite = collectibleIcon2 ? check : uncheck;
        checkMarks[2].sprite = collectibleIcon3 ? check : uncheck;

        int percentage = 0;
        if (mainIcon) percentage += 34;
        if (collectibleIcon1) percentage += 22;
        if (collectibleIcon2) percentage += 22;
        if (collectibleIcon3) percentage += 22;
        percent.text = $"{percentage}%";
    }
}

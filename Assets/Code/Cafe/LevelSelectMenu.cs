using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using TMPro;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] TextMeshProUGUI title1, percent1, title2, percent2, startText1, startText2;
    [SerializeField] Image[] itemIcons1, itemIcons2, checkMarks1, checkMarks2;
    [SerializeField] Button startButton;
    [SerializeField] Sprite missingIcon, uncheck, check;
    [SerializeField] PlayableAsset enterPortal;

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
        SetPageContents(checkMarks2, itemIcons2, percent2, title2, 0);
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
            GameManager.PlayCutscene(enterPortal);
            //GameManager.playerIsInControl = true;
        }

        if (playerMover.GetMoveInput().x < 0 && currentLevel > 0)
        {
            SetPageContents(checkMarks1, itemIcons1, percent1, title1, -1);
            SetPageContents(checkMarks2, itemIcons2, percent2, title2, 0);
            
            currentLevel--;
            anim.Play("TurnPageLeft");
        }
        else if (playerMover.GetMoveInput().x > 0 && currentLevel < levelCount)
        {
            SetPageContents(checkMarks1, itemIcons1, percent1, title1, 0);
            SetPageContents(checkMarks2, itemIcons2, percent2, title2, 1);

            currentLevel++;
            anim.Play("TurnPageRight");
        }
    }

    public void PageTurned()
    {
        SetPageContents(checkMarks2, itemIcons2, percent2, title2, 0);
    }

    void SetPageContents(Image[] checkMarks, Image[] itemIcons, TextMeshProUGUI percent, TextMeshProUGUI title, int offset)
    {
        if (levelName.Length > currentLevel + offset)
        {
            title.text = levelName[currentLevel + offset];
        }
        else
        {
            title.text = "TITLE_MISSING";
            Debug.LogError("Kentälle ei ole määritelty nimeä LevelSelectMenu.cs skriptissä!");
        }
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

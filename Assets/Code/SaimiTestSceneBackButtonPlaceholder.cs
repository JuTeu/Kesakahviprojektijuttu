using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaimiTestSceneBackButtonPlaceholder : MonoBehaviour
{
    // Start is called before the first frame update
    public void Press()
    {
        GameManager.CloseLevel("saimiTestScene");
        GameManager.playerIsInControl = true;
    }
}

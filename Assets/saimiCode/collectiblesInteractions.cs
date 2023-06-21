using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectiblesInteractions : MonoBehaviour
{
    public GameObject infoBox;
    public void openInfoBox()
    {
        infoBox.SetActive(true);
    }
    public void closeInfoBox()
    {
        infoBox.SetActive(false);
    }
}

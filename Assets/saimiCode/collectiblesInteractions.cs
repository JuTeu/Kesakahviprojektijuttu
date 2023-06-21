using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class collectiblesInteractions : MonoBehaviour
{
    public GameObject infoBox;
    public TextMeshProUGUI infoText;
    private string selectedCollectible;
    public void openInfoBox()
    {
        infoBox.SetActive(true);
        selectedCollectible = EventSystem.current.currentSelectedGameObject.name;
        infoTextContents();
    }
    public void closeInfoBox()
    {
        infoBox.SetActive(false);
        selectedCollectible = "";
    }

    private void infoTextContents()
    {
        switch (selectedCollectible)
        {
            case "collectible1":
            infoText.text = "Information of collectible1, writing sample text to test the resisable infobox :)";
            break;
            
            case "collectible2":
            infoText.text = "Information of collectible2 writing sample text to test the resisable infobox :) writing sample text to test the resisable infobox :) writing sample text to test the resisable infobox :)";
            break;

            case "collectible3":
            infoText.text = "Information of collectible3 writing sample text to test the resisable infobox :) writing sample text to test the resisable infobox :) writing sample text to test the resisable infobox :) writing sample text to test the resisable infobox :) writing sample text to test the resisable infobox :) writing sample text to test the resisable infobox :)";
            break;
        }
    }
}

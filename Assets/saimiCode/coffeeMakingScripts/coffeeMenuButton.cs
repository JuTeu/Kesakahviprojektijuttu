using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coffeeMenuButton : MonoBehaviour
{
    public GameObject coffeeMenu;
    public GameObject coffeeMenuSlider;
    public TMP_Text arrow;

    private void Start()
    {
        arrow.text = "<-";
        this.gameObject.SetActive(true);
        coffeeMenu.SetActive(false);
        coffeeMenuSlider.SetActive(false);
    }
    public void openAndCloseCoffeeMenu()
    {
        var menuButton = this.gameObject.GetComponent<RectTransform>();
        var pos = menuButton.anchoredPosition;
        if (coffeeMenu.activeSelf && coffeeMenuSlider.activeSelf)
        {
        menuButton.anchoredPosition = new Vector2(0, pos.y);
        arrow.text = "<-";
        coffeeMenu.SetActive(false);
        coffeeMenuSlider.SetActive(false);
        }
        else
        {
        menuButton.anchoredPosition = new Vector2(-565, pos.y);
        arrow.text = "->";
        coffeeMenu.SetActive(true);
        coffeeMenuSlider.SetActive(true);
        }
    }
}

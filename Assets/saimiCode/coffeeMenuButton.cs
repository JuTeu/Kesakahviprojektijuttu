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
        this.gameObject.transform.position = new Vector2 (1869, 904);
        coffeeMenu.SetActive(false);
        coffeeMenuSlider.SetActive(false);
    }
    public void openAndCloseCoffeeMenu()
    {
        if (coffeeMenu.activeSelf && coffeeMenuSlider.activeSelf)
        {
        arrow.text = "<-";
        coffeeMenu.SetActive(false);
        coffeeMenuSlider.SetActive(false);
        this.gameObject.transform.position = new Vector2 (1869, 904);
        }
        else
        {
        arrow.text = "->";
        coffeeMenu.SetActive(true);
        coffeeMenuSlider.SetActive(true);
        this.gameObject.transform.position = new Vector2 (1305, 904);
        }
    }
}

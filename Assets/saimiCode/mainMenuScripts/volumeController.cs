using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class volumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMP_Text volumeTextUI = null;

    public void volumeSliderFunc(float volume)
    {
        volumeTextUI.text = volumeSlider.value.ToString("0.00");
    }
}

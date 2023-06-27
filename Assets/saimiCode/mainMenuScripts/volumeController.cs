using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class volumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMP_Text volumeTextUI = null;

    private void Start()
    {
        loadValues();
    }

    public void volumeSliderFunc(float volume)
    {
        volumeTextUI.text = volumeSlider.value.ToString("0.00");
    }

    public void saveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        loadValues();
    }

    void loadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}

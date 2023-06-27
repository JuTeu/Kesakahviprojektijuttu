using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}

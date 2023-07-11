using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;




    // scripti joka vaihtaa levelin seuraavaan, kun on t�rm�tty oikeaan esineeseen
    public class LevelChange : MonoBehaviour
    {
        [SerializeField] public string goNextScene;

        public void OnTriggerEnter2D()
        {
            SceneManager.LoadScene(goNextScene);
        }




    }


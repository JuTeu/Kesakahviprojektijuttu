using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class openDoor : MonoBehaviour
    {
        public GameObject Door;
      

        void Start()
        {
            Door.SetActive(false);
        }

        void OnMouseDown()
        {
            Debug.Log("Sprite Clicked");

            
            Door.SetActive(true);
        }



    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasohyppelynasettaminen : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // pelaajan koodissa asetetaan aluksi gamemode 0
        // IEnumeratorilla odotetaan että pelaajan scriptissä se on asetettu, jonka jälkeen se muutetaan toiseksi

        yield return new WaitForSeconds(0.5f);
        GameManager.SetGameMode(1);
        
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

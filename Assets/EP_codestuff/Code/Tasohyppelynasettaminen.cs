using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasohyppelynasettaminen : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // pelaajan koodissa asetetaan aluksi gamemode 0
        // IEnumeratorilla odotetaan ett� pelaajan scriptiss� se on asetettu, jonka j�lkeen se muutetaan toiseksi

        yield return new WaitForSeconds(0.5f);
        GameManager.SetGameMode(1);
        
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusAudio : MonoBehaviour
{

    public AudioSource firstKill, lastKill;

    public int virusKilled;

    void Start()
    {

        virusKilled = 0;

    }
    
    public void KillingVirus()
    {

        virusKilled += 1;

        if (virusKilled == 1)
        {

            firstKill.Play();

        }
        else if (virusKilled == 3)
        {

            lastKill.Play();

        }

    }

}

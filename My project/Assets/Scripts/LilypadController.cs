using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilypadController : MonoBehaviour
{
    // This script is simply for making every lilypad being rotated at a different angle, so all of them looks unique

    // The start function gets called automatically at the start of the game
    void Start()
    {
        // This line of code rotates the Lilypad that this script is attached onto, since this script is attached to every lilypad, all lilypad will be rotated at a random range from 1 - 360 degrees
        this.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
        // So technically every lilypad is rotating themselves.
    }

}

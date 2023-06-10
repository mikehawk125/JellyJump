using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncreasingHeartScript : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col)
    {
         GameControlScript.health += 1;
    }
}

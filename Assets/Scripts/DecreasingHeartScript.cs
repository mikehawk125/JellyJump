using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasingHeartScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        if (col.gameObject.CompareTag("Player")) {
            GameControlScript.health -= 1;
            Debug.Log(col.name);        
        }
    }
}
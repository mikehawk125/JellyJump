using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasingHeartScript : MonoBehaviour
{
    bool canTakeDamage = true;
    float delay = 2f;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && canTakeDamage) {
            GameControlScript.health -= 1;
            StartCoroutine(delayDamage());
            Debug.Log(col.name);        
        }
    }

    IEnumerator delayDamage() 
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(delay);
        canTakeDamage = true;
    }
}
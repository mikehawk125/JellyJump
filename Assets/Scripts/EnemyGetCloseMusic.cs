using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetCloseMusic : MonoBehaviour
{
    public Transform playerTransform;
    public AudioSource backgroundMusic;
    public AudioSource enemyGetCloseMusic;
    public float maxVolDistance = 20;
    public float minVolDistance = 5;
    

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(playerTransform.position, transform.position);
        float transition = Mathf.Clamp01(Mathf.InverseLerp(minVolDistance, maxVolDistance, distance));
        enemyGetCloseMusic.volume = Mathf.Lerp(1, 0, transition);
        backgroundMusic.volume = Mathf.Lerp(0, 1, transition);
    }
}

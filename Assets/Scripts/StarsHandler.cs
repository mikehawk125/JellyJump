using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsHandler : MonoBehaviour
{
    public GameObject[] stars;
    private int coinsCount;

    void Start()
    {
        coinsCount = GameObject.FindGameObjectsWithTag("Items").Length;
    }

    public void starsAcheived()
    {
        int coinsLeft = GameObject.FindGameObjectsWithTag("Items").Length;
        int coinsCollected = coinsCount - coinsLeft;

        float percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCount.ToString()) * 100f;

        if (percentage >= 33f && percentage < 66f)
        {
            stars[0].SetActive(true);
        }
        else if (percentage >= 66f && percentage <= 80f)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
}

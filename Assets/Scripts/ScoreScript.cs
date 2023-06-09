using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ScoreText;
    private int ScoreNumber;

    void Start()
    {
        ScoreNumber = 0;
        ScoreText.text = "Score: " + ScoreNumber;
    }

    // player touches colectable items (colItems)
    private void OnTriggerEnter2D (Collider2D colItems)
    {
        if(colItems.tag == "Items")
        {
            ScoreNumber++;
            Destroy(colItems.gameObject);
            ScoreText.text = "Score: " + ScoreNumber.ToString();
        }
    }
}

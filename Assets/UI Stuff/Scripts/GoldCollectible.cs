using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCollectible : MonoBehaviour
{
    public TextMeshProUGUI ScoreUpdateHere; 

    private int score; 

    private void Start()
    {
        UpdateScoreText(0); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gold"))
        {
            UpdateScoreText(5);
            Destroy(other.gameObject);
        }
    }


    private void UpdateScoreText(int amount)
    {   
        score += amount;
        ScoreUpdateHere.text = "" + score; 
    }
}

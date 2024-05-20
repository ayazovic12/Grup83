using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountCoinsPls : MonoBehaviour
{
    public static CountCoinsPls instance;

    public TMP_Text cointText;
    public int currentCoins;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cointText.text = currentCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCoinCount(int coinValue)
    {
        currentCoins += coinValue;
        cointText.text = currentCoins.ToString();
    }
}

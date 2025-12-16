using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickUp : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
}

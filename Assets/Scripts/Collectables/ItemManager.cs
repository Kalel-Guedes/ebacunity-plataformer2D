using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    //public static ItemManager Instance;
    public int coins;

    public TextMeshProUGUI coinsNumber;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        coinsNumber.text = "0";
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        coinsNumber.text = coins.ToString();
    }
}

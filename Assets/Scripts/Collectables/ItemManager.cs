using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    //public static ItemManager Instance;
    //public int coins;

    public SOCoins sOCoins;

    public TextMeshProUGUI coinsNumber;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        sOCoins.valor = 0;
        coinsNumber.text = sOCoins.valor.ToString();
    }

    public void AddBCoins(int amount = 1)
    {
        sOCoins.valor += amount;
        coinsNumber.text = sOCoins.valor.ToString();
    }
    public void AddGCoins(int amount = 3)
    {        
        sOCoins.valor += amount;
        coinsNumber.text = sOCoins.valor.ToString();
    }

    

    
}

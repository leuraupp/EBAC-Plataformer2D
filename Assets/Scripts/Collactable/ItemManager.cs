using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public TMP_Text coinsText;

    private void Reset() {
        coins = 0;
    }

    public void AddCoins(int amount = 1) {
        coins += amount;
        coinsText.text = "X "+coins;
    }
}

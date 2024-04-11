using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;

    private void Reset() {
        coins.value = 0;
        UpdateUi();
    }

    public void AddCoins(int amount = 1) {
        coins.value += amount;
        UpdateUi();
    }

    private void UpdateUi() {
        //UIInGameManager.UpdateUICoins("X " + coins.value.ToString());
    }
}

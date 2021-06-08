using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark;
using UI;

public class Engineering : Bay
{
    public void OpenMenu()
    {
        if (Purchased)
        {
            UIManager.ShowEngeneerBayMenu();
        }
        else
        {
            BuyBay();
        }
    }
}

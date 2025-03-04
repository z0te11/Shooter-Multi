using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPController : MonoBehaviour
{
    public void OnPurchaseCompleted(string productID)
    {
        switch (productID)
        {
            case "10Gold":
            {
                MoneyController.instance.AddMoney(10);
                break;
            }
            case "100Gold":
            {
                MoneyController.instance.AddMoney(100);
                break;
            }
            case "1000Gold":
            {
                MoneyController.instance.AddMoney(1000);
                break;
            }
        }
        Debug.Log("Purchased");
    }

}

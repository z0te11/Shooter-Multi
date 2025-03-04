using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject _shopUI;

    public void OpenShop()
    {
        _shopUI.SetActive(true);
    }

    public void CloseShop()
    {
        _shopUI.SetActive(false);
    }
}

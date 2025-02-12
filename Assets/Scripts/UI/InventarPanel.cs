using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarPanel : MonoBehaviour
{
    private bool isOpen;

    private void Start()
    {
        isOpen = true;
        CloseInventar();
    }

    public void CloseInventar()
    {
        if (isOpen)
        {
            gameObject.SetActive(false);
            isOpen = false;
        } 
        else return;
    } 

    public void OpenInventar()
    {
        if (!isOpen) 
        {
            gameObject.SetActive(true);
            isOpen = true;
        }
        else return;
    }
}

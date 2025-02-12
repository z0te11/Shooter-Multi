using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CraftController : MonoBehaviour
{
    public CraftSettings craftSettings;

    private List<ICraftable> items = new List<ICraftable>();
    private List<GameObject> selected = new List<GameObject>();

    public void EnterCraftMode()
    {
        selected.Clear();
        items = GetComponentsInChildren<ICraftable>().ToList();

        foreach (var item in items)
        {
            var button = ((MonoBehaviour)item)?.gameObject.AddComponent<Button>();
            button.onClick.AddListener(() => { Select(button.gameObject);}); 
        }
    }

    private void Select(GameObject item)
    {
        if (selected.Contains(item))
        {
            selected.Remove(item);
            item.GetComponent<Image>().color = new Color (1,1,1,1);
        }
        else
        {
            selected.Add(item);
            item.GetComponent<Image>().color = new Color (1,0.5f,0.5f,0.7f);
        }

        CheckCombo();
    }

    private void CheckCombo()
    {
        Debug.Log("StartCheck");
        List<string> selectedNames = new List<string>();
        foreach (var item in selected)
        {
            var n = item.GetComponent<ICraftable>().Name;
            selectedNames.Add(n);
        }
        List<string> sortList = selectedNames.OrderBy(s=>{return s[0];}).ToList();
        
        

        foreach (var combination in craftSettings.combinations)
        {
            combination.sources.Sort();
            if (combination.sources.SequenceEqual(sortList))
            {
                Debug.Log("Match");
                foreach (var item in selected)
                {
                    Destroy(item);
                }
                GameManager.instance.inventar.CreateItem(combination.result);
                
            }
        }
    }
}

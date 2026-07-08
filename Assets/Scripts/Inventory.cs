using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Linq;

public record invItem(string type, int amount);
public class Inventory : MonoBehaviour
{
    public List<invItem> items;
    public TMP_Text invBox;
    void Start()
    {
        items = new List<invItem>();
    }

    void Update()
    {
           invBox.text = "Inventory: "+string.Join(", ",items.Select(i => i.type + "(" + i.amount + ")"));
    }

    public void addItems(invItem item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(item.type == items[i].type)
            {
                items[i]= new invItem(items[i].type, items[i].amount + item.amount);
                return;
            }
        }
        items.Add(item);
    }

    public bool removeItems(invItem item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(item.type == items[i].type)
            {
                if(item.amount < items[i].amount)
                {
                items[i] = new invItem(items[i].type, items[i].amount - item.amount);
                return true;
                }
                else if(item.amount == items[i].amount){
                    items.Remove(item);
                    return true;
                }
            }
        }
        return false;
    }
}

using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using invItem = resource;
public class Inventory : MonoBehaviour
{
    bool shiftPressed = false;
    public int selector = 0;
    public List<invItem> items;
    public TMP_Text invBox;
    void Start()
    {
        items = new List<invItem>();
    }

    string ColorIfTrue(string str, bool shouldColor)
    {
        if (!shouldColor)
        {
            return str;
        }
        return "<color=yellow>"+str+"</color>";
    }
    void Update()
    {
        shiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
           invBox.text = "Inventory: "+string.Join(", ",items.Select((i, index) => ColorIfTrue(i.type + "(" + i.amount + ")",index == selector)));
        if (Input.GetKeyDown("1") && !shiftPressed)
        {
            selector = 0;
        }
        else if (Input.GetKeyDown("2") && !shiftPressed)
        {
            selector = 1;
        }
        else if (Input.GetKeyDown("3") && !shiftPressed)
        {
            selector = 2;
        }
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
                    items.RemoveAt(i);
                    return true;
                }
            }
        }
        return false;
    }

    public invItem GetSelectedItem()
    {
        if(items.Count > selector)
        {
            return items[selector];
        }
        return null;
    }
}

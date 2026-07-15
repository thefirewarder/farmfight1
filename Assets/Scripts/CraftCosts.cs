using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;

[System.Serializable]
public class Craft
{
    public List<resource> resources;
    public UnityEvent e;
    public string name;

  
    public Craft(List<resource> resources1, UnityEvent ev, string name1)
    {
        resources = resources1;
        e = ev;
        name = name1;
    }

    public string craftToString()
    {

        return name + " {"+string.Join(", ",resources.Select(r => r.type + "(" + r.amount + ")"))+"}";
    }
}

[System.Serializable]
public class CraftListWrapper
{
    public List<Craft> craftList;
}

public class CraftCosts : MonoBehaviour
{
    public Kingdom playerKingdom;
    public Craft currentCraft
    {
        get=>currentCraftPrivate;
        set
        {
            currentCraftPrivate=value;
        }

    }
    private Craft currentCraftPrivate;
     public List<CraftListWrapper> Crafts;

    void Start()
    {
        playerKingdom = GetComponent<Kingdom>();
    }

    public void TryCraftCurrent()
    {
        if (currentCraft != null && TryCraftItem(currentCraft))
        {
            currentCraft = null;
            Crafts.RemoveAt(0);
          
        }
    }

    void Update()
    {
        
            if (currentCraft == null && Crafts.Count != 0) 
            {
                 int index = (int) UnityEngine.Random.Range(0f, Crafts[0].craftList.Count);
                currentCraft = Crafts[0].craftList[index];
            }
    }

    public bool TryCraftItem(Craft item)
    {
        foreach(resource res in item.resources)
        {
            if (!playerKingdom.HasResource(res))
            {
                return false;
            }
        }
        foreach(resource res in item.resources)
        {
            playerKingdom.removeResources(res);
        }
        item.e?.Invoke();
        return true;
    }
}
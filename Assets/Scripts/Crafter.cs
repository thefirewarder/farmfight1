using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
public class Crafter : MonoBehaviour
{
    public List<resource> input;
    public CraftCosts craftCosts;
    public bool isResource;
    public resource output;
    public Kingdom kingdom;
    public Inventory inventory;
    float timer = 0f;
    public float timerMax = 60f;
    void Start()
    {
        craftCosts = GameObject.FindWithTag("Player").GetComponent<CraftCosts>();
        kingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timerMax)
        {
            timer = 0f;
            UnityEvent ev = new UnityEvent();
            ev.AddListener(CraftResult);
            Craft craft = new Craft(input, ev, "expand");
            craftCosts.TryCraftItem(craft);
        }
    }
    void CraftResult()
    {
        if (isResource)
        {
            kingdom.addResources(output);
        }
        else
        {
            inventory.addItems(output);
        }
    }
}

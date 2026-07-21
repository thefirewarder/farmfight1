using UnityEngine;
using TMPro;

using invItem = resource;
public class Build : MonoBehaviour
{
    public TMP_Dropdown buildDropdown; 
    public Market market;
    public Kingdom kingdom;
    public Inventory invScript;
    void Start()
    {
        buildDropdown = GetComponent<TMP_Dropdown>();
        market = GameObject.FindWithTag("Player").GetComponent<Market>();
        kingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
        invScript = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        buildDropdown.onValueChanged.AddListener(onBuildSelected);
    }
    void onBuildSelected(int index)
    {
        if(index == 0) return;
        if(index == 1 && kingdom.money >= 30)
        {
            kingdom.money -= 30;
            invScript.addItems(new invItem("camp", 1));
        }
        if(index == 2 && kingdom.money >= 25 && kingdom.HasResource(new resource("wood", 5)))
        {
            kingdom.money -= 25;
            kingdom.removeResources(new resource("wood", 5));
            invScript.addItems(new invItem("townhall", 1));
        }
        if(index == 3 && kingdom.money >= 50 && kingdom.HasResource(new resource("fargelstone", 5)))
        {
            kingdom.money -= 50;
            kingdom.removeResources(new resource("fargelstone", 5));
            invScript.addItems(new invItem("fargelbuilding", 1));
        }
        if(index == 4 && kingdom.money >= 100 && kingdom.HasResource(new resource("mallite", 5)))
        {
            kingdom.money -= 100;
            kingdom.removeResources(new resource("mallite", 5));
            invScript.addItems(new invItem("mallitebuilding", 1));
        }
        buildDropdown.SetValueWithoutNotify(0);
    }
}

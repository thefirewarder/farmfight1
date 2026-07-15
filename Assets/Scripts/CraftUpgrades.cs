using UnityEngine;

public class CraftUpgrades : MonoBehaviour
{
    public Grow[] growers;
    public bool hasCanal = false;
    public Kingdom playerKingdom;
    void Update()
    {
        if(hasCanal){
        growers = GameObject.FindObjectsByType<Grow>();
        foreach(Grow grower in growers)
        {
            grower.timerLength = 3.5f;
        }
        }
    }
    public void Start()
    {
        playerKingdom = GetComponent<Kingdom>();
    }
    public void addCanal()
    {
        hasCanal = true;
    }
    public void buildFargelstonePickaxe()
    {
        playerKingdom.oreMultiplier = 1.2f;
    }
    public void buildFargelstoneBoots()
    {
        playerKingdom.genericSpeedMultiplier = 1.1f;
    }
}

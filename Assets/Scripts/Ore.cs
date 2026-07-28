using UnityEngine;

public class Ore : MonoBehaviour
{
    tileData data;
    Kingdom kingdom;
    public int value = 50;
    public string resName = "copper ingot";
    public Transmutation transmutation;
    void Start()
    {
        data = GetComponent<tileData>();
        kingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
        transmutation = FindFirstObjectByType<Transmutation>();
    }

    void Update()
    {
        if (data.playerControlled)
        {
            if(transmutation.currentEffect == "Boon of Riches"){
            kingdom.money += (int) (value * 1.3f * kingdom.oreMultiplier);
            }
            else
            {
            kingdom.money += (int) (value * kingdom.oreMultiplier);
            }
            data.map.setTile(data.location, "dirt");
            if(Random.Range(1, 4) == 1)
            {
                kingdom.addResources(new resource(resName, 1));
            }
        }
    }
}

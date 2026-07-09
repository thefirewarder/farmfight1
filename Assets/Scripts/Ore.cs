using UnityEngine;

public class Ore : MonoBehaviour
{
    tileData data;
    Kingdom kingdom;
    public int value = 50;
    void Start()
    {
        data = GetComponent<tileData>();
        kingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
    }

    void Update()
    {
        if (data.playerControlled)
        {
            kingdom.money += value;
            data.map.setTile(data.location, "dirt");
        }
    }
}

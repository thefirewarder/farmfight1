using UnityEngine;

public class Gold : MonoBehaviour
{
    tileData data;
    Money moneyScript;

    public int value = 50;
    void Start()
    {
        data = GetComponent<tileData>();
        moneyScript = FindFirstObjectByType<Money>();
    }

    void Update()
    {
        if (data.playerControlled)
        {
            moneyScript.money += value;
            data.map.setTile(data.location, "dirt");
        }
    }
}

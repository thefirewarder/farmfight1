using UnityEngine;

public class House : MonoBehaviour
{
    Food foodScript;
    public float timerLength;
    
    Kingdom kingdom;
    tileData data;
    public float timer = 0f;
    public int troopChance = 3;
    void Start()
    {
        data = GetComponent<tileData>();
        foodScript = FindFirstObjectByType<Food>();
        kingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
    }

    void Update()
    {
       timer += Time.deltaTime;
       if(timer > timerLength)
        {
            timer = 0f;
            if(foodScript.currentFood == 0)
            {
                data.map.setTile(data.location, "dirt");
            }
            else
            {
                foodScript.currentFood--;
            }
            for(int x = 0; x < data.map.mapSize.x; x++)
            {
                for(int y = 0; y < data.map.mapSize.y; y++)
                {
                    if(data.map.getTileAtPosition(new Vector2Int(x, y)).GetComponent<tileData>().type == "camp" && Random.Range(1, troopChance) == 1)
                    {
                        kingdom.troops++;
                    }
                }
            }
        }
    }
}

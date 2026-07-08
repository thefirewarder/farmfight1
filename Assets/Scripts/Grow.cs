using UnityEngine;

public class Grow : MonoBehaviour
{
    public float timer = 0f;
    

    Food foodScript; 
    public float timerLength;
    void Start()
    {
        foodScript = FindFirstObjectByType<Food>();
    }

    void Update()
    {
        int houses = 0;
        Vector2Int[] directions = {new Vector2Int(0, 1), new Vector2Int(-1, 0), new Vector2Int(0, -1), new Vector2Int(1, 0)};
        tileData data = GetComponent<tileData>();
        foreach(Vector2Int dir in directions)
        {
            GameObject tile = data.map.getTileAtPosition(dir + data.location);
            if(tile && tile.GetComponent<tileData>().type == "house")
            {
                houses++;
            }
        }
        timer += Time.deltaTime * houses;
        if(timer > timerLength)
        {
            data.map.setTile(data.location, "dirt");
            foodScript.currentFood++;
            timer = 0f;
        }
    }
}

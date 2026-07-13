using UnityEngine;

public class Grow : MonoBehaviour
{
    public float timer = 0f;
    public float timer2 = 0f;

    Food foodScript; 
    public float timerLength;
    public float timer2Length;
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
        timer2 += Time.deltaTime * houses;
        if(timer > timerLength)
        {
            if(gameObject.name == "Crop(Clone)"){
            data.map.setTile(data.location, "dirt");
            foodScript.currentFood++;
            timer = 0f;
            }
        }
        if(timer2 > timer2Length)
        {
            if(gameObject.name == "Dirt(Clone)" && houses >= 3){
            data.map.setTile(data.location, "crop");
            }
            timer2 = 0f;
        }
    }
}

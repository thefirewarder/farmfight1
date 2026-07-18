using UnityEngine;
using System.Collections.Generic;

public class Grow : MonoBehaviour
{
    public Queue<(GameObject road, int distance)> queue = new Queue<(GameObject , int)>();
    HashSet<GameObject> visitedRoads = new HashSet<GameObject>();
    HashSet<GameObject> countedHouses = new HashSet<GameObject>();
    
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
        queue.Clear();
        visitedRoads.Clear();
        countedHouses.Clear();
        float farmingPower = 0f;
        Vector2Int[] directions = {new Vector2Int(0, 1), new Vector2Int(-1, 0), new Vector2Int(0, -1), new Vector2Int(1, 0)};
        tileData data = GetComponent<tileData>();
        foreach(Vector2Int dir in directions)
        {
            GameObject tile = data.map.getTileAtPosition(dir + data.location);
            if(tile && tile.GetComponent<tileData>().type == "house")
            {
                farmingPower++;
                countedHouses.Add(tile);
            }
            else if(tile && tile.GetComponent<tileData>().type == "road")
            {
                queue.Enqueue((tile, 1));
                visitedRoads.Add(tile);
            }
        }
        while(queue.Count > 0)
        {
            (GameObject currentRoad, int distance) = queue.Dequeue();
            tileData roadData = currentRoad.GetComponent<tileData>();
            foreach(Vector2Int dir in directions)
            {
                GameObject neighbor = data.map.getTileAtPosition(dir + roadData.location);
                if(neighbor)
                {
                    if(neighbor.GetComponent<tileData>().type == "house")
                    {
                        if (!countedHouses.Contains(neighbor))
                        {
                            farmingPower += GetFarmingPowerByDistance(distance);
                            countedHouses.Add(neighbor);
                        }
                    }
                    else if(neighbor.GetComponent<tileData>().type == "road")
                    {
                        if (!visitedRoads.Contains(neighbor))
                        {
                            visitedRoads.Add(neighbor);
                            queue.Enqueue((neighbor, distance + 1));
                        }
                    }
                }
            }
        }
        timer += Time.deltaTime * farmingPower;
        timer2 += Time.deltaTime * farmingPower;
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
            if(gameObject.name == "Dirt(Clone)" && farmingPower >= 3){
            data.map.setTile(data.location, "crop");
            }
            timer2 = 0f;
        }
    }
    public float GetFarmingPowerByDistance(int distance)
    {
        return 1f / (float) distance;
    }
}

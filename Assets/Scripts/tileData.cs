using UnityEngine;

public class tileData : MonoBehaviour
{
    public Vector2Int location;
    public string type;
    public bool playerControlled = true;
    public tileMap map;
    void Start()
    {
    
    }

    void Update()
    {
        if (playerControlled || type == "wall")
        {
            return;
        }
        Vector2Int[] directions = {new Vector2Int(0, 1), new Vector2Int(-1, 0), new Vector2Int(0, -1), new Vector2Int(1, 0)};
        foreach(Vector2Int direction in directions)
        {
            GameObject neighbor = map.getTileAtPosition(direction + location);
            if(neighbor && neighbor.GetComponent<tileData>().playerControlled)
            {
                if(type == "dirt"){
                GameObject tile = map.setTile(location, "wall");
                tile.GetComponent<tileData>().playerControlled = false;
                }
                else
                {
                    playerControlled = true;
                }
                return;
            }
        }
    }
}

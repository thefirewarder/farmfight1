using UnityEngine;
using System.Collections.Generic;
public class tileMap : MonoBehaviour
{
    private GameObject folder;
    public Vector2Int mapSize;
    public GameObject dirt;
    public GameObject crop;
    public GameObject house;
    public GameObject wall;
    public GameObject camp;
    public GameObject gold;
    public GameObject copper;
    public GameObject silver;
    public GameObject townhall;

    public float goldChance = 100f;

    public float silverChance = 50f;

    public float copperChance = 25f;
    public Dictionary<string, GameObject> types;
    GameObject[,] map;
    int minX = 30;
    int maxX = 31;
    int minY = 30;
    int maxY = 31;
 
    void Start() 
    {
        types = new Dictionary<string, GameObject>();
        types["dirt"]=dirt;
        types["crop"]=crop;
        types["house"]=house;
        types["wall"]=wall;
        types["camp"]=camp;
        types["gold"]=gold;
        types["silver"]=silver;
        types["copper"] = copper;
        types["townhall"] = townhall;
        folder = new GameObject("folder");
        map = new GameObject[mapSize.x,mapSize.y];
        for(int x = 0; x < mapSize.x; x++){
            for(int y = 0; y < mapSize.y; y++){
                Vector2Int pos = new Vector2Int(x, y);
                setTile(pos, "dirt");
                if(x < minX || x > maxX  || y < minY || y > maxY)
                {
                    if(Random.Range(0, goldChance) < 1)
                    {
                        setTile(pos, "gold");
                    }
                    else if(Random.Range(0, silverChance) < 1)
                    {
                        setTile(pos, "silver");
                    }
                    else if(Random.Range(0, copperChance) < 1)
                    {
                        setTile(pos, "copper");
                    }
                    map[x,y].GetComponent<tileData>().playerControlled = false;
                }
            }
        }
    }

    public GameObject setTile(Vector2Int pos, string type){
        if(inMap(pos)){
            if(map[pos.x,pos.y] != null)
            {
                Destroy(map[pos.x,pos.y]);
            }
             map[pos.x,pos.y] = Instantiate(types[type], new Vector3(pos.x+.5f-mapSize.x/2, pos.y+.5f-mapSize.y/2, 0), Quaternion.identity, folder.transform); 
             GameObject tile = map[pos.x,pos.y];
             tileData data = tile.AddComponent<tileData>();
             data.type = type;
             data.location = pos;
             data.map = this; 
             return tile;  
        }
        else
        {
            return null;
        }
    }

    void Update()
    {
        
    }

    public GameObject getTileAtPosition(Vector2Int pos){
        if(inMap(pos)){
        return map[pos.x,pos.y];
        }
        else{
            return null;
        }
    }

    public Vector2Int getBlockCoords(Vector2 pos){
        return new Vector2Int((int) Mathf.Floor(pos.x + mapSize.x/2), (int) Mathf.Floor(pos.y + mapSize.y/2));
    }

    public GameObject getTileAtPosition(Vector2 pos){
        Vector2Int location = getBlockCoords(pos);
        return getTileAtPosition(location);
    }
    public bool inMap(Vector2Int pos){
        return pos.x >= 0 && pos.y >= 0 && mapSize.x > pos.x && mapSize.y > pos.y;
    }
}

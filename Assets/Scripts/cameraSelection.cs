using UnityEngine;

public class cameraSelection : MonoBehaviour
{
    public tileMap map;
    public Inventory inventory;

    public Wall wallScript;

    public Money moneyScript;
    void Start()
    {
        wallScript = FindFirstObjectByType<Wall>();
        map = FindFirstObjectByType<tileMap>();
        inventory = FindFirstObjectByType<Inventory>();
        moneyScript = FindFirstObjectByType<Money>();
    }

    void Update()
    {
        GameObject worldPos = map.getTileAtPosition(getWorldPosition());
        Vector2Int worldCoords = map.getBlockCoords(getWorldPosition());
        if (!worldPos)
        {
            return;
        }
        tileData worldData = worldPos.GetComponent<tileData>();
        
        if(Input.GetMouseButtonDown(0)){
            if(worldData.type == "wall" && moneyScript.money > 0 && wallScript.wallStrength < wallScript.maxStrength)
                {
                    int moneyRequired = (int) ((wallScript.maxStrength - wallScript.wallStrength) * 20);
                    if(moneyRequired >= moneyScript.money){
                    wallScript.wallStrength += moneyScript.money / 20f;
                    moneyScript.money = 0;
                    }
                    else
                    {
                        moneyScript.money -= moneyRequired;
                        wallScript.wallStrength = wallScript.maxStrength;
                    }
                }
                 if(worldData.playerControlled){
            map.setTile(worldCoords,"crop");
                 }
        }
        else if (Input.GetMouseButtonDown(1))
        {
             if(worldData.playerControlled && worldData.type != "house"){
            map.setTile(worldCoords, "house");
             }
        }
        if (Input.GetMouseButtonDown(2)) 
            {
                if(inventory.items.Count == 0){
                    return;
                }
                string itemType = inventory.items[0].type;
                bool wasRemoved = inventory.removeItems(new invItem(inventory.items[0].type, 1));
                if (wasRemoved)
                {
                    switch(itemType){
                        case "land":
                        if(worldData.type == "wall")
                        {
                            map.setTile(worldCoords,"dirt");
                        }
                        break;
                        default:
                        if(worldData.playerControlled){
                        map.setTile(worldCoords, itemType);
                        }
                        break;
                    }
                }
            }
    }

    Vector2 getWorldPosition(){
        Vector3 position = Input.mousePosition;
        position.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 location = Camera.main.ScreenToWorldPoint(position);
        return new Vector3(location.x, location.y);
    }
}

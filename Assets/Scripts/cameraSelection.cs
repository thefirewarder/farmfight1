using UnityEngine;
using System.Linq;
public class cameraSelection : MonoBehaviour
{
    public tileMap map;
    public Inventory inventory;

   Kingdom kingdom;
    void Start()
    {
        kingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
        map = FindFirstObjectByType<tileMap>();
        inventory = FindFirstObjectByType<Inventory>();
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
            if(worldData.type == "wall" && kingdom.money > 0 && kingdom.wallStrength < kingdom.maxStrength)
                {
                    int moneyRequired = (int) ((kingdom.maxStrength - kingdom.wallStrength) * 20);
                    if(moneyRequired >= kingdom.money){
                    kingdom.wallStrength += kingdom.money / 20f;
                    kingdom.money = 0;
                    }
                    else
                    {
                        kingdom.money -= moneyRequired;
                        kingdom.wallStrength = kingdom.maxStrength;
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

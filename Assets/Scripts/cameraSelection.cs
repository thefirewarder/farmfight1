using UnityEngine;
using System.Linq;

using invItem = resource;
public class cameraSelection : MonoBehaviour
{
    public tileMap map;
    public Inventory inventory;
    public WallDmgDisplay dmgDisplay;
    public int wallUpCost = 75;
    public int wallUpCost2 = 135;
    public int wallUpCost3 = 300;

   Kingdom kingdom;
    void Start()
    {
        kingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
        map = FindFirstObjectByType<tileMap>();
        inventory = FindFirstObjectByType<Inventory>();
        dmgDisplay = GetComponent<WallDmgDisplay>();
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
                if(worldData.TryGetComponent<Crafter>(out Crafter cr))
            {
                cr.enabled = !cr.enabled;
            }
                 else if(worldData.playerControlled){
                if(worldData.type == "road")
                {
                    inventory.addItems(new invItem("road", 1));
                }
                else if(worldData.type == "house2")
                {
                    inventory.addItems(new invItem("house upgrade", 1));
                }
            map.setTile(worldCoords,"crop");
                 }
        }
        else if (Input.GetMouseButtonDown(1))
        {
             if(worldData.playerControlled && worldData.type != "house"){
            map.setTile(worldCoords, "house");
             }
             if(worldData.type == "wall")
            {
                if(kingdom.maxStrength == 0.5f && kingdom.money >= wallUpCost)
                {
                    kingdom.money -= wallUpCost;
                    kingdom.maxStrength = 0.8f;
                    kingdom.wallStrength = kingdom.maxStrength;
                }
                else if(kingdom.maxStrength == 0.8f && kingdom.money >= wallUpCost2)
                {
                    kingdom.money -= wallUpCost2;
                    kingdom.maxStrength = 1.5f;
                    kingdom.wallStrength = kingdom.maxStrength;
                }
                else if(kingdom.maxStrength == 1.5f && kingdom.money >= wallUpCost3)
                {
                    kingdom.money -= wallUpCost3;
                    kingdom.maxStrength = 2.5f;
                    kingdom.wallStrength = kingdom.maxStrength;
                }
            }
            }
        if (Input.GetMouseButtonDown(2)) 
            {
                if(inventory.items.Count == 0){
                    return;
                }
                invItem item1 = inventory.GetSelectedItem();
                if(item1 == null) return;
                string itemType = item1.type;
                invItem item = new invItem(itemType, 1);
                bool wasRemoved = inventory.removeItems(new invItem(itemType, 1));
                if (wasRemoved)
                {
                    switch(itemType){
                        case "land":
                        if(worldData.type == "wall")
                        {
                            map.setTile(worldCoords,"dirt");
                        }
                        else{
                            inventory.addItems(item);
                        }
                        break;
                        case "house upgrade":
                        if(worldData.type == "house")
                        {
                            map.setTile(worldCoords,"house2");
                        }
                        else
                        {
                            inventory.addItems(item);
                        }
                        break;
                        default:
                        if(worldData.playerControlled){
                        map.setTile(worldCoords, itemType);
                        }
                        else{
                            inventory.addItems(item);
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

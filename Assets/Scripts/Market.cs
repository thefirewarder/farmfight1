using UnityEngine;

public class Market : MonoBehaviour
{
    Food foodScript;
    public int landCost = 15;
    public int campCost = 35;
    Kingdom kingdom;
    Inventory invScript;
     void Start()
    {
        kingdom = GetComponent<Kingdom>();
        foodScript = GetComponent<Food>();
        invScript = GetComponent<Inventory>();
    }

    public void sellFood()
    {
        if(foodScript.currentFood >= 1)
        {
            foodScript.currentFood--;
            kingdom.money++;
        }
    }

    public void buyLand()
    {
        if(kingdom.money >= landCost)
        {
            kingdom.money -= landCost;
            invScript.addItems(new invItem("land", 1));
        }
    }

    public void buyTrainingCamp()
    {
        if(kingdom.money >= campCost)
        {
            kingdom.money -= campCost;
            invScript.addItems(new invItem("camp", 1));
        }
    }
}

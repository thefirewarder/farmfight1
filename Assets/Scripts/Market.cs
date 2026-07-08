using UnityEngine;

public class Market : MonoBehaviour
{
    Food foodScript;
    Money moneyScript;

    public int landCost = 15;
    public int campCost = 35;

    Inventory invScript;
     void Start()
    {
        foodScript = GetComponent<Food>();
        moneyScript = GetComponent<Money>();
        invScript = GetComponent<Inventory>();
    }

    public void sellFood()
    {
        if(foodScript.currentFood >= 1)
        {
            foodScript.currentFood--;
            moneyScript.money++;
        }
    }

    public void buyLand()
    {
        if(moneyScript.money >= landCost)
        {
            moneyScript.money -= landCost;
            invScript.addItems(new invItem("land", 1));
        }
    }

    public void buyTrainingCamp()
    {
        if(moneyScript.money >= campCost)
        {
            moneyScript.money -= campCost;
            invScript.addItems(new invItem("camp", 1));
        }
    }
}

using UnityEngine;
using TMPro;

using invItem = resource;
public class Market : MonoBehaviour
{
    Food foodScript;
    public int landCost = 15;
    Kingdom kingdom;
    public TMP_InputField foodInput;
    Inventory invScript;
     void Start()
    {
        kingdom = GetComponent<Kingdom>();
        foodScript = GetComponent<Food>();
        invScript = GetComponent<Inventory>();
    }

    public void sellFood()
    {
        if(int.TryParse(foodInput.text, out int sale)){
        if(foodScript.currentFood >= sale)
        {
            foodScript.currentFood-=sale;
            kingdom.money+=sale;
            foodInput.text = "";
        }
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
}

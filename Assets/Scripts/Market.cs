using UnityEngine;
using TMPro;

using invItem = resource;
public class Market : MonoBehaviour
{
    public int landBought = 0;
    Food foodScript;
    public int landCost = 15;
    Kingdom kingdom;
    public TMP_InputField foodInput;
    public TMP_Text BasicLandTxt;
    public bool mustIncreaseCost = false;
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
            landBought++;
            invScript.addItems(new invItem("land", 1));
            if(mustIncreaseCost){
            landCost++;
            mustIncreaseCost = false;
            }
            else
            {
            mustIncreaseCost = true;
            }
            BasicLandTxt.text = "Buy Land ("+landCost+")";
        }
    }
}

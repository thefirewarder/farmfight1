using UnityEngine;
using TMPro;
public class Food : MonoBehaviour
{
    public TMP_Text foodCounter;
    public int currentFood = 10;
    
     void Awake()
    {
        Debug.Log("Wall upgrade costs: \n Stone: 75 money, Iron: 135 money, Rainbow: 300 money");
    }
    void Update()
    {
        foodCounter.text = "Food: "+currentFood;
    }
}

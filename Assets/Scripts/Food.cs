using UnityEngine;
using TMPro;
public class Food : MonoBehaviour
{
    public TMP_Text foodCounter;
    public int currentFood = 10;
    void Start()
    {
        
    }

    void Update()
    {
        foodCounter.text = "Food: "+currentFood;
    }
}

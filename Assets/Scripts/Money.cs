using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int money = 0;
    public TMP_Text moneyCounter;
    void Start()
    {
        
    }

    void Update()
    {
        moneyCounter.text = "Tokens: "+money;
    }
}

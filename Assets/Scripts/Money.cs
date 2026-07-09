using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    Kingdom kingdom;
    public TMP_Text moneyCounter;
    void Start()
    {
         kingdom = GetComponent<Kingdom>();
    }

    void Update()
    {
        moneyCounter.text = "Gold: "+kingdom.money;
    }
}

using UnityEngine;
using TMPro;

public class Troops : MonoBehaviour
{
    public TMP_Text troopCounter;
    Kingdom kingdom;
    void Start()
    {
        kingdom = GetComponent<Kingdom>();
    }
    
    void Update()
    {
        troopCounter.text = "Troops: "+kingdom.troops;
    }
}

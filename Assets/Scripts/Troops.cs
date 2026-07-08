using UnityEngine;
using TMPro;

public class Troops : MonoBehaviour
{
    public TMP_Text troopCounter;
    public int currentTroops = 0;
    void Start()
    {
        
    }
    
    void Update()
    {
        troopCounter.text = "Troops: "+currentTroops;
    }
}

using UnityEngine;
using TMPro;

public class CraftText : MonoBehaviour
{
    public CraftCosts costs;
    public TMP_Text txt;
    void Start()
    {
        costs = GameObject.FindWithTag("Player").GetComponent<CraftCosts>();
        txt = GetComponent<TMP_Text>();
    }
    void Update()
    {
        if(costs.currentCraft != null){
        txt.text = costs.currentCraft.craftToString();
        }
        else
        {
        txt.text = "Fully Upgraded! No more crafting recipes!";
        }
    }
}

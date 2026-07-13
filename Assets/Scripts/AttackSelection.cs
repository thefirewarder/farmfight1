using UnityEngine;
using TMPro;

public class AttackSelection : MonoBehaviour
{
    private Kingdom playerKingdom;
    private Kingdom fireKingdom; 
    private Kingdom pirateKingdom; 
    private Kingdom banditKingdom;
    public TMP_InputField input; 
    
    public TMP_Dropdown civDropdown; 

    void Start() 
    { 
        civDropdown = GetComponent<TMP_Dropdown>(); 
        playerKingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>(); 
        fireKingdom = GameObject.FindWithTag("Fire").GetComponent<Kingdom>(); 
        pirateKingdom = GameObject.FindWithTag("Pirate").GetComponent<Kingdom>(); 
        banditKingdom = GameObject.FindWithTag("Bandit").GetComponent<Kingdom>(); 

        civDropdown.onValueChanged.AddListener(OnCivSelected);
    } 

    void OnCivSelected(int index)
{
    if (index == 0) return;

    if (!int.TryParse(input.text, out int troopsSent) ||
        troopsSent <= 0 ||
        troopsSent > playerKingdom.troops)
        return;

    Kingdom targetKingdom = index switch
    {
        1 => fireKingdom,
        2 => pirateKingdom,
        3 => banditKingdom,
        _ => null
    };

    if (targetKingdom == null)
        return;

    if (playerKingdom.invadee != null)
        return;

    playerKingdom.invadee = targetKingdom;
    playerKingdom.troopsInvading = troopsSent;
    playerKingdom.troops -= troopsSent;
    playerKingdom.StartArmyMarch();

    civDropdown.SetValueWithoutNotify(0);
}

}

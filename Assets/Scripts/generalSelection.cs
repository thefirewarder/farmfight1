using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class generalSelection : MonoBehaviour
{
    public Kingdom playerKingdom;
    public OwnedGenerals ownedGenerals;
    public TMP_Dropdown genDropdown; 
    void Start()
    {
        playerKingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
        ownedGenerals = GameObject.FindWithTag("Player").GetComponent<OwnedGenerals>();
        genDropdown = GetComponent<TMP_Dropdown>();
    }

    void Update()
    {
        int currentIndex = genDropdown.value;
        genDropdown.ClearOptions();
        List<string> text = ownedGenerals.generalsOwned.Select(t => t.toString()).ToList();
        genDropdown.AddOptions(text);
        genDropdown.value = currentIndex;
    }
    public void SelectGeneral(int index){
        playerKingdom.general = ownedGenerals.generalsOwned[index];
    }
}

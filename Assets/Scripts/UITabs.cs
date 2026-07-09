using UnityEngine;

public class UITabs : MonoBehaviour
{
    public GameObject militaryPanel;
    public GameObject economyPanel;

    public void ShowEconomy()
    {
        economyPanel.SetActive(true);
        militaryPanel.SetActive(false);
    } 
    public void ShowMilitary()
    {
        economyPanel.SetActive(false);
        militaryPanel.SetActive(true);
    }
    void Start()
    {
        ShowEconomy();
    }

    void Update()
    {
        
    }
}

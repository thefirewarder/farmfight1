using UnityEngine;

public class UITabs : MonoBehaviour
{
    public GameObject militaryPanel;
    public GameObject economyPanel;
    public GameObject craftingPanel;

    public void ShowEconomy()
    {
        economyPanel.SetActive(true);
        militaryPanel.SetActive(false);
        craftingPanel.SetActive(false);
    } 
    public void ShowMilitary()
    {
        economyPanel.SetActive(false);
        militaryPanel.SetActive(true);
        craftingPanel.SetActive(false);
    }
    public void ShowCrafting()
    {
        craftingPanel.SetActive(true);
        militaryPanel.SetActive(false);
        economyPanel.SetActive(false);
    }
    void Start()
    {
        ShowEconomy();
    }

}

using UnityEngine;

public class UITabs : MonoBehaviour
{
    public GameObject militaryPanel;
    public GameObject economyPanel;
    public GameObject alchemyPanel;

    public void ShowEconomy()
    {
        economyPanel.SetActive(true);
        militaryPanel.SetActive(false);
        alchemyPanel.SetActive(false);
    } 
    public void ShowMilitary()
    {
        economyPanel.SetActive(false);
        militaryPanel.SetActive(true);
        alchemyPanel.SetActive(false);
    }

    public void ShowAlchemy()
    {
        economyPanel.SetActive(false);
        militaryPanel.SetActive(false);
        alchemyPanel.SetActive(true);
    }
    void Start()
    {
        ShowEconomy();
    }

}

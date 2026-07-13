using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GeneralShop : MonoBehaviour
{
    public List<General> shopInv;
    public Kingdom playerKingdom;
    public TMP_Text btnTxt;
    public OwnedGenerals ownedGenerals;
    public int generalCost = 100;
    public float generalExponent = 1.5f;
    void Start()
    {
        btnTxt = GetComponentInChildren<TMP_Text>();
        playerKingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
        ownedGenerals = GameObject.FindWithTag("Player").GetComponent<OwnedGenerals>();
    }
    public void TryGetGeneral(){
        if(playerKingdom.money >= generalCost && shopInv.Count > 0){
            playerKingdom.money -= generalCost;
            generalCost = (int) (generalExponent * generalCost);
            int index = (int) (Random.Range(0f, (float) shopInv.Count));
            General general = shopInv[index];
            ownedGenerals.addGeneral(general);
            shopInv.RemoveAt(index);
            Debug.Log("General Unlocked: "+general.name+" ("+general.computeRarity()+")!");
        }
    }
    void Update(){
        if(shopInv.Count > 0){
        btnTxt.text = "Hire General ("+generalCost+")";
        }
        else{
        btnTxt.text = "";
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public record resource(string type, int amount);
public class Kingdom : MonoBehaviour
{
    public string name;
    public int troops;
    public int money;
    public float distance;
    public float wallStrength;
    public float maxStrength;
    public Kingdom invadee;
    public int troopsInvading;
    public General general;

     bool gotUpdate1 = false;
    bool gotUpdate2 = false;
    bool gotUpdat3 = false;

    public float perUnitWood = 0.09f;
    public float perUnitFargel = 0.05f;
    public float perUnitMallite = 0.02f;
    public float perUnitArksaloid = 0.007f;

    public int mineDistance = 150;
    public List<resource> resources;

    public int troopsMining = 0;
    
    public void addResources(resource item)
    {
        if(item.amount == 0)
        {
            return;
        }
        for(int i = 0; i < resources.Count; i++)
        {
            if(item.type == resources[i].type)
            {
                resources[i]= new resource(resources[i].type, resources[i].amount + item.amount);
                return;
            }
        }
        resources.Add(item);
    }

    public bool removeResources(resource item)
    {
        for(int i = 0; i < resources.Count; i++)
        {
            if(item.type == resources[i].type)
            {
                if(item.amount < resources[i].amount)
                {
                resources[i] = new resource(resources[i].type, resources[i].amount - item.amount);
                return true;
                }
                else if(item.amount == resources[i].amount){
                    resources.Remove(item);
                    return true;
                }
            }
        }
        return false;
    }
    void Start()
    {
        resources = new List<resource>();
        if(distance == 0){
        general = GetComponent<OwnedGenerals>().startingGeneral;
        }
        else
        {
        general = GetComponent<General>();
        }
    }
    public int totalTroops()
    {
        return troops + troopsInvading + troopsMining;
    }
    public void StartArmyMarch()
    {
        Debug.Log("An army from the " + name + " kingdom led by "+general.name+" is approaching the "+invadee.name+" kingdom!");
        
        if(distance > 0){
        troopsInvading = (int) troops / 2;
        troops -= troopsInvading;
        }

        float travelDuration = Mathf.Abs(distance - invadee.distance) / general.speed;
        if(distance == 0)
        {
            Invoke(nameof(Invade), travelDuration * 2);
        }
        else{
        Invoke(nameof(Invade), travelDuration);
        }
        Invoke(nameof(TravelBack), travelDuration * 2);
    }

    public void StartMineMarch()
    {
        Debug.Log("A group of troops from the "+name+" kingdom is going mining!");
        float travelDuration = mineDistance / general.speed;
        Invoke(nameof(GoMining), travelDuration * 2);
    }
    void TravelBack()
    {
        troops += troopsInvading;
        troopsInvading = 0;
        invadee = null;
    }

    public void Invade()
    {
        if (invadee == null)
        {
            Debug.LogWarning("Invasion cancelled: One of the kingdoms no longer exists.");
            return;
        }

        Debug.Log("An army from the " + name + " kingdom led by "+general.name+" has invaded the " + invadee.name + " kingdom! ");
        
        int invaderStrength = (int) (troopsInvading * Random.Range(0.85f, 1.15f) * general.atk);
        int invadeeStrength = (int)(invadee.troops * ((invadee.wallStrength / general.siege) + 1) * Random.Range(0.85f, 1.15f));
        
        if (invaderStrength <= 0)
        {
            Debug.Log("The invader arrived with no troops and immediately retreated!");
            return;
        }

        float result = (float)invadeeStrength / invaderStrength;
        Debug.Log("Battle Results: \n Invader strength: " + invaderStrength + ". Invadee strength: " + invadeeStrength + ".");
        
        if (result > 2.5f)
        {
            troopsInvading -= (int) (troopsInvading / (2 * general.def));
            Debug.Log("The invader lost half their troops!");
        }
        else if (result > 1f)
        {
            troopsInvading -= (int)(troopsInvading * (1 - 1/Random.Range(1.2f, 1.8f)) * general.def);
            invadee.troops = (int)(invadee.troops / Random.Range(1.1f, 1.5f));
            Debug.Log("Some troops didn't make it.");
        }
        else if (result > 0.4f)
        {
            int moneyLost = (int)(invadee.money * Random.Range(0.2f, 0.4f)* general.looting);
            money += moneyLost;
            invadee.money -= moneyLost;
            invadee.troops = (int)(invadee.troops / Random.Range(1.2f, 1.8f));
            troopsInvading = (int)(troopsInvading * (1 - 1 / Random.Range(1.1f, 1.5f)));
            invadee.wallStrength *= Random.Range(0.3f, 0.6f);
            Debug.Log("The invadee was robbed of " + moneyLost + " gold. Their wall was damaged and some troops didn't make it");
        }
        else
        {
            invadee.troops = invadee.troops / 2;
            money += invadee.money;
            invadee.money = 0;
            invadee.wallStrength = 0;
            Debug.Log("The invadee was sacked. Badly. All of their gold was taken, half of their troops were killed and their wall was obliterated.");
        }
    }

    public void GoMining()
    {
        int woodEarned = DrawValue(perUnitWood);
        int fargelstoneEarned = DrawValue(perUnitFargel);
        int malliteEarned = DrawValue(perUnitMallite);
        int arksaloidEarned = DrawValue(perUnitArksaloid);
        addResources(new resource("wood", woodEarned));
        addResources(new resource("fargelstone", fargelstoneEarned));
        addResources(new resource("mallite", malliteEarned));
        addResources(new resource("arksaloid", arksaloidEarned));
        Debug.Log("Your troops have returned from mining! They found: \n"+woodEarned+" wood, "+fargelstoneEarned+" fargelstone, "+malliteEarned+" mallite, and "+arksaloidEarned+" arksaloid.");
        troops += troopsMining;
        troopsMining = 0;
    }

    public int DrawValue(float probability)
    {
        return (int) (Random.Range(0f, 2f) * probability * troopsMining);
    }
}

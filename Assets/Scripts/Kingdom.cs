using UnityEngine;

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

    public int totalTroops()
    {
        return troops + troopsInvading;
    }
    public void StartArmyMarch()
    {
        Debug.Log("An army from the " + name + " kingdom is approaching the "+invadee.name+" kingdom!");
        
        if(distance > 0){
        troopsInvading = (int) troops / 2;
        troops -= troopsInvading;
        }

        float travelDuration = Mathf.Abs(distance - invadee.distance);
        if(distance == 0)
        {
            Invoke(nameof(Invade), travelDuration * 2);
        }
        else{
        Invoke(nameof(Invade), travelDuration);
        }
        Invoke(nameof(TravelBack), travelDuration * 2);
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

        Debug.Log("The " + name + " kingdom has invaded the " + invadee.name + " kingdom! ");
        
        int invaderStrength = (int) (troopsInvading * Random.Range(0.85f, 1.15f));
        int invadeeStrength = (int)(invadee.troops * (invadee.wallStrength + 1) * Random.Range(0.85f, 1.15f));
        
        if (invaderStrength <= 0)
        {
            Debug.Log("The invader arrived with no troops and immediately retreated!");
            return;
        }

        float result = (float)invadeeStrength / invaderStrength;
        Debug.Log("Battle Results: \n Invader strength: " + invaderStrength + ". Invadee strength: " + invadeeStrength + ".");
        
        if (result > 2.5f)
        {
            troopsInvading = troopsInvading / 2;
            Debug.Log("The invader lost half their troops!");
        }
        else if (result > 1f)
        {
            troopsInvading = (int)(troopsInvading / Random.Range(1.2f, 1.8f));
            invadee.troops = (int)(invadee.troops / Random.Range(1.1f, 1.5f));
            Debug.Log("Some troops didn't make it.");
        }
        else if (result > 0.4f)
        {
            int moneyLost = (int)(invadee.money * Random.Range(0.2f, 0.4f));
            money += moneyLost;
            invadee.money -= moneyLost;
            invadee.troops = (int)(invadee.troops / Random.Range(1.2f, 1.8f));
            troopsInvading = (int)(troopsInvading / Random.Range(1.1f, 1.5f));
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
}

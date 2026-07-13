using UnityEngine;

public class General : MonoBehaviour
{
    public string name;
    public float atk = 1f;
    public float def = 1f;
    public float speed = 1f;
    public float siege = 1f;
    public float looting = 1f;

    public string toString(){
        return $"{name} - Attack: {atk}, Defense: {def}, Speed: {speed}, Siege: {siege}, Looting: {looting}";
    }

    public string computeRarity(){
        float mean = (atk + def + speed + siege + looting) / 5f;
        if(mean <= 1.1f){
            return "Common";
        }
        else if(mean <= 1.35f){
            return "Uncommon";
        }
        else if(mean <= 1.8f){
            return "Rare";
        }
        return "Mythical";
    }
}

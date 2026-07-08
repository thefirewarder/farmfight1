using UnityEngine;

public class Invasion : MonoBehaviour 
{ 
    public float invasionPeriod = 60f; 
    
    Food foodScript; 
    Money moneyScript; 
    Wall wallScript; 
    Troops troopScript; 

    public int moneyThreshold = 5;

    void Start() 
    { 
        foodScript = FindFirstObjectByType<Food>(); 
        troopScript = FindFirstObjectByType<Troops>(); 
        wallScript = FindFirstObjectByType<Wall>(); 
        moneyScript = FindFirstObjectByType<Money>(); 
    } 

    void Update() 
    { 
        if (Random.Range(0f, invasionPeriod) < Time.deltaTime && moneyScript.money > moneyThreshold) 
        { 
            float initialLevel = Random.Range(1f, 16f); 
            int level; 

            if (initialLevel <= 5f) { level = 2; } 
            else if (initialLevel <= 9f) { level = 3; } 
            else if (initialLevel <= 12f) { level = 1; } 
            else if (initialLevel <= 14f) { level = 4; } 
            else { level = 5; } 

            Debug.Log("A level " + level + " invasive force is coming to your city! Brace yourself!"); 

            int opposingTroops = Mathf.RoundToInt(level * level * level * Random.Range(0.5f, 1.5f)); 
            int playerStrength = Mathf.RoundToInt(wallScript.wallStrength * troopScript.currentTroops); 
            
            float result = (float)playerStrength / opposingTroops; 

            Debug.Log("Player Strength: " + playerStrength + ". Invader Strength: " + opposingTroops + "."); 

            if (result > 2.5f) 
            { 
                moneyScript.money += Mathf.RoundToInt(result * 3f); 
            } 
            else if (result > 1f) 
            { 
                troopScript.currentTroops = Mathf.RoundToInt(troopScript.currentTroops / Random.Range(1.1f, 1.3f)); 
            } 
            else if (result > 0.4f) 
            { 
                moneyScript.money = Mathf.RoundToInt(moneyScript.money * result); 
                wallScript.wallStrength *= result; 
                troopScript.currentTroops = Mathf.RoundToInt(troopScript.currentTroops / Random.Range(1.4f, 1.7f)); 
            } 
            else 
            { 
                wallScript.wallStrength = 0f; 
                troopScript.currentTroops = 0; 
                moneyScript.money = 0; 
            } 
        } 
    } 
}
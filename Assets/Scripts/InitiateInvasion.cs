using UnityEngine;

public class InitiateInvasion : MonoBehaviour
{
    public Kingdom playerKingdom;
    public Kingdom enemyKingdom; 
    
    public float elapsedTime;
    public float targetTime;
    public float invasionInterval = 60f;
    public float invasionDeviation = 15f;
    public float minInvasionTime = 75f;

    public int fearThreshold = 150;
    public int troopThreshold = 100;
    public float spu = 1f;

    void Start()
    {
        ResetTimer();
        playerKingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
        enemyKingdom = GetComponent<Kingdom>();
    
        IncrementTroops();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (Time.time >= minInvasionTime && elapsedTime >= targetTime && enemyKingdom.invadee == null && playerKingdom.troops < fearThreshold)
        {
            enemyKingdom.invadee = playerKingdom;
            ResetTimer();
            enemyKingdom.StartArmyMarch();
        }
    }

    void ResetTimer()
    {
        elapsedTime = 0f;
        targetTime = Random.Range(invasionInterval - invasionDeviation, invasionInterval + invasionDeviation);
    }

    void IncrementTroops()
    {
        if(enemyKingdom.totalTroops() < troopThreshold)
        {
            enemyKingdom.troops++;
            enemyKingdom.money++;
        }
        Invoke(nameof(IncrementTroops), spu);
    }
}
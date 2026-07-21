using UnityEngine;
using TMPro;
public class MarketValue : MonoBehaviour
{
    public TMP_Text arkTxt;
    public float timer;
    public int value;
    public Kingdom playerKingdom;
    void Start()
    {
        timer = 0f;
        value = Random.Range(20, 31);
        playerKingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 60f)
        {
            timer = 0f;
            value += Random.Range(-5, 6);
        }
        arkTxt.text = "Arksaloid Market Value: "+value+".";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(playerKingdom.HasResource(new resource("arksaloid", 1)))
            {
                playerKingdom.removeResources(new resource("arksaloid",1));
                playerKingdom.money += value;
            }
        }
    }
}

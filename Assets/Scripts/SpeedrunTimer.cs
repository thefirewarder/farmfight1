using UnityEngine;
using TMPro;
public class SpeedrunTimer : MonoBehaviour
{
    float timer = 0f;
    public TMP_Text speedRunText;
    void Start()
    {
        speedRunText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1f)
        {
            timer = 0f;
            if((int) Time.time == 1)
            {
            speedRunText.text = "1 second";
            }
            else{
            speedRunText.text = (int) Time.time+ " seconds";
            }
        }
    }
}

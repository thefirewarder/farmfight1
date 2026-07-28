using UnityEngine;
using TMPro;
public class Transmutation : MonoBehaviour
{
    public Kingdom kingdom;
    public float recipeValue = 0f;
    public string currentEffect = "";
    public float effectTimeLeft = 0f;
    public TMP_Text mixTxt;
    public TMP_Text effectTxt;
    bool shiftPressed = false;
    void Start()
    {
        kingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
    }
    void Update()
    {
        mixTxt.text = "Transmutate ("+recipeValue+")";
        shiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        if(currentEffect == "")
        {
            effectTxt.text = "Current Effects: None";
        }
        else
        {
            effectTxt.text = "Current Effects: "+currentEffect+". Time Remaining: "+(int) effectTimeLeft;
        }
        int selector = -1;
        if (Input.GetKeyDown("1") && shiftPressed)
        {
            selector = 0;
        }
        else if (Input.GetKeyDown("2") && shiftPressed)
        {
            selector = 1;
        }
        else if (Input.GetKeyDown("3") && shiftPressed)
        {
            selector = 2;
        }
        else if (Input.GetKeyDown("4") && shiftPressed)
        {
            selector = 3;
        }
        else if (Input.GetKeyDown("5") && shiftPressed)
        {
            selector = 4;
        }
        if(kingdom.resources.Count > selector && selector != -1)
        {
            string removedType = kingdom.resources[selector].type;
            kingdom.removeResources(new resource(removedType , 1));
            switch (removedType)
            {
                case "wood":
                recipeValue++;
                break;
                case "fargelstone":
                recipeValue += 4f;
                break;
                case "mallite":
                recipeValue += 10f;
                break;
                case "arksaloid":
                recipeValue += 25f;
                break;
                case "copper ingot":
                recipeValue += 4f;
                break;
                case "silver ingot":
                recipeValue += 10f;
                break;
                case "gold ingot":
                recipeValue += 25f;
                break;
            }
        }
        if(effectTimeLeft <= 0f)
        {
            effectTimeLeft = 0f;
            currentEffect = "";
        }
        effectTimeLeft -= Time.deltaTime;
    }
    
    public void OnTransmutation()
    {
        if(recipeValue <= 10f)
        {
            return;
        }
        else
        {
            if(Random.Range(1, 3 + (int) (recipeValue / 15f)) == 1)
            {
                currentEffect = "Curse of the Drought";
                effectTimeLeft = 30f;
            }
            else if (Random.Range(1, 3) == 1)
            {
                currentEffect = "Boon of Agriculture";
                effectTimeLeft = 20f + (int) ((recipeValue - 10) / 5);
            }
            else
            {
                currentEffect = "Boon of Riches";
                effectTimeLeft = 20f + (int) ((recipeValue - 10) / 5);
            }
        }
        recipeValue = 0;
    }
}

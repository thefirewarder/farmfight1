using UnityEngine;

public class WallDmgDisplay : MonoBehaviour
{
    SpriteRenderer renderer;
    Kingdom kingdom;
    public Sprite sprite;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        kingdom = GameObject.FindWithTag("Player").GetComponent<Kingdom>();
    }

    void Update()
    {
        Color tmpColor = renderer.color;
        tmpColor.a = kingdom.wallStrength / kingdom.maxStrength;
        renderer.color = tmpColor;
        if(kingdom.maxStrength == 0.5f)
        {
            renderer.sprite = sprite;
        }
        else if(kingdom.maxStrength == 0.8f)
        {
            renderer.sprite = sprite2;
        }
        else if(kingdom.maxStrength == 1.5f)
        {
            renderer.sprite = sprite3;
        }
        else
        {
            renderer.sprite = sprite4;
        }
    }
}

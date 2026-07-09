using UnityEngine;

public class WallDmgDisplay : MonoBehaviour
{
    SpriteRenderer renderer;
    Kingdom kingdom;
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
    }
}

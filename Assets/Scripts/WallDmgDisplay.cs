using UnityEngine;

public class WallDmgDisplay : MonoBehaviour
{
    SpriteRenderer renderer;
    Wall wallScript;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        wallScript = FindFirstObjectByType<Wall>();
    }

    void Update()
    {
        Color tmpColor = renderer.color;
        tmpColor.a = wallScript.wallStrength / wallScript.maxStrength;
        renderer.color = tmpColor;
    }
}

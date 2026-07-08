using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float speed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        transform.position += new Vector3(movement.x, movement.y, 0);
    }
}

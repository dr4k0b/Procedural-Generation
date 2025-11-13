using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    int speed;
    void Start()
    {
        speed = 10;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.linearVelocity = new Vector2(dir.x * speed, rb.linearVelocity.y);

        Input.GetAxis("Horizontal");


        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;


        if (dir.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 12);
        }
        Debug.Log(dir);
    }
}

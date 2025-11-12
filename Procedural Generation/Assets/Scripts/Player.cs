using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = (new Vector2(3, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = (new Vector2(-3, 0));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocity = (new Vector2(0, 5));
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}

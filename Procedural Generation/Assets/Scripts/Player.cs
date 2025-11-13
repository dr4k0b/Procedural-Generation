using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet;

    int speed;
    void Start()
    {
        speed = 10;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}

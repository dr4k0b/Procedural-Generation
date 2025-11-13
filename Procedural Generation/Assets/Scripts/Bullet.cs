using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed;

    Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.position;

    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = dir.normalized * bulletSpeed;
    }

    

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Ground")
    //    {
    //        var grid = gridGO.GetComponent<Grid>();
    //        var tilePos = grid.WorldToCell(transform.position);

    //        gt.map.SetTile(tilePos, null);
    //    }
    //}
}

using UnityEngine;
using UnityEngine.Tilemaps;

public class DeleteTiles : MonoBehaviour
{
    Grid grid;
    Tilemap map;

    private void Start()
    {
        grid = GetComponentInParent<Grid>();
        map = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            var tilePos = grid.WorldToCell(collision.transform.position);

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    map.SetTile(tilePos + new Vector3Int(i, j), null);
                }
            }

            Destroy(collision.gameObject);

        }
    }
}

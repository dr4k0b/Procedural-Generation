using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;
using static GlobalInformation;
public class GenerateTerrain : MonoBehaviour
{
    public Tilemap map;
    public RuleTile tile;
    public RuleTile tileRed;
    public RuleTile DecoGrey;
    public RuleTile DecoRed;


    public GameObject player;
    GlobalInformation g;
    public int renderDistance;

    private Vector2 renderedX;
    private Vector2 renderedY;
    private Vector2 pos;
    void Start()
    {
        pos = player.transform.position;
        g = FindAnyObjectByType<GlobalInformation>();
        PlaceTiles((int)pos.x - renderDistance, (int)pos.x + renderDistance, (int)pos.y - renderDistance, (int)pos.y + renderDistance);
        renderedX = new Vector2(pos.x, pos.x);
        renderedY = new Vector2(pos.y, pos.y);
    }
    private void Update()
    {
        pos = player.transform.position;
        if (pos.x + renderDistance > renderedX.y)
        {
            PlaceTiles((int)renderedX.y, (int)renderedX.y + renderDistance, (int)renderedY.x, (int)renderedY.y);
        }
        if (pos.y + renderDistance > renderedY.y)
        {
            PlaceTiles((int)renderedX.x, (int)renderedX.y, (int)renderedY.y, (int)renderedY.y + renderDistance);
        }
        if (pos.x - renderDistance < renderedX.x)
        {
            PlaceTiles((int)renderedX.x - renderDistance, (int)renderedX.x, (int)renderedY.x, (int)renderedY.y);
        }
        if (pos.y - renderDistance < renderedY.x)
        {
            PlaceTiles((int)renderedX.x, (int)renderedX.y, (int)renderedY.x - renderDistance, (int)renderedY.x);
        }
    }

    public void PlaceTiles(int xStart, int xEnd, int yStart, int yEnd)
    {
        renderedX = new Vector2((renderedX.x < xStart) ? renderedX.x : xStart, (renderedX.y > xEnd) ? renderedX.y : xEnd);
        renderedY = new Vector2((renderedY.x < yStart) ? renderedY.x : yStart, (renderedY.y > yEnd) ? renderedY.y : yEnd);
        for (int x = xStart; x < xEnd; x++)
        {
            for (int y = yStart; y < yEnd; y++)
            {
                if (g.GenerateIndexGrey(x, y) > g.threshold)
                {
                    if (g.GenerateIndexRed(x, y) > .5f)
                    {
                        map.SetTile(new Vector3Int(x, y), tileRed);
                        if (!(g.GenerateIndexRed(x, y + 1) > .5f))
                        {
                            map.SetTile(new Vector3Int(x, y + 1), DecoRed);
                        }
                    }
                    else
                    {
                        map.SetTile(new Vector3Int(x, y), tile);
                        if (!(g.GenerateIndexGrey(x, y + 1) > .5f))
                        {
                            map.SetTile(new Vector3Int(x, y + 1), DecoGrey);
                        }
                    }
                }
            }
        }
    }
}

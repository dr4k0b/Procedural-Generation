using UnityEngine;
using UnityEngine.Tilemaps;

public class GlobalInformation : MonoBehaviour
{
    [Header("Noise Function")]


    [SerializeField] public int width = 256;
    [SerializeField] public int height = 256;

    [SerializeField] public int scale = 100;

    [SerializeField] public int xOffset;
    [SerializeField] public int yOffset;

    [Range(0, 1)]
    [SerializeField] public float threshold;
    [SerializeField] public int depth;

    [SerializeField] public bool noise;

    public float GenerateIndexGrey(int x, int y)
    {
        float xCord = (float)x / width * scale + xOffset;
        float yCord = (float)y / height * scale + yOffset;

        return Mathf.PerlinNoise(xCord, yCord);
    }
    public float GenerateIndexRed(int x, int y)
    {
        float xCord = (float)x / width * 30 + xOffset;
        float yCord = (float)y / height * 30 + yOffset;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}

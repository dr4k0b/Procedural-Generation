using System;
using UnityEngine;

public class NoiseFunction : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public int scale = 100;

    public int xOffset;
    public int yOffset;

    [Range(0, 1)]
    public float threshold;

    public int depth;
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                texture.SetPixel(x, y, GenerateColor(x, y));
            }
        }
        texture.Apply();
        return texture;
    }

    Color GenerateColor(int x, int y)
    {
        float xCord = (float)x / width * scale + xOffset;
        float yCord = (float)y / height * scale + yOffset;

        float sample = Mathf.PerlinNoise(xCord, yCord);

        return (sample >= threshold - yCord/depth) ? Color.white : Color.black;
        return new Color(sample, sample, sample);
    }
}

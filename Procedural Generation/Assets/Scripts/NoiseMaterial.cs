using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;
using static GlobalInformation;

public class NoiseMaterial : MonoBehaviour
{
    GlobalInformation g;
    private void Start()
    {
        g = FindAnyObjectByType<GlobalInformation>();
    }
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(g.width, g.height);
        for (int x = 0; x < g.width; x++)
        {
            for (int y = 0; y < g.height; y++)
            {
                float i = g.GenerateIndex(x, y);

                Color color = new Color(i, i, i);

                if (!g.noise)
                {
                    if (i > g.threshold)
                        color = Color.white;
                    else
                        color = Color.black;
                }
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseVisualizer : MonoBehaviour
{

    [Header("Noise Settings")]
    public int width = 100;
    public int height = 100; 
    public float scale = 10f;
    public Vector2 offset;

    [Header("Waves")]
    public Wave[] waves;

    private Texture2D noiseTexture;

    void Start()
    {
        VisualizeNoise();
    }

    public void VisualizeNoise()
    {
        float[,] noiseMap = NoiseGenerator.Generate(width, height, scale, waves, offset);

        // Log some sample noise values
        //Debug.Log($"Noise Value at (0, 0): {noiseMap[0, 0]}");
        //Debug.Log($"Noise Value at (width-1, height-1): {noiseMap[width - 1, height - 1]}");

        // Check for uniform values
        float firstValue = noiseMap[0, 0];
        bool uniform = true;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (noiseMap[x, y] != firstValue)
                {
                    uniform = false;
                    break;
                }
            }
            if (!uniform) break;
        }
        //Debug.Log($"Noise map is uniform: {uniform}");

        // Continue with texture creation
        noiseTexture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float noiseValue = noiseMap[x, y];
                Color color = new Color(noiseValue, noiseValue, noiseValue);
                noiseTexture.SetPixel(x, y, color);
            }
        }

        noiseTexture.Apply();

        RawImage rawImage = GetComponent<RawImage>();
        if (rawImage != null)
        {
            rawImage.texture = noiseTexture;
        }
        else
        {
            Debug.LogError($"Raw image is null in : {gameObject.name}");
        }
    }

}



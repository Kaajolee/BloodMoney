using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UI;

public class PerlinNoiseVisualizer : MonoBehaviour
{



    [Header("Noise Settings")]
    [SerializeField]
    private NoiseType noiseType;

    [Header("Waves")]
    public Wave[] waves;

    private Texture2D noiseTexture;

    void Start()
    {
        VisualizeNoise();

        UIEvents.Instance.GenerateMapPressed += VisualizeNoise;
    }

    public void VisualizeNoise()
    {
        
        Map map = Map.Instance;
        float[,] noiseMap = new float[map.width, map.height];
        switch (noiseType)
        {
            case
                NoiseType.LandValue:

                noiseMap = map.landValueMap;

                break;
            case
                NoiseType.Proximity:
                noiseMap = map.proximityMap;
                break;
            case
                NoiseType.Density:

                noiseMap = map.densityMap;

                break;
        }

        

        // Log some sample noise values
        //Debug.Log($"Noise Value at (0, 0): {noiseMap[0, 0]}");
        //Debug.Log($"Noise Value at (width-1, height-1): {noiseMap[width - 1, height - 1]}");

        // Check for uniform values
        float firstValue = noiseMap[0, 0];
        bool uniform = true;
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
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
        noiseTexture = new Texture2D(map.width, map.height);

        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
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
    private enum NoiseType
    {
        Density,
        LandValue,
        Proximity
    }
}





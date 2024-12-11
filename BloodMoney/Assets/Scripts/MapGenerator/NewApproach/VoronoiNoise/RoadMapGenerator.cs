using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadMapGenerator : MonoBehaviour
{
    [SerializeField]
    private float maxGrayscaleValue = 0.5f;
    [SerializeField]
    private float minGrayscaleValue = 0.1f;

    [SerializeField]
    private Color backgroundColor = Color.black;

    private RawImage image;

    public VoronoiNoiseGenerator generator;

    void Start()
    {
        image = GetComponent<RawImage>();

        UIEvents.Instance.VoronoiTextureGenerated += GenerateRoadTexture;
    }

    public void GenerateRoadTexture()
    {
        float[,] originalNoise = generator.grayscaleValues;

        Texture2D texture = new Texture2D(generator.imageDim.x, generator.imageDim.y, TextureFormat.RGBA32, false);

        Color[] pixels = new Color[generator.imageDim.x * generator.imageDim.y];

        for (int x = 0; x < generator.imageDim.x; x++)
        {
            for (int y = 0; y < generator.imageDim.y; y++)
            {
                float value = originalNoise[x, y];

                if(value > minGrayscaleValue && value < maxGrayscaleValue)
                    pixels[x * generator.imageDim.x + y] = new Color(1, 1, 1, 1f);
                    //pixels[x + y * generator.imageDim.x] = new Color(value, value, value, 1f);
                else
                    pixels[x * generator.imageDim.x + y] = backgroundColor;
            }
        }

        texture.SetPixels(pixels);
        texture.Apply();

        image.texture = texture;
    }
    void test()
    {
        Texture2D testTexture = new Texture2D(100, 100, TextureFormat.RGBA32, false);
        for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 100; y++)
            {
                testTexture.SetPixel(x, y, Color.red); // Set all pixels to red
            }
        }
        testTexture.Apply();
        image.texture = testTexture;
    }
}



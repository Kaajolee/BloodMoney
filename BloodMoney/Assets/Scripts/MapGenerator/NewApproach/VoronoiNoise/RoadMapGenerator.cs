using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadMapGenerator : MonoBehaviour
{
    [SerializeField]
    private float grayscaleValue = 0.5f;

    [SerializeField]
    private Color backgroundColor = Color.black; // Default background color

    private Color maximumAllowedColorValue;

    private RawImage image;

    public VoronoiNoiseGenerator generator;

    void Start()
    {
        image = GetComponent<RawImage>();
        maximumAllowedColorValue = new Color(grayscaleValue, grayscaleValue, grayscaleValue);
    }

    public void GenerateRoadTexture()
    {
        Texture2D originalNoise = generator.noiseTexture;

   
        Texture2D noiseCopy = new Texture2D(originalNoise.width, originalNoise.height, originalNoise.format, false);
        noiseCopy.SetPixels(originalNoise.GetPixels()); 

        ChangePixels(noiseCopy);
        noiseCopy.Apply();

        image.texture = noiseCopy; 
    }

    void ChangePixels(Texture2D noiseTexture)
    {
        for (int x = 0; x < noiseTexture.width; x++)
        {
            for (int y = 0; y < noiseTexture.height; y++)
            {
                Color pixelColor = noiseTexture.GetPixel(x, y);

                pixelColor = CheckAndSetColor(pixelColor);

                noiseTexture.SetPixel(x, y, pixelColor);
            }
        }
    }

    Color CheckAndSetColor(Color pixelColor)
    {
        //Debug.Log($"Pixel grayscale: {pixelColor.grayscale}, Threshold: {grayscaleValue}");
        if (pixelColor.grayscale <= grayscaleValue)
        {
            pixelColor = backgroundColor;
        }
        return pixelColor;
    }
}



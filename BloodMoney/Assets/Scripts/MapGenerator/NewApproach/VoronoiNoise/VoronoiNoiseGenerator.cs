
using UnityEngine;
using UnityEngine.UI;

public class VoronoiNoiseGenerator : MonoBehaviour
{
    public Vector2Int imageDim;
    public int regionAmount;

    public Texture2D noiseTexture;
    private RawImage RawImage;

    // This array will hold the grayscale values of each pixel
    public float[,] grayscaleValues;
    public float contrast;
    private void OnEnable()
    {
        RawImage = GetComponent<RawImage>();
        if (RawImage == null)
            Debug.LogError("Image null");

        RawImage.texture = GenerateDiagramWithGrayscale();
    }
    public void Regenerate()
    {
        RawImage.texture = GenerateDiagramWithGrayscale();
    }

    // Method to generate diagram and populate the grayscale array
    Texture2D GenerateDiagramWithGrayscale()
    {
        Vector2Int[] centroids = new Vector2Int[regionAmount];
        for (int i = 0; i < regionAmount; i++)
        {
            centroids[i] = new Vector2Int(Random.Range(0, imageDim.x), Random.Range(0, imageDim.y));
        }

        Color[] pixelColors = new Color[imageDim.x * imageDim.y];
        grayscaleValues = new float[imageDim.x, imageDim.y]; // Initialize the array

        float[] distances = new float[imageDim.x * imageDim.y];
        float maxDst = float.MinValue;

        // Calculate distances and find max distance
        for (int x = 0; x < imageDim.x; x++)
        {
            for (int y = 0; y < imageDim.y; y++)
            {
                int index = x * imageDim.x + y;
                distances[index] = Vector2.Distance(new Vector2Int(x, y), centroids[GetClosestCentroidIndex(new Vector2Int(x, y), centroids)]);
                if (distances[index] > maxDst)
                {
                    maxDst = distances[index];
                }
            }
        }

        // Normalize distances and populate colors and grayscale array
        for (int x = 0; x < imageDim.x; x++)
        {
            for (int y = 0; y < imageDim.y; y++)
            {
                int index = x * imageDim.x + y;
                float colorValue = distances[index] / maxDst;

                colorValue = Mathf.Pow(colorValue, 1f / contrast);

                pixelColors[index] = new Color(colorValue, colorValue, colorValue, 1f);
                grayscaleValues[x, y] = colorValue; // Store the normalized grayscale value
            }
        }
        UIEvents.Instance.VoronoiGenerated();
        return GetImageFromColorArray(pixelColors);
    }

    int GetClosestCentroidIndex(Vector2Int pixelPos, Vector2Int[] centroids)
    {
        float smallestDst = float.MaxValue;
        int index = 0;
        for (int i = 0; i < centroids.Length; i++)
        {
            float distance = Vector2.Distance(pixelPos, centroids[i]);
            if (distance < smallestDst)
            {
                smallestDst = distance;
                index = i;
            }
        }
        return index;
    }

    Texture2D GetImageFromColorArray(Color[] pixelColors)
    {
        noiseTexture = new Texture2D(imageDim.x, imageDim.y);
        //noiseTexture.filterMode = FilterMode.Point;
        noiseTexture.SetPixels(pixelColors);
        noiseTexture.Apply();
        return noiseTexture;
    }
    void PrintArray(float[,] array)
    {
        for (int i = 0; i < imageDim.x; i++)
        {
            for (int j = 0; j < imageDim.y; j++)
            {
                Debug.Log(array[i,j]);
            }
        }
        
    }
}





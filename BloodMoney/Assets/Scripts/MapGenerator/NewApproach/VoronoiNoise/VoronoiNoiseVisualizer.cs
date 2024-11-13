using UnityEngine;
using UnityEngine.UI;

public class VoronoiNoiseVisualizer : MonoBehaviour
{
    [Header("Noise Settings")]
    public int width = 100;
    public int height = 100;
    public float scale = 10f;
    public float contrast;
    public Vector2 offset;

    [Header("Sites")]
    public Vector2[] sites;

    private Texture2D noiseTexture;

    void Start()
    {
        sites = new Vector2[]
        {
        // Cluster 1
        new Vector2(50, 50),
        new Vector2(100, 50),
        new Vector2(75, 100),

        // Cluster 2
        new Vector2(200, 300),
        new Vector2(250, 280),
        new Vector2(220, 350),

        // Cluster 3
        new Vector2(400, 150),
        new Vector2(420, 180),
        new Vector2(380, 140),

        // Linear Path (Road-like pattern)
        new Vector2(600, 100),
        new Vector2(650, 120),
        new Vector2(700, 150),
        new Vector2(750, 180),
        new Vector2(800, 200),

        // Sparse Random Points
        new Vector2(100, 400),
        new Vector2(300, 500),
        new Vector2(700, 600),
        new Vector2(800, 700),

        // Centralized Cluster (Intersections)
        new Vector2(500, 500),
        new Vector2(520, 520),
        new Vector2(540, 500),
        new Vector2(520, 480)
        };

        VisualizeNoise();
    }


    public void VisualizeNoise()
    {

        //float[,] noiseMap = VoronoiNoiseGenerator.Generate(width, height, scale, sites, offset, contrast);

        // Debug.Log($"Noise Value at (0, 0): {noiseMap[0, 0]}");
        // Debug.Log($"Noise Value at (width-1, height-1): {noiseMap[width - 1, height - 1]}");

        
        /*float firstValue = noiseMap[0, 0];
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
        }*



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
        }*/
    }
}


using UnityEngine;


public class PerlinNoiseGenerator : MonoBehaviour
{
    public static float[,] Generate(int width, int height, float scale, Wave[] waves, Vector2 offset)
    {
        float[,] noiseMap = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float samplePosX = (float)x * scale + offset.x;
                float samplePosY = (float)y * scale + offset.y;

                //float normalization = 0.0f;
                float totalAmpliturde = 0.0f;

                foreach (Wave wave in waves)
                {
                    noiseMap[x, y] += wave.amplitude * Mathf.PerlinNoise(samplePosX * wave.frequency + wave.seed,
                                                                         samplePosY * wave.frequency + wave.seed);
                    totalAmpliturde += wave.amplitude;
                }

                if(totalAmpliturde > 0)
                {

                    noiseMap[x, y] /= totalAmpliturde;
                }
                

            }
        }

        //Debug.Log($"Noise Value at (0,0): {noiseMap[0, 0]}");
       // Debug.Log($"Noise Value at (width-1, height-1): {noiseMap[width - 1, height - 1]}");

        return noiseMap;
    }
}

[System.Serializable]
public class Wave
{
    public float seed;
    public float frequency;
    public float amplitude;

}

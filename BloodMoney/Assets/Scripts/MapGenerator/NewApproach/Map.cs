using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public BuildingPreset[] buildingPresets;
    public GameObject tilePrefab;

    public int width;
    public int height;
    public float scale;
    public Vector2 offset;

    public Wave[] densityWaves;
    public float[,] densityMap;

    public Wave[] landValueWaves;
    public float[,] landValueMap;

    public Wave[] proximityWaves;
    public float[,] proximityMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GenerateMap();
    }
    
    void GenerateMap()
    {
        densityMap = PerlinNoiseGenerator.Generate(width, height, scale, densityWaves, offset);

        landValueMap = PerlinNoiseGenerator.Generate(width, height, scale, landValueWaves, offset);

        proximityMap = PerlinNoiseGenerator.Generate(width, height, scale, proximityWaves, offset);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                tile.GetComponent<SpriteRenderer>().sprite = GetBuilding(densityMap[x,y], landValueMap[x,y], proximityMap[x,y]).GetRandomTile();
            }
        }
    }
    BuildingPreset GetBuilding(float density, float landValue, float proximity)
    {
        List<BuildingTempData> buildingTemp = new List<BuildingTempData>();

        foreach (var building in buildingPresets)
        {
            if(building.MatchConditions(density, landValue, proximity))
            {

                buildingTemp.Add(new BuildingTempData(building));
            }
        }

        float currVal = 0.0f;
        BuildingPreset buildingToReturn = null;

        foreach (var building in buildingTemp)
        {
            if(buildingToReturn == null)
            {
                buildingToReturn = building.building;
                currVal = building.GetDiffValue(density, landValue, proximity);
            }
            else
            {
                if (building.GetDiffValue(density, landValue, proximity) < currVal)
                {
                    buildingToReturn = building.building;
                    currVal = building.GetDiffValue(density, landValue, proximity);
                }
            }
        }

        if (buildingToReturn == null)
            buildingToReturn = buildingPresets[0];

        return buildingToReturn;
    }
}

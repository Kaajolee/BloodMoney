using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance { get; private set; }

    public BuildingPreset[] buildingPresets;
    public List<GameObject> generatedTiles;
    public GameObject tilePrefab;
    public GameObject tileParent;

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
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GenerateMap()
    {
        RandomiseSeed(densityWaves);
        RandomiseSeed(landValueWaves);
        RandomiseSeed(proximityWaves);

        densityMap = PerlinNoiseGenerator.Generate(width, height, scale, densityWaves, offset);

        landValueMap = PerlinNoiseGenerator.Generate(width, height, scale, landValueWaves, offset);

        proximityMap = PerlinNoiseGenerator.Generate(width, height, scale, proximityWaves, offset);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, tileParent.transform);
                generatedTiles.Add(tile);
                TileType tileType;
                tile.GetComponent<SpriteRenderer>().sprite = GetBuilding(densityMap[x,y], landValueMap[x,y], proximityMap[x,y], out tileType).GetRandomTile();
                tile.AddComponent<TileDataHolder>().tileType = tileType;
            }
        }

        UIEvents.Instance.RegenerateMapPressed();
    }
    public void Regenerate()
    {
        foreach (var item in generatedTiles)
        {
            Destroy(item.gameObject);
        }

        generatedTiles.Clear();
        GenerateMap();
    }
    BuildingPreset GetBuilding(float density, float landValue, float proximity, out TileType tileType)
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
        {
            buildingToReturn = buildingPresets[0];
        }


        tileType = buildingToReturn.tileType;
        return buildingToReturn;
    }

    void RandomiseSeed(Wave[] waveArray)
    {
        foreach (var item in waveArray)
        {

            item.seed = Random.Range(1, 500);
        }
    }
}

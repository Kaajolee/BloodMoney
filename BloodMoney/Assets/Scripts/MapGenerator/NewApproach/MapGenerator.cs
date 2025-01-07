using NavMeshPlus.Components;
using System.Net;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    Map mapDataGenerator;

    [Header("Data arrays")]
    [SerializeField]
    private TileDataHolder[] tileObjects;
    [SerializeField]
    private TileType[,] tileTypes; // Two-dimensional array for tile types
    private int[,] roads;

    [Space]
    [Header("Building presets")]
    [SerializeField]
    private BuildingPreset residentialPreset;
    [SerializeField]
    private BuildingPreset industrialPreset;
    [SerializeField]
    private BuildingPreset cityCentrePreset;
    [SerializeField]
    private BuildingPreset grassPreset;
    [SerializeField]
    private RoadPreset roadPreset;

    [SerializeField]
    private Transform parent;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private NavMeshSurface aiSurface;

    private void Start()
    {
        mapDataGenerator = Map.Instance;
        tileTypes = new TileType[mapDataGenerator.width, mapDataGenerator.height];
        roads = new int[mapDataGenerator.width, mapDataGenerator.height];
        GetTiles();

        spriteRenderer = residentialPreset.prefabs[0].GetComponent<SpriteRenderer>();

        InstantiatePrefabs();
        //aiSurface.BuildNavMesh();
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))

    }
    void GetTiles()
    {
        tileObjects = mapDataGenerator.tileParent.GetComponentsInChildren<TileDataHolder>();

        int index = 0;
        for (int x = 0; x < mapDataGenerator.width; x++)
        {
            for (int y = 0; y < mapDataGenerator.height; y++)
            {
                if (index < tileObjects.Length)
                {
                    tileTypes[x, y] = tileObjects[index].tileType;
                    index++;
                }
                else
                {
                    Debug.LogError("Tile data out ofd bounds");
                }
            }
        }
    }
    public void InstantiatePrefabs()
    {
        for (int x = 0; x < mapDataGenerator.width; x++)
        {
            for (int y = 0; y < mapDataGenerator.height; y++)
            {
                Vector2 pos = new Vector2(x * spriteRenderer.bounds.size.x, y * spriteRenderer.bounds.size.y);

                TileType currentTileType = tileTypes[x, y];

                if (currentTileType != TileType.Grass)
                {

                    if (y % 4 == 0)
                    {
                        if (x % 4 == 0)
                        {
                            InstantiateMapTile(roadPreset.intersectionPrefab, pos);
                            roads[x, y] = 1;
                            continue;
                            
                        }
                        else
                        {
                            InstantiateMapTile(roadPreset.horizontalPrefab, pos);
                            roads[x, y] = 1;
                            continue;
                        }
                    }
                    else if (x % 4 == 0 && y % 4 != 0)
                    {
                        InstantiateMapTile(roadPreset.verticalPrefab, pos);
                        roads[x, y] = 1;
                        continue;
                    }
                }
                else if (currentTileType == TileType.Grass)
                {
                    if (x != 0 && y != 0)
                    {
                        if (roads[x - 1, y] == 1)
                        {

                            //  PROBLEMA: TURI ROTATE'INT SUKURTA O NE MAIN PREFAB
                            GameObject roadEnd = InstantiateMapTile(roadPreset.roadEndPrefab, pos);

                            roadEnd.transform.rotation = Quaternion.Euler(0, 0, 90);

                            Debug.Log("Road End Rotation: " + roadEnd.transform.rotation.eulerAngles);

                            continue;
                        }
                    }
                }



                //vidurys tarp pastatu
                if (x % 2 == 0 && y % 2 == 0)
                {
                    InstantiateMapTile(GetPreset(TileType.Grass).GetRandomPrefab(), pos);
                    continue;
                }

                //kiti objektai
                GameObject prefabToInstantiate = GetPreset(currentTileType).GetRandomPrefab();

                InstantiateMapTile(prefabToInstantiate, pos);


            }
        }
    }
    BuildingPreset GetPreset(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.Residential:
                return residentialPreset;

            case TileType.CityCentre:
                return cityCentrePreset;

            case TileType.Industrial:
                return industrialPreset;

            case TileType.Grass:
                return grassPreset;

            default:
                return grassPreset;
        }
    }
    //IEnumerator Generator()
    //{
    //    for (int x = 0; x < mapDataGenerator.width; x++)
    //    {
    //        for (int y = 0; y < mapDataGenerator.height; y++)
    //        {
    //            Vector2 pos = new Vector2(x * spriteRenderer.bounds.size.x, y * spriteRenderer.bounds.size.y);

    //            GameObject prefabToInstantiate = GetPreset(tileTypes[x, y]).GetRandomPrefab();

    //            if (prefabToInstantiate != null)
    //            {
    //                Instantiate(prefabToInstantiate, pos, Quaternion.identity);
    //                yield return new WaitForSeconds(0.01f);
    //            }
    //            else
    //                Debug.LogError("Prefab is null");
    //        }
    //    }
    //}
    GameObject InstantiateMapTile(GameObject prefab, Vector2 pos)
    {
        if (prefab != null)
        {
            GameObject prefabToInstantiate = Instantiate(prefab, pos, Quaternion.identity, parent);
            return prefabToInstantiate;
        }
        else
        {
            Debug.LogError("Prefab is null, original: " + prefab.name);
            return null;
        }
            
    }
}



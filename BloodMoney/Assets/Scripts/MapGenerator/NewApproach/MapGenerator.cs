using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    Map mapDataGenerator;

    [Header("Data arrays")]
    [SerializeField]
    private TileDataHolder[] tileObjects;
    [SerializeField]
    private List<TileType> tileTypes;

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

    private void Start()
    {
        mapDataGenerator = Map.Instance;
        GetTiles();

        spriteRenderer = residentialPreset.prefabs[0].GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            InstantiatePrefabs();
    }
    void GetTiles()
    {
        tileObjects = mapDataGenerator.tileParent.GetComponentsInChildren<TileDataHolder>();

        foreach (var item in tileObjects)
        {
            tileTypes.Add(item.tileType);

        }
    }
    public void InstantiatePrefabs()
    {
        for (int x = 0; x < mapDataGenerator.width; x++)
        {
            for (int y = 0; y < mapDataGenerator.height; y++)
            {
                int index = x * mapDataGenerator.width + y;

                if (index < tileTypes.Count)
                {
                    Vector2 pos = new Vector2(x * spriteRenderer.bounds.size.x, y * spriteRenderer.bounds.size.y);

                    if(y % 2 != 0)
                    {
                        if(x % 2 != 0)
                        {
                            InstantiateMapTile(roadPreset.intersectionPrefab, pos);

                        }
                        else
                        {
                            InstantiateMapTile(roadPreset.horizontalPrefab, pos);
                        }

                    }
                    else if(x % 2 != 0 && y % 2 == 0)
                    {
                        InstantiateMapTile(roadPreset.verticalPrefab, pos);
                    }
                    else
                    {
                        GameObject prefabToInstantiate = GetPreset(tileTypes[index]).GetRandomPrefab();

                        if (prefabToInstantiate != null)
                        {
                            Instantiate(prefabToInstantiate, pos, Quaternion.identity, parent);
                        }
                        else
                            Debug.LogError("Building prefab is null");
                    }


                }
                else
                    Debug.LogError("Index too big");

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
    IEnumerator Generator()
    {
        for (int x = 0; x < mapDataGenerator.width; x++)
        {
            for (int y = 0; y < mapDataGenerator.height; y++)
            {
                int index = x * mapDataGenerator.width + y;

                if (index < tileTypes.Count)
                {
                    Vector2 pos = new Vector2(x * spriteRenderer.bounds.size.x, y * spriteRenderer.bounds.size.y);

                    GameObject prefabToInstantiate = GetPreset(tileTypes[index]).GetRandomPrefab();



                    if (prefabToInstantiate != null)
                    {
                        Instantiate(prefabToInstantiate, pos, Quaternion.identity);
                        yield return new WaitForSeconds(0.01f);
                    }
                    else
                        Debug.LogError("Prefab is null");
                    
                }
                else
                    Debug.LogError("Index too big");

            }
        }
    }
    void InstantiateMapTile(GameObject prefab, Vector2 pos)
    {
        GameObject prefabToInstantiate = prefab;

        if (prefabToInstantiate != null)
        {
            Instantiate(prefabToInstantiate, pos, Quaternion.identity, parent);
        }
        else
            Debug.LogError("Prefab is null, original: " + prefab.name);
    }

}

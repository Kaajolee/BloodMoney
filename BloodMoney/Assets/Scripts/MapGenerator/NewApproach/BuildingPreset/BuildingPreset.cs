using UnityEngine;

[CreateAssetMenu(fileName = "Building preset", menuName = "New Building Preset")]
public class BuildingPreset : ScriptableObject
{
    public Sprite[] tiles;
    public GameObject[] prefabs;
    public float minDensity;
    public float minLandValue;
    public float maxProximity;


    public TileType tileType;
    public Sprite GetRandomTile()
    {
        return tiles[Random.Range(0, tiles.Length)];
    }

    public GameObject GetRandomPrefab()
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }

    public bool MatchConditions(float density, float landValue, float proximity)
    {
        return density >= minDensity && landValue >= minLandValue; //&& proximity >= maxProximity;
    }
}


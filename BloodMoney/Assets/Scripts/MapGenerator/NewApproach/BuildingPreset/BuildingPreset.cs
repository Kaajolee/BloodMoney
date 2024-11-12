using UnityEngine;

[CreateAssetMenu(fileName = "Building preset", menuName = "New Building Preset")]
public class BuildingPreset : ScriptableObject
{
    public Sprite[] tiles;
    public float minDensity;
    public float minLandValue;
    public float maxProximity;

    public Sprite GetRandomTile()
    {
        return tiles[Random.Range(0, tiles.Length)];
    }

    public bool MatchConditions(float density, float landValue, float proximity)
    {
        return density >= minDensity && landValue >= minLandValue && proximity <= maxProximity;
    }
}


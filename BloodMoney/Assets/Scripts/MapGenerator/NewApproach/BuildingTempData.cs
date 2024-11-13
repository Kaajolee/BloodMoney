using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTempData
{
    public BuildingPreset building;

    public BuildingTempData (BuildingPreset preset)
    {
        building = preset;
    }

    public float GetDiffValue(float density, float landValue, float proximity)
    {
        return (density - building.minDensity) + (landValue - building.minLandValue) + (proximity - building.maxProximity);
    }
    
}
